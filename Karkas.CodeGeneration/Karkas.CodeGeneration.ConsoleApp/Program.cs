using Karkas.CodeGeneration.Helpers.PersistenceService;

string connectionName = "EXAMPLE_SQLITE";


DatabaseEntry db = DatabaseService.GetByConnectionName("EXAMPLE_SQLITE");

System.Console.WriteLine(db);