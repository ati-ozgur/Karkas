using System;


using Karkas.CodeGeneration.Helpers;
using Karkas.CodeGeneration.Helpers.BaseClasses;
using Karkas.CodeGeneration.Helpers.Interfaces;
using Karkas.CodeGeneration.Helpers.PersistenceService;

using Karkas.CodeGeneration.Sqlite.Implementations;
using Karkas.CodeGeneration.SqlServer.Implementations;
using Karkas.CodeGeneration.Oracle.Implementations;


using Karkas.Data;


using CommandLine;
using System.Globalization;


namespace Karkas.CodeGeneration.ConsoleApp
{
    public class Program
    {
        /// <returns>0 on success, 1 on invalid arguments, connection failure or code generation errors</returns>
        public static int Main(string[] args)
        {


            // check launch.json for arguments
            var parsedOptions = Parser.Default.ParseArguments<CommandLineOptions>(args);
            if( parsedOptions.Value is null)
            {
                // --help and --version are not errors; missing or invalid arguments are
                return parsedOptions.Errors.IsHelp() || parsedOptions.Errors.IsVersion() ? 0 : 1;
            }
            CommandLineOptions options = parsedOptions.Value;

            Console.WriteLine($"arguments {options}");

            CodeGenerationConfig db = DatabaseService.GetByConnectionName(options.ConnectionName,options.ConfigFileName);
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
                    return generateCode(db);

                default:
                    Console.Error.WriteLine($"NOT Supported yet in command line {db.ConnectionDatabaseType}");
                    return 1;
            }

        }


        private static int generateCode(CodeGenerationConfig codeGenerationConfig)
        {

            Console.WriteLine($"trying connection string {codeGenerationConfig.ConnectionString}");

            IAdoTemplate<IParameterBuilder> template =  ConnectionHelper.TestConnection(codeGenerationConfig.ConnectionDatabaseType, codeGenerationConfig.ConnectionString);
            if (template == null)
            {
                Console.Error.WriteLine($"error in connecting {codeGenerationConfig.ConnectionDatabaseType} using connection string {codeGenerationConfig.ConnectionString}");
                return 1;
            }
            else
            {
                Console.WriteLine($"Successfully connected. Starting code generation in folder {codeGenerationConfig.CodeGenerationDirectory}");
            }


            BaseCodeGenerationDatabase generator = null;
            // case-insensitive, same as the check in Main
            switch (codeGenerationConfig.ConnectionDatabaseType.ToLowerInvariant())
            {
                case "sqlite":
                    generator = new CodeGenerationSqlite(template,codeGenerationConfig);
                    break;
                case "sqlserver":
                    generator = new CodeGenerationSqlServer(template,codeGenerationConfig);
                    break;
                case "oracle":
                    generator = new CodeGenerationOracle(template,codeGenerationConfig);
                    break;

                default:
                    Console.Error.WriteLine($"NOT Supported yet in command line {codeGenerationConfig.ConnectionDatabaseType}");
                    return 1;
            }


            string result = generator.CodeGenerateAllTables();
            Console.WriteLine("Code generation finished");
            Console.WriteLine("Errors: ");
            Console.WriteLine(result);
            if (!string.IsNullOrEmpty(result))
            {
                Console.Error.WriteLine("There are errors in the code generation");
                return 1;
            }
            return 0;

        }



    }
}





