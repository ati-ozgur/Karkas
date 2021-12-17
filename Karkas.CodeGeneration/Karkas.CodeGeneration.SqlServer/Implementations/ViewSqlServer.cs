using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Karkas.CodeGenerationHelper.Interfaces;
using Karkas.Core.DataUtil;

namespace Karkas.CodeGeneration.SqlServer.Implementations
{
    public class ViewSqlServer : IView
    {

        public ViewSqlServer(DatabaseSqlServer database, AdoTemplate template, string viewName, string schemaName)
        {
            this.database = database;
            this.template = template;
            this.viewName = viewName;
            this.schemaName = schemaName;
        }
        DatabaseSqlServer database;
        AdoTemplate template;
        string viewName;
        string schemaName;


        public string Alias
        {
            get { throw new NotImplementedException(); }
        }

        public List<IColumn> Columns
        {
            get { throw new NotImplementedException(); }
        }

        public IDatabase Database
        {
            get 
            {
                return database;
            }
        }

        public DateTime DateCreated
        {
            get { throw new NotImplementedException(); }
        }

        public DateTime DateModified
        {
            get { throw new NotImplementedException(); }
        }

        public string Description
        {
            get { throw new NotImplementedException(); }
        }

        public string Name
        {
            get 
            {
                return viewName;
            }
        }

        public string Schema
        {
            get 
            {
                return schemaName;
            }
        }
    }
}
