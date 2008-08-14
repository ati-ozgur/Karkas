using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

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



        public SqlConnection Connection
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
                }
                else
                {
                    throw new ArgumentException("Connection Stringler aras�nda Main bulunamad�, l�tfen config dosyas�n�(web.config/app.config) kontrol ediniz");
                }

            }
        }
        private Dictionary<string, string> connectionStringList = new Dictionary<string, string>();
        public string getConnectionString(string pDatabaseName)
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
                    throw new ArgumentException(string.Format("Connection Stringler aras�nda {0} bulunamad�, l�tfen config dosyas�n�(web.config/app.config) kontrol ediniz",pDatabaseName));
                }
            }
        }

    }
}
