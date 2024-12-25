using Karkas.Data.Exceptions;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karkas.Data.Sqlite
{
	public class ExceptionChangerSqlite : ExceptionChanger
	{
		protected override void ChangeDbSpecific(DbException ex, string pMessage = "NO SQL QUERY")
		{
			Exception exceptionToThrow = null;
			string sqliteMessage = ex.Message;

			switch(sqliteMessage)
			{
				case string a when a.Contains("SQLite Error 1: 'no such column"): 
					exceptionToThrow = new WrongSQLQueryException(ex.Message, ex);
					break;
				case string b when b.Contains("SQLite Error 1"): 
					exceptionToThrow = new KarkasDataException(string.Format("SQLITE Exception , Messsage = {0}", ex.Message), ex);
					break;
				default:
					exceptionToThrow = new KarkasDataException(string.Format("SQLITE Exception , Messsage = {0}", ex.Message), ex);
					break;				
			}

			new LoggingInfo().LogInfo(Type.GetType("Karkas.Data.Sqlite.ExceptionChangerSqlite"), ex, pMessage);
			throw exceptionToThrow;
		}

	}
}
