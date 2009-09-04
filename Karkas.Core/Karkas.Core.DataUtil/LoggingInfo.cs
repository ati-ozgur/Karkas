using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using log4net;
using System.Threading;

namespace Karkas.Core.DataUtil
{
    [Serializable]
    public class LoggingInfo
    {
        private static ILog logger = LogManager.GetLogger("Dal");

        public LoggingInfo()
        {

        }

        public LoggingInfo(Guid pKisiKey, SqlCommand sqlCommand)
        {
            this.kisiKey = pKisiKey;
            this.sqlCommand = sqlCommand;
        }



        internal void LogInfo(Type pLoggingType, Exception ex)
        {
            log4netEkBilgi(pLoggingType);
            logger.Info(this.ToString(), ex);
        }

        private string kullaniciIsmi
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
            MDC.Set("Kullanici", kullaniciIsmi);
            MDC.Set("KisiKey", KisiKey.ToString());
            MDC.Set("LoggingType", pLoggingType.FullName);
        }

        public void LogInfo(Type pLoggingType)
        {
            log4netEkBilgi(pLoggingType);
            logger.Info(this.ToString());
        }

        internal void LogInfo(Type pLoggingType, SqlException ex, string pMesaj)
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

        private Guid? kisiKey;

        public Guid? KisiKey
        {
            get { return kisiKey; }
            set { kisiKey = value; }
        }

        private SqlCommand sqlCommand;

        public SqlCommand SqlCommand
        {
            get { return sqlCommand; }
            set { sqlCommand = value; }
        }




        public override string ToString()
        {

            StringBuilder sb = new StringBuilder();
            if (SqlCommand != null)
            {
                foreach (SqlParameter param in SqlCommand.Parameters)
                {
                    sb.Append(String.Format("DECLARE {0} {1} = '{2}' "
                        , param.ParameterName, param.SqlDbType, param.Value) + Environment.NewLine);
                }
                sb.Append(Environment.NewLine);
                sb.Append(SqlCommand.CommandText);
            }
            return sb.ToString();
        }


    }
}

