using System;
using System.Collections.Generic;
using System.Text;
using log4net;
using System.Threading;
using System.Web;
using System.Data.Common;

namespace Karkas.Core.DataUtil
{
    [Serializable]
    public class LoggingInfo
    {
        private static ILog logger = LogManager.GetLogger("Dal");

        public LoggingInfo()
        {

        }
        public LoggingInfo(DbCommand sqlCommand)
        {
            this.sqlCommand = sqlCommand;
        }



        internal void LogInfo(Type pLoggingType, Exception ex)
        {
            log4netEkBilgi(pLoggingType);
            logger.Info(this.ToString(), ex);
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

        private void log4netEkBilgi(Type pLoggingType)
        {
            MDC.Set("Kullanici", KullaniciIsmi);
            MDC.Set("LoggingType", pLoggingType.FullName);
        }

        public void LogInfo(Type pLoggingType)
        {
            log4netEkBilgi(pLoggingType);
            logger.Info(this.ToString());
        }

        internal void LogInfo(Type pLoggingType, DbException ex, string pMesaj)
        {
            log4netEkBilgi(pLoggingType);
            logger.Info("LoggingInfo: " + this.ToString() + pMesaj, ex);
        }

        internal void LogDebug(Type pLoggingType, Exception ex)
        {
            log4netEkBilgi(pLoggingType);
            logger.Debug(this.ToString(), ex);
        }

        public void LogDebug(Type pLoggingType)
        {
            log4netEkBilgi(pLoggingType);
            logger.Debug(this.ToString());
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

