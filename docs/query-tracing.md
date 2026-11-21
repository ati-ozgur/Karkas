# Query tracing

Every query Karkas runs gets two ids:

| Id | Example | Changes |
|---|---|---|
| **QueryId** | `AlbumDal.QueryByArtistId` | never: it is the same for every run of the same call site |
| **ExecutionId** | `9f1c0e2b6a7d4c55b0f3a1e8d2c47b90` | on every run |

You can use them to match an application log line, an OpenTelemetry span, an exception and the
query the database saw.

All settings are on `Karkas.Data.Tracing.KarkasTracing` and are process wide. Nothing changes
until you set them: SQL text is sent unchanged and nothing is logged.

## Where the ids appear

| Place | How to turn it on |
|---|---|
| Log messages and log scopes (`QueryId`, `ExecutionId`) | `KarkasTracing.LoggerFactory = loggerFactory;` |
| `Activity` / OpenTelemetry spans (source `Karkas.Data`) | listen to the source, e.g. `.AddSource("Karkas.Data")` |
| Exceptions thrown by Karkas | always on |
| SQL text sent to the database | `KarkasTracing.TagMode = QueryTagMode.QueryId;` |

## How the QueryId is chosen

1. Inside a `KarkasTracing.BeginQuery("...")` scope, that name is used.
2. Generated and hand-written Dal methods use `DalName.MethodName`, for example
   `AlbumDal.QueryByAlbumId`, `AlbumDal.QueryByArtistId`, `AlbumDal.Insert`, `AlbumDal.Update`,
   `AlbumDal.Delete`, `AlbumDal.QueryAll`, `AlbumDal.TableRowCount`.
   A method in your partial `AlbumDal.cs` that calls `ExecuteQuery(list, filter, parameters)` is
   named after itself automatically.
3. SQL given directly to an AdoTemplate (`GetRows`, `GetOneValue`, `ExecuteNonQueryCommand`,
   `CreateDataTable`, ...) gets `TemplateName.Operation#hash`, for example
   `AdoTemplateSqlite.GetRows#3f2a9c1b`. The hash comes from the SQL text, so the same SQL keeps
   the same id across runs and different SQL gets different ids. Use `BeginQuery` for a readable name:

```csharp
using Karkas.Data.Tracing;

using (KarkasTracing.BeginQuery("Reports.MonthlySales"))
{
    var rows = dal.Template.GetRows(sql, parameters);
}
```

Scopes can be nested; the innermost wins. They flow with `async`/`await`.

## Logging

```csharp
KarkasTracing.LoggerFactory = app.Services.GetRequiredService<ILoggerFactory>();
// or: KarkasTracing.LoggerFactory = LoggerFactory.Create(b => b.AddConsole().SetMinimumLevel(LogLevel.Debug));
```

The logger category is `Karkas.Data`.

- **Debug**: `Executing AlbumDal.QueryByAlbumId (9f1c...): SELECT ... | parameters: @AlbumId` and
  `Executed AlbumDal.QueryByAlbumId (9f1c...) in 1.2 ms`
- **Error**: `Failed ...` with the exception, the SQL and the parameter names

Parameter **values** are not logged, because they can contain personal data. To log them while
debugging, set `KarkasTracing.LogParameterValues = true`.

## OpenTelemetry

```csharp
builder.Services.AddOpenTelemetry()
    .WithTracing(t => t.AddSource(KarkasTracing.ActivitySourceName));
```

Each query is a client span named after its QueryId, with these tags: `db.system`
(`sqlite`, `mssql`, `oracle`), `db.query.text`, `karkas.query_id` and `karkas.execution_id`.
Failed queries have status `Error` and an `error.type` tag. When no listener is attached,
no `Activity` is created.

## Exceptions

`KarkasDataException` (and the exceptions derived from it, such as `ForeignKeyException`) and
`DatabaseConnectionException` have `QueryId` and `ExecutionId` properties. Their `Message` ends with
`[QueryId: ..., ExecutionId: ...]`. For any exception type, including a provider exception
Karkas rethrows as-is, use:

```csharp
catch (Exception ex)
{
    string queryId = KarkasTracing.GetQueryId(ex);
    string executionId = KarkasTracing.GetExecutionId(ex);
}
```

The ids are stored in `Exception.Data` under `Karkas.QueryId` and `Karkas.ExecutionId`.

## Tagging the SQL text

```csharp
KarkasTracing.TagMode = QueryTagMode.QueryId;
```

Every SQL statement then starts with a comment:

```sql
/* karkas:AlbumDal.QueryByAlbumId */ SELECT AlbumId, Title, ArtistId FROM Album WHERE AlbumId = @AlbumId
```

You can then find the query in SQL Server Profiler / Extended Events, `sys.dm_exec_query_stats`
(via `sys.dm_exec_sql_text`), Oracle `V$SQL` / AWR, or the SQLite trace.

```sql
-- SQL Server
SELECT qs.execution_count, qs.total_elapsed_time, st.text
FROM sys.dm_exec_query_stats qs CROSS APPLY sys.dm_exec_sql_text(qs.sql_handle) st
WHERE st.text LIKE '%karkas:AlbumDal.%';

-- Oracle
SELECT executions, elapsed_time, sql_text FROM v$sql WHERE sql_text LIKE '/* karkas:AlbumDal.%';
```

| Mode | Comment | Plan cache |
|---|---|---|
| `None` (default) | none | unchanged |
| `QueryId` | `/* karkas:QueryId */` | safe: the text is the same on every run |
| `QueryIdAndExecutionId` | `/* karkas:QueryId exec:ExecutionId */` | **every run is new SQL text**: SQL Server compiles a new plan and Oracle hard parses each time. Use it only while debugging. |

Stored procedure calls (`CommandType.StoredProcedure`) are never tagged. A command that is run
again keeps a single tag.

## Custom execution ids

Execution ids are Guids by default. To use your own, for example the current request's
correlation id plus a counter:

```csharp
KarkasTracing.ExecutionIdFactory = () => $"{CorrelationContext.Id}-{Interlocked.Increment(ref counter)}";
```
