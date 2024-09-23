using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Karkas.Data.Exceptions;
using System.Reflection;
using System.Runtime.Remoting;
using System.Web;
using System.Data.Common;

namespace Karkas.Data.BaseClasses
{
    /// <summary>
    /// TYPE_LIBRARY_TYPE TypeLibrary Class
    /// M Type of Primary Key of TYPE_LIBRARY_TYPE
    /// </summary>
    /// <typeparam name="TYPE_LIBRARY_TYPE"></typeparam>
    public abstract class BaseDal<TYPE_LIBRARY_TYPE, ADOTEMPLATE_DB_TYPE, PARAMETER_BUILDER> : BaseDalWithoutEntity<ADOTEMPLATE_DB_TYPE, PARAMETER_BUILDER>
            where TYPE_LIBRARY_TYPE : BaseTypeLibrary, new()
            where ADOTEMPLATE_DB_TYPE: IAdoTemplate<IParameterBuilder>, new()
            where PARAMETER_BUILDER : IParameterBuilder, new()
    {



        public BaseDal()
        {
        }







        public DIGER_DAL_TIPI GetDalInstance<DIGER_DAL_TIPI, DIGER_TYPE_LIBRARY_TIPI, DIGER_PARAMETER_BUILDER>()
            where DIGER_TYPE_LIBRARY_TIPI : BaseTypeLibrary, new()
            where DIGER_DAL_TIPI : BaseDal<DIGER_TYPE_LIBRARY_TIPI,ADOTEMPLATE_DB_TYPE, PARAMETER_BUILDER>, new()
            where DIGER_PARAMETER_BUILDER : IParameterBuilder, new()
        {
            DIGER_DAL_TIPI di = new DIGER_DAL_TIPI();
            di.Connection = Connection;
            di.IsInTransaction = IsInTransaction;
            if (IsInTransaction)
            {
                di.AutomaticConnectionManagement = false;
                di.CurrentTransaction = CurrentTransaction;
            }
            return di;
        }


        public virtual int TableRowCount
        {
            get
            {
                object o = getNewAdoTemplate().GetOneValue(SelectCountString);
                return Convert.ToInt32(o);
            }
        }


        public virtual void Update(TYPE_LIBRARY_TYPE row)
        {
            ExecuteNonQueryUpdate(UpdateString, row);

            row.RowState = DataRowState.Unchanged;
        }
        public virtual void Delete(TYPE_LIBRARY_TYPE row)
        {
            ExecuteNonQueryDelete(DeleteString, row);
            row.RowState = DataRowState.Unchanged;
        }


        public virtual void BatchInsertUpdateDelete(List<TYPE_LIBRARY_TYPE> liste)
        {
            if (liste == null)
            {
                return;
            }
            foreach (TYPE_LIBRARY_TYPE t in liste)
            {
                InsertUpdateDeleteAccordingToState(t);
            }
        }

        public virtual void InsertUpdateDeleteAccordingToState(TYPE_LIBRARY_TYPE t)
        {
            switch (t.RowState)
            {
                case DataRowState.Added:
                    Insert(t);
                    break;
                case DataRowState.Deleted:
                    Delete(t);
                    break;
                case DataRowState.Modified:
                    Update(t);
                    break;
            }
        }

        public virtual List<TYPE_LIBRARY_TYPE> QueryAll()
        {
            List<TYPE_LIBRARY_TYPE> liste = new List<TYPE_LIBRARY_TYPE>();
            ExecuteQuery(liste);
            return liste;
        }

        public virtual List<TYPE_LIBRARY_TYPE> QueryAll(int maxRowCount)
        {
            // TODO does it work with all databases, this does not seem to work with even SQL Server
            List<TYPE_LIBRARY_TYPE> liste = new List<TYPE_LIBRARY_TYPE>();
            ExecuteQuery(liste);
            return liste;
        }

        /// <summary>
        /// Query using Column Name.
        /// Example: Given Customer table
        /// CustomerDal and Customer are generated. &#60;br /&#62;
        /// List&#60;Customer&#62; l1 = QueryUsingColumnName(Kisi.ColumnNames.Email,"example@example.com")
        /// &#60;br /&#62;This will bring Customers with a given email.
        /// </summary>
        /// <param name="pFilter">ColumnName to filter.
        /// Instead of writing the column name as string like "Email", please use
        /// TypeLibraryName.ColumnNames.PropertyName </param>
        /// <param name="pValue"> value of the filter</param>
        /// <returns></returns>
        public virtual List<TYPE_LIBRARY_TYPE> QueryUsingColumnName(string pFilter, object pValue)
        {
            return QueryUsingColumnName(new String[] { pFilter }, new Object[] { pValue });
        }
        public virtual List<TYPE_LIBRARY_TYPE> QueryUsingColumnName(List<string> pFilterList, List<object> degerListesi)
        {
            return QueryUsingColumnName(pFilterList.ToArray(), degerListesi.ToArray());
        }
        public virtual List<TYPE_LIBRARY_TYPE> QueryUsingColumnName(string[] pListFilterColumnNames, object[] pListValues)
        {
            List<TYPE_LIBRARY_TYPE> liste = new List<TYPE_LIBRARY_TYPE>();
            QueryHelper sy = QueryHelper;
            IParameterBuilder builder = getParameterBuilder();
            for (int i = 0; i < pListFilterColumnNames.Length; i++)
            {

                string filtre = pListFilterColumnNames[i];
                sy.AddWhereCriteria(filtre);
                builder.AddParameter(ParameterCharacter + filtre, pListValues[i]);
            }
            ExecuteQuery(liste, sy.GetCriteriaResultsWithoutWhere(), builder.GetParameterArray());
            return liste;
        }
        public abstract string ParameterCharacter { get;  }


        public virtual QueryHelper QueryHelper
        {
            get
            {
                return new QueryHelper(this.ParameterCharacter);
            }
        }


        public virtual List<TYPE_LIBRARY_TYPE> QueryAllOrderBy(params string[] pListOrderBy)
        {
            List<TYPE_LIBRARY_TYPE> liste = new List<TYPE_LIBRARY_TYPE>();
            QueryHelper sy = QueryHelper;
            int listeUzunluk = pListOrderBy.Length;
            for (int i = 0; i < listeUzunluk; i++)
            {
                if (i + 1 < listeUzunluk)
                {
                    sy.AddOrderBy(pListOrderBy[i], pListOrderBy[i + 1]);
                    i++;
                }
                else
                {
                    sy.AddOrderBy(pListOrderBy[i]);
                }
            }
            // HACK Should find better solution to this;
            ExecuteQuery(liste, " 1 = 1 " + sy.GetCriteriaResultsWithoutWhere());
            return liste;
        }





        public long Insert(TYPE_LIBRARY_TYPE row)
        {
            return InsertNormal(row);
        }


        private long InsertNormal(TYPE_LIBRARY_TYPE row)
        {
            DbCommand cmd = Template.getDatabaseCommand(InsertString, Connection);
            InsertCommandParametersAdd(cmd, row);
            int result = ExecuteNonQueryCommandInternal(cmd);

            row.RowState = DataRowState.Unchanged;
            return result;
        }
        protected void ExecuteNonQueryUpdate(string cmdText, TYPE_LIBRARY_TYPE row)
        {
            DbCommand cmd = Template.getDatabaseCommand(cmdText, Connection);
            UpdateCommandParametersAdd(cmd, row);
            int kayitSayisi = ExecuteNonQueryCommandInternal(cmd);

            bool updateResultuBasarisiz = (kayitSayisi == 0);

            // This code will blow in BatchInsertUpdateDelete
            // Developers should write their own custom logic for this purpose

            if (updateResultuBasarisiz)
            {
                throw new UniqueKeyConstraintException("Guncellemeye calıstıgınız kayıt daha önce başkası tarafından güncellenmiştir");
            }
        }

        protected void ExecuteNonQueryDelete(string cmdText, TYPE_LIBRARY_TYPE row)
        {
            DbCommand cmd = Template.getDatabaseCommand(cmdText, Connection);
            DeleteCommandParametersAdd(cmd, row);
            ExecuteNonQueryCommandInternal(cmd);
        }
        public TYPE_LIBRARY_TYPE ExecuteQueryBringOneRow(String pFilterString)
        {
            List<TYPE_LIBRARY_TYPE> liste = new List<TYPE_LIBRARY_TYPE>();
            ExecuteQuery(liste, pFilterString);
            if (liste.Count > 0)
            {
                return liste[0];
            }
            else
            {
                return null;
            }
        }
        public TYPE_LIBRARY_TYPE ExecuteQueryBringOneRow(String pFilterString, DbParameter[] parameterArray)
        {
            List<TYPE_LIBRARY_TYPE> liste = new List<TYPE_LIBRARY_TYPE>();
            ExecuteQuery(liste, pFilterString, parameterArray);
            if (liste.Count > 0)
            {
                return liste[0];
            }
            else
            {
                return null;
            }
        }

        public void ExecuteQuery(List<TYPE_LIBRARY_TYPE> liste)
        {
            ExecuteQuery(liste, "");
        }
        public void ExecuteQuery(List<TYPE_LIBRARY_TYPE> liste, String pFilterString, DbParameter[] parameterArray)
        {
            ExecuteQuery(liste, pFilterString, parameterArray, true);
        }
        public void ExecuteQuery(List<TYPE_LIBRARY_TYPE> liste, String pFilterString, DbParameter[] parameterArray, bool otomatikWhereEkle)
        {
            DbCommand cmd = Template.getDatabaseCommand(Connection);
            setFilterString(pFilterString, otomatikWhereEkle, cmd);
            foreach (DbParameter prm in parameterArray)
            {
                cmd.Parameters.Add(prm);
            }
            ExecuteQueryInternal(liste, cmd);

        }

        public void ExecuteQuery(List<TYPE_LIBRARY_TYPE> liste, String pFilterString, bool otomatikWhereEkle)
        {
            DbCommand cmd = Template.getDatabaseCommand(Connection);
            setFilterString(pFilterString, otomatikWhereEkle, cmd);
            ExecuteQueryInternal(liste, cmd);
        }

        private void setFilterString(String pFilterString, bool otomatikWhereEkle, DbCommand cmd)
        {
            if (String.IsNullOrEmpty(pFilterString))
            {
                cmd.CommandText = SelectString;
            }
            else
            {
                if (otomatikWhereEkle)
                {
                    cmd.CommandText = String.Format("{0}  WHERE  {1}", SelectString, pFilterString);
                }
                else
                {
                    cmd.CommandText = String.Format("{0} {1}", SelectString, pFilterString);
                }
            }
        }

        public void ExecuteQuery(List<TYPE_LIBRARY_TYPE> liste, String pFilterString)
        {
            ExecuteQuery(liste, pFilterString, true);
        }

        private void ExecuteQueryInternal(List<TYPE_LIBRARY_TYPE> liste, DbCommand cmd)
        {
            DbDataReader reader = null;
            try
            {

                if (ShouldOpenConnection())
                {
                    Connection.Open();
                }
                if (CurrentTransaction != null)
                {
                    cmd.Transaction = CurrentTransaction;
                }
                reader = cmd.ExecuteReader();

                TYPE_LIBRARY_TYPE row = default(TYPE_LIBRARY_TYPE);
                while (reader.Read())
                {
                    row = new TYPE_LIBRARY_TYPE();
                    ProcessRow(reader, row);
                    row.RowState = DataRowState.Unchanged;
                    liste.Add(row);
                }

            }
            catch (DbException ex)
            {
                ExceptionChanger.Change(ex);
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
                if (ShouldCloseConnection())
                {
                    Connection.Close();
                }
            }
            return;
        }

        protected abstract string SelectString
        {
            get;
        }
        protected abstract string InsertString
        {
            get;
        }
        protected abstract string UpdateString
        {
            get;
        }
        protected abstract string DeleteString
        {
            get;
        }
        protected abstract string SelectCountString
        {
            get;
        }
        protected abstract bool IdentityExists
        {
            get;
        }

        protected abstract bool IsPkGuid
        {
            get;
        }


        public List<T1> QueryDetailTable<T1>(object degeri) where T1 : new()
        {
            T1 t = new T1();

            string typeLibrary = t.ToString();
            string dal = typeLibrary.Replace("TypeLibrary", "Dal") + "Dal";
            string assemblyName = dal.Remove(dal.IndexOf("Dal") + 3);
            Type type = Type.GetType(dal + "," + assemblyName);
            MethodInfo methodInfo = type.GetMethod("QueryUsingColumnName");
            ObjectHandle oh = Activator.CreateInstance(assemblyName, dal);

            object result = methodInfo.Invoke(oh.Unwrap(), new object[] { PrimaryKey, degeri });
            return (List<T1>)result;
        }
        public virtual string PrimaryKey
        {
            get
            {
                return "";
            }
        }

        protected abstract void ProcessRow(IDataReader dr, TYPE_LIBRARY_TYPE row);
        protected abstract void InsertCommandParametersAdd(DbCommand Cmd, TYPE_LIBRARY_TYPE row);
        protected abstract void UpdateCommandParametersAdd(DbCommand Cmd, TYPE_LIBRARY_TYPE row);
        protected abstract void DeleteCommandParametersAdd(DbCommand Cmd, TYPE_LIBRARY_TYPE row);


        public class OrderBy
        {
            public const string Ascending = "ASC";
            public const string Descending = "DESC";
        }



    }
}

