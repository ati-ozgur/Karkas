using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;

namespace Karkas.Core.DataUtil
{
    public abstract class BaseBsWithoutEntity
    {

        private bool isInTransaction = false;
        public bool IsInTransaction
        {
            get
            {
                return isInTransaction;
            }
            set
            {
                isInTransaction = value;
                if (value)
                {
                    this.Dal.OtomatikConnectionYonetimi = false;
                    Dal.CurrentTransaction = transaction;

                }
            }
        }

        protected abstract BaseDalWithoutEntity Dal
        {
            get;
        }


        protected DbTransaction transaction;
        public void BeginTransaction()
        {
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
                transaction = connection.BeginTransaction();
            }
            IsInTransaction = true;
        }
        public void CommitTransaction()
        {
            transaction.Commit();
        }
        public void ClearTransactionInformation()
        {
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
            IsInTransaction = false;
            this.Dal.OtomatikConnectionYonetimi = true;
        }

        public virtual string DatabaseName
        {
            get
            {
                return "";
            }
        }


        private DbConnection connection;
        public DbConnection Connection
        {
            get
            {
                if (connection == null)
                {
                    if (string.IsNullOrEmpty(DatabaseName))
                    {
                        connection =  ConnectionSingleton.Instance.Connection;
                    }
                    else
                    {
                        connection = (SqlConnection) ConnectionSingleton.Instance.getConnection(DatabaseName);
                    }
                }
                return connection;
            }
            set { connection = value; }
        }
    }
}
