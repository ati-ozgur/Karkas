﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;

namespace Karkas.Core.DataUtil.BaseClasses
{
    public abstract class BaseDalWithoutEntity
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
            int sonucRowSayisi = 0;
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

                sonucRowSayisi = cmd.ExecuteNonQuery();
            }
            catch (DbException ex)
            {
                if (currentTransaction != null)
                {
                    currentTransaction.Rollback();
                }
                ExceptionChanger.Degistir(ex, new LoggingInfo(cmd).ToString());
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
            return Connection.State != ConnectionState.Closed && AutomaticConnectionManagement;
        }

        protected bool ShouldOpenConnection()
        {
            return (Connection.State != ConnectionState.Open) && (AutomaticConnectionManagement);
        }



        protected ParameterBuilder getParameterBuilder()
        {
            return Template.getParameterBuilder();
        }
    }
}
