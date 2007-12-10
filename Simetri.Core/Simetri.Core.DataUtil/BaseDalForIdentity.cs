using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Simetri.Core.TypeLibrary;

namespace Simetri.Core.DataUtil
{
    /// <summary>
    /// T TypeLibrary Class
    /// M Type of Primary Key of T
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="M"></typeparam>
    public abstract class BaseDalForIdentity<T, M> : BaseDal<T> where T : BaseTypeLibrary,new()
    {

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
            try
            {
                Connection.Open();
                if (IdentityVarMi)
                {
                    object o = cmd.ExecuteScalar();
                    sonuc =(M) Convert.ChangeType(o, sonuc.GetType());
                }
                else
                {
                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                ExceptionDegistirici.Degistir(ex, InsertString);
            }
            finally
            {
                Connection.Close();
            }

            return sonuc;
        }




    }
}
