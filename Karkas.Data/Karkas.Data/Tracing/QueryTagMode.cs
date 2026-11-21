namespace Karkas.Data.Tracing
{
	/// <summary>
	/// Controls whether Karkas writes a comment with the query id in front of the SQL text it sends to the database.
	/// The comment makes queries easy to find in database-side tools such as
	/// SQL Server Profiler / Extended Events, sys.dm_exec_query_stats or Oracle V$SQL.
	/// </summary>
	public enum QueryTagMode
	{
		/// <summary>SQL text is sent unchanged (default).</summary>
		None = 0,

		/// <summary>
		/// Adds <c>/* karkas:QueryId */</c>. The text is the same on every run,
		/// so database plan caches are not affected.
		/// </summary>
		QueryId = 1,

		/// <summary>
		/// Adds <c>/* karkas:QueryId exec:ExecutionId */</c>. Every run has different SQL text,
		/// so SQL Server compiles a new plan and Oracle hard parses each time.
		/// Use it only while debugging.
		/// </summary>
		QueryIdAndExecutionId = 2,
	}
}
