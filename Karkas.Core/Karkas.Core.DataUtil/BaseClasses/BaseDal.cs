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
    /// T TypeLibrary Class
    /// M Type of Primary Key of T
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class BaseDal<T> : BaseDalWithoutEntity where T : BaseTypeLibrary, new()
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
                object o = getNewAdoTemplate().TekDegerGetir(SelectCountString);
                return Convert.ToInt32(o);
            }
        }


        public virtual void Update(T row)
        {
            ExecuteNonQueryUpdate(UpdateString, row);

            //rowstate'i unchanged yapiyoruz
            row.RowState = DataRowState.Unchanged;
        }
        public virtual void Delete(T row)
        {
            ExecuteNonQueryDelete(DeleteString, row);
            //rowstate'i unchanged yapiyoruz
            row.RowState = DataRowState.Unchanged;
        }


        public virtual void BatchInsertUpdateDelete(List<T> liste)
        {
            if (liste == null)
            {
                return;
            }
            foreach (T t in liste)
            {
                DurumaGoreEkleGuncelleVeyaSil(t);
            }
        }

        public virtual void DurumaGoreEkleGuncelleVeyaSil(T t)
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

        public virtual List<T> SorgulaHepsiniGetir()
        {
            List<T> liste = new List<T>();
            ExecuteQuery(liste);
            return liste;
        }

        public virtual List<T> SorgulaHepsiniGetir(int maxRowCount)
        {
            List<T> liste = new List<T>();
            ExecuteQuery(liste);
            return liste;
        }

        /// <summary>
        /// Veritabanındaki tablo üzerinde kolon ismi ile filtreleme
        /// yapararak arama yapar. Ornegin KISI tablosunda
        /// List&gtKisi&lt kisiListesi = SorgulaKolonIsmiIle(Kisi.PropertyIsimleri.Cinsiyeti,"e");
        /// Cinsiyeti e olan kisileri getirir. Cogunlukla master detay tablolarında 
        /// Foreign key ile sorgulama için kullanılır.
        /// </summary>
        /// <param name="filtre">filtre yapılacak olan kolonun ismi, 
        ///  TypeLibraryName.PropertyIsimleri.PropertyName kullanmanız tavsiye edilir.</param>
        /// <param name="oDegeri"> aranacak kolonun filtre değeri</param>
        /// <returns></returns>
        public virtual List<T> SorgulaKolonIsmiIle(string filtre, object oDegeri)
        {
            return SorgulaKolonIsmiIle(new String[] { filtre }, new Object[] { oDegeri });
        }
        public virtual List<T> SorgulaKolonIsmiIle(List<string> filtreListesi, List<object> degerListesi)
        {
            return SorgulaKolonIsmiIle(filtreListesi.ToArray(), degerListesi.ToArray());
        }
        public virtual List<T> SorgulaKolonIsmiIle(string[] filtreListesi, object[] degerListesi)
        {
            List<T> liste = new List<T>();
            QueryHelper sy = SorguYardimcisi;
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


        public virtual QueryHelper SorguYardimcisi
        {
            get
            {
                return new QueryHelper(this.ParameterCharacter);
            }
        }


        public virtual List<T> SorgulaHepsiniGetirSirali(params string[] pSiraListesi)
        {
            List<T> liste = new List<T>();
            QueryHelper sy = SorguYardimcisi;
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
            // HACK buna daha duzgun bir cozum lazim;
            ExecuteQuery(liste, " 1 = 1 " + sy.GetCriteriaResultsWithoutWhere());
            return liste;
        }

        protected abstract void identityKolonDegeriniSetle(T pTypeLibrary, long pIdentityKolonValue);

        private long InsertIdentity(T row)
        {
            long sonuc = 0;
            DbCommand cmd = Template.getDatabaseCommand(InsertString, Connection);
            InsertCommandParametersAdd(cmd, row);


            //rowstate'i unchanged yapiyoruz
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
                if (IdentityVarMi)
                {
                    new LoggingInfo( cmd).LogInfo(this.GetType());
                    object id_degeri = cmd.ExecuteScalar();
                    sonuc = Convert.ToInt64(id_degeri);
                    identityKolonDegeriniSetle(row, sonuc);
                }
                else
                {
                    cmd.ExecuteNonQuery();
                }
            }
            catch (DbException ex)
            {
                ExceptionChanger.Degistir(ex, new LoggingInfo( cmd).ToString());
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

            return sonuc;
        }




        public long Insert(T row)
        {
            if (IdentityVarMi)
            {
                return InsertIdentity(row);
            }
            else
            {
                return InsertNormal(row);
            }
        }


        private long InsertNormal(T row)
        {
            DbCommand cmd = Template.getDatabaseCommand(InsertString, Connection);
            InsertCommandParametersAdd(cmd, row);
            int sonuc = ExecuteNonQueryCommandInternal(cmd);

            //rowstate'i unchanged yapiyoruz
            row.RowState = DataRowState.Unchanged;
            return sonuc;
        }
        protected void ExecuteNonQueryUpdate(string cmdText, T row)
        {
            DbCommand cmd = Template.getDatabaseCommand(cmdText, Connection);
            UpdateCommandParametersAdd(cmd, row);
            int kayitSayisi = ExecuteNonQueryCommandInternal(cmd);

            bool updateSonucuBasarisiz = (kayitSayisi == 0);
            // Bu kod TopluEkleGuncelle icinde patlamaya yol acacak,
            // bunu kabul ederek birakiyoruz. Bu tur durumlar icin
            // gerekirse yazilimci kendisi kod yazsin.

            if (updateSonucuBasarisiz)
            {
                throw new UniqueKeyConstraintException("Guncellemeye calıstıgınız kayıt daha önce başkası tarafından güncellenmiştir");
            }
        }

        protected void ExecuteNonQueryDelete(string cmdText, T row)
        {
            DbCommand cmd = Template.getDatabaseCommand(cmdText, Connection);
            DeleteCommandParametersAdd(cmd, row);
            ExecuteNonQueryCommandInternal(cmd);
        }
        public T ExecuteQueryBringOneRow(String pFilterString)
        {
            List<T> liste = new List<T>();
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
        public T ExecuteQueryBringOneRow(String pFilterString, DbParameter[] parameterArray)
        {
            List<T> liste = new List<T>();
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

        public void ExecuteQuery(List<T> liste)
        {
            ExecuteQuery(liste, "");
        }
        public void ExecuteQuery(List<T> liste, String pFilterString, DbParameter[] parameterArray)
        {
            ExecuteQuery(liste, pFilterString, parameterArray, true);
        }
        public void ExecuteQuery(List<T> liste, String pFilterString, DbParameter[] parameterArray, bool otomatikWhereEkle)
        {
            DbCommand cmd = Template.getDatabaseCommand(Connection);
            filtreStringiniSetle(pFilterString, otomatikWhereEkle, cmd);
            foreach (DbParameter prm in parameterArray)
            {
                cmd.Parameters.Add(prm);
            }
            ExecuteQueryInternal(liste, cmd);

        }

        public void ExecuteQuery(List<T> liste, String pFilterString, bool otomatikWhereEkle)
        {
            DbCommand cmd = Template.getDatabaseCommand(Connection);
            filtreStringiniSetle(pFilterString, otomatikWhereEkle, cmd);
            ExecuteQueryInternal(liste, cmd);
        }

        private void filtreStringiniSetle(String pFilterString, bool otomatikWhereEkle, DbCommand cmd)
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

        public void ExecuteQuery(List<T> liste, String pFilterString)
        {
            ExecuteQuery(liste, pFilterString, true);
        }

        private void ExecuteQueryInternal(List<T> liste, DbCommand cmd)
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

                T row = default(T);
                while (reader.Read())
                {
                    row = new T();
                    ProcessRow(reader, row);
                    row.RowState = DataRowState.Unchanged;
                    liste.Add(row);
                }

            }
            catch (DbException ex)
            {
                ExceptionChanger.Degistir(ex);
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
        protected abstract bool IdentityVarMi
        {
            get;
        }

        protected abstract bool PkGuidMi
        {
            get;
        }


        public List<T1> SorgulaDetayTabloGetir<T1>(object degeri) where T1 : new()
        {
            T1 t = new T1();

            string typeLibrary = t.ToString();
            string dal = typeLibrary.Replace("TypeLibrary", "Dal") + "Dal";
            string assemblyName = dal.Remove(dal.IndexOf("Dal") + 3);
            Type type = Type.GetType(dal + "," + assemblyName);
            MethodInfo methodInfo = type.GetMethod("SorgulaKolonIsmiIle");
            ObjectHandle oh = Activator.CreateInstance(assemblyName, dal);

            object sonuc = methodInfo.Invoke(oh.Unwrap(), new object[] { PrimaryKey, degeri });
            return (List<T1>)sonuc;
        }
        public virtual string PrimaryKey
        {
            get
            {
                return "";
            }
        }

        protected abstract void ProcessRow(IDataReader dr, T row);
        protected abstract void InsertCommandParametersAdd(DbCommand Cmd, T row);
        protected abstract void UpdateCommandParametersAdd(DbCommand Cmd, T row);
        protected abstract void DeleteCommandParametersAdd(DbCommand Cmd, T row);


        public class Siralama
        {
            public const string Azalarak = "DESC";
            public const string Artarak = "ASC";
            public const string Ascending = "ASC";
            public const string Descending = "DESC";
        }



    }
}

