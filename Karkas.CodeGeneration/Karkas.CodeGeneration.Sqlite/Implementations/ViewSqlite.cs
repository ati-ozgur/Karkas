﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Karkas.Data;

using Karkas.CodeGeneration.Helpers.Interfaces;
using Karkas.CodeGeneration.Helpers.PersistenceService;


namespace Karkas.CodeGeneration.Sqlite.Implementations
{
    public class ViewSqlite : IView
    {
        public ViewSqlite(CodeGenerationSqlite database, IAdoTemplate<IParameterBuilder> template, string viewName, string schemaName)
        {
            this.database = database;
            this.template = template;
            this.viewName = viewName;
            this.schemaName = schemaName;
        }
        CodeGenerationSqlite database;
        IAdoTemplate<IParameterBuilder> template;
        string viewName;
        string schemaName;

        public CodeGenerationConfig CodeGenerationConfig
        {
            get
            {
                return database.CodeGenerationConfig;
            }
        }


        public string Alias
        {
            get { throw new NotImplementedException(); }
        }

        public List<IColumn> Columns
        {
            get { throw new NotImplementedException(); }
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
