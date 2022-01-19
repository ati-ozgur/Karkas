using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Data.Common;

using System.Data.SQLite;
using Karkas.Core.DataUtil;

namespace Karkas.CodeGeneration.WinApp
{
    static class Program
    {



        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            string dbProviderName = "System.Data.SQLite";
            DbProviderFactories.RegisterFactory(dbProviderName, SQLiteFactory.Instance);
            ConnectionSingleton.Instance.ProviderName = dbProviderName;
            ConnectionSingleton.Instance.ConnectionString = "Data Source=connectionsDb.sqlite";



            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormMain());

        }
    }
}
