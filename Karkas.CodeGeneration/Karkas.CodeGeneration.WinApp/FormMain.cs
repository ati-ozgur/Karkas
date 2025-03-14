﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using Karkas.Data;
using Karkas.CodeGeneration.SqlServer;
using System.Reflection;
using System.Data.Common;
using System.Runtime.Remoting;
using Karkas.CodeGeneration.Helpers;
using Karkas.CodeGeneration.Oracle;
using Karkas.CodeGeneration.Helpers.Interfaces;
using Karkas.CodeGeneration.WinApp.PersistenceService;
using Karkas.CodeGeneration.Oracle.Implementations;
using Karkas.CodeGeneration.Sqlite.Implementations;
using Karkas.CodeGeneration.SqlServer.Implementations;
using Karkas.Data.Oracle;
using Karkas.Data.SqlServer;
using Karkas.Data.Sqlite;

namespace Karkas.CodeGeneration.WinApp
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
            userControlCodeGenerationOptions1.getLastAccessedConnectionToTextbox();
            this.WindowState = FormWindowState.Maximized;
        }


        DbConnection connection;
        IAdoTemplate<IParameterBuilder> template;
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
        
        public string[] GetSchemaList()
        {
            return CurrentDatabaseEntry.getSchemaList();
        }

        
        private void buttonTestConnectionString_Click(object sender, EventArgs e)
        {
            string type = userControlCodeGenerationOptions1.SelectedDatabaseType;
            string connectionString = userControlCodeGenerationOptions1.ConnectionString;
            string connectionName = userControlCodeGenerationOptions1.ConnectionName;
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

                labelConnectionStatus.ForeColor = Color.Black;
                labelConnectionStatus.Text = "Connection is SUCCESFULL";
                fillInformation();
                this.tabControlDatabase.Enabled = true;


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                labelConnectionStatus.ForeColor = Color.Red;
                labelConnectionStatus.Text = "!!!!Connection is NOT succesfull!!!!";
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


                template = new AdoTemplateOracle();
                template.Connection = connection;
                template.DbProviderName = ConnectionDbProviderName;
                DatabaseHelper = new CodeGenerationOracle( template);
                DbProviderFactories.RegisterFactory(ConnectionDbProviderName, factory);



            }
        }




        private void testSqlServer(string connectionString,string databaseName)
        {
            const string providerName = "Microsoft.Data.SqlClient";

            DbProviderFactories.TryGetFactory(providerName, out var factory);

            if(factory == null)
            {
                DbProviderFactories.RegisterFactory(providerName, SqlClientFactory.Instance);
            }

            connection = new SqlConnection(connectionString);
            connection.Open();
            connection.Close();
            template = new AdoTemplateSqlServer();
            template.Connection = connection;
            template.DbProviderName = providerName;

            DatabaseHelper = new SqlServerDalGenerator(template);

        }










        private void fillInformation( )
        {
            userControlCodeGenerationOptions1.databaseNameLabelDoldur(DatabaseHelper);
            fillSchema();

            userControlTableRelated1.fillTablesInListBox();
            userControlViewRelated1.listBoxViewListDoldur();
            userControlStoredProcedureRelated1.fillListBoxStoredProcedures();
            userControlSequenceRelated1.fillListBoxSequences();
        }

        private void fillSchema()
        {
            string[] schemaList = userControlCodeGenerationOptions1.GetSchemaList();
            if(schemaList == null || schemaList.Length == 0)
            {
                schemaList = DatabaseHelper.getSchemaList();
            }
            userControlTableRelated1.fillComboBoxSchemaList(schemaList);
            userControlViewRelated1.fillComboBoxSchemaList(schemaList);
            userControlStoredProcedureRelated1.fillComboBoxSchemaList(schemaList);
            userControlSequenceRelated1.fillComboBoxSchemaList(schemaList);
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


        public bool ProduceAllTablesAreYouSure()
        {
            string databaseType = entry.ConnectionDatabaseType;
            if (databaseType == DatabaseType.Oracle && string.IsNullOrEmpty(entry.SchemaList))
            {
                string message = "Normally, codes are produced for only some schemas in Oracle database. May be you should fill TEXTBOX SCHEMA LIST. Are you sure to generate tables for all schemas in oracle?";
                string caption = "PRODUCE CODE FOR ALL DATABASE";
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
            DatabaseService.InsertOrUpdate(CurrentDatabaseEntry);

            MessageBox.Show("Values saved;");
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
