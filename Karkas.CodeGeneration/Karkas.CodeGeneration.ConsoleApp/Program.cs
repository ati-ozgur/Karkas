using System;

using Karkas.CodeGeneration.Helpers.PersistenceService;

string[] arguments = Environment.GetCommandLineArgs();

// foreach (var arg in arguments)
// {
//     Console.WriteLine(arg);
    
// }

if(arguments.Length != 2)
{
    string commandName = arguments[0];
    Console.WriteLine($"please use as \n {commandName} DB_NAME");
    return;
}


string connectionName = arguments[1];

DatabaseEntry db = DatabaseService.GetByConnectionName(connectionName);

System.Console.WriteLine(db);






