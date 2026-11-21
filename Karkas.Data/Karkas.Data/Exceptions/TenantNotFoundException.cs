using System;

namespace Karkas.Data.Exceptions
{
	/// <summary>Thrown when no database exists for the requested tenant.</summary>
	[Serializable]
	public class TenantNotFoundException : Exception
	{
		public TenantNotFoundException()
			: base()
		{
		}

		public TenantNotFoundException(string pMessage)
			: base(pMessage)
		{
		}

		public TenantNotFoundException(string pMessage, Exception pInnerException)
			: base(pMessage, pInnerException)
		{
		}

		public TenantNotFoundException(string pMessage, string tenantId)
			: base(pMessage)
		{
			TenantId = tenantId;
		}

		/// <summary>The normalized (lower-case) tenant id that was not found.</summary>
		public string TenantId { get; }
	}
}
