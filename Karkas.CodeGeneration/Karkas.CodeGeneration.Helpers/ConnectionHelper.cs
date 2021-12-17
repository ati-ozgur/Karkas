using System;
using System.Collections.Generic;
using System.Text;

namespace Karkas.CodeGenerationHelper
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

    }
}

