using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;

namespace Karkas.Core.DataUtil.BaseClasses
{
    public abstract class BaseDalWithoutEntity<ADOTEMPLATE_DB_TYPE,PARAMETER_BUILDER>
        where ADOTEMPLATE_DB_TYPE : IAdoTemplate<IParameterBuilder>, new()
        where PARAMETER_BUILDER : IParameterBuilder, new()
    {

        public BaseDalWithoutEntity()
        {

        }


        private bool automaticConnectionManagement = true;
        /// <summary>
        /// Eger varsayılan deger, true bırakılırsa, connection yonetimi 
        /// BaseDal tarafından yapılır. Komutlar cagrılmadan once, connection getirme
        /// Connection'u acma ve kapama BaseDal kontrolundedir.
        /// Eger false ise connection olusturma, acma Kapama Kullanıcıya aittir.
        /// </summary>
        public bool AutomaticConnectionManagement
        {
            get
            {
                return automaticConnectionManagement;
            }
            set
            {
                automaticConnectionManagement = value;
                this.Template.AutomaticConnectionManagement = value;
            }
        }



        private ADOTEMPLATE_DB_TYPE template;
        public virtual ADOTEMPLATE_DB_TYPE Template
        {
            get
            {
                template = getNewAdoTemplate();
                return template;
            }
        }

        protected ADOTEMPLATE_DB_TYPE getNewAdoTemplate()
        {
            ADOTEMPLATE_DB_TYPE t = new ADOTEMPLATE_DB_TYPE();
            t.Connection = Connection;
            t.CurrentTransaction = currentTransaction;
            t.AutomaticConnectionManagement = automaticConnectionManagement;
            t.DbProviderName = DbProviderName;
            return t;
        }

        public abstract string DbProviderName
        {
            get;
        }

        public virtual string DatabaseName
        {
            get
            {
                return "";
            }
        }
        private DbConnection connection = null;

        public DbConnection Connection
        {
            get
            {
                if (connection == null)
                {
                    if (string.IsNullOrEmpty(DatabaseName))
                    {
                        connection =  ConnectionSingleton.Instance.getConnection("Main");
                    }
                    else
                    {
                        connection = ConnectionSingleton.Instance.getConnection(DatabaseName);
                    }
                }
                return connection;
            }
            set { connection = value; }
        }


        private DbTransaction currentTransaction;

        public DbTransaction CurrentTransaction
        {
            get { return currentTransaction; }
            set { currentTransaction = value; }
        }

        protected int ExecuteNonQueryCommandInternal(DbCommand cmd)
        {
            int resultRowSayisi = 0;
            try
            {
                if (ShouldOpenConnection())
                {
                    Connection.Open();
                }
                else if (currentTransaction != null)
                {
                    cmd.Transaction = currentTransaction;
                }
                new LoggingInfo( cmd).LogInfo(this.GetType());

                resultRowSayisi = cmd.ExecuteNonQuery();
            }
            catch (DbException ex)
            {
                if (currentTransaction != null)
                {
                    currentTransaction.Rollback();
                }
                ExceptionChanger.Change(ex, new LoggingInfo(cmd).ToString());
            }
            finally
            {
                if (ShouldCloseConnection())
                {
                    Connection.Close();
                }
            }
            return resultRowSayisi;
        }

        protected bool ShouldCloseConnection()
        {
            return Connection.State != ConnectionState.Closed && AutomaticConnectionManagement;
        }

        protected bool ShouldOpenConnection()
        {
            return (Connection.State != ConnectionState.Open) && (AutomaticConnectionManagement);
        }



        public IParameterBuilder getParameterBuilder()
        {
            return new PARAMETER_BUILDER();
        }
    }
}
