using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace Simetri.Core.DataUtil
{
    internal class PagingHelper
    {

        public PagingHelper(SqlConnection pConnection)
        {
            helper = new HelperFunctions(pConnection);
        }

        private HelperFunctions helper;

        private const string PAGING_SQL = @"
                                WITH temp AS 
                                ( 
                                {0}
                                ) 
                                SELECT * 
                                FROM temp 
                                WHERE RowNumber >= {1} AND RowNumber  < {2}
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
                sql = sql.Replace("FROM", String.Format(",ROW_NUMBER() OVER (order by {0}) as RowNumber FROM ", pOrderBy));
                sql = String.Format(PAGING_SQL, sql, pStartRowNumber, rowEnd);
            }
        }

        #endregion


    }
}
