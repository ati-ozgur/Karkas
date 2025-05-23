using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;

using Karkas.CodeGeneration.Helpers;



namespace Karkas.CodeGeneration.Helpers.PersistenceService;

public class DatabaseService
{

	public const string CONFIG_FILENAME = "karkas-config.json";

	private static string findJsonFileNamePath(string configFileName = CONFIG_FILENAME)
	{
		string json_filename;
		string tool_install_directory = AppDomain.CurrentDomain.BaseDirectory;
		string process_start_directory = Directory.GetCurrentDirectory();

		process_start_directory += "/";

		if (Path.IsPathRooted(configFileName))
		{
			json_filename = configFileName;
			return json_filename;
		}
		json_filename = $"{process_start_directory}{configFileName}";
		if (File.Exists(json_filename))
		{
			return json_filename;
		}
		Console.WriteLine($"file {json_filename} is not found using process start directory:{process_start_directory} ");
		json_filename = $"{tool_install_directory}{configFileName}";
		if (File.Exists(json_filename))
		{
			Console.WriteLine($"file {json_filename} is found using tool install directory:{process_start_directory} ");
			return json_filename;
		}
		else
		{
			Console.WriteLine($"file {json_filename} is not found using tool install directory:{tool_install_directory} ");
		}
		throw new ArgumentException($"config filename: {configFileName} does not exits");
	}


	public static List<CodeGenerationConfig> GetAllDatabaseEntries(string configFileName = CONFIG_FILENAME)
	{
		string json_filename = findJsonFileNamePath(configFileName);
		string jsonString = File.ReadAllText(json_filename);
		List<CodeGenerationConfig> entries = new List<CodeGenerationConfig>();
		if (string.IsNullOrWhiteSpace(jsonString))
		{
			var example = getExampleDatabaseEntry();
			entries.Add(example);
		}
		else
		{
			entries = JsonSerializer.Deserialize<List<CodeGenerationConfig>>(jsonString);

		}

		return entries;
	}

	public static CodeGenerationConfig GetLastAccessedDatabaseEntry()
	{
		var entries = GetAllDatabaseEntries();
		var sortedList = entries.OrderBy(o => o.LastWriteTime).ToList();
		return sortedList[sortedList.Count -1];
	}

	public static void SaveDatabaseEntries(List<CodeGenerationConfig> entries, string configFileName = CONFIG_FILENAME)
	{
		var options = new JsonSerializerOptions { WriteIndented = true };
		string jsonString = JsonSerializer.Serialize(entries, options);
		File.WriteAllText(configFileName, jsonString, Encoding.UTF8);

	}


	public static CodeGenerationConfig GetByConnectionName(string connectionName, string configFileName = CONFIG_FILENAME)
	{
		var liste = GetAllDatabaseEntries(configFileName);
		foreach (var e in liste)
		{
			if (e.ConnectionName == connectionName)
			{
				return e;
			}

		}
		throw new Exception($"connection {connectionName} is not found");
	}



	private static CodeGenerationConfig getExampleDatabaseEntry()
	{
		CodeGenerationConfig de = new CodeGenerationConfig();
		de.CodeGenerationDirectory = "$HOME\\Projects\\my-projects\\KarkasExampleSqlServer";
		de.ProjectNameSpace = "Karkas.Example";
		de.ConnectionDatabaseType = DatabaseType.SqlServer;
		de.ConnectionName = "KARKAS_EXAMPLE";

		de.ConnectionString = "Integrated Security = SSPI; Persist Security Info=False;Initial Catalog=KARKAS_EXAMPLE;Data Source=localhost";
		de.setTimeValues();
		return de;
	}




	public static void DeleteDatabase(CodeGenerationConfig databaseEntry, string configFileName = CONFIG_FILENAME)
	{

		var entries = GetAllDatabaseEntries(configFileName);
		entries.Remove(databaseEntry);
		SaveDatabaseEntries(entries, configFileName);

	}



	public static void InsertOrUpdate(CodeGenerationConfig databaseEntry, string configFileName = CONFIG_FILENAME)
	{
		var entries = GetAllDatabaseEntries(configFileName);
		entries.Remove(databaseEntry);
		entries.Add(databaseEntry);
		SaveDatabaseEntries(entries, configFileName);
	}


}
