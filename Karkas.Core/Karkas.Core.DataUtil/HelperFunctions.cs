using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

namespace Karkas.Core.DataUtil
{
    internal class HelperFunctions
    {

        private AdoTemplate template;

        public AdoTemplate Template
        {
            get { return template; }
            set { template = value; }
        }

        public HelperFunctions(AdoTemplate pTemplate)
        {
            template = pTemplate;
            this.currentTransaction = pTemplate.CurrentTransaction;
            conn = pTemplate.Connection;
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
            }
        }

        private DbTransaction currentTransaction;

        public DbTransaction CurrentTransaction
        {
            get { return currentTransaction; }
            set { currentTransaction = value; }
        }


        protected bool ConnectionKapatilacakMi()
        {
            return AutomaticConnectionManagement;
        }

        protected bool ConnectionAcilacakMi()
        {
            return (AutomaticConnectionManagement);
        }



        DbConnection conn;


        internal void ExecuteQuery(DataTable dt, string sql, CommandType cmdType)
        {
            DbCommand cmd = Template.getDatabaseCommand(sql, conn);
            cmd.CommandType = cmdType;

            DbDataAdapter adapter = AdapterDondur(cmd);
            try
            {
                adapter.Fill(dt);
            }
            catch (DbException ex)
            {
                ExceptionChanger.Degistir(ex, new LoggingInfo(cmd).ToString());
            }
            finally
            {
                if (ConnectionKapatilacakMi())
                {
                    conn.Close();
                }
            }

        }
        internal DbDataAdapter AdapterDondur(DbCommand cmd)
        {
            if (currentTransaction != null)
            {
                cmd.Transaction = currentTransaction;
            }
            DbDataAdapter adapter = template.getDatabaseAdapter(cmd);
            return adapter;
        }


        internal void ExecuteQuery(DataTable dt, DbCommand cmd)
        {
            DbDataAdapter adapter = AdapterDondur(cmd);

            try
            {
                adapter.Fill(dt);
            }
            catch (DbException ex)
            {
                ExceptionChanger.Degistir(ex, new LoggingInfo(cmd).ToString());

            }
            finally
            {
                if (ConnectionKapatilacakMi())
                {
                    conn.Close();
                }
            }

        }



        internal void ExecuteQuery(DataTable dt, string sql, CommandType cmdType, DbParameter[] parameters)
        {
            DbCommand cmd = Template.getDatabaseCommand(sql, conn);
            cmd.CommandType = cmdType;
            foreach (DbParameter p in parameters)
            {
                cmd.Parameters.Add(p);
            }
            ExecuteQuery(dt, cmd);


        }


        public void ValidateFillArguments(DataTable dataTable, string sql)
        {
            if (dataTable == null)
            {
                throw new ArgumentNullException("dataTable", "DataTable argument can not be null");
            }
            if (sql == null)
            {
                throw new ArgumentNullException("sql", "SQL for DataSet Fill operation can not be null");
            }
        }
        public void ValidateFillArguments(DataSet dataSet, string sql)
        {
            if (dataSet == null)
            {
                throw new ArgumentNullException("dataSet", "DataSet argument can not be null");
            }
            if (sql == null)
            {
                throw new ArgumentNullException("sql", "SQL for DataSet Fill operation can not be null");
            }
        }
        public void ValidateFillArguments(DataSet dataSet, string sql, DbParameter[] parameters)
        {
            if (dataSet == null)
            {
                throw new ArgumentNullException("dataSet", "DataSet argument can not be null");
            }
            if (sql == null)
            {
                throw new ArgumentNullException("sql", "SQL for DataSet Fill operation can not be null");
            }
            if (parameters == null)
            {
                throw new ArgumentNullException("parameters", "Parameters for DataSet Fill operations can not be null");
            }
        }
        public void ValidateFillArguments(DataTable dataTable, string sql, DbParameter[] parameters)
        {
            if (dataTable == null)
            {
                throw new ArgumentNullException("dataTable", "DataTable argument can not be null");
            }
            if (sql == null)
            {
                throw new ArgumentNullException("sql", "SQL for DataTable Fill operation can not be null");
            }
            if (parameters == null)
            {
                throw new ArgumentNullException("parameters", "Parameters for DataTable Fill operations can not be null");
            }
        }

    }
}

