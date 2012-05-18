using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Data.Common;

namespace Karkas.Core.DataUtil
{
    public class ConnectionSingleton
    {

        private string connectionString = null;

        public string ConnectionString
        {
            get 
            {
                return connectionString; 
            }
            set { connectionString = value; }
        }

        private string providerName;
        public string ProviderName
        {
            get
            {
                return providerName;
            }
            set { providerName = value; }
        }

       


        public DbConnection Connection
        {
            get
            {
                return new SqlConnection(connectionString);
            }
        }

        private static ConnectionSingleton _instance = new ConnectionSingleton();

        public static ConnectionSingleton Instance
        {
            get { return ConnectionSingleton._instance; }
            set { ConnectionSingleton._instance = value; }
        }
        private ConnectionSingleton()
        {
            if (connectionString == null)
            {
                if (ConfigurationManager.ConnectionStrings["Main"] != null)
                {
                    connectionString = ConfigurationManager.ConnectionStrings["Main"].ConnectionString;
                    providerName = ConfigurationManager.ConnectionStrings["Main"].ProviderName;
                }
                else
                {
                    throw new ArgumentException("Connection Stringler arasında Main bulunamadı, lütfen config dosyasını(web.config/app.config) kontrol ediniz");
                }

            }
        }
        private Dictionary<string, string> connectionStringList = new Dictionary<string, string>();
        private string getConnectionString(string pDatabaseName)
        {
            if (connectionStringList.ContainsKey(pDatabaseName))
            {
                return connectionStringList[pDatabaseName];
            }
            else
            {
                if (ConfigurationManager.ConnectionStrings[pDatabaseName] != null)
                {
                    connectionStringList.Add(pDatabaseName, ConfigurationManager.ConnectionStrings[pDatabaseName].ConnectionString);
                    return connectionStringList[pDatabaseName];
                }
                else
                {
                    throw new ArgumentException(string.Format("Connection Stringler arasında {0} bulunamadı, lütfen config dosyasını(web.config/app.config) kontrol ediniz",pDatabaseName));
                }
            }
        }
        private Dictionary<string, string> providerNameList = new Dictionary<string, string>();
        private string getProviderName(string pDatabaseName)
        {
            if (providerNameList.ContainsKey(pDatabaseName))
            {
                return providerNameList[pDatabaseName];
            }
            else
            {
                if (ConfigurationManager.ConnectionStrings[pDatabaseName] != null)
                {
                    providerNameList.Add(pDatabaseName, ConfigurationManager.ConnectionStrings[pDatabaseName].ProviderName);
                    return providerNameList[pDatabaseName];
                }
                else
                {
                    throw new ArgumentException(string.Format("Connection Stringler arasında {0} bulunamadı, lütfen config dosyasını(web.config/app.config) kontrol ediniz", pDatabaseName));
                }
            }
        }

        public DbConnection getConnection(string DatabaseName)
        {
            DbConnection conn = new DbProviderFactoryHelper(getProviderName(DatabaseName)).Factory.CreateConnection();
            conn.ConnectionString = getConnectionString(DatabaseName);
            return conn;

        }
    }
}

