using System;
using System.Data;
using System.Text;
using System.Configuration;
using System.Diagnostics;
using System.Xml.Serialization;
using System.Collections.Generic;
using Karkas.Core.TypeLibrary;
using System.ComponentModel.DataAnnotations;

namespace Karkas.CodeGeneration.Helpers.PersistenceService

{
	[Serializable]
	[DebuggerDisplay("ConnectionName = {ConnectionName}")]
	public partial class 	CodeGenerationConfig: BaseTypeLibrary
	{
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
		private bool useSchemaNameInSqlQueries;
		private bool useSchemaNameInFolders;
		private bool ignoreSystemTables;
		private string ignoredSchemaList;
		private string schemaList;

		private string abbrevationsAsString;
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

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public string ConnectionDatabaseType
		{
			[DebuggerStepThrough]
			get
			{
				return connectionDatabaseType;
			}
			[DebuggerStepThrough]
			set
			{
				if ((this.RowState == DataRowState.Unchanged) && (connectionDatabaseType!= value))
				{
					this.RowState = DataRowState.Modified;
				}
				connectionDatabaseType = value;
			}
		}

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public string ConnectionDbProviderName
		{
			[DebuggerStepThrough]
			get
			{
				return connectionDbProviderName;
			}
			[DebuggerStepThrough]
			set
			{
				if ((this.RowState == DataRowState.Unchanged) && (connectionDbProviderName!= value))
				{
					this.RowState = DataRowState.Modified;
				}
				connectionDbProviderName = value;
			}
		}

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public string ConnectionString
		{
			[DebuggerStepThrough]
			get
			{
				return connectionString;
			}
			[DebuggerStepThrough]
			set
			{
				if ((this.RowState == DataRowState.Unchanged) && (connectionString!= value))
				{
					this.RowState = DataRowState.Modified;
				}
				connectionString = value;
			}
		}

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public string DatabaseNamePhysical
		{
			[DebuggerStepThrough]
			get
			{
				return databaseNamePhysical;
			}
			[DebuggerStepThrough]
			set
			{
				if ((this.RowState == DataRowState.Unchanged) && (databaseNamePhysical!= value))
				{
					this.RowState = DataRowState.Modified;
				}
				databaseNamePhysical = value;
			}
		}

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public string DatabaseNameLogical
		{
			[DebuggerStepThrough]
			get
			{
				return databaseNameLogical;
			}
			[DebuggerStepThrough]
			set
			{
				if ((this.RowState == DataRowState.Unchanged) && (databaseNameLogical!= value))
				{
					this.RowState = DataRowState.Modified;
				}
				databaseNameLogical = value;
			}
		}

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public string ProjectNameSpace
		{
			[DebuggerStepThrough]
			get
			{
				return projectNameSpace;
			}
			[DebuggerStepThrough]
			set
			{
				if ((this.RowState == DataRowState.Unchanged) && (projectNameSpace!= value))
				{
					this.RowState = DataRowState.Modified;
				}
				projectNameSpace = value;
			}
		}

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public string CodeGenerationDirectory
		{
			[DebuggerStepThrough]
			get
			{
				return codeGenerationDirectory;
			}
			[DebuggerStepThrough]
			set
			{
				if ((this.RowState == DataRowState.Unchanged) && (codeGenerationDirectory!= value))
				{
					this.RowState = DataRowState.Modified;
				}
				codeGenerationDirectory = value;
			}
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public bool TableCodeGenerate
		{
			[DebuggerStepThrough]
			get
			{
				return tableCodeGenerate;
			}
			[DebuggerStepThrough]
			set
			{
				if ((this.RowState == DataRowState.Unchanged) && (viewCodeGenerate!= value))
				{
					this.RowState = DataRowState.Modified;
				}
				tableCodeGenerate = value;
			}
		}

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public bool ViewCodeGenerate
		{
			[DebuggerStepThrough]
			get
			{
				return viewCodeGenerate;
			}
			[DebuggerStepThrough]
			set
			{
				if ((this.RowState == DataRowState.Unchanged) && (viewCodeGenerate!= value))
				{
					this.RowState = DataRowState.Modified;
				}
				viewCodeGenerate = value;
			}
		}

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public bool StoredProcedureCodeGenerate
		{
			[DebuggerStepThrough]
			get
			{
				return storedProcedureCodeGenerate;
			}
			[DebuggerStepThrough]
			set
			{
				if ((this.RowState == DataRowState.Unchanged) && (storedProcedureCodeGenerate!= value))
				{
					this.RowState = DataRowState.Modified;
				}
				storedProcedureCodeGenerate = value;
			}
		}

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public bool SequenceCodeGenerate
		{
			[DebuggerStepThrough]
			get
			{
				return sequenceCodeGenerate;
			}
			[DebuggerStepThrough]
			set
			{
				if ((this.RowState == DataRowState.Unchanged) && (sequenceCodeGenerate!= value))
				{
					this.RowState = DataRowState.Modified;
				}
				sequenceCodeGenerate = value;
			}
		}

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public bool UseSchemaNameInSqlQueries
		{
			[DebuggerStepThrough]
			get
			{
				return useSchemaNameInSqlQueries;
			}
			[DebuggerStepThrough]
			set
			{
				if ((this.RowState == DataRowState.Unchanged) && (useSchemaNameInSqlQueries!= value))
				{
					this.RowState = DataRowState.Modified;
				}
				useSchemaNameInSqlQueries = value;
			}
		}

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public bool UseSchemaNameInFolders
		{
			[DebuggerStepThrough]
			get
			{
				return useSchemaNameInFolders;
			}
			[DebuggerStepThrough]
			set
			{
				if ((this.RowState == DataRowState.Unchanged) && (useSchemaNameInFolders!= value))
				{
					this.RowState = DataRowState.Modified;
				}
				useSchemaNameInFolders = value;
			}
		}

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public bool IgnoreSystemTables
		{
			[DebuggerStepThrough]
			get
			{
				return ignoreSystemTables;
			}
			[DebuggerStepThrough]
			set
			{
				if ((this.RowState == DataRowState.Unchanged) && (ignoreSystemTables!= value))
				{
					this.RowState = DataRowState.Modified;
				}
				ignoreSystemTables = value;
			}
		}

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public string IgnoredSchemaList
		{
			[DebuggerStepThrough]
			get
			{
				return ignoredSchemaList;
			}
			[DebuggerStepThrough]
			set
			{
				if ((this.RowState == DataRowState.Unchanged) && (ignoredSchemaList!= value))
				{
					this.RowState = DataRowState.Modified;
				}
				ignoredSchemaList = value;
			}
		}

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public string SchemaList
		{
			[DebuggerStepThrough]
			get
			{
				return schemaList;
			}
			[DebuggerStepThrough]
			set
			{
				if ((this.RowState == DataRowState.Unchanged) && (ignoredSchemaList != value))
				{
					this.RowState = DataRowState.Modified;
				}
				schemaList = value;
			}
		}

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public string AbbrevationsAsString
		{
			[DebuggerStepThrough]
			get
			{
				return abbrevationsAsString;
			}
			[DebuggerStepThrough]
			set
			{
				if ((this.RowState == DataRowState.Unchanged) && (abbrevationsAsString!= value))
				{
					this.RowState = DataRowState.Modified;
				}
				abbrevationsAsString = value;
			}
		}

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public string CreationTime
		{
			[DebuggerStepThrough]
			get
			{
				return creationTime;
			}
			[DebuggerStepThrough]
			set
			{
				if ((this.RowState == DataRowState.Unchanged) && (creationTime!= value))
				{
					this.RowState = DataRowState.Modified;
				}
				creationTime = value;
			}
		}

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public string LastAccessTime
		{
			[DebuggerStepThrough]
			get
			{
				return lastAccessTime;
			}
			[DebuggerStepThrough]
			set
			{
				if ((this.RowState == DataRowState.Unchanged) && (lastAccessTime!= value))
				{
					this.RowState = DataRowState.Modified;
				}
				lastAccessTime = value;
			}
		}

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public string LastWriteTime
		{
			[DebuggerStepThrough]
			get
			{
				return lastWriteTime;
			}
			[DebuggerStepThrough]
			set
			{
				if ((this.RowState == DataRowState.Unchanged) && (lastWriteTime!= value))
				{
					this.RowState = DataRowState.Modified;
				}
				lastWriteTime = value;
			}
		}

		public CodeGenerationConfig ShallowCopy()
		{
			CodeGenerationConfig obj = new CodeGenerationConfig();
			obj.connectionName = connectionName;
			obj.connectionDatabaseType = connectionDatabaseType;
			obj.connectionDbProviderName = connectionDbProviderName;
			obj.connectionString = connectionString;
			obj.databaseNamePhysical = databaseNamePhysical;
			obj.databaseNameLogical = databaseNameLogical;
			obj.projectNameSpace = projectNameSpace;
			obj.codeGenerationDirectory = codeGenerationDirectory;
			obj.viewCodeGenerate = viewCodeGenerate;
			obj.storedProcedureCodeGenerate = storedProcedureCodeGenerate;
			obj.sequenceCodeGenerate = sequenceCodeGenerate;
			obj.useSchemaNameInSqlQueries = useSchemaNameInSqlQueries;
			obj.useSchemaNameInFolders = useSchemaNameInFolders;
			obj.ignoreSystemTables = ignoreSystemTables;
			obj.ignoredSchemaList = ignoredSchemaList;
			obj.abbrevationsAsString = abbrevationsAsString;
			obj.creationTime = creationTime;
			obj.lastAccessTime = lastAccessTime;
			obj.lastWriteTime = lastWriteTime;
			return obj;
		}
		

		public class PropertyNames
		{
			public const string ConnectionName = "ConnectionName";
			public const string ConnectionDatabaseType = "ConnectionDatabaseType";
			public const string ConnectionDbProviderName = "ConnectionDbProviderName";
			public const string ConnectionString = "ConnectionString";
			public const string DatabaseNamePhysical = "DatabaseNamePhysical";
			public const string DatabaseNameLogical = "DatabaseNameLogical";
			public const string ProjectNameSpace = "ProjectNameSpace";
			public const string CodeGenerationDirectory = "CodeGenerationDirectory";
			public const string ViewCodeGenerate = "ViewCodeGenerate";
			public const string StoredProcedureCodeGenerate = "StoredProcedureCodeGenerate";
			public const string SequenceCodeGenerate = "SequenceCodeGenerate";
			public const string UseSchemaNameInSqlQueries = "UseSchemaNameInSqlQueries";
			public const string UseSchemaNameInFolders = "UseSchemaNameInFolders";
			public const string IgnoreSystemTables = "IgnoreSystemTables";
			public const string IgnoredSchemaList = "IgnoredSchemaList";
			public const string AbbrevationsAsString = "AbbrevationsAsString";
			public const string CreationTime = "CreationTime";
			public const string LastAccessTime = "LastAccessTime";
			public const string LastWriteTime = "LastWriteTime";
		}

	}
}
