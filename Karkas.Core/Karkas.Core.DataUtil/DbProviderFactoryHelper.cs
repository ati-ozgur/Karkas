using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;

namespace Karkas.Core.DataUtil
{
    public class DbProviderFactoryHelper
    {



        DbProviderFactory factory;

        public DbProviderFactory Factory
        {
            get { return factory; }
            set { factory = value; }
        }

        public DbProviderFactoryHelper()
        {
            if (String.IsNullOrEmpty(ConnectionSingleton.Instance.ProviderName))
            {
                factory = DbProviderFactories.GetFactory("System.Data.SqlClient");

            }
            else
            {
                factory = DbProviderFactories.GetFactory(ConnectionSingleton.Instance.ProviderName);
            }
        }
        public DbProviderFactoryHelper(String providerName)
        {
            factory = DbProviderFactories.GetFactory(providerName);
        }

        public DbParameter GetParameter()
        {
            return this.factory.CreateParameter();
        }

    }
}
