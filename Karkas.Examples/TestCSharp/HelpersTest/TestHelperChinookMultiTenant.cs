using Karkas.Data.Tenancy;

namespace Karkas.Examples;

/// <summary>
/// End to end tests for one-SQLite-file-per-tenant. Every check throws on failure,
/// so the test script fails if tenants are not isolated.
/// Expects tenants/acme.sqlite, tenants/globex.sqlite and tenants/{GuidTenant}.sqlite
/// (copies of the Chinook database), created by run_sqlite_chinook_multi_tenant.bash.
/// </summary>
public static class TestHelperMultiTenant
{
	public static readonly Guid GuidTenant = Guid.Parse("3f2504e0-4f89-41d3-9a0c-0305e82c3301");

	private static readonly SqliteTenantConnectionFactory Tenants =
		new SqliteTenantConnectionFactory("tenants/{tenant}.sqlite");

	private static void Check(bool condition, string message)
	{
		if (!condition)
		{
			throw new Exception("Multi tenant test failed: " + message);
		}
		Console.WriteLine("OK: " + message);
	}

	private static int CountArtists(ITenantConnectionFactory factory, string tenantId, string artistName)
	{
		ArtistBs bs = new ArtistBs(factory.CreateConnection(tenantId));
		return bs.QueryUsingColumnName(Artist.ColumnNames.Name, artistName).Count;
	}

	private static string UniqueName(string prefix)
	{
		return prefix + Guid.NewGuid().ToString();
	}

	public static void TestTenantsAreIsolated()
	{
		string name = UniqueName("acme-artist-");
		ArtistBs acmeArtistBs = new ArtistBs(Tenants.CreateConnection("acme"));
		acmeArtistBs.Insert(new Artist { Name = name });

		Check(CountArtists(Tenants, "acme", name) == 1, "row inserted for acme is visible in acme");
		Check(CountArtists(Tenants, "globex", name) == 0, "row inserted for acme is not visible in globex");
	}

	public static void TestTenantIdIsCaseInsensitive()
	{
		string name = UniqueName("case-artist-");
		new ArtistBs(Tenants.CreateConnection("ACME")).Insert(new Artist { Name = name });

		Check(CountArtists(Tenants, "acme", name) == 1, "\"ACME\" and \"acme\" are the same tenant");
		Check(Tenants.GetDatabasePath("AcMe") == "tenants/acme.sqlite", "tenant id is lower-cased in the file path");
	}

	public static void TestTransactionCommitStaysInTenant()
	{
		string artistName = UniqueName("tx-artist-");
		string title = UniqueName("tx-title-");
		new AlbumBs(Tenants.CreateConnection("acme")).InsertNewArtistAndAlbum(artistName, title);

		int acmeAlbums = new AlbumBs(Tenants.CreateConnection("acme"))
			.QueryUsingColumnName(Album.ColumnNames.Title, title).Count;
		int globexAlbums = new AlbumBs(Tenants.CreateConnection("globex"))
			.QueryUsingColumnName(Album.ColumnNames.Title, title).Count;

		Check(acmeAlbums == 1, "committed transaction is visible in acme");
		Check(globexAlbums == 0, "committed transaction is not visible in globex");
	}

	public static void TestTransactionRollbackInTenant()
	{
		string artistName = UniqueName("rollback-artist-");
		string title = UniqueName("rollback-title-");
		bool thrown = false;
		try
		{
			new AlbumBs(Tenants.CreateConnection("globex")).InsertNewArtistAndAlbumError(artistName, title);
		}
		catch (Exception)
		{
			thrown = true;
		}

		Check(thrown, "simulated error is thrown inside the globex transaction");
		Check(CountArtists(Tenants, "globex", artistName) == 0, "rolled back artist is not in globex");
		Check(CountArtists(Tenants, "acme", artistName) == 0, "rolled back artist is not in acme");
	}

	public static void TestGuidTenant()
	{
		string name = UniqueName("guid-artist-");
		new ArtistBs(Tenants.CreateConnection(GuidTenant)).Insert(new Artist { Name = name });

		Check(CountArtists(Tenants, GuidTenant.ToString("D").ToUpperInvariant(), name) == 1,
			"Guid overload and upper-case Guid string reach the same tenant");
		Check(CountArtists(Tenants, "acme", name) == 0, "Guid tenant row is not visible in acme");
	}

	public static void TestInvalidAndUnknownTenants()
	{
		ExpectThrows<TenantNotFoundException>(() => Tenants.CreateConnection("no-such-tenant"),
			"unknown tenant throws TenantNotFoundException");
		ExpectThrows<ArgumentException>(() => Tenants.CreateConnection("../acme"),
			"path traversal in tenant id throws ArgumentException");
		ExpectThrows<ArgumentException>(() => Tenants.CreateConnection(""),
			"empty tenant id throws ArgumentException");
		ExpectThrows<ArgumentException>(() => Tenants.CreateConnection(GuidTenant.ToString("B")),
			"Guid in braces format throws ArgumentException");
		ExpectThrows<ArgumentException>(() => new SqliteTenantConnectionFactory("tenants/fixed.sqlite"),
			"path pattern without {tenant} throws ArgumentException");
		Check(!Tenants.TenantExists("no-such-tenant") && Tenants.TenantExists("globex"), "TenantExists works");
	}

	private static void ExpectThrows<TException>(Action action, string message) where TException : Exception
	{
		try
		{
			action();
		}
		catch (TException)
		{
			Check(true, message);
			return;
		}
		Check(false, message);
	}
}
