using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Karkas.CodeGeneration.SqliteSupport.TypeLibrary.Main;
using Karkas.CodeGeneration.SqliteSupport.Dal.Main;
using Karkas.CodeGenerationHelper;

namespace Karkas.CodeGeneration.WinApp.PersistenceService
{
    public class DatabaseService
    {
        static DatabaseEntryDal dal = new DatabaseEntryDal();
        public static List<DatabaseEntry> getAllDatabaseEntriesSortedByName()
        {
            return dal.SorgulaHepsiniGetirSirali(DatabaseEntry.PropertyIsimleri.ConnectionName);
        }

        public static DatabaseEntry getLastAccessedDatabaseEntry()
        {
            List<DatabaseEntry> liste= dal.SorgulaHepsiniGetirSirali(DatabaseEntry.PropertyIsimleri.LastAccessTime,"DESC");
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
            dal.Sil(databaseEntry);
        }

        internal static void Ekle(DatabaseEntry databaseEntry)
        {
            dal.Ekle(databaseEntry);
        }

        internal static void Guncelle(DatabaseEntry databaseEntry)
        {
            dal.Guncelle(databaseEntry);
        }

        internal static void EkleVeyaGuncelle(DatabaseEntry databaseEntry)
        {
            DatabaseEntry de = dal.SorgulaConnectionNameIle(databaseEntry.ConnectionName);
            if (de != null)
            {
                Guncelle(databaseEntry);
            }
            else
            {
                Ekle(databaseEntry);
            }
        }
    }
}
