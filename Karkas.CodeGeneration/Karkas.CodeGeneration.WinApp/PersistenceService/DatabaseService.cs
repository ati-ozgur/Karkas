using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;

using Karkas.CodeGeneration.SqliteSupport.TypeLibrary.Main;
using Karkas.CodeGeneration.SqliteSupport.Dal.Main;
using Karkas.CodeGenerationHelper;



namespace Karkas.CodeGeneration.WinApp.PersistenceService
{
    public class DatabaseService
    {
        const string json_filename = "config.json";
        static DatabaseEntryDal dal = new DatabaseEntryDal();
        public static List<DatabaseEntry> getAllDatabaseEntriesSortedByName()
        {
            string jsonString = File.ReadAllText(json_filename);
            List<DatabaseEntry> entries = new List<DatabaseEntry>();
            if (!string.IsNullOrWhiteSpace(jsonString))
            {
                entries = JsonSerializer.Deserialize<List<DatabaseEntry>>(jsonString);
            }

            return entries;
        }

        public static DatabaseEntry getLastAccessedDatabaseEntry()
        {
            List<DatabaseEntry> liste= dal.QueryAllOrderBy(DatabaseEntry.PropertyIsimleri.LastAccessTime,"DESC");
            return liste[0];
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
            dal.Delete(databaseEntry);
        }

        internal static void Insert(DatabaseEntry databaseEntry)
        {
            dal.Insert(databaseEntry);
        }

        internal static void Update(DatabaseEntry databaseEntry)
        {
            dal.Update(databaseEntry);
        }

        internal static void InsertOrUpdate(DatabaseEntry databaseEntry)
        {
            DatabaseEntry de = dal.SorgulaConnectionNameIle(databaseEntry.ConnectionName);
            if (de != null)
            {
                Update(databaseEntry);
            }
            else
            {
                Insert(databaseEntry);
            }
        }
    }
}
