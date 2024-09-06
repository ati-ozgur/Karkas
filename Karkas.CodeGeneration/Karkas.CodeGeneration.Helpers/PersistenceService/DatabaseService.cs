using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;

using Karkas.CodeGeneration.Helpers;



namespace Karkas.CodeGeneration.Helpers.PersistenceService
{
    public class DatabaseService
    {

        static string json_filename = $"{AppDomain.CurrentDomain.BaseDirectory}/config.json";

        public static List<DatabaseEntry> getAllDatabaseEntriesSortedByName()
        {
            // TODO sort later
            return getAllDatabaseEntries();
        }

        public static List<DatabaseEntry> getAllDatabaseEntries()
        {
            string jsonString = File.ReadAllText(json_filename);
            List<DatabaseEntry> entries = new List<DatabaseEntry>();
            if (string.IsNullOrWhiteSpace(jsonString))
            {
                var example = getExampleDatabaseEntry();
                entries.Add(example);
            }
            else
            {
                entries = JsonSerializer.Deserialize<List<DatabaseEntry>>(jsonString);

            }

            return entries;
        }

        public static void SaveDatabaseEntries(List<DatabaseEntry> entries)
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string jsonString = JsonSerializer.Serialize(entries, options);
            File.WriteAllText(json_filename, jsonString, Encoding.UTF8);

        }

        public static DatabaseEntry getLastAccessedDatabaseEntry()
        {
            var list = getAllDatabaseEntries();            
            return list[0];
            //List<DatabaseEntry> liste= dal.QueryAllOrderBy(DatabaseEntry.PropertyIsimleri.LastAccessTime,"DESC");
            //return liste[0];
        }

        private static DatabaseEntry getExampleDatabaseEntry()
        {
            DatabaseEntry de = new DatabaseEntry();
            de.CodeGenerationDirectory = "$HOME\\Projects\\my-projects\\KarkasExampleSqlServer";
            de.ProjectNameSpace = "Karkas.Example";
            de.ConnectionDatabaseType = DatabaseType.SqlServer;
            de.ConnectionName = "KARKAS_EXAMPLE";
            
            de.ConnectionString = "Integrated Security = SSPI; Persist Security Info=False;Initial Catalog=KARKAS_EXAMPLE;Data Source=localhost";
            de.setTimeValues();
            return de;
        }




        internal static void deleteDatabase(DatabaseEntry databaseEntry)
        {

            var entries = getAllDatabaseEntries();
            entries.Remove(databaseEntry);
            SaveDatabaseEntries(entries);

        }



        internal static void InsertOrUpdate(DatabaseEntry databaseEntry)
        {
            var entries = getAllDatabaseEntries();
            entries.Remove(databaseEntry);
            entries.Add(databaseEntry);
            SaveDatabaseEntries(entries);
        }
    }
}
