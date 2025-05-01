namespace Karkas.CodeGeneration.Helpers.PersistenceService;

public class CodeGenerationConfig
{

	public CodeGenerationConfig()
	{
		this.CreationTime = DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss");
		setTimeValues();
	}



	public void setTimeValues()
	{
		this.LastWriteTime = DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss");
		this.LastAccessTime = DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss");

	}

	public string[] getSchemaList()
	{
		return this.SchemaList.Split(",");
	}


	private bool generateNormalClassValidationExamples = false;

	public bool GenerateNormalClassValidationExamples
	{
		get { return generateNormalClassValidationExamples; }
		set { generateNormalClassValidationExamples = value; }
	}

	private bool generateNormalClassAgain = false;
	public bool GenerateNormalClassAgain
	{
		get
		{
			return generateNormalClassAgain;
		}
		set
		{
			generateNormalClassAgain = value;
		}

	}

	private string connectionName;
	private string connectionDatabaseType;
	private string connectionDbProviderName;
	private string connectionString;
	private string projectNameSpace;
	private string codeGenerationDirectory;
	private bool tableCodeGenerate;
	private bool viewCodeGenerate;
	private bool storedProcedureCodeGenerate;
	private bool sequenceCodeGenerate;
	private bool useSchemaNameInNamespaces;
	private bool useSchemaNameInSqlQueries;
	private bool useSchemaNameInFolders;
	private bool ignoreSystemTables = true;
	private string ignoredSchemaList;
	private string schemaList;

	private bool useQuotesInQueries = false;
	private string dateRegex = "";
	private string dateTimeRegex = "";

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

	private bool useMultipleDatabaseNames = false;

	public bool UseMultipleDatabaseNames
	{
		get
		{
			return useMultipleDatabaseNames;
		}

		set
		{
			useMultipleDatabaseNames = value;
		}
	}

	public bool UseQuotesInQueries { get => useQuotesInQueries; set => useQuotesInQueries = value; }

	private bool useGlobalUsings;

	public bool UseGlobalUsings { get => useGlobalUsings; set => useGlobalUsings = value; }
	private bool useFileScopedNamespace;

	public bool UseFileScopedNamespace { get => useFileScopedNamespace; set => useFileScopedNamespace = value; }
	private bool generateForeignKeyQueries = false;

	public bool GenerateForeignKeyQueries { get => generateForeignKeyQueries; set => generateForeignKeyQueries = value; }

	private bool oracleChangeNumericToLong;

	public bool OracleChangeNumericToLong { get => oracleChangeNumericToLong; set => oracleChangeNumericToLong = value; }

	public string DateRegex
	{
		get
		{
			return dateRegex;
		}
		set
		{
			dateRegex = value;
		}
	}

	public string DateTimeRegex
	{
		get
		{
			return dateTimeRegex;
		}
		set
		{
			dateTimeRegex = value;
		}
	}
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
