using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace Karkas.Core.DataUtil
{
    internal class HelperFunctions
    {

        private bool otomatikConnectionYonetimi = true;
        /// <summary>
        /// Eger varsayılan deger, true bırakılırsa, connection yonetimi 
        /// BaseDal tarafından yapılır. Komutlar cagrılmadan once, connection getirme
        /// Connection'u acma ve kapama BaseDal kontrolundedir.
        /// Eger false ise connection olusturma, acma Kapama Kullanıcıya aittir.
        /// </summary>
        public bool OtomatikConnectionYonetimi
        {
            get
            {
                return otomatikConnectionYonetimi;
            }
            set
            {
                otomatikConnectionYonetimi = value;
            }
        }

        private SqlTransaction currentTransaction;

        public SqlTransaction CurrentTransaction
        {
            get { return currentTransaction; }
            set { currentTransaction = value; }
        }


        protected bool ConnectionKapatilacakMi()
        {
            return OtomatikConnectionYonetimi;
        }

        protected bool ConnectionAcilacakMi()
        {
            return (OtomatikConnectionYonetimi);
        }



        SqlConnection conn;
        public HelperFunctions(SqlConnection pConnection,SqlTransaction currentTransaction)
        {
            this.currentTransaction = currentTransaction;
            conn = pConnection;
        }

        internal void SorguCalistir(DataTable dt, string sql, CommandType cmdType)
        {
            SqlCommand cmd = getSqlCommand(sql, conn);
            cmd.CommandType = cmdType;

            SqlDataAdapter adapter = AdapterDondur(cmd);
            try
            {
                adapter.Fill(dt);
            }
            catch (SqlException ex)
            {
                ExceptionDegistirici.Degistir(ex, new LoggingInfo(cmd).ToString());
            }
            finally
            {
                if (ConnectionKapatilacakMi())
                {
                    conn.Close();
                }
            }

        }
        internal SqlDataAdapter AdapterDondur(SqlCommand cmd)
        {
            if (currentTransaction != null)
            {
                cmd.Transaction = currentTransaction;
            }
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            return adapter;
        }


        internal void SorguCalistir(DataTable dt, SqlCommand cmd)
        {
            SqlDataAdapter adapter = AdapterDondur(cmd);

            try
            {
                adapter.Fill(dt);
            }
            catch (SqlException ex)
            {
                ExceptionDegistirici.Degistir(ex, new LoggingInfo(cmd).ToString());

            }
            finally
            {
                if (ConnectionKapatilacakMi())
                {
                    conn.Close();
                }
            }

        }

        public static SqlCommand getSqlCommand(string sql, SqlConnection conn)
        {
            return new SqlCommand(sql, conn);
        }

        internal void SorguCalistir(DataTable dt, string sql, CommandType cmdType, SqlParameter[] parameters)
        {
            SqlCommand cmd = getSqlCommand(sql, conn);
            cmd.CommandType = cmdType;
            foreach (SqlParameter p in parameters)
            {
                cmd.Parameters.Add(p);
            }
            SorguCalistir(dt, cmd);


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
        public void ValidateFillArguments(DataSet dataSet, string sql, SqlParameter[] parameters)
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
        public void ValidateFillArguments(DataTable dataTable, string sql, SqlParameter[] parameters)
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

