using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;

using Karkas.CodeGenerationHelper;



namespace Karkas.CodeGeneration.WinApp.PersistenceService
{
    public class DatabaseService
    {
        const string json_filename = "config.json";

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
            de.CodeGenerationDirectory = "P:\\karkas\\Karkas.Ornek";
            de.ProjectNameSpace = "Karkas.Ornek";
            de.ConnectionDatabaseType = DatabaseType.SqlServer;
            de.ConnectionName = "KARKAS_ORNEK";
            
            de.ConnectionString = "Integrated Security = SSPI; Persist Security Info=False;Initial Catalog=KARKAS_ORNEK;Data Source=localhost";
            de.setTimeValues();
            return de;
        }




        internal static void deleteDatabase(DatabaseEntry databaseEntry)
        {
            throw new NotImplementedException();

        }

        internal static void Insert(DatabaseEntry databaseEntry)
        {
            var entries = getAllDatabaseEntries();
            entries.Add(databaseEntry);

            throw new NotImplementedException();

        }

        internal static void Update(DatabaseEntry databaseEntry)
        {
            throw new NotImplementedException();

        }

        internal static void InsertOrUpdate(DatabaseEntry databaseEntry)
        {
            throw new NotImplementedException();

            //DatabaseEntry de = dal.SorgulaConnectionNameIle(databaseEntry.ConnectionName);
            //if (de != null)
            //{
            //    Update(databaseEntry);
            //}
            //else
            //{
            //    Insert(databaseEntry);
            //}
        }
    }
}
