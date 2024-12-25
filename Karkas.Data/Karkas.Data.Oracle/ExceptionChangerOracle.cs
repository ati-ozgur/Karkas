using Karkas.Data.Exceptions;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Oracle.ManagedDataAccess.Client;

namespace Karkas.Data.Oracle;

public class ExceptionChangerOracle : ExceptionChanger
{

	private Exception translateException(OracleException ex)
	{
		Exception exceptionToThrow = null;
		// TODO Need to change this for Oracle
		switch (ex.Number)
		{
			case 942:
			case 904:
				exceptionToThrow = new WrongSQLQueryException(ex.Message,ex);
				break;
			default:
				exceptionToThrow = new KarkasDataException(string.Format("Unknown Data Exception , Messsage = {0}", ex.Message), ex);
				break;
		}
		return exceptionToThrow;
	}
	protected override void ChangeDbSpecific(DbException ex, string pMessage = "NO SQL QUERY")
	{

		Exception exceptionToThrow = null;

		if(ex is OracleException)
		{
			OracleException sqlEx = ex as OracleException;
			exceptionToThrow = translateException(sqlEx);
		}
		else
		{
			exceptionToThrow = ex;
		}

		new LoggingInfo().LogInfo(Type.GetType("Karkas.Data.Oracle.ExceptionChanger"), ex, pMessage);
		throw exceptionToThrow;

	}
}
