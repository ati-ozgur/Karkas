using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Karkas.Core.TypeLibrary;
using Karkas.Core.DataUtil.Exceptions;
using System.Reflection;
using System.Runtime.Remoting;
using System.Web;
using System.Data.Common;

namespace Karkas.Core.DataUtil.BaseClasses
{
    /// <summary>
    /// TL TypeLibrary Class
    /// M Type of Primary Key of TL
    /// </summary>
    /// <typeparam name="TL"></typeparam>
    public abstract class BaseDal<TL> : BaseDalWithoutEntity where TL : BaseTypeLibrary, new()
    {



        public BaseDal()
        {
        }






        private bool isInTransaction = false;

        public bool IsInTransaction
        {
            get { return isInTransaction; }
            set { isInTransaction = value; }
        }

        public DIGER_DAL_TIPI GetDalInstance<DIGER_DAL_TIPI, DIGER_TYPE_LIBRARY_TIPI>()
            where DIGER_TYPE_LIBRARY_TIPI : BaseTypeLibrary, new()
            where DIGER_DAL_TIPI : BaseDal<DIGER_TYPE_LIBRARY_TIPI>, new()
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
                object o = getNewAdoTemplate().BringOneValue(SelectCountString);
                return Convert.ToInt32(o);
            }
        }


        public virtual void Update(TL row)
        {
            ExecuteNonQueryUpdate(UpdateString, row);

            row.RowState = DataRowState.Unchanged;
        }
        public virtual void Delete(TL row)
        {
            ExecuteNonQueryDelete(DeleteString, row);
            row.RowState = DataRowState.Unchanged;
        }


        public virtual void BatchInsertUpdateDelete(List<TL> liste)
        {
            if (liste == null)
            {
                return;
            }
            foreach (TL t in liste)
            {
                InsertUpdateDeleteAccordingToState(t);
            }
        }

        public virtual void InsertUpdateDeleteAccordingToState(TL t)
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

        public virtual List<TL> QueryAll()
        {
            List<TL> liste = new List<TL>();
            ExecuteQuery(liste);
            return liste;
        }

        public virtual List<TL> QueryAll(int maxRowCount)
        {
            List<TL> liste = new List<TL>();
            ExecuteQuery(liste);
            return liste;
        }

        /// <summary>
        /// Veritabanındaki tablo üzerinde kolon ismi ile filtreleme
        /// yapararak arama yapar. Ornegin KISI tablosunda
        /// List&gtKisi&lt kisiListesi = QueryUsingColumnName(Kisi.PropertyIsimleri.Cinsiyeti,"e");
        /// Cinsiyeti e olan kisileri getirir. Cogunlukla master detay tablolarında 
        /// Foreign key ile sorgulama için kullanılır.
        /// </summary>
        /// <param name="filtre">filtre yapılacak olan kolonun ismi, 
        ///  TypeLibraryName.PropertyIsimleri.PropertyName kullanmanız tavsiye edilir.</param>
        /// <param name="oDegeri"> aranacak kolonun filtre değeri</param>
        /// <returns></returns>
        public virtual List<TL> QueryUsingColumnName(string filtre, object oDegeri)
        {
            return QueryUsingColumnName(new String[] { filtre }, new Object[] { oDegeri });
        }
        public virtual List<TL> QueryUsingColumnName(List<string> filtreListesi, List<object> degerListesi)
        {
            return QueryUsingColumnName(filtreListesi.ToArray(), degerListesi.ToArray());
        }
        public virtual List<TL> QueryUsingColumnName(string[] filtreListesi, object[] degerListesi)
        {
            List<TL> liste = new List<TL>();
            QueryHelper sy = QueryHelper;
            ParameterBuilder builder = getParameterBuilder();
            for (int i = 0; i < filtreListesi.Length; i++)
            {

                string filtre = filtreListesi[i];
                sy.AddWhereCriteria(filtre);
                builder.AddParameter(ParameterCharacter + filtre, degerListesi[i]);
            }
            ExecuteQuery(liste, sy.GetCriteriaResultsWithoutWhere(), builder.GetParameterArray());
            return liste;
        }
        /// <summary>
        /// Uses @ for sql server, any other should override this in code generation.
        /// </summary>
        public virtual string ParameterCharacter
        {
            get
            {
                return "@";
            }
        }


        public virtual QueryHelper QueryHelper
        {
            get
            {
                return new QueryHelper(this.ParameterCharacter);
            }
        }


        public virtual List<TL> QueryAllOrderBy(params string[] pSiraListesi)
        {
            List<TL> liste = new List<TL>();
            QueryHelper sy = QueryHelper;
            int listeUzunluk = pSiraListesi.Length;
            for (int i = 0; i < listeUzunluk; i++)
            {
                if (i + 1 < listeUzunluk)
                {
                    sy.AddOrderBy(pSiraListesi[i], pSiraListesi[i + 1]);
                    i++;
                }
                else
                {
                    sy.AddOrderBy(pSiraListesi[i]);
                }
            }
            // HACK Should find better solution to this;
            ExecuteQuery(liste, " 1 = 1 " + sy.GetCriteriaResultsWithoutWhere());
            return liste;
        }

        protected abstract void setIdentityColumnValue(TL pTypeLibrary, long pIdentityKolonValue);

        private long InsertIdentity(TL row)
        {
            long result = 0;
            DbCommand cmd = Template.getDatabaseCommand(InsertString, Connection);
            InsertCommandParametersAdd(cmd, row);


            row.RowState = DataRowState.Unchanged;

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
                if (IdentityExists)
                {
                    new LoggingInfo( cmd).LogInfo(this.GetType());
                    object id_degeri = cmd.ExecuteScalar();
                    result = Convert.ToInt64(id_degeri);
                    setIdentityColumnValue(row, result);
                }
                else
                {
                    cmd.ExecuteNonQuery();
                }
            }
            catch (DbException ex)
            {
                ExceptionChanger.Change(ex, new LoggingInfo( cmd).ToString());
            }
            catch (Exception ex)
            {
                new LoggingInfo( cmd).LogInfo(this.GetType(),ex);
                throw;
            }

            finally
            {
                if (ShouldCloseConnection())
                {
                    Connection.Close();
                }
            }

            return result;
        }




        public long Insert(TL row)
        {
            if (IdentityExists)
            {
                return InsertIdentity(row);
            }
            else
            {
                return InsertNormal(row);
            }
        }


        private long InsertNormal(TL row)
        {
            DbCommand cmd = Template.getDatabaseCommand(InsertString, Connection);
            InsertCommandParametersAdd(cmd, row);
            int result = ExecuteNonQueryCommandInternal(cmd);

            row.RowState = DataRowState.Unchanged;
            return result;
        }
        protected void ExecuteNonQueryUpdate(string cmdText, TL row)
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

        protected void ExecuteNonQueryDelete(string cmdText, TL row)
        {
            DbCommand cmd = Template.getDatabaseCommand(cmdText, Connection);
            DeleteCommandParametersAdd(cmd, row);
            ExecuteNonQueryCommandInternal(cmd);
        }
        public TL ExecuteQueryBringOneRow(String pFilterString)
        {
            List<TL> liste = new List<TL>();
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
        public TL ExecuteQueryBringOneRow(String pFilterString, DbParameter[] parameterArray)
        {
            List<TL> liste = new List<TL>();
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

        public void ExecuteQuery(List<TL> liste)
        {
            ExecuteQuery(liste, "");
        }
        public void ExecuteQuery(List<TL> liste, String pFilterString, DbParameter[] parameterArray)
        {
            ExecuteQuery(liste, pFilterString, parameterArray, true);
        }
        public void ExecuteQuery(List<TL> liste, String pFilterString, DbParameter[] parameterArray, bool otomatikWhereEkle)
        {
            DbCommand cmd = Template.getDatabaseCommand(Connection);
            setFilterString(pFilterString, otomatikWhereEkle, cmd);
            foreach (DbParameter prm in parameterArray)
            {
                cmd.Parameters.Add(prm);
            }
            ExecuteQueryInternal(liste, cmd);

        }

        public void ExecuteQuery(List<TL> liste, String pFilterString, bool otomatikWhereEkle)
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

        public void ExecuteQuery(List<TL> liste, String pFilterString)
        {
            ExecuteQuery(liste, pFilterString, true);
        }

        private void ExecuteQueryInternal(List<TL> liste, DbCommand cmd)
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

                TL row = default(TL);
                while (reader.Read())
                {
                    row = new TL();
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

        protected abstract void ProcessRow(IDataReader dr, TL row);
        protected abstract void InsertCommandParametersAdd(DbCommand Cmd, TL row);
        protected abstract void UpdateCommandParametersAdd(DbCommand Cmd, TL row);
        protected abstract void DeleteCommandParametersAdd(DbCommand Cmd, TL row);


        public class OrderBy
        {
            public const string Ascending = "ASC";
            public const string Descending = "DESC";
        }



    }
}

