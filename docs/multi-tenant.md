# Multi-tenant SQLite (one database file per tenant)

Karkas supports multi-tenant SQLite applications where **each tenant has its own database file**
with the same schema:

```
tenants/
  acme.sqlite
  globex.sqlite
  3f2504e0-4f89-41d3-9a0c-0305e82c3301.sqlite
```

The generated code does not change. Every generated `XBs` and `XDal` already takes a
`DbConnection` in its constructor, so you pick the tenant by passing that tenant's connection.

## Code generation

Point the `karkas-config.json` entry at **any one tenant's file** (or a reference copy with the
same schema) and generate as usual. Every tenant file must have the schema the code was
generated from.

## Usage

```csharp
using Karkas.Data.Sqlite;

var tenants = new SqliteTenantConnectionFactory("tenants/{tenant}.sqlite");

var albumBs = new AlbumBs(tenants.CreateConnection("acme"));
var albums = albumBs.QueryAll();

// Guid tenant ids are supported too
var artistBs = new ArtistBs(tenants.CreateConnection(tenantGuid));
```

Transactions work as before. `GetDalInstance` passes the Bs connection on, so everything in one
transaction stays in one tenant's file.

Create one factory and reuse it, for example as a singleton in dependency injection. Code that
only needs connections can depend on `Karkas.Data.Tenancy.ITenantConnectionFactory`.

If you keep the current tenant in a request context, read it there and pass it in:
`new AlbumBs(tenants.CreateConnection(currentTenantId))`.

## Tenant ids

- Allowed: 1–64 letters, digits, `-` and `_`. Anything else (`../x`, spaces, `{guid}`) throws
  `ArgumentException`, so a tenant id can never point outside the tenant folder.
- Ids are **lower-cased**: `ACME`, `Acme` and `acme` all use `acme.sqlite`. This matters on Linux,
  where file names are case-sensitive.
- `CreateConnection(Guid)` uses the `D` format (`3f2504e0-4f89-…`, lower case). The `N` format
  string of the same Guid is a valid but **different** tenant id, so use one format consistently.

## Path pattern and connection options

- The pattern must contain `{tenant}`. Relative paths are resolved against the current directory,
  so prefer an absolute path in applications, e.g.
  `Path.Combine(AppContext.BaseDirectory, "tenants", "{tenant}.sqlite")`.
- Extra connection string options can be set with a callback. `Data Source` and `Mode` are always
  set by the factory:

  ```csharp
  var tenants = new SqliteTenantConnectionFactory("tenants/{tenant}.sqlite",
      b => b.Cache = SqliteCacheMode.Shared);
  ```

## Missing tenants

Connections use `Mode=ReadWrite`, so SQLite never creates an empty file for an unknown tenant.
`CreateConnection` throws `Karkas.Data.Exceptions.TenantNotFoundException` if the file does not
exist. `TenantExists(tenantId)` and `GetDatabasePath(tenantId)` let you check before connecting.

## What the application is responsible for

- **Creating tenant databases**, for example by copying an empty template file or running a schema
  script.
- **Schema migrations**: apply every schema change to all tenant files, then regenerate the code.
- Backups, and deleting tenants.

## Tests

`Karkas.Examples/TestBash/run_sqlite_chinook_multi_tenant.bash` generates code from Chinook, copies
it into three tenant files and checks isolation, commit/rollback per tenant, case-insensitive and
Guid ids, and invalid/unknown tenant errors.
