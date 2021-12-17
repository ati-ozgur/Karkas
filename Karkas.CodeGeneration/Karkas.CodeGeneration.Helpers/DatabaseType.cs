using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karkas.CodeGenerationHelper
{
    public class DatabaseType
    {

        static DatabaseType()
        {
            databaseTypeList.Add(SqlServer);
            databaseTypeList.Add(Oracle);
            databaseTypeList.Add(Sqlite);

        }

        private static List<String> databaseTypeList = new List<String>();

        public static List<String> DatabaseTypeList
        {
            get { return DatabaseType.databaseTypeList; }
        }

        public const string SqlServer = "SqlServer";
        public const string Oracle = "Oracle";
        public const string Sqlite = "Sqlite";


    }
}


        