using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;

namespace Karkas.Data.Exceptions
{
	public abstract class ExceptionChanger
	{

		public void Change(DbException ex, string pMessage = "NO SQL QUERY")
		{
			ChangeDbSpecific(ex, pMessage);
		}

		protected abstract void ChangeDbSpecific(DbException ex, string pMessage = "NO SQL QUERY");


	}
}

