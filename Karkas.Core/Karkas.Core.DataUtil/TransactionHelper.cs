using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Karkas.Core.TypeLibrary;

namespace Karkas.Core.DataUtil
{
    public class TransactionHelper
    {

        public TransactionHelper()
        {
            this.currentConnection = ConnectionSingleton.Instance.Connection;
        }

        public TransactionHelper(SqlConnection pConnection)
        {
            this.currentConnection = pConnection;
        }

	

        private SqlConnection currentConnection;

        public SqlConnection CurrentConnection
        {
            get { return currentConnection; }
        }
	

        private bool isInTransaction = false;

        public bool IsInTransaction
        {
            get { return isInTransaction; }
        }
        private SqlTransaction currentTransaction;
        public SqlTransaction CurrentTransaction
        {
            get
            {
                return currentTransaction;
            }
        }
        /// <summary>
        /// Starts a transaction and open a database connection
        /// </summary>
        public void BeginTransaction()
        {
            if (CurrentConnection.State != ConnectionState.Open)
            {
                CurrentConnection.Open();
            }
            currentTransaction = CurrentConnection.BeginTransaction();
            isInTransaction = true;
        }
        /// <summary>
        /// Commit a transaction and close database connection
        /// </summary>
        public void EndTransaction()
        {
            currentTransaction.Commit();
            isInTransaction = false;
            CurrentConnection.Close();
        }

    }
}
