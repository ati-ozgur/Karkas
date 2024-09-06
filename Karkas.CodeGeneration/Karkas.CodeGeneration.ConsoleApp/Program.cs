using System;
using Karkas.CodeGeneration.Helpers;
using Karkas.CodeGeneration.Helpers.PersistenceService;

string[] arguments = Environment.GetCommandLineArgs();

// foreach (var arg in arguments)
// {
//     Console.WriteLine(arg);
    
// }

#if(DEBUG)
    arguments = new string[2]{arguments[0],"Chinook"};
#endif


if(arguments.Length != 2)
{
    string commandName = arguments[0];
    Console.WriteLine($"please use as \n {commandName} DB_NAME");
    return;
}


string connectionName = arguments[1];

DatabaseEntry db = DatabaseService.GetByConnectionName(connectionName);

string homeDirectory = Environment.GetEnvironmentVariable("HOME");

if(db.ConnectionString.Contains("$HOME"))
{
    db.ConnectionString = db.ConnectionString.Replace("$HOME",homeDirectory);    
}
if(db.CodeGenerationDirectory.Contains("$HOME"))
{
    db.CodeGenerationDirectory = db.CodeGenerationDirectory.Replace("$HOME",homeDirectory);    
}


Console.WriteLine(db);

Console.WriteLine($"trying connection string {db.ConnectionString}");

ConnectionHelper.TestSqlite(db.ConnectionString);




