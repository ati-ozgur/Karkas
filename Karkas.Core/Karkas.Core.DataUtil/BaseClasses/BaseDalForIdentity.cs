﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Karkas.Core.TypeLibrary;
using System.Data.Common;

namespace Karkas.Core.DataUtil.BaseClasses
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

        public new M Insert(T row)
        {
            M sonuc = default(M);
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
                if (IdentityExists)
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
            catch (DbException ex)
            {
                ExceptionChanger.Degistir(ex, new LoggingInfo(cmd).ToString());
            }
            catch (Exception ex)
            {
                new LoggingInfo(cmd).LogInfo(this.GetType(),ex);
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




    }
}

