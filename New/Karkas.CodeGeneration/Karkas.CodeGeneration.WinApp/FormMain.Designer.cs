using Karkas.CodeGeneration.WinApp.UserControls;
namespace Karkas.CodeGeneration.WinApp
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.buttonTestConnectionString = new System.Windows.Forms.Button();
            this.labelConnectionStatus = new System.Windows.Forms.Label();
            this.panelListe = new System.Windows.Forms.Panel();
            this.tabControlDatabase = new System.Windows.Forms.TabControl();
            this.tabPageTableRelated = new System.Windows.Forms.TabPage();
            this.userControlTableRelated1 = new Karkas.CodeGeneration.WinApp.UserControls.UserControlTableRelated();
            this.tabPageViewRelated = new System.Windows.Forms.TabPage();
            this.userControlViewRelated1 = new Karkas.CodeGeneration.WinApp.UserControls.UserControlViewRelated();
            this.tabPageStoredProcedures = new System.Windows.Forms.TabPage();
            this.userControlStoredProcedureRelated1 = new Karkas.CodeGeneration.WinApp.UserControls.UserControlStoredProcedureRelated();
            this.tabPageSequences = new System.Windows.Forms.TabPage();
            this.userControlSequenceRelated1 = new Karkas.CodeGeneration.WinApp.UserControls.UserControlSequenceRelated();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contentsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator11 = new System.Windows.Forms.ToolStripSeparator();
            this.aboutToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.saveToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.databaseProvidersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.userControlCodeGenerationOptions1 = new Karkas.CodeGeneration.WinApp.UserControls.UserControlCodeGenerationOptions();
            this.panelListe.SuspendLayout();
            this.tabControlDatabase.SuspendLayout();
            this.tabPageTableRelated.SuspendLayout();
            this.tabPageViewRelated.SuspendLayout();
            this.tabPageStoredProcedures.SuspendLayout();
            this.tabPageSequences.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonTestConnectionString
            // 
            this.buttonTestConnectionString.Location = new System.Drawing.Point(607, 597);
            this.buttonTestConnectionString.Margin = new System.Windows.Forms.Padding(2);
            this.buttonTestConnectionString.Name = "buttonTestConnectionString";
            this.buttonTestConnectionString.Size = new System.Drawing.Size(97, 58);
            this.buttonTestConnectionString.TabIndex = 3;
            this.buttonTestConnectionString.Text = "test";
            this.buttonTestConnectionString.UseVisualStyleBackColor = true;
            this.buttonTestConnectionString.Click += new System.EventHandler(this.buttonTestConnectionString_Click);
            // 
            // labelConnectionStatus
            // 
            this.labelConnectionStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelConnectionStatus.Location = new System.Drawing.Point(611, 520);
            this.labelConnectionStatus.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelConnectionStatus.Name = "labelConnectionStatus";
            this.labelConnectionStatus.Size = new System.Drawing.Size(93, 57);
            this.labelConnectionStatus.TabIndex = 4;
            this.labelConnectionStatus.Text = "Bağlantı Denenmedi";
            // 
            // panelListe
            // 
            this.panelListe.Controls.Add(this.tabControlDatabase);
            this.panelListe.Location = new System.Drawing.Point(3, 442);
            this.panelListe.Margin = new System.Windows.Forms.Padding(2);
            this.panelListe.Name = "panelListe";
            this.panelListe.Size = new System.Drawing.Size(604, 375);
            this.panelListe.TabIndex = 5;
            // 
            // tabControlDatabase
            // 
            this.tabControlDatabase.Controls.Add(this.tabPageTableRelated);
            this.tabControlDatabase.Controls.Add(this.tabPageViewRelated);
            this.tabControlDatabase.Controls.Add(this.tabPageStoredProcedures);
            this.tabControlDatabase.Controls.Add(this.tabPageSequences);
            this.tabControlDatabase.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlDatabase.Location = new System.Drawing.Point(0, 0);
            this.tabControlDatabase.Name = "tabControlDatabase";
            this.tabControlDatabase.SelectedIndex = 0;
            this.tabControlDatabase.Size = new System.Drawing.Size(604, 375);
            this.tabControlDatabase.TabIndex = 0;
            // 
            // tabPageTableRelated
            // 
            this.tabPageTableRelated.Controls.Add(this.userControlTableRelated1);
            this.tabPageTableRelated.Location = new System.Drawing.Point(4, 22);
            this.tabPageTableRelated.Name = "tabPageTableRelated";
            this.tabPageTableRelated.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageTableRelated.Size = new System.Drawing.Size(596, 349);
            this.tabPageTableRelated.TabIndex = 0;
            this.tabPageTableRelated.Text = "Table";
            this.tabPageTableRelated.UseVisualStyleBackColor = true;
            // 
            // userControlTableRelated1
            // 
            this.userControlTableRelated1.Location = new System.Drawing.Point(3, 6);
            this.userControlTableRelated1.Name = "userControlTableRelated1";
            this.userControlTableRelated1.Size = new System.Drawing.Size(569, 384);
            this.userControlTableRelated1.TabIndex = 0;
            // 
            // tabPageViewRelated
            // 
            this.tabPageViewRelated.Controls.Add(this.userControlViewRelated1);
            this.tabPageViewRelated.Location = new System.Drawing.Point(4, 22);
            this.tabPageViewRelated.Name = "tabPageViewRelated";
            this.tabPageViewRelated.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageViewRelated.Size = new System.Drawing.Size(596, 349);
            this.tabPageViewRelated.TabIndex = 1;
            this.tabPageViewRelated.Text = "View";
            this.tabPageViewRelated.UseVisualStyleBackColor = true;
            // 
            // userControlViewRelated1
            // 
            this.userControlViewRelated1.Location = new System.Drawing.Point(0, 6);
            this.userControlViewRelated1.Name = "userControlViewRelated1";
            this.userControlViewRelated1.Size = new System.Drawing.Size(524, 338);
            this.userControlViewRelated1.TabIndex = 0;
            // 
            // tabPageStoredProcedures
            // 
            this.tabPageStoredProcedures.Controls.Add(this.userControlStoredProcedureRelated1);
            this.tabPageStoredProcedures.Location = new System.Drawing.Point(4, 22);
            this.tabPageStoredProcedures.Name = "tabPageStoredProcedures";
            this.tabPageStoredProcedures.Size = new System.Drawing.Size(596, 349);
            this.tabPageStoredProcedures.TabIndex = 2;
            this.tabPageStoredProcedures.Text = "Stored Procedures";
            this.tabPageStoredProcedures.UseVisualStyleBackColor = true;
            // 
            // userControlStoredProcedureRelated1
            // 
            this.userControlStoredProcedureRelated1.Location = new System.Drawing.Point(3, 0);
            this.userControlStoredProcedureRelated1.Name = "userControlStoredProcedureRelated1";
            this.userControlStoredProcedureRelated1.Size = new System.Drawing.Size(524, 338);
            this.userControlStoredProcedureRelated1.TabIndex = 0;
            // 
            // tabPageSequences
            // 
            this.tabPageSequences.Controls.Add(this.userControlSequenceRelated1);
            this.tabPageSequences.Location = new System.Drawing.Point(4, 22);
            this.tabPageSequences.Name = "tabPageSequences";
            this.tabPageSequences.Size = new System.Drawing.Size(596, 349);
            this.tabPageSequences.TabIndex = 3;
            this.tabPageSequences.Text = "Sequences";
            this.tabPageSequences.UseVisualStyleBackColor = true;
            // 
            // userControlSequenceRelated1
            // 
            this.userControlSequenceRelated1.Location = new System.Drawing.Point(6, 3);
            this.userControlSequenceRelated1.Name = "userControlSequenceRelated1";
            this.userControlSequenceRelated1.Size = new System.Drawing.Size(524, 338);
            this.userControlSequenceRelated1.TabIndex = 0;
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.aboutToolStripMenuItem.Text = "&About...";
            // 
            // contentsToolStripMenuItem1
            // 
            this.contentsToolStripMenuItem1.Name = "contentsToolStripMenuItem1";
            this.contentsToolStripMenuItem1.Size = new System.Drawing.Size(122, 22);
            this.contentsToolStripMenuItem1.Text = "&Contents";
            // 
            // toolStripSeparator11
            // 
            this.toolStripSeparator11.Name = "toolStripSeparator11";
            this.toolStripSeparator11.Size = new System.Drawing.Size(119, 6);
            // 
            // aboutToolStripMenuItem1
            // 
            this.aboutToolStripMenuItem1.Name = "aboutToolStripMenuItem1";
            this.aboutToolStripMenuItem1.Size = new System.Drawing.Size(122, 22);
            this.aboutToolStripMenuItem1.Text = "&About...";
            // 
            // newToolStripMenuItem1
            // 
            this.newToolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("newToolStripMenuItem1.Image")));
            this.newToolStripMenuItem1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newToolStripMenuItem1.Name = "newToolStripMenuItem1";
            this.newToolStripMenuItem1.Size = new System.Drawing.Size(143, 22);
            this.newToolStripMenuItem1.Text = "&New";
            // 
            // openToolStripMenuItem1
            // 
            this.openToolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripMenuItem1.Image")));
            this.openToolStripMenuItem1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openToolStripMenuItem1.Name = "openToolStripMenuItem1";
            this.openToolStripMenuItem1.Size = new System.Drawing.Size(143, 22);
            this.openToolStripMenuItem1.Text = "&Open";
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(140, 6);
            // 
            // saveToolStripMenuItem1
            // 
            this.saveToolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripMenuItem1.Image")));
            this.saveToolStripMenuItem1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveToolStripMenuItem1.Name = "saveToolStripMenuItem1";
            this.saveToolStripMenuItem1.Size = new System.Drawing.Size(143, 22);
            this.saveToolStripMenuItem1.Text = "&Save";
            // 
            // saveAsToolStripMenuItem1
            // 
            this.saveAsToolStripMenuItem1.Name = "saveAsToolStripMenuItem1";
            this.saveAsToolStripMenuItem1.Size = new System.Drawing.Size(143, 22);
            this.saveAsToolStripMenuItem1.Text = "Save &As";
            // 
            // exitToolStripMenuItem1
            // 
            this.exitToolStripMenuItem1.Name = "exitToolStripMenuItem1";
            this.exitToolStripMenuItem1.Size = new System.Drawing.Size(143, 22);
            this.exitToolStripMenuItem1.Text = "E&xit";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(734, 24);
            this.menuStrip1.TabIndex = 23;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem2,
            this.databaseProvidersToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem2
            // 
            this.aboutToolStripMenuItem2.Name = "aboutToolStripMenuItem2";
            this.aboutToolStripMenuItem2.Size = new System.Drawing.Size(174, 22);
            this.aboutToolStripMenuItem2.Text = "About";
            this.aboutToolStripMenuItem2.Click += new System.EventHandler(this.aboutToolStripMenuItem2_Click);
            // 
            // databaseProvidersToolStripMenuItem
            // 
            this.databaseProvidersToolStripMenuItem.Name = "databaseProvidersToolStripMenuItem";
            this.databaseProvidersToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.databaseProvidersToolStripMenuItem.Text = "Database Providers";
            this.databaseProvidersToolStripMenuItem.Click += new System.EventHandler(this.databaseProvidersToolStripMenuItem_Click);
            // 
            // userControlCodeGenerationOptions1
            // 
            this.userControlCodeGenerationOptions1.Location = new System.Drawing.Point(2, 27);
            this.userControlCodeGenerationOptions1.Name = "userControlCodeGenerationOptions1";
            this.userControlCodeGenerationOptions1.Size = new System.Drawing.Size(719, 410);
            this.userControlCodeGenerationOptions1.TabIndex = 20;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 752);
            this.Controls.Add(this.userControlCodeGenerationOptions1);
            this.Controls.Add(this.panelListe);
            this.Controls.Add(this.labelConnectionStatus);
            this.Controls.Add(this.buttonTestConnectionString);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FormMain";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Karkas  CodeGeneration WinApp";
            this.panelListe.ResumeLayout(false);
            this.tabControlDatabase.ResumeLayout(false);
            this.tabPageTableRelated.ResumeLayout(false);
            this.tabPageViewRelated.ResumeLayout(false);
            this.tabPageStoredProcedures.ResumeLayout(false);
            this.tabPageSequences.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonTestConnectionString;
        private System.Windows.Forms.Label labelConnectionStatus;
        private System.Windows.Forms.Panel panelListe;
        private UserControlCodeGenerationOptions userControlCodeGenerationOptions1;
        private System.Windows.Forms.TabControl tabControlDatabase;
        private System.Windows.Forms.TabPage tabPageTableRelated;
        private System.Windows.Forms.TabPage tabPageViewRelated;
        private System.Windows.Forms.TabPage tabPageStoredProcedures;
        private System.Windows.Forms.TabPage tabPageSequences;
        private UserControlTableRelated userControlTableRelated1;
        private UserControlViewRelated userControlViewRelated1;
        private UserControlStoredProcedureRelated userControlStoredProcedureRelated1;
        private UserControlSequenceRelated userControlSequenceRelated1;
        private System.Windows.Forms.ToolStripMenuItem contentsToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator11;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator10;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem databaseProvidersToolStripMenuItem;
    }
}

