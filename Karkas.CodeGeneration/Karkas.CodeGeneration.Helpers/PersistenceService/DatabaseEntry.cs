using System;
using System.Data;
using System.Text;
using System.Configuration;
using System.Diagnostics;
using System.Xml.Serialization;
using System.Collections.Generic;
using Karkas.Core.TypeLibrary;
using Karkas.CodeGeneration.Helpers.Interfaces;

namespace Karkas.CodeGeneration.Helpers.PersistenceService
{
    public partial class DatabaseEntry :   ICodeGenerationNotPersistedValues
    {

        public DatabaseEntry()
        {
            this.CreationTime = DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss");
            setTimeValues();
        }

        public override string ToString()
        {
            return this.ConnectionName + "," + this.ProjectNameSpace;
        }


        public void setTimeValues()
        {
            this.LastWriteTime = DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss"); ;
            this.LastAccessTime = DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss"); ;
            
        }

        public string[] getSchemaList()
        {
            return this.SchemaList.Split(",");
        }


        public void setIDatabaseValues(IDatabase database)
        {
            database.CodeGenerationDirectory = this.CodeGenerationDirectory;
            database.ConnectionDatabaseType = this.ConnectionDatabaseType;
            database.ConnectionName = this.ConnectionName;
            database.ConnectionString = this.ConnectionString;
            database.DatabaseNameLogical = this.databaseNameLogical;
            database.DatabaseNamePhysical = this.DatabaseNamePhysical;
            database.ConnectionDbProviderName = this.ConnectionDbProviderName;
            database.IgnoredSchemaList = this.IgnoredSchemaList;
            database.IgnoreSystemTables = Convert.ToBoolean(this.IgnoreSystemTables);
            database.ProjectNameSpace = this.ProjectNameSpace;
            database.StoredProcedureCodeGenerate = Convert.ToBoolean(this.StoredProcedureCodeGenerate);
            database.UseSchemaNameInFolders = Convert.ToBoolean(this.UseSchemaNameInFolders);
            database.UseSchemaNameInSqlQueries = Convert.ToBoolean(this.useSchemaNameInSqlQueries);
            database.TableCodeGenerate = Convert.ToBoolean(this.TableCodeGenerate);
            database.ViewCodeGenerate = Convert.ToBoolean(this.ViewCodeGenerate);
            database.SequenceCodeGenerate = Convert.ToBoolean(this.SequenceCodeGenerate);
            database.CreateMainClassAgain = this.CreateMainClassAgain;
            database.CreateMainClassValidationExamples = this.CreateMainClassValidationExamples;

        }

        private bool createMainClassValidationExamples = false;

        public bool CreateMainClassValidationExamples
        {
            get { return createMainClassValidationExamples; }
            set { createMainClassValidationExamples = value; }
        }

        private bool createMainClassAgain = false;
        public bool CreateMainClassAgain
        {
            get
            {
                return createMainClassAgain;
            }
            set
            {
                createMainClassAgain = value;
            }

        }

        public override bool Equals(object obj)
        {
            // If the passed object is null
            if (obj == null)
            {
                return false;
            }
            if (!(obj is DatabaseEntry))
            {
                return false;
            }
            return (this.ConnectionName == ((DatabaseEntry)obj).ConnectionName);
        }
        public override int GetHashCode()
        {
            return ConnectionName.GetHashCode();
        }
    }
}
