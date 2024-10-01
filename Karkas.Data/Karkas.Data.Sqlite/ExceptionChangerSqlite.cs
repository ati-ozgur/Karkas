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
			// TODO Need to change this for sqlite
			switch (ex.ErrorCode)
			{
				//case 208:
				//	exceptionToThrow = new DatabaseConnectionException(string.Format("Cannot connect to database. Please verify connection string correctness and server is working. Connection String = {0}, Error Message = {1}", ConnectionSingleton.Instance.ConnectionString, ex.Message));
				//	break;
				default:
					exceptionToThrow = new KarkasDataException(string.Format("Unknown Data Exception , Messsage = {0}", ex.Message), ex);
					break;
			}
			new LoggingInfo().LogInfo(Type.GetType("Karkas.DataUtil.ExceptionChanger"), ex, pMessage);
			throw exceptionToThrow;
		}

	}
}
