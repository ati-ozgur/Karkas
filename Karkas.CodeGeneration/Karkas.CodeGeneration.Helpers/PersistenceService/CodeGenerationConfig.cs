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
    public class CodeGenerationConfig 
    {

        public CodeGenerationConfig()
        {
            this.CreationTime = DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss");
            setTimeValues();
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

		private string connectionName;
		private string connectionDatabaseType;
		private string connectionDbProviderName;
		private string connectionString;
		private string databaseNamePhysical;
		private string databaseNameLogical;
		private string projectNameSpace;
		private string codeGenerationDirectory;
		private bool tableCodeGenerate;
		private bool viewCodeGenerate;
		private bool storedProcedureCodeGenerate;
		private bool sequenceCodeGenerate;
		private bool useSchemaNameInNamespaces;
		private bool useSchemaNameInSqlQueries;
		private bool useSchemaNameInFolders;
		private bool ignoreSystemTables;
		private string ignoredSchemaList;
		private string schemaList;

		private string abbreviationsAsString;
		private string creationTime;
		private string lastAccessTime;
		private string lastWriteTime;


		public string ConnectionName
		{

			get
			{
				return connectionName;
			}

			set
			{
				connectionName = value;
			}
		}

		public string ConnectionDatabaseType
		{
			get
			{
				return connectionDatabaseType;
			}
			set
			{
				connectionDatabaseType = value;
			}
		}

		public string ConnectionDbProviderName
		{
			get
			{
				return connectionDbProviderName;
			}
			set
			{
				connectionDbProviderName = value;
			}
		}

		public string ConnectionString
		{
			get
			{
				return connectionString;
			}
			set
			{
				connectionString = value;
			}
		}

		
		public string DatabaseNamePhysical
		{
			
			get
			{
				return databaseNamePhysical;
			}
			
			set
			{
				
				databaseNamePhysical = value;
			}
		}

		
		public string DatabaseNameLogical
		{
			
			get
			{
				return databaseNameLogical;
			}
			
			set
			{
				
				databaseNameLogical = value;
			}
		}

		
		public string ProjectNameSpace
		{
			
			get
			{
				return projectNameSpace;
			}
			
			set
			{
				
				projectNameSpace = value;
			}
		}

		
		public string CodeGenerationDirectory
		{
			
			get
			{
				return codeGenerationDirectory;
			}
			
			set
			{
				
				codeGenerationDirectory = value;
			}
		}
		
		public bool TableCodeGenerate
		{
			
			get
			{
				return tableCodeGenerate;
			}
			
			set
			{
				
				tableCodeGenerate = value;
			}
		}

		
		public bool ViewCodeGenerate
		{
			
			get
			{
				return viewCodeGenerate;
			}
			
			set
			{
				
				viewCodeGenerate = value;
			}
		}

		
		public bool StoredProcedureCodeGenerate
		{
			
			get
			{
				return storedProcedureCodeGenerate;
			}
			
			set
			{
				
				storedProcedureCodeGenerate = value;
			}
		}

		
		public bool SequenceCodeGenerate
		{
			
			get
			{
				return sequenceCodeGenerate;
			}
			
			set
			{
				
				sequenceCodeGenerate = value;
			}
		}

		

        public bool UseSchemaNameInNamespaces
		{
			
			get
			{
				return useSchemaNameInNamespaces;
			}
			
			set
			{
				
				useSchemaNameInNamespaces = value;
			}
		}
        
		public bool UseSchemaNameInSqlQueries
		{
			
			get
			{
				return useSchemaNameInSqlQueries;
			}
			
			set
			{
				
				useSchemaNameInSqlQueries = value;
			}
		}

		
		public bool UseSchemaNameInFolders
		{
			
			get
			{
				return useSchemaNameInFolders;
			}
			
			set
			{
				
				useSchemaNameInFolders = value;
			}
		}

		
		public bool IgnoreSystemTables
		{
			
			get
			{
				return ignoreSystemTables;
			}
			
			set
			{
				
				ignoreSystemTables = value;
			}
		}

		
		public string IgnoredSchemaList
		{
			
			get
			{
				return ignoredSchemaList;
			}
			
			set
			{
				
				ignoredSchemaList = value;
			}
		}

		
		public string SchemaList
		{
			
			get
			{
				return schemaList;
			}
			
			set
			{
				
				schemaList = value;
			}
		}

		
		public string AbbreviationsAsString
		{
			
			get
			{
				return abbreviationsAsString;
			}
			
			set
			{
				
				abbreviationsAsString = value;
			}
		}

		
		public string CreationTime
		{
			
			get
			{
				return creationTime;
			}
			
			set
			{
				
				creationTime = value;
			}
		}

		
		public string LastAccessTime
		{
			
			get
			{
				return lastAccessTime;
			}
			
			set
			{
				
				lastAccessTime = value;
			}
		}

		
		public string LastWriteTime
		{
			
			get
			{
				return lastWriteTime;
			}
			
			set
			{
				
				lastWriteTime = value;
			}
		}


        public override int GetHashCode()
        {
            return ConnectionName.GetHashCode();
        }

        string DatabaseAbbreviations { get; set; }


        public override bool Equals(object obj)
        {
            // If the passed object is null
            if (obj == null)
            {
                return false;
            }
            if (!(obj is CodeGenerationConfig))
            {
                return false;
            }
            return (this.ConnectionName == ((CodeGenerationConfig)obj).ConnectionName);
        }


        public override string ToString()
        {
            return $"{this.ConnectionName}, {this.ConnectionDatabaseType}, {this.ConnectionString}, {this.CodeGenerationDirectory} ";
        }



    }
}
