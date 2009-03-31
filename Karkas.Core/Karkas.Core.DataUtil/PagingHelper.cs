using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using Karkas.Core.Utility;

namespace Karkas.Core.DataUtil
{
    internal class PagingHelper
    {
        private Guid komutuCalistiranKullaniciKisiKey;
        /// <summary>
        /// Dal komutumuzu calistiran kisinin guid olarak key bilgisi.
        /// Login olan kullanicinin Kisi Key'ine setlenmesi gerekir.
        /// Otomatik olarak Bs tarafindan yapilacak
        /// </summary>
        public Guid KomutuCalistiranKullaniciKisiKey
        {
            get { return komutuCalistiranKullaniciKisiKey; }
            set { komutuCalistiranKullaniciKisiKey = value; }
        }


        private SqlTransaction currentTransaction;

        public SqlTransaction CurrentTransaction
        {
            get { return currentTransaction; }
            set { currentTransaction = value; }
        }

        public PagingHelper(SqlConnection pConnection, Guid pKisiKey, SqlTransaction currentTransaction)
        {
            helper = new HelperFunctions(pConnection, pKisiKey, currentTransaction);
            this.komutuCalistiranKullaniciKisiKey = pKisiKey;
        }

        private HelperFunctions helper;

        private const string PAGING_SQL = @"
                                WITH temp AS 
                                ( 
                                {0}
                                ) 
                                SELECT * 
                                FROM temp 
                                WHERE RowNumber > {1} AND RowNumber  <= {2}
                                ";

        //Where RowNumber >= @RowStart and RowNumber <= @

        #region "DataTable Doldur"
        public void DataTableDoldurSayfalamaYap(
            DataTable dataTable, string sql
            , int pPageSize, int pStartRowIndex
            , string pOrderBy, SqlParameter[] parameters)
        {
            pagingSqliniAyarla(ref sql, pPageSize, ref pStartRowIndex, pOrderBy);
            helper.ValidateFillArguments(dataTable, sql);
            helper.SorguCalistir(dataTable, sql, CommandType.Text, parameters);
        }


        internal void DataTableDoldurSayfalamaYap(DataTable dataTable, string sql
        , int pPageSize, int pStartRowIndex, string pOrderBy)
        {
            pagingSqliniAyarla(ref sql, pPageSize, ref pStartRowIndex, pOrderBy);
            helper.ValidateFillArguments(dataTable, sql);
            helper.SorguCalistir(dataTable, sql, CommandType.Text);

        }


        #endregion

        #region "DataTable Olustur"

        internal DataTable DataTableOlusturSayfalamaYap(string sql
        , int pPageSize, int pStartRowIndex, string pOrderBy)
        {
            DataTable dataTable = new DataTable();
            pagingSqliniAyarla(ref sql, pPageSize, ref pStartRowIndex, pOrderBy);
            helper.ValidateFillArguments(dataTable, sql);
            helper.SorguCalistir(dataTable, sql, CommandType.Text);
            return dataTable;
        }


        internal DataTable DataTableOlusturSayfalamaYap(string sql
, int pPageSize, int pStartRowIndex, string pOrderBy, SqlParameter[] parameters)
        {
            DataTable dataTable = new DataTable();
            pagingSqliniAyarla(ref sql, pPageSize, ref pStartRowIndex, pOrderBy);
            helper.ValidateFillArguments(dataTable, sql);
            helper.SorguCalistir(dataTable, sql, CommandType.Text, parameters);
            return dataTable;
        }

        #endregion





        #region HelperFunctions
        private static void pagingSqliniAyarla(ref string sql, int pPageSize, ref int pStartRowNumber, string pOrderBy)
        {
            if (pStartRowNumber == 0)
            {
                sql = sql.Replace("SELECT", "SELECT TOP " + pPageSize);
                sql = sql + " ORDER BY " + pOrderBy;
            }
            else
            {
                int rowEnd = pStartRowNumber + pPageSize;
                sql = sql.ReplaceLastOccurance("FROM", String.Format(",ROW_NUMBER() OVER (order by {0}) as RowNumber FROM ", pOrderBy));
                sql = String.Format(PAGING_SQL, sql, pStartRowNumber, rowEnd);
            }
        }

        #endregion


    }
}

