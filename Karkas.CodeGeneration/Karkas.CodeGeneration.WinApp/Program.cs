using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Data.Common;

using Microsoft.Data.Sqlite;
using Karkas.Data;

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
            string dbProviderName = "Microsoft.Data.Sqlite";
            DbProviderFactories.RegisterFactory(dbProviderName, SqliteFactory.Instance);



            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormMain());

        }
    }
}
