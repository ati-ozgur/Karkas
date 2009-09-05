using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Karkas.Core.TypeLibrary;
using log4net;

namespace Karkas.Core.DataUtil
{
    /// <summary>
    /// T TypeLibrary Class
    /// M Type of Primary Key of T
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="M"></typeparam>
    public abstract class BaseDalForIdentity<T, M> : BaseDal<T> where T : BaseTypeLibrary, new()
    {

        public BaseDalForIdentity()
        {

        }

        protected abstract void identityKolonDegeriniSetle(T pTypeLibrary, M pIdentityKolonValue);

        public new M Ekle(T row)
        {
            M sonuc = default(M);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = InsertString;
            cmd.Connection = Connection;
            InsertCommandParametersAdd(cmd, row);


            //rowstate'i unchanged yapiyoruz
            row.RowState = DataRowState.Unchanged;

            try
            {
                if (ConnectionAcilacakMi())
                {
                    Connection.Open();
                }
                if (CurrentTransaction != null)
                {
                    cmd.Transaction = CurrentTransaction;
                }
                if (IdentityVarMi)
                {
                    new LoggingInfo(cmd).LogInfo(this.GetType());
                    object o = cmd.ExecuteScalar();
                    sonuc = (M)Convert.ChangeType(o, sonuc.GetType());
                    identityKolonDegeriniSetle(row, sonuc);
                }
                else
                {
                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                ExceptionDegistirici.Degistir(ex, new LoggingInfo(cmd).ToString());
            }
            catch (Exception ex)
            {
                new LoggingInfo(cmd).LogInfo(this.GetType(),ex);
            }

            finally
            {
                if (ConnectionKapatilacakMi())
                {
                    Connection.Close();
                }
            }

            return sonuc;
        }




    }
}

