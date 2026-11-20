# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## What this is

Karkas is a **database-first** C# code generator. Point it at an existing database (SQLite, SQL Server or Oracle) and it reads the schema, then writes three layers of classes for each table (and optionally for views and sequences):

- **TypeLibrary**: POCO entity classes
- **Dal**: CRUD, QueryByPrimaryKey and QueryByForeignKey (plus index queries)
- **Bs**: business services that wrap Dal calls and handle transactions across tables

The generated code needs the `Karkas.Data*` runtime libraries, which are published to NuGet.

## Commands

```bash
dotnet build Karkas.sln                       # main solution (cross-platform)
dotnet test Karkas.Tests                      # xUnit unit tests (only Oracle datatype mapping today)
dotnet test Karkas.Tests --filter "FullyQualifiedName~HelperOracleDataTypesTest.<Method>"   # single test

# Run the code generator; connection names are entries in karkas-config.json
dotnet run --project Karkas.CodeGeneration/Karkas.CodeGeneration.ConsoleApp -- --connectionname ChinookSqliteAutoIncrement
#   -f/--configfilename <file>  (default: karkas-config.json, resolved from the current dir)
#   $HOME inside ConnectionString / CodeGenerationDirectory is expanded
```

Most of the real testing is done end to end by the scripts in `Karkas.Examples/TestBash/`. **Run them from the repo root**, because config paths are relative to it. Each script:

1. starts a Docker database (SQL Server/Oracle only)
2. runs the generator into `Karkas.Examples/GeneratedProjects/<Name>` (gitignored, deleted first)
3. creates a console project there and copies in test harness files from `Karkas.Examples/TestCSharp/`
4. runs `dotnet build && dotnet run`, which checks CRUD, queries and transaction commit/rollback

```bash
./Karkas.Examples/TestBash/run_sqlite_chinook_auto_increment.bash   # no Docker needed; quickest check
./Karkas.Examples/TestBash/run_sqlite_datatypes.bash
./Karkas.Examples/TestBash/run_sqlserver_chinook_auto_increment.bash stop   # "stop" removes the container afterwards
./Karkas.Examples/TestBash/run_all.bash
```

The GitHub Actions workflows (`.github/workflows/*.yml`) run these same scripts on .NET 10. SQLite runs first, and the other workflows are chained after it with `workflow_run`.

Other scripts:
- `delete_bin_obj.bash` removes all bin/obj folders.
- `deploy_nuget_packages.bash` packs and pushes to NuGet. It reads versions from `version.txt` and needs `KARKAS_NUGET_API_KEY`.
- `Karkas.WinApp.sln` contains the Windows Forms front end (`net10.0-windows`, Windows only).

## Architecture

There are two independent halves, each split into a shared core plus one project per database:

**`Karkas.CodeGeneration/`** is the generator.
- `Helpers` holds the database-agnostic core:
  - `BaseCodeGenerationDatabase` is the abstract per-database entry point (schema/table/view/sequence listing, `CodeGenerateAllTables`). It exposes abstract `TypeLibraryGenerator`, `DalGenerator` and `BsGenerator`.
  - Those generator base classes in `Generators/` write C# through `IOutput`.
  - Schema metadata comes through the `ITable`, `IColumn`, `IView` and related interfaces.
  - `CodeGenerationConfig` holds one entry from `karkas-config.json`; `docs/karkas-config.md` documents the options.
- `Sqlite` / `SqlServer` / `Oracle` each contain:
  - `Implementations/`: `CodeGeneration<Db>`, plus `Table<Db>`, `Column<Db>` and `View<Db>`, which run metadata queries and map database types to C# types
  - `Generators/`: overrides that emit the database-specific base classes and generic parameters
- `ConsoleApp` dispatches on `ConnectionDatabaseType`. The exact casing is `"sqlite"`, `"SqlServer"`, `"Oracle"`. When adding a database, wire it in both switch statements in `Program.cs`.

**`Karkas.Data/`** is the runtime library that generated code inherits from.
- `Karkas.Data` defines generic base classes such as `BaseDal<TYPE_LIBRARY, ADOTEMPLATE, PARAMETER_BUILDER>`, `BaseDalForIdentity<…, PRIMARY_KEY>`, `BaseBs<…>`, `BaseBsForIdentity<…>`, `BaseTypeLibrary`, `BaseAdoTemplate` / `IAdoTemplate`, and `IParameterBuilder`. It also contains `QueryHelper`/`WhereCriteria`, paging, and `ExceptionChanger`, which maps provider errors to `ForeignKeyException`, `UniqueKeyConstraintException` and similar.
- `Karkas.Data.<Db>` provides `AdoTemplate<Db>`, `ParameterBuilder<Db>`, `BaseDal<Db>`, `ExceptionChanger<Db>` and the `…ForIdentity` variants.
- Tables with identity/auto-increment PKs use the `…ForIdentity` base classes. The generators choose this per table.

**Generated file convention:** each class is split into a partial pair.
- `X.generated.cs` / `XDal.generated.cs` / `XBs.generated.cs` are always overwritten.
- A "normal" partial class (`XDal.cs`, etc.) is for hand-written code. It is only written if it does not already exist, or if `GenerateNormalClassAgain` is true.
- Output goes under `<CodeGenerationDirectory>/{TypeLibrary,Dal,Bs}/<Namespace>.<Layer>/[schema]/`.
- `Karkas.Examples/TestCSharp/{Dal,Bs}` contains hand-written partials that the test scripts copy over the generated ones.

**Test databases:**
- `Karkas.Examples/Databases/` holds the SQLite files, plus Dockerfiles and SQL scripts for SQL Server and Oracle.
- There are two families: Chinook (relationships, CRUD, transactions) and datatypes (type mapping).
- Oracle Chinook comes in "normal" (sequence) and "identity" variants.

## Conventions

- `.editorconfig`: tabs (size 4), CRLF line endings, max line length 120. `*.bash` files must stay LF.
- Some identifiers and comments are in Turkish (for example `TurkishHelper`, and the `AbbrevationsAsString` config spelling). Keep existing names as they are.
- Library projects target `net10.0`, but generated code is meant to stay usable on older .NET (4.x, Core 1–3). Avoid emitting newer-only C# unless it is behind a config flag such as `UseFileScopedNamespace` or `UseGlobalUsings`.
