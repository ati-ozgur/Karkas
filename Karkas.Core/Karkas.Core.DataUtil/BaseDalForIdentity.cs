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
        private static ILog logger = LogManager.GetLogger("Dal");

        public BaseDalForIdentity()
        {

        }



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
                Connection.Open();
                if (IdentityVarMi)
                {
                    logger.Info(new LoggingInfo(KomutuCalistiranKullaniciKisiKey, cmd));
                    object o = cmd.ExecuteScalar();
                    sonuc = (M)Convert.ChangeType(o, sonuc.GetType());
                }
                else
                {
                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                ExceptionDegistirici.Degistir(ex, new LoggingInfo(KomutuCalistiranKullaniciKisiKey, cmd).ToString());
            }
            finally
            {
                Connection.Close();
            }

            return sonuc;
        }




    }
}
