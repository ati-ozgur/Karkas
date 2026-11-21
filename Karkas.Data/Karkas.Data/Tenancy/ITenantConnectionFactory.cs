using System;
using System.Data.Common;

namespace Karkas.Data.Tenancy
{
	/// <summary>
	/// Creates database connections for a given tenant.
	/// Pass the returned connection to a generated Bs or Dal constructor,
	/// e.g. <c>new AlbumBs(factory.CreateConnection("acme"))</c>.
	/// </summary>
	public interface ITenantConnectionFactory
	{
		/// <summary>Creates a new, unopened connection to the tenant's database.</summary>
		DbConnection CreateConnection(string tenantId);

		/// <summary>Creates a new, unopened connection to the tenant's database.</summary>
		DbConnection CreateConnection(Guid tenantId);
	}
}
