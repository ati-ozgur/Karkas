﻿using Karkas.Core.DataUtil;
using Karkas.Core.DataUtil.BaseClasses;
using Karkas.Core.TypeLibrary;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Data.Common;

namespace Karkas.Core.Data.SqlServer
{
    public abstract class BaseDalSqlServer<TYPE_LIBRARY_TYPE, ADOTEMPLATE_DB_TYPE> : 
        BaseDal<TYPE_LIBRARY_TYPE, ADOTEMPLATE_DB_TYPE>
        where TYPE_LIBRARY_TYPE : BaseTypeLibrary, new ()
        where ADOTEMPLATE_DB_TYPE : IAdoTemplate, new()
    {

        private ADOTEMPLATE_DB_TYPE templateSqlServer;
        public override ADOTEMPLATE_DB_TYPE Template
        {
            get
            {
                templateSqlServer = getNewAdoTemplateSqlServer();
                return templateSqlServer;
            }
        }

        protected ADOTEMPLATE_DB_TYPE getNewAdoTemplateSqlServer()
        {
            ADOTEMPLATE_DB_TYPE t = new ADOTEMPLATE_DB_TYPE();
            t.Connection = Connection;
            t.CurrentTransaction = CurrentTransaction;
            t.AutomaticConnectionManagement = AutomaticConnectionManagement;
            t.DbProviderName = DbProviderName;
            return t;
        }


        private SqlParameter getSqlParameter()
        {
            SqlParameter prm = new SqlParameter();
            return prm;
        }
        private DbParameter setParameterValue(string parameterName, SqlDbType dbType, object value)
        {
            SqlParameter prm = getSqlParameter();
            prm.ParameterName = parameterName;
            prm.SqlDbType = dbType;
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

        public void AddParameter(string parameterName, SqlDbType dbType, object value)
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


    }
}