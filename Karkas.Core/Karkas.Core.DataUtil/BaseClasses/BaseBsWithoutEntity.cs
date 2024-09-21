using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;

namespace Karkas.Core.DataUtil.BaseClasses
{
    public abstract class BaseBsWithoutEntity<ADOTEMPLATE_DB_TYPE, PARAMETER_BUILDER>
            where ADOTEMPLATE_DB_TYPE : IAdoTemplate<IParameterBuilder>, new()
            where PARAMETER_BUILDER : IParameterBuilder, new()

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
                    this.Dal.AutomaticConnectionManagement = false;
                    Dal.CurrentTransaction = transaction;

                }
            }
        }

        protected abstract BaseDalWithoutEntity<ADOTEMPLATE_DB_TYPE,PARAMETER_BUILDER> Dal
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
            this.Dal.IsInTransaction = true;
        }
        public void CommitTransaction()
        {
            transaction.Commit();
            ClearTransactionInformation();
        }
        public void ClearTransactionInformation()
        {
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
            IsInTransaction = false;
            this.Dal.AutomaticConnectionManagement = true;
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

                    connection = ConnectionSingleton.Instance.getConnection(DatabaseName);
                }
                return connection;
            }
            set { connection = value; }
        }
    }
}
