﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Karkas.Core.DataUtil;
using Karkas.Core.DataUtil.BaseClasses;
using Karkas.Core.TypeLibrary;
using System.Data;
using System.Data.Common;

using System.Data.SQLite;

namespace Karkas.Core.Data.Sqlite
{
    public abstract class BaseDalSqlite<TYPE_LIBRARY_TYPE, ADOTEMPLATE_DB_TYPE, PARAMETER_BUILDER> :
        BaseDal<TYPE_LIBRARY_TYPE, ADOTEMPLATE_DB_TYPE, PARAMETER_BUILDER>
        where TYPE_LIBRARY_TYPE : BaseTypeLibrary, new()
        where ADOTEMPLATE_DB_TYPE : IAdoTemplate<IParameterBuilder>, new()
        where PARAMETER_BUILDER : IParameterBuilder, new()
    {

        private ADOTEMPLATE_DB_TYPE templateSqlite;
        public override ADOTEMPLATE_DB_TYPE Template
        {
            get
            {
                templateSqlite = getNewAdoTemplateSqlite();
                return templateSqlite;
            }
        }

        protected ADOTEMPLATE_DB_TYPE getNewAdoTemplateSqlite()
        {
            ADOTEMPLATE_DB_TYPE t = new ADOTEMPLATE_DB_TYPE();
            t.Connection = Connection;
            t.CurrentTransaction = CurrentTransaction;
            t.AutomaticConnectionManagement = AutomaticConnectionManagement;
            t.DbProviderName = DbProviderName;
            return t;
        }


        private SQLiteParameter  getSqlParameter()
        {
            SQLiteParameter prm = new SQLiteParameter();
            return prm;
        }
        private DbParameter setParameterValue(string parameterName, DbType dbType, object value)
        {
            SQLiteParameter prm = getSqlParameter();
            prm.ParameterName = parameterName;
            prm.DbType = dbType;

            if (value == null)
            {
                prm.Value = DBNull.Value;
            }
            else
            {
                prm.Value = value;
            }
            return prm;
        }

        public void AddParameter(string parameterName, DbType dbType, object value)
        {
            DbParameter prm = setParameterValue(parameterName, dbType, value);
            AddParameterToCommandOrList(prm);
        }

        private void AddParameterToCommandOrList(DbParameter prm)
        {
            //if (command != null)
            //{
            //    command.Parameters.Add(prm);
            //}
            //else
            //{
            //    parameterList.Add(prm);
            //}
        }

        // 
        /// <summary>
        /// https://learn.microsoft.com/en-us/dotnet/standard/data/sqlite/parameters
        /// Parameters can be prefixed with either :, @, or $.
        /// </summary>
        public override string ParameterCharacter
        {
            get
            {
                return "@";
            }
        }

    }
}
