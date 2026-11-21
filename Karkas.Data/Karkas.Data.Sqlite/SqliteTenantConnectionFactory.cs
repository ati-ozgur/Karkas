using System;
using System.Data.Common;
using System.IO;
using Karkas.Data.Exceptions;
using Karkas.Data.Tenancy;
using Microsoft.Data.Sqlite;

namespace Karkas.Data.Sqlite;

/// <summary>
/// One SQLite database file per tenant. The file path comes from a pattern such as
/// <c>"tenants/{tenant}.sqlite"</c>, where <c>{tenant}</c> is replaced with the
/// validated, lower-cased tenant id.
/// </summary>
/// <remarks>
/// Connections use <c>Mode=ReadWrite</c>, so a missing file is never created silently;
/// <see cref="TenantNotFoundException"/> is thrown instead. Creating tenant databases is up to
/// the application. All tenant files must share the schema the code was generated from.
/// </remarks>
public class SqliteTenantConnectionFactory : BaseTenantConnectionFactory
{
	public const string TenantPlaceholder = "{tenant}";
	public const string DbProviderName = "Microsoft.Data.Sqlite";

	private readonly string pathPattern;
	private readonly Action<SqliteConnectionStringBuilder> configureConnectionString;

	/// <param name="pathPattern">Database file path containing <c>{tenant}</c>, e.g. <c>"tenants/{tenant}.sqlite"</c>.
	/// Relative paths are resolved against the current directory.</param>
	/// <param name="configureConnectionString">Optional callback to set extra connection string options
	/// (cache, password, pooling...). Data Source and Mode are set by the factory.</param>
	public SqliteTenantConnectionFactory(string pathPattern,
		Action<SqliteConnectionStringBuilder> configureConnectionString = null)
	{
		if (string.IsNullOrWhiteSpace(pathPattern))
		{
			throw new ArgumentException("Path pattern can not be empty.", nameof(pathPattern));
		}
		if (!pathPattern.Contains(TenantPlaceholder))
		{
			throw new ArgumentException(
				string.Format("Path pattern '{0}' must contain {1}.", pathPattern, TenantPlaceholder),
				nameof(pathPattern));
		}
		this.pathPattern = pathPattern;
		this.configureConnectionString = configureConnectionString;

		// Karkas looks providers up by name (e.g. for data adapters); registering twice is harmless.
		DbProviderFactories.RegisterFactory(DbProviderName, SqliteFactory.Instance);
	}

	/// <summary>Returns the database file path for a tenant (validated and lower-cased).</summary>
	public string GetDatabasePath(string tenantId)
	{
		return GetDatabasePathForNormalizedTenantId(NormalizeTenantId(tenantId));
	}

	/// <summary>Returns true if the tenant's database file exists.</summary>
	public bool TenantExists(string tenantId)
	{
		return File.Exists(GetDatabasePath(tenantId));
	}

	protected override DbConnection CreateConnectionForNormalizedTenantId(string normalizedTenantId)
	{
		string path = GetDatabasePathForNormalizedTenantId(normalizedTenantId);
		if (!File.Exists(path))
		{
			throw new TenantNotFoundException(
				string.Format("No database for tenant '{0}' (expected file '{1}').", normalizedTenantId, path),
				normalizedTenantId);
		}

		var builder = new SqliteConnectionStringBuilder();
		configureConnectionString?.Invoke(builder);
		builder.DataSource = path;
		builder.Mode = SqliteOpenMode.ReadWrite;
		return new SqliteConnection(builder.ToString());
	}

	private string GetDatabasePathForNormalizedTenantId(string normalizedTenantId)
	{
		return pathPattern.Replace(TenantPlaceholder, normalizedTenantId);
	}
}
