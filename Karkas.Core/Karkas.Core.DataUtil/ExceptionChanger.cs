﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using Karkas.Core.DataUtil.Exceptions;
using System.Data.Common;

namespace Karkas.Core.DataUtil
{
    public class ExceptionChanger
    {

        public static void Change(DbException ex, string pMesaj = "NO SQL QUERY")
        {
            DegistirPrivate(ex, pMesaj);
        }


        private static void DegistirPrivate(DbException ex, string pMesaj = "NO SQL QUERY")
        {
            Exception exceptionToThrow = null;
            // TODO burayı oracle ve diğer veritabanları için yazmak gerekiyor.
            switch (ex.ErrorCode)
            {
                default:
                    exceptionToThrow = new KarkasDataException(String.Format("Unknown Data Exception , Messsage = {0}", ex.Message), ex);
                    break;
                case 137:
                    exceptionToThrow = new WrongSQLQueryException(String.Format("Sql statement parameters are not defined/added correctly, sql statement = {0}, orjinal error message = {1}", pMesaj, ex.Message), ex);
                    break;
                case -1:
                    exceptionToThrow = new DatabaseConnectionException(String.Format("Cannot connect to database using connection string: {0} . Error Message = {1}", ConnectionSingleton.Instance.ConnectionString, ex.Message), ex);
                    break;
                case 102:
                case 207:
                    exceptionToThrow = new WrongSQLQueryException(String.Format("Sql statement is not correct: {0} . Error Message from server: {1}", pMesaj, ex.Message), ex);
                    break;
                case 2627:
                    exceptionToThrow = new KarkasDataException(String.Format("Value used as Primary Key already exists in the table."), ex);
                    break;
                case 109:
                    exceptionToThrow = new KarkasDataException(String.Format("Neccessary values for all columns are not given for insert/update."), ex);
                    break;
                case 515:
                    exceptionToThrow = new KarkasDataException(String.Format("Neccessary values for the column is not given"), ex);
                    break;
                case 110:
                    exceptionToThrow = new KarkasDataException(String.Format("More parameters are given than necessary."), ex);
                    break;
                case 245:
                    exceptionToThrow = new KarkasDataException(String.Format("Data type is not correct for the column."), ex);
                    break;
                case 2812:
                    exceptionToThrow = new KarkasDataException(String.Format("Value used as Primary Key already exists in the table."), ex);
                    break;
                case 8144:
                    exceptionToThrow = new KarkasDataException(String.Format("Stored procedure has more parameters: {0} ", ex.Data), ex);
                    break;
                case 201:
                    exceptionToThrow = new KarkasDataException(String.Format("Stored procedure has less parameters {0}  {1}", ex.Data), ex);
                    break;
                case 547:
                    exceptionToThrow = new ForeignKeyException(String.Format("Table constraints are violated."), ex);
                    break;
                case 208:
                    exceptionToThrow = new DatabaseConnectionException(String.Format("Cannot connect to database. Please verify connection string correctness and server is working. Connection String = {0}, Error Message = {1}", ConnectionSingleton.Instance.ConnectionString, ex.Message));
                    break;
            }
            new LoggingInfo().LogInfo(Type.GetType("Karkas.Core.DataUtil.ExceptionChanger"), ex, pMesaj);
            throw exceptionToThrow;
        }


    }
}

