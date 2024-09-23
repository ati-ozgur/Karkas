using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;
using Microsoft.Extensions.Logging;

namespace Karkas.Data
{
    [Serializable]
    public class LoggingInfo
    {
        private ILogger logger = null;


        public LoggingInfo()
        {
            LoggerFactory factory = new LoggerFactory();
            logger = factory.CreateLogger("Dal");

        }
        public LoggingInfo(DbCommand sqlCommand): this()
        {
            this.sqlCommand = sqlCommand;
        }



        internal void LogInfo(Type pLoggingType, Exception ex)
        {
            logger.Log(LogLevel.Information,this.ToString(), ex);
        }

        private string KullaniciIsmi
        {
            get
            {
                if (Thread.CurrentPrincipal != null
                    &&
                    Thread.CurrentPrincipal.Identity != null)
                {
                    return Thread.CurrentPrincipal.Identity.Name;
                }
                else
                {
                    return "";
                }
            }
        }



        public void LogInfo(Type pLoggingType)
        {
            logger.Log(LogLevel.Information,this.ToString());
        }
        public void LogInfo(Type pLoggingType,string message)
        {
            logger.Log(LogLevel.Information, this.ToString() + $"{pLoggingType}: {message}");
        }

        internal void LogInfo(Type pLoggingType, DbException ex, string pMesaj)
        {
            logger.Log(LogLevel.Information, this.ToString() + pMesaj, ex);
        }

        internal void LogDebug(Type pLoggingType, Exception ex)
        {
            logger.Log(LogLevel.Debug, this.ToString() , ex);
        }

        public void LogDebug(Type pLoggingType)
        {
            logger.Log(LogLevel.Debug, this.ToString());
        }

        private DbCommand sqlCommand;

        public DbCommand SqlCommand
        {
            get { return sqlCommand; }
            set { sqlCommand = value; }
        }




        public override string ToString()
        {

            StringBuilder sb = new StringBuilder();
            if (SqlCommand != null)
            {
                foreach (DbParameter param in SqlCommand.Parameters)
                {
                    if (
                        param.Value != null
                        ||
                        param.Value != DBNull.Value
                        )
                    {
                        sb.Append(String.Format("DECLARE {0} {1} = '{2}' "
                            , param.ParameterName, param.DbType, param.Value) + Environment.NewLine);
                    }
                    else
                    {
                        sb.Append(String.Format("DECLARE {0} {1}"
                            , param.ParameterName, param.DbType) + Environment.NewLine);
                    }
                }
                sb.Append(Environment.NewLine);
                sb.Append(SqlCommand.CommandText);
            }
            return sb.ToString();
        }


    }
}

