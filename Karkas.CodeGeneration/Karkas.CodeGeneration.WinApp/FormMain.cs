﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using Karkas.Core.DataUtil;
using Karkas.CodeGeneration.SqlServer;
using System.Reflection;
using System.Data.Common;
using System.Runtime.Remoting;
using Karkas.CodeGenerationHelper;
using Karkas.CodeGeneration.Oracle;
using Karkas.CodeGenerationHelper.Interfaces;
using Karkas.CodeGeneration.WinApp.PersistenceService;
using Karkas.CodeGeneration.SqliteSupport.TypeLibrary.Main;
using Karkas.CodeGeneration.Sqlite;
using Karkas.CodeGeneration.Oracle.Implementations;
using Karkas.CodeGeneration.Sqlite.Implementations;
using Karkas.CodeGeneration.SqlServer.Implementations;

namespace Karkas.CodeGeneration.WinApp
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
            userControlCodeGenerationOptions1.getLastAccessedConnectionToTextbox();
        }


        DbConnection connection;
        AdoTemplate template;
        private IDatabase databaseHelper;

        public IDatabase DatabaseHelper
        {
            get
            {
                CurrentDatabaseEntry.setIDatabaseValues(databaseHelper);
                return databaseHelper;
            }
            set
            {
                databaseHelper = value;
                CurrentDatabaseEntry.setIDatabaseValues(databaseHelper);
            }
        }



        DatabaseEntry entry;
        private DatabaseEntry CurrentDatabaseEntry
        {
            get
            {
                entry = userControlCodeGenerationOptions1.getDatabaseEntry();
                return entry;

            }
        }
        
        
        private void buttonTestConnectionString_Click(object sender, EventArgs e)
        {
            string type = userControlCodeGenerationOptions1.SelectedDatabaseType;
            string connectionString = userControlCodeGenerationOptions1.ConnectionString;
            string connectionName =userControlCodeGenerationOptions1.ConnectionName;
            string ConnectionDbProviderName = userControlCodeGenerationOptions1.ConnectionDbProviderName;

            userControlTableRelated1.setComboBoxSchemaListText("");
            
            try
            {
                if (connection != null && connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
                if (type == null || type == DatabaseType.SqlServer)
                {
                    testSqlServer(connectionString, connectionName);
                }
                else if (type == DatabaseType.Oracle)
                {

                    testOracle(connectionString, connectionName, ConnectionDbProviderName);

                }
                else if (type == DatabaseType.Sqlite)
                {
                    testSqlite(connectionString);

                }

                labelConnectionStatus.Text = "Bağlantı Başarılı";
                BilgileriDoldur();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                labelConnectionStatus.ForeColor = Color.Red;
                labelConnectionStatus.Text = "!!!!Bağlantı BAŞARISIZ!!!!";
            }

        }


        private void testOracle(string connectionString,string databaseName, string ConnectionDbProviderName)
        {
            if (ConnectionDbProviderName == null)
            {
                throw new Exception("Please set the Connection DB Provider name");
            }
            string dllName = ConnectionDbProviderName.Replace(".Client", "");
            //Assembly oracleAssembly = Assembly.LoadWithPartialName(ConnectionDbProviderName);
            Assembly oracleAssembly = Assembly.LoadWithPartialName(dllName);
            string connectionClassName = ConnectionDbProviderName + ".OracleConnection";
            string factoryClassName = ConnectionDbProviderName + ".OracleClientFactory";
            Object objReflectionConnection = Activator.CreateInstance(oracleAssembly.FullName, connectionClassName);
            Object objReflectionFactory = Activator.CreateInstance(oracleAssembly.FullName, factoryClassName);

            if (objReflectionConnection != null
                && objReflectionConnection is ObjectHandle
                && objReflectionFactory != null
                && objReflectionFactory is ObjectHandle
                )
            {
                ObjectHandle handleConnection = (ObjectHandle)objReflectionConnection;
                Object objConnection = handleConnection.Unwrap();
                connection = (DbConnection)objConnection;

                ObjectHandle handleFactory = (ObjectHandle)objReflectionFactory;
                Object objFactory = handleFactory.Unwrap();
                DbProviderFactory factory = (DbProviderFactory)objFactory;

                //Object objFactory = 

                connection.ConnectionString = connectionString;
                connection.Open();
                connection.Close();
                template = new AdoTemplate();
                template.Connection = connection;
                template.DbProviderName = ConnectionDbProviderName;
                DatabaseHelper = new DatabaseOracle( template);
                DbProviderFactories.RegisterFactory(ConnectionDbProviderName, factory);



            }
        }

        private void testSqlite(string connectionString)
        {
            Assembly assembly = Assembly.LoadWithPartialName("System.Data.SQLite");
            Object objReflection = Activator.CreateInstance(assembly.FullName, "System.Data.SQLite.SQLiteConnection");

            if (objReflection != null && objReflection is ObjectHandle)
            {
                ObjectHandle handle = (ObjectHandle)objReflection;

                Object objConnection = handle.Unwrap();
                connection = (DbConnection)objConnection;
                connection.ConnectionString = connectionString;
                connection.Open();
                connection.Close();
                template = new AdoTemplate();
                template.Connection = connection;
                template.DbProviderName = "System.Data.SQLite";
                DatabaseHelper = new DatabaseSqlite(template);
            }
        }


        private void testSqlServer(string connectionString,string databaseName)
        {
            connection = new SqlConnection(connectionString);
            connection.Open();
            connection.Close();
            template = new AdoTemplate();
            template.Connection = connection;
            template.DbProviderName = "System.Data.SqlClient";

            DatabaseHelper = new DatabaseSqlServer(template);

        }










        private void BilgileriDoldur( )
        {
            userControlCodeGenerationOptions1.databaseNameLabelDoldur(DatabaseHelper);
            schemaDoldur();

            userControlTableRelated1.listBoxTableListDoldur();
            userControlViewRelated1.listBoxViewListDoldur();
            userControlStoredProcedureRelated1.listBoxStoredProcedureListDoldur();
            userControlSequenceRelated1.listBoxSequenceListDoldur();
        }

        private void schemaDoldur()
        {
            var schemaList = DatabaseHelper.getSchemaList();
            userControlTableRelated1.comboBoxSchemaListDoldur(schemaList);
            userControlViewRelated1.comboBoxSchemaListDoldur(schemaList);
            userControlStoredProcedureRelated1.comboBoxSchemaListDoldur(schemaList);
            userControlSequenceRelated1.comboBoxSchemaListDoldur(schemaList);
        }







        private void buttonGecerliDegerleriKaydet_Click(object sender, EventArgs e)
        {

            DatabaseService.EkleVeyaGuncelle(CurrentDatabaseEntry);

            MessageBox.Show("Değerler Kaydedildi;");

        }






        private void buttonOtherConnections_Click(object sender, EventArgs e)
        {
            FormConnectionList frm = new FormConnectionList();
            frm.ShowDialog();

            if (frm.SelectedDatabaseEntry != null)
            {
                userControlCodeGenerationOptions1.databaseEntryToForm(frm.SelectedDatabaseEntry);
            }
        }



        private void buttonNewConnection_Click(object sender, EventArgs e)
        {
            userControlCodeGenerationOptions1.ClearInputControlValues();

        }


        public bool TumVeritabaniKodUretmeEminMisiniz()
        {
            string databaseType = entry.ConnectionDatabaseType;
            if (databaseType == DatabaseType.Oracle)
            {
                string message = "Oracle veritabanında genellikle sadece bir şema için Kod üretilir , emin Misiniz";
                string caption = "TUM VERİTABANI İÇİN KOD ÜRETME";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result;

                // Displays the MessageBox.

                result = MessageBox.Show(this, message, caption, buttons);

                if (result == DialogResult.Yes)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return true;
            }

        }

        private void aboutToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            FormAbout formAbout = new FormAbout();
            formAbout.ShowDialog();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DatabaseService.EkleVeyaGuncelle(CurrentDatabaseEntry);

            MessageBox.Show("Değerler Kaydedildi;");
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            userControlCodeGenerationOptions1.ClearInputControlValues();

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormConnectionList frm = new FormConnectionList();
            frm.ShowDialog();

            if (frm.SelectedDatabaseEntry != null)
            {
                userControlCodeGenerationOptions1.databaseEntryToForm(frm.SelectedDatabaseEntry);
            }
        }

        private void databaseProvidersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormDatabaseProviders form = new FormDatabaseProviders();
            form.ShowDialog();
        }

    }
}