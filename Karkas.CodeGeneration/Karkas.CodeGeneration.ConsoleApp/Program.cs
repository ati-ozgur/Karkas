﻿using System;
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

CommandLineOptions arguments;

#if(DEBUG)
    arguments = new CommandLineOptions();
    arguments.ConfigFileName = "config.json";
    arguments.ConnectionName = "ChinookSqlite";
#endif

#if(!DEBUG)
    arguments = Parser.Default.ParseArguments<CommandLineOptions>(args);
#endif


DatabaseEntry db = DatabaseService.GetByConnectionName(arguments.ConnectionName);

string homeDirectory = Environment.GetEnvironmentVariable("HOME")!;

if(db.ConnectionString.Contains("$HOME"))
{
    db.ConnectionString = db.ConnectionString.Replace("$HOME",homeDirectory);    
}
if(db.CodeGenerationDirectory.Contains("$HOME"))
{
    db.CodeGenerationDirectory = db.CodeGenerationDirectory.Replace("$HOME",homeDirectory);    
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


void generateSqliteCode(DatabaseEntry db)
{

    Console.WriteLine($"trying connection string {db.ConnectionString}");

    DbConnection connection = ConnectionHelper.TestSqlite(db.ConnectionString);
    if(connection == null)
    {
        Console.WriteLine($"error in connecting sqlite using connection string {db.ConnectionString}");
        return;
    }
    else
    {
        Console.WriteLine($"Successfully connected. Starting code generation in folder {db.CodeGenerationDirectory}");
    }


    DbProviderFactories.RegisterFactory("Microsoft.Data.Sqlite",SqliteFactory.Instance);


    IAdoTemplate<IParameterBuilder> template = new AdoTemplateSqlite();
    template.Connection = connection;



    IDatabase databaseHelper = new DatabaseSqlite(template);
    db.setIDatabaseValues(databaseHelper);


    databaseHelper.CodeGenerateAllTables();
    Console.WriteLine("Code generation finished");

}

