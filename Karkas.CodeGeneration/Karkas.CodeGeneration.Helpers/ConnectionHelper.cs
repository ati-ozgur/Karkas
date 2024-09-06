﻿using System;
using System.Collections.Generic;
using System.Text;

using System.Reflection;
using System.Runtime.Remoting;
using System.Data.Common;


namespace Karkas.CodeGeneration.Helpers
{
    public class ConnectionHelper
    {
        public static string RemoveProviderFromConnectionString(string connectionString)
        {
            if (connectionString.Contains("Provider"))
            {
                int providerBaslangic = connectionString.IndexOf("Provider");
                int providerBitis = connectionString.IndexOf(';', providerBaslangic + 1);
                connectionString = connectionString.Remove(providerBaslangic, providerBitis + 1);
            }
            return connectionString;
        }


        public static DbConnection TestSqlite(string connectionString)
        {
            try
            {
                Assembly assembly = Assembly.LoadWithPartialName("Microsoft.Data.Sqlite");
                Object objReflection = Activator.CreateInstance(assembly.FullName, "Microsoft.Data.Sqlite.SqliteConnection");


                if (objReflection != null && objReflection is ObjectHandle)
                {
                    ObjectHandle handle = (ObjectHandle)objReflection;

                    Object objConnection = handle.Unwrap();
                    DbConnection connection = (DbConnection)objConnection;
                    connection.ConnectionString = connectionString;
                    connection.Open();
                    connection.Close();
                    return connection;

                }
                
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

    }
}

