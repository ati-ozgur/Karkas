using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using log4net;
using System.Data;

namespace Karkas.Core.DataUtil
{
    public abstract class BaseDalWithoutEntity
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
                this.Template.OtomatikConnectionYonetimi = value;
            }
        }



        private AdoTemplate template;
        public AdoTemplate Template
        {
            get
            {
                template = getNewAdoTemplate();
                return template;
            }
        }

        protected AdoTemplate getNewAdoTemplate()
        {
            AdoTemplate t = new AdoTemplate();
            t.Connection = Connection;
            t.CurrentTransaction = currentTransaction;
            t.OtomatikConnectionYonetimi = otomatikConnectionYonetimi;
            return t;
        }


        public virtual string DatabaseName
        {
            get
            {
                return "";
            }
        }
        private SqlConnection connection = null;

        public SqlConnection Connection
        {
            get
            {
                if (connection == null)
                {
                    if (string.IsNullOrEmpty(DatabaseName))
                    {
                        connection = ConnectionSingleton.Instance.Connection;
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


        private SqlTransaction currentTransaction;

        public SqlTransaction CurrentTransaction
        {
            get { return currentTransaction; }
            set { currentTransaction = value; }
        }

        protected int SorguHariciKomutCalistirInternal(SqlCommand cmd)
        {
            int sonucRowSayisi = 0;
            try
            {
                if (ConnectionAcilacakMi())
                {
                    Connection.Open();
                }
                else if (currentTransaction != null)
                {
                    cmd.Transaction = currentTransaction;
                }
                new LoggingInfo( cmd).LogInfo(this.GetType());

                sonucRowSayisi = cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                if (currentTransaction != null)
                {
                    currentTransaction.Rollback();
                }
                ExceptionDegistirici.Degistir(ex, new LoggingInfo(cmd).ToString());
            }
            finally
            {
                if (ConnectionKapatilacakMi())
                {
                    Connection.Close();
                }
            }
            return sonucRowSayisi;
        }

        protected bool ConnectionKapatilacakMi()
        {
            return Connection.State != ConnectionState.Closed && OtomatikConnectionYonetimi;
        }

        protected bool ConnectionAcilacakMi()
        {
            return (Connection.State != ConnectionState.Open) && (OtomatikConnectionYonetimi);
        }

    }
}
