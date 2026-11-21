using System;
using System.Data.Common;
using System.Text.RegularExpressions;

namespace Karkas.Data.Tenancy
{
	/// <summary>
	/// Validates and normalizes tenant ids, then lets the database specific subclass
	/// turn the normalized id into a connection.
	/// </summary>
	/// <remarks>
	/// Tenant ids may contain letters, digits, '-' and '_' (1-64 characters), so Guids in
	/// "D" and "N" format are accepted. Ids are lower-cased, so "ACME" and "acme" are the same
	/// tenant on case-sensitive file systems too.
	/// </remarks>
	public abstract class BaseTenantConnectionFactory : ITenantConnectionFactory
	{
		private static readonly Regex TenantIdRegex = new Regex("^[A-Za-z0-9_-]{1,64}$", RegexOptions.CultureInvariant);

		public DbConnection CreateConnection(string tenantId)
		{
			return CreateConnectionForNormalizedTenantId(NormalizeTenantId(tenantId));
		}

		public DbConnection CreateConnection(Guid tenantId)
		{
			return CreateConnection(tenantId.ToString("D"));
		}

		/// <summary>
		/// Checks the tenant id and returns its lower-case form.
		/// Throws <see cref="ArgumentException"/> for an invalid id.
		/// </summary>
		public static string NormalizeTenantId(string tenantId)
		{
			if (tenantId == null)
			{
				throw new ArgumentNullException(nameof(tenantId));
			}
			if (!TenantIdRegex.IsMatch(tenantId))
			{
				throw new ArgumentException(
					string.Format("Invalid tenant id '{0}'. Use 1-64 letters, digits, '-' or '_'.", tenantId),
					nameof(tenantId));
			}
			return tenantId.ToLowerInvariant();
		}

		/// <summary>Creates a new, unopened connection. The id is already validated and lower-cased.</summary>
		protected abstract DbConnection CreateConnectionForNormalizedTenantId(string normalizedTenantId);
	}
}
