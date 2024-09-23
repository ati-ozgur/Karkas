using System;
using System.Data;
using System.Data.Common;
using System.Drawing.Text;


using Karkas.CodeGeneration.Helpers;
using Karkas.CodeGeneration.Helpers.BaseClasses;
using Karkas.CodeGeneration.Helpers.Interfaces;
using Karkas.CodeGeneration.Helpers.PersistenceService;

using Karkas.CodeGeneration.Sqlite.Implementations;
using Karkas.CodeGeneration.SqlServer.Implementations;
using Karkas.CodeGeneration.Oracle.Implementations;


using Karkas.Data;


using CommandLine;


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

            CodeGenerationConfig db = DatabaseService.GetByConnectionName(options.ConfigFileName, options.ConnectionName);
            Console.WriteLine($"DatabaseEntry {db}");

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

            switch (db.ConnectionDatabaseType.ToLowerInvariant())
            {
                case "sqlite":
                case "sqlserver":
                case "oracle":
                    generateCode(db);
                    break;

                default:
                    Console.WriteLine($"NOT Supported yet in command line {db.ConnectionDatabaseType}");
                    break;
            }

        }


        private static void generateCode(CodeGenerationConfig codeGenerationConfig)
        {

            Console.WriteLine($"trying connection string {codeGenerationConfig.ConnectionString}");

            IAdoTemplate<IParameterBuilder> template =  ConnectionHelper.TestConnection(codeGenerationConfig.ConnectionDatabaseType, codeGenerationConfig.ConnectionString);
            if (template == null)
            {
                Console.WriteLine($"error in connecting sqlite using connection string {codeGenerationConfig.ConnectionString}");
                return;
            }
            else
            {
                Console.WriteLine($"Successfully connected. Starting code generation in folder {codeGenerationConfig.CodeGenerationDirectory}");
            }


            BaseCodeGenerationDatabase generator = null;
            switch (codeGenerationConfig.ConnectionDatabaseType)
            {
                case "sqlite":
                    generator = new CodeGenerationSqlite(template,codeGenerationConfig);
                    break;
                case "SqlServer":
                    generator = new CodeGenerationSqlServer(template,codeGenerationConfig);
                    break;
                case "Oracle":
                    generator = new CodeGenerationOracle(template,codeGenerationConfig);
                    break;

                default:
                    Console.WriteLine($"NOT Supported yet in command line {codeGenerationConfig.ConnectionDatabaseType}");
                    break;
            }
            

            string result = generator.CodeGenerateAllTables();
            Console.WriteLine("Code generation finished");
            Console.WriteLine("Errors: ");
            Console.WriteLine(result);
            if (!string.IsNullOrEmpty(result))
            {
                throw new Exception("There are errors in the code generation");
            }

        }



    }
}





