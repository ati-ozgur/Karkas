using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

namespace Karkas.Core.DataUtil
{
    public class ConnectionSingleton
    {
        private const string MainDBName = "Main";
        private ConnectionSingleton()
        {

        }

        public string ConnectionString
        {
            get 
            {
                return getConnectionString(MainDBName); 
            }
            set 
            { 
                connectionStringList.Add(MainDBName, value);
            }
        }

        public string ProviderName
        {
            get
            {

                return getProviderName(MainDBName);
            }
            set 
            {
                providerNameList[MainDBName] = value; 
            }
        }

       



        private static ConnectionSingleton _instance = new ConnectionSingleton();

        public static ConnectionSingleton Instance
        {
            get { return ConnectionSingleton._instance; }
            set { ConnectionSingleton._instance = value; }
        }

        private Dictionary<string, string> connectionStringList = new Dictionary<string, string>();
        private string getConnectionString(string pDatabaseName)
        {
            if (connectionStringList.ContainsKey(pDatabaseName))
            {
                return connectionStringList[pDatabaseName];
            }
            throw new ArgumentException(string.Format("Connection String for database {0} could not be found. Please check it", pDatabaseName));

        }
        private Dictionary<string, string> providerNameList = new Dictionary<string, string>();
        private string getProviderName(string pDatabaseName)
        {
            if (providerNameList.ContainsKey(pDatabaseName))
            {
                return providerNameList[pDatabaseName];
            }
            throw new ArgumentException(string.Format("Provider name for database {0} could not be found. Please check it", pDatabaseName));
        }

        public DbConnection getConnectionUsingConnectionString(string connectionString,string providerName)
        {

            DbConnection conn = DbProviderFactoryHelper.Create(providerName).Factory.CreateConnection();
            conn.ConnectionString = connectionString;
            return conn;

        }


        public DbConnection getConnection(string DatabaseName)
        {
            string providerName = getProviderName(DatabaseName);
            string connectionString = getConnectionString(providerName);

            DbConnection conn = DbProviderFactoryHelper.Create(providerName).Factory.CreateConnection();
            conn.ConnectionString = connectionString;
            return conn;

        }
    }
}

