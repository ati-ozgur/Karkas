using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Diagnostics;
using System.Text;
using Karkas.Data.Exceptions;
using Microsoft.Extensions.Logging;

namespace Karkas.Data.Tracing
{
	/// <summary>
	/// Tracing for one query run: tags the SQL text, starts the Activity and the log scope,
	/// and attaches the ids to exceptions. Created right before a command runs, disposed right after.
	/// </summary>
	internal sealed class QueryTrace : IDisposable
	{
		internal const string TagPrefix = "/* karkas:";
		private const string TagSuffix = " */ ";

		private readonly DbCommand command;
		private readonly Activity activity;
		private readonly IDisposable logScope;
		private readonly long startTimestamp;
		private bool failed;
		private bool disposed;

		public string QueryId { get; }
		public string ExecutionId { get; }

		private QueryTrace(DbCommand command, string queryId, string dbProviderName)
		{
			this.command = command;
			QueryId = queryId;
			ExecutionId = KarkasTracing.NewExecutionId();

			TagCommandText();

			ILogger logger = KarkasTracing.Logger;
			if (KarkasTracing.LoggerFactory != null)
			{
				logScope = logger.BeginScope(new List<KeyValuePair<string, object>>
				{
					new KeyValuePair<string, object>("QueryId", QueryId),
					new KeyValuePair<string, object>("ExecutionId", ExecutionId),
				});
			}

			activity = KarkasTracing.ActivitySource.StartActivity(QueryId, ActivityKind.Client);
			if (activity != null)
			{
				activity.SetTag("db.system", GetDbSystem(dbProviderName));
				activity.SetTag("db.query.text", command.CommandText);
				activity.SetTag("karkas.query_id", QueryId);
				activity.SetTag("karkas.execution_id", ExecutionId);
			}

			if (logger.IsEnabled(LogLevel.Debug))
			{
				logger.LogDebug("Executing {QueryId} ({ExecutionId}): {CommandText}{Parameters}",
					QueryId, ExecutionId, command.CommandText, FormatParameters());
			}
			startTimestamp = Stopwatch.GetTimestamp();
		}

		/// <summary>
		/// Starts tracing with the given query id.
		/// A <see cref="KarkasTracing.BeginQuery"/> scope overrides it.
		/// </summary>
		public static QueryTrace Start(DbCommand command, string queryId, string dbProviderName)
		{
			string effectiveId = KarkasTracing.CurrentQueryId;
			if (string.IsNullOrEmpty(effectiveId))
			{
				effectiveId = string.IsNullOrEmpty(queryId) ? "query" : queryId;
			}
			return new QueryTrace(command, effectiveId, dbProviderName);
		}

		/// <summary>
		/// Starts tracing for SQL that has no call-site name, such as SQL given directly to an AdoTemplate.
		/// The id is <c>owner.operation#hash</c>, where hash comes from the SQL text,
		/// so it stays the same for the same SQL and differs between different SQL.
		/// </summary>
		public static QueryTrace StartForSql(DbCommand command, string owner, string operation, string dbProviderName)
		{
			string queryId = null;
			if (string.IsNullOrEmpty(KarkasTracing.CurrentQueryId))
			{
				queryId = owner + "." + operation + "#" + StableHash(RemoveTag(command.CommandText));
			}
			return Start(command, queryId, dbProviderName);
		}

		/// <summary>Records the failure on the Activity and in the log, and attaches the ids to the exception.</summary>
		public void Fail(Exception ex)
		{
			if (failed)
			{
				Attach(ex);
				return;
			}
			failed = true;
			Attach(ex);
			if (activity != null)
			{
				activity.SetStatus(ActivityStatusCode.Error, ex.Message);
				activity.SetTag("error.type", ex.GetType().FullName);
			}
			ILogger logger = KarkasTracing.Logger;
			if (logger.IsEnabled(LogLevel.Error))
			{
				logger.LogError(ex, "Failed {QueryId} ({ExecutionId}) after {ElapsedMs} ms: {CommandText}{Parameters}",
					QueryId, ExecutionId, ElapsedMilliseconds(), command.CommandText, FormatParameters());
			}
		}

		/// <summary>
		/// Records the failure, lets the database specific ExceptionChanger translate it,
		/// and attaches the ids to the translated exception before it leaves.
		/// </summary>
		public void ChangeException(ExceptionChanger changer, DbException ex, string message)
		{
			Fail(ex);
			if (changer == null)
			{
				// keep the original error and stack trace instead of a NullReferenceException
				System.Runtime.ExceptionServices.ExceptionDispatchInfo.Capture(ex).Throw();
			}
			try
			{
				changer.Change(ex, message);
			}
			catch (Exception translated)
			{
				Attach(translated);
				throw;
			}
		}

		public void Attach(Exception ex)
		{
			if (ex == null)
			{
				return;
			}
			try
			{
				ex.Data[KarkasTracing.QueryIdDataKey] = QueryId;
				ex.Data[KarkasTracing.ExecutionIdDataKey] = ExecutionId;
			}
			catch (Exception)
			{
				// some exception types have read-only Data; tracing must not hide the real error
			}
		}

		public void Dispose()
		{
			if (disposed)
			{
				return;
			}
			disposed = true;
			if (!failed)
			{
				ILogger logger = KarkasTracing.Logger;
				if (logger.IsEnabled(LogLevel.Debug))
				{
					logger.LogDebug("Executed {QueryId} ({ExecutionId}) in {ElapsedMs} ms",
						QueryId, ExecutionId, ElapsedMilliseconds());
				}
			}
			activity?.Dispose();
			logScope?.Dispose();
		}

		private double ElapsedMilliseconds()
		{
			return Stopwatch.GetElapsedTime(startTimestamp).TotalMilliseconds;
		}

		private void TagCommandText()
		{
			QueryTagMode mode = KarkasTracing.TagMode;
			if (mode == QueryTagMode.None || command.CommandType != CommandType.Text
				|| string.IsNullOrEmpty(command.CommandText))
			{
				return;
			}
			string tag = TagPrefix + SanitizeForComment(QueryId);
			if (mode == QueryTagMode.QueryIdAndExecutionId)
			{
				tag += " exec:" + SanitizeForComment(ExecutionId);
			}
			// a reused command already has a tag from its previous run; replace it
			command.CommandText = tag + TagSuffix + RemoveTag(command.CommandText);
		}

		internal static string RemoveTag(string commandText)
		{
			if (commandText == null || !commandText.StartsWith(TagPrefix, StringComparison.Ordinal))
			{
				return commandText;
			}
			int end = commandText.IndexOf("*/", TagPrefix.Length, StringComparison.Ordinal);
			if (end < 0)
			{
				return commandText;
			}
			string rest = commandText.Substring(end + 2);
			return rest.StartsWith(" ", StringComparison.Ordinal) ? rest.Substring(1) : rest;
		}

		internal static string SanitizeForComment(string value)
		{
			return value
				.Replace("*/", "* /")
				.Replace("/*", "/ *")
				.Replace('\r', ' ')
				.Replace('\n', ' ');
		}

		/// <summary>FNV-1a; string.GetHashCode is randomized per process, so it can not be used for stable ids.</summary>
		internal static string StableHash(string text)
		{
			uint hash = 2166136261;
			if (text != null)
			{
				foreach (char c in text)
				{
					hash = (hash ^ c) * 16777619;
				}
			}
			return hash.ToString("x8");
		}

		private string FormatParameters()
		{
			if (command.Parameters.Count == 0)
			{
				return "";
			}
			StringBuilder sb = new StringBuilder();
			sb.Append(" | parameters: ");
			bool first = true;
			foreach (DbParameter p in command.Parameters)
			{
				if (!first)
				{
					sb.Append(", ");
				}
				first = false;
				sb.Append(p.ParameterName);
				if (KarkasTracing.LogParameterValues)
				{
					object value = p.Value;
					sb.Append(" = ");
					sb.Append(value == null || value == DBNull.Value ? "NULL" : "'" + value + "'");
				}
			}
			return sb.ToString();
		}

		private static string GetDbSystem(string dbProviderName)
		{
			string name = dbProviderName ?? "";
			if (name.IndexOf("Sqlite", StringComparison.OrdinalIgnoreCase) >= 0)
			{
				return "sqlite";
			}
			if (name.IndexOf("Oracle", StringComparison.OrdinalIgnoreCase) >= 0)
			{
				return "oracle";
			}
			if (name.IndexOf("SqlClient", StringComparison.OrdinalIgnoreCase) >= 0)
			{
				return "mssql";
			}
			return "other_sql";
		}
	}
}
