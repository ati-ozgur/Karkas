using Karkas.Data.Exceptions;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;


namespace Karkas.Data.SqlServer
{
	public class ExceptionChangerSqlServer : ExceptionChanger
	{


		private Exception translateException(SqlException ex,string pMessage)
		{
			Exception exceptionToThrow = null;
			// TODO Need to change this for oracle and other databases
			switch (ex.Number)
			{
				default:
					exceptionToThrow = new KarkasDataException(string.Format("Unknown Data Exception , Messsage = {0}", ex.Message), ex);
					break;
				case 137:
					exceptionToThrow = new WrongSQLQueryException(string.Format("Sql statement parameters are not defined/added correctly, sql statement = {0}, orjinal error message = {1}", pMessage, ex.Message), ex);
					break;
				case -1:
					exceptionToThrow = new DatabaseConnectionException(string.Format("Cannot connect to database using connection string: {0} . Error Message = {1}", ConnectionSingleton.Instance.ConnectionString, ex.Message), ex);
					break;
				case 102:
				case 207:
					exceptionToThrow = new WrongSQLQueryException(string.Format("Sql statement is not correct: {0} . Error Message from server: {1}", pMessage, ex.Message), ex);
					break;
				case 2627:
					exceptionToThrow = new KarkasDataException(string.Format("Value used as Primary Key already exists in the table."), ex);
					break;
				case 109:
					exceptionToThrow = new KarkasDataException(string.Format("Neccessary values for all columns are not given for insert/update."), ex);
					break;
				case 515:
					exceptionToThrow = new KarkasDataException(string.Format("Neccessary values for the column is not given"), ex);
					break;
				case 110:
					exceptionToThrow = new KarkasDataException(string.Format("More parameters are given than necessary."), ex);
					break;
				case 245:
					exceptionToThrow = new KarkasDataException(string.Format("Data type is not correct for the column."), ex);
					break;
				case 2812:
					exceptionToThrow = new KarkasDataException(string.Format("Value used as Primary Key already exists in the table."), ex);
					break;
				case 8144:
					exceptionToThrow = new KarkasDataException(string.Format("Stored procedure has more parameters: {0} ", ex.Data), ex);
					break;
				case 201:
					exceptionToThrow = new KarkasDataException(string.Format("Stored procedure has less parameters {0}  {1}", ex.Data), ex);
					break;
				case 547:
					exceptionToThrow = new ForeignKeyException(string.Format("Table constraints are violated."), ex);
					break;
				case 208:
					exceptionToThrow = new DatabaseConnectionException(string.Format("Cannot connect to database. Please verify connection string correctness and server is working. Connection String = {0}, Error Message = {1}", ConnectionSingleton.Instance.ConnectionString, ex.Message));
					break;
			}
			return exceptionToThrow;

		}

		protected override void ChangeDbSpecific(DbException ex, string pMessage = "NO SQL QUERY")
		{
			Exception exceptionToThrow = null;
			if(ex is SqlException)
			{
				SqlException sqlEx = ex as SqlException;
				exceptionToThrow = translateException(sqlEx,pMessage);
			}
			else
			{
				exceptionToThrow = ex;
			}

			new LoggingInfo().LogInfo(Type.GetType("Karkas.Data.SqlServer.ExceptionChanger"), ex, pMessage);
			throw exceptionToThrow;
		}


	}
}
