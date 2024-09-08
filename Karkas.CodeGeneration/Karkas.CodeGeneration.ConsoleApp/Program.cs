using System;
using System.Data;
using System.Data.Common;
using System.Drawing.Text;
using Karkas.CodeGeneration.Helpers;
using Karkas.CodeGeneration.Helpers.Interfaces;
using Karkas.CodeGeneration.Helpers.PersistenceService;
using Karkas.CodeGeneration.Sqlite.Implementations;
using Karkas.Core.Data.Sqlite;
using Karkas.Core.DataUtil;

using Microsoft.Data.Sqlite;
using CommandLine;

using System.IO;

namespace Karkas.CodeGeneration.ConsoleApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // check launch.json for arguments
            var parsedOptions = Parser.Default.ParseArguments<CommandLineOptions>(args);
            if( parsedOptions.Value is null)
            {
                return;
            }
            CommandLineOptions options = parsedOptions.Value;

            Console.WriteLine($"arguments {options}");

            DatabaseEntry db = DatabaseService.GetByConnectionName(options.ConfigFileName, options.ConnectionName);

            string homeDirectory = Environment.GetEnvironmentVariable("HOME")!;

            if (db.ConnectionString.Contains("$HOME"))
            {
                db.ConnectionString = db.ConnectionString.Replace("$HOME", homeDirectory);
            }
            if (db.CodeGenerationDirectory.Contains("$HOME"))
            {
                db.CodeGenerationDirectory = db.CodeGenerationDirectory.Replace("$HOME", homeDirectory);
            }

            Console.WriteLine(db.ConnectionDatabaseType);

            switch (db.ConnectionDatabaseType)
            {
                case "sqlite":
                    generateSqliteCode(db);
                    break;
                default:
                    Console.WriteLine($"NOT Supported yet in commandline {db.ConnectionDatabaseType}");
                    break;
            }

        }


        private static void generateSqliteCode(DatabaseEntry db)
        {

            Console.WriteLine($"trying connection string {db.ConnectionString}");

            DbConnection connection = ConnectionHelper.TestSqlite(db.ConnectionString);
            if (connection == null)
            {
                Console.WriteLine($"error in connecting sqlite using connection string {db.ConnectionString}");
                return;
            }
            else
            {
                Console.WriteLine($"Successfully connected. Starting code generation in folder {db.CodeGenerationDirectory}");
            }


            DbProviderFactories.RegisterFactory("Microsoft.Data.Sqlite", SqliteFactory.Instance);


            IAdoTemplate<IParameterBuilder> template = new AdoTemplateSqlite();
            template.Connection = connection;



            IDatabase databaseHelper = new DatabaseSqlite(template);
            db.setIDatabaseValues(databaseHelper);


            databaseHelper.CodeGenerateAllTables();
            Console.WriteLine("Code generation finished");

        }


    }
}





