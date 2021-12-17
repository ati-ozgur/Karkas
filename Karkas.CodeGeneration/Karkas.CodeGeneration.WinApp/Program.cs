using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Data.Common;

using System.Data.SQLite;

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
            DbProviderFactories.RegisterFactory("System.Data.SQLite", SQLiteFactory.Instance);
       

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormMain());

        }
    }
}
