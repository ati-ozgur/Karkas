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
			buttonTestConnectionString = new Button();
			labelConnectionStatus = new Label();
			tabControlDatabase = new TabControl();
			tabPageTableRelated = new TabPage();
			userControlTableRelated1 = new UserControlTableRelated();
			tabPageViewRelated = new TabPage();
			userControlViewRelated1 = new UserControlViewRelated();
			tabPageStoredProcedures = new TabPage();
			userControlStoredProcedureRelated1 = new UserControlStoredProcedureRelated();
			tabPageSequences = new TabPage();
			userControlSequenceRelated1 = new UserControlSequenceRelated();
			contentsToolStripMenuItem1 = new ToolStripMenuItem();
			toolStripSeparator11 = new ToolStripSeparator();
			newToolStripMenuItem1 = new ToolStripMenuItem();
			openToolStripMenuItem1 = new ToolStripMenuItem();
			toolStripSeparator6 = new ToolStripSeparator();
			saveToolStripMenuItem1 = new ToolStripMenuItem();
			saveAsToolStripMenuItem1 = new ToolStripMenuItem();
			exitToolStripMenuItem1 = new ToolStripMenuItem();
			menuStrip1 = new MenuStrip();
			fileToolStripMenuItem = new ToolStripMenuItem();
			newToolStripMenuItem = new ToolStripMenuItem();
			openFromLocalDirectoryToolStripMenuItem = new ToolStripMenuItem();
			saveToLocalWorkingDirectoryToolStripMenuItem = new ToolStripMenuItem();
			helpToolStripMenuItem = new ToolStripMenuItem();
			aboutToolStripMenuItem = new ToolStripMenuItem();
			databaseProvidersToolStripMenuItem = new ToolStripMenuItem();
			userControlCodeGenerationOptions1 = new UserControlCodeGenerationOptions();
			tableLayoutPanel1 = new TableLayoutPanel();
			tabControlDatabase.SuspendLayout();
			tabPageTableRelated.SuspendLayout();
			tabPageViewRelated.SuspendLayout();
			tabPageStoredProcedures.SuspendLayout();
			tabPageSequences.SuspendLayout();
			menuStrip1.SuspendLayout();
			tableLayoutPanel1.SuspendLayout();
			SuspendLayout();
			// 
			// buttonTestConnectionString
			// 
			buttonTestConnectionString.Location = new Point(965, 3);
			buttonTestConnectionString.Name = "buttonTestConnectionString";
			buttonTestConnectionString.Size = new Size(101, 76);
			buttonTestConnectionString.TabIndex = 3;
			buttonTestConnectionString.Text = "Test Connection";
			buttonTestConnectionString.UseVisualStyleBackColor = true;
			buttonTestConnectionString.Click += buttonTestConnectionString_Click;
			// 
			// labelConnectionStatus
			// 
			labelConnectionStatus.Font = new Font("Microsoft Sans Serif", 12F);
			labelConnectionStatus.Location = new Point(965, 426);
			labelConnectionStatus.Name = "labelConnectionStatus";
			labelConnectionStatus.Size = new Size(101, 75);
			labelConnectionStatus.TabIndex = 4;
			labelConnectionStatus.Text = "Connection is not tried yet.";
			// 
			// tabControlDatabase
			// 
			tabControlDatabase.Controls.Add(tabPageTableRelated);
			tabControlDatabase.Controls.Add(tabPageViewRelated);
			tabControlDatabase.Controls.Add(tabPageStoredProcedures);
			tabControlDatabase.Controls.Add(tabPageSequences);
			tabControlDatabase.Dock = DockStyle.Fill;
			tabControlDatabase.Enabled = false;
			tabControlDatabase.Location = new Point(4, 429);
			tabControlDatabase.Margin = new Padding(4, 3, 4, 3);
			tabControlDatabase.Name = "tabControlDatabase";
			tabControlDatabase.SelectedIndex = 0;
			tabControlDatabase.Size = new Size(954, 148);
			tabControlDatabase.TabIndex = 0;
			// 
			// tabPageTableRelated
			// 
			tabPageTableRelated.Controls.Add(userControlTableRelated1);
			tabPageTableRelated.Location = new Point(4, 24);
			tabPageTableRelated.Margin = new Padding(4, 3, 4, 3);
			tabPageTableRelated.Name = "tabPageTableRelated";
			tabPageTableRelated.Padding = new Padding(4, 3, 4, 3);
			tabPageTableRelated.Size = new Size(946, 120);
			tabPageTableRelated.TabIndex = 0;
			tabPageTableRelated.Text = "Table";
			tabPageTableRelated.UseVisualStyleBackColor = true;
			// 
			// userControlTableRelated1
			// 
			userControlTableRelated1.Dock = DockStyle.Fill;
			userControlTableRelated1.Location = new Point(4, 3);
			userControlTableRelated1.Margin = new Padding(11, 12, 11, 12);
			userControlTableRelated1.Name = "userControlTableRelated1";
			userControlTableRelated1.Size = new Size(938, 114);
			userControlTableRelated1.TabIndex = 0;
			// 
			// tabPageViewRelated
			// 
			tabPageViewRelated.Controls.Add(userControlViewRelated1);
			tabPageViewRelated.Location = new Point(4, 24);
			tabPageViewRelated.Margin = new Padding(4, 3, 4, 3);
			tabPageViewRelated.Name = "tabPageViewRelated";
			tabPageViewRelated.Padding = new Padding(4, 3, 4, 3);
			tabPageViewRelated.Size = new Size(192, 72);
			tabPageViewRelated.TabIndex = 1;
			tabPageViewRelated.Text = "View";
			tabPageViewRelated.UseVisualStyleBackColor = true;
			// 
			// userControlViewRelated1
			// 
			userControlViewRelated1.Dock = DockStyle.Fill;
			userControlViewRelated1.Location = new Point(4, 3);
			userControlViewRelated1.Margin = new Padding(11, 12, 11, 12);
			userControlViewRelated1.Name = "userControlViewRelated1";
			userControlViewRelated1.Size = new Size(184, 66);
			userControlViewRelated1.TabIndex = 0;
			// 
			// tabPageStoredProcedures
			// 
			tabPageStoredProcedures.Controls.Add(userControlStoredProcedureRelated1);
			tabPageStoredProcedures.Location = new Point(4, 24);
			tabPageStoredProcedures.Margin = new Padding(4, 3, 4, 3);
			tabPageStoredProcedures.Name = "tabPageStoredProcedures";
			tabPageStoredProcedures.Size = new Size(192, 72);
			tabPageStoredProcedures.TabIndex = 2;
			tabPageStoredProcedures.Text = "Stored Procedures";
			tabPageStoredProcedures.UseVisualStyleBackColor = true;
			// 
			// userControlStoredProcedureRelated1
			// 
			userControlStoredProcedureRelated1.Dock = DockStyle.Fill;
			userControlStoredProcedureRelated1.Location = new Point(0, 0);
			userControlStoredProcedureRelated1.Margin = new Padding(11, 12, 11, 12);
			userControlStoredProcedureRelated1.Name = "userControlStoredProcedureRelated1";
			userControlStoredProcedureRelated1.Size = new Size(192, 72);
			userControlStoredProcedureRelated1.TabIndex = 0;
			// 
			// tabPageSequences
			// 
			tabPageSequences.Controls.Add(userControlSequenceRelated1);
			tabPageSequences.Location = new Point(4, 24);
			tabPageSequences.Margin = new Padding(4, 3, 4, 3);
			tabPageSequences.Name = "tabPageSequences";
			tabPageSequences.Size = new Size(192, 72);
			tabPageSequences.TabIndex = 3;
			tabPageSequences.Text = "Sequences";
			tabPageSequences.UseVisualStyleBackColor = true;
			// 
			// userControlSequenceRelated1
			// 
			userControlSequenceRelated1.Dock = DockStyle.Fill;
			userControlSequenceRelated1.Location = new Point(0, 0);
			userControlSequenceRelated1.Margin = new Padding(11, 12, 11, 12);
			userControlSequenceRelated1.Name = "userControlSequenceRelated1";
			userControlSequenceRelated1.Size = new Size(192, 72);
			userControlSequenceRelated1.TabIndex = 0;
			// 
			// contentsToolStripMenuItem1
			// 
			contentsToolStripMenuItem1.Name = "contentsToolStripMenuItem1";
			contentsToolStripMenuItem1.Size = new Size(122, 22);
			contentsToolStripMenuItem1.Text = "&Contents";
			// 
			// toolStripSeparator11
			// 
			toolStripSeparator11.Name = "toolStripSeparator11";
			toolStripSeparator11.Size = new Size(119, 6);
			// 
			// newToolStripMenuItem1
			// 
			newToolStripMenuItem1.Image = (Image)resources.GetObject("newToolStripMenuItem1.Image");
			newToolStripMenuItem1.ImageTransparentColor = Color.Magenta;
			newToolStripMenuItem1.Name = "newToolStripMenuItem1";
			newToolStripMenuItem1.Size = new Size(143, 22);
			newToolStripMenuItem1.Text = "&New";
			// 
			// openToolStripMenuItem1
			// 
			openToolStripMenuItem1.Image = (Image)resources.GetObject("openToolStripMenuItem1.Image");
			openToolStripMenuItem1.ImageTransparentColor = Color.Magenta;
			openToolStripMenuItem1.Name = "openToolStripMenuItem1";
			openToolStripMenuItem1.Size = new Size(143, 22);
			openToolStripMenuItem1.Text = "&Open";
			// 
			// toolStripSeparator6
			// 
			toolStripSeparator6.Name = "toolStripSeparator6";
			toolStripSeparator6.Size = new Size(140, 6);
			// 
			// saveToolStripMenuItem1
			// 
			saveToolStripMenuItem1.Image = (Image)resources.GetObject("saveToolStripMenuItem1.Image");
			saveToolStripMenuItem1.ImageTransparentColor = Color.Magenta;
			saveToolStripMenuItem1.Name = "saveToolStripMenuItem1";
			saveToolStripMenuItem1.Size = new Size(143, 22);
			saveToolStripMenuItem1.Text = "&Save";
			// 
			// saveAsToolStripMenuItem1
			// 
			saveAsToolStripMenuItem1.Name = "saveAsToolStripMenuItem1";
			saveAsToolStripMenuItem1.Size = new Size(143, 22);
			saveAsToolStripMenuItem1.Text = "Save &As";
			// 
			// exitToolStripMenuItem1
			// 
			exitToolStripMenuItem1.Name = "exitToolStripMenuItem1";
			exitToolStripMenuItem1.Size = new Size(143, 22);
			exitToolStripMenuItem1.Text = "E&xit";
			// 
			// menuStrip1
			// 
			menuStrip1.ImageScalingSize = new Size(40, 40);
			menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, helpToolStripMenuItem });
			menuStrip1.Location = new Point(0, 0);
			menuStrip1.Name = "menuStrip1";
			menuStrip1.Padding = new Padding(8, 3, 0, 3);
			menuStrip1.Size = new Size(1069, 25);
			menuStrip1.TabIndex = 23;
			menuStrip1.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { newToolStripMenuItem, openFromLocalDirectoryToolStripMenuItem, saveToLocalWorkingDirectoryToolStripMenuItem });
			fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			fileToolStripMenuItem.Size = new Size(37, 19);
			fileToolStripMenuItem.Text = "File";
			// 
			// newToolStripMenuItem
			// 
			newToolStripMenuItem.Name = "newToolStripMenuItem";
			newToolStripMenuItem.Size = new Size(256, 22);
			newToolStripMenuItem.Text = "New";
			newToolStripMenuItem.Click += newToolStripMenuItem_Click;
			// 
			// openFromLocalDirectoryToolStripMenuItem
			// 
			openFromLocalDirectoryToolStripMenuItem.Name = "openFromLocalDirectoryToolStripMenuItem";
			openFromLocalDirectoryToolStripMenuItem.Size = new Size(256, 22);
			openFromLocalDirectoryToolStripMenuItem.Text = "Open from local working directory";
			openFromLocalDirectoryToolStripMenuItem.Click += openFromLocalDirectoryToolStripMenuItem_Click;
			// 
			// saveToLocalWorkingDirectoryToolStripMenuItem
			// 
			saveToLocalWorkingDirectoryToolStripMenuItem.Name = "saveToLocalWorkingDirectoryToolStripMenuItem";
			saveToLocalWorkingDirectoryToolStripMenuItem.Size = new Size(256, 22);
			saveToLocalWorkingDirectoryToolStripMenuItem.Text = "Save to local working directory";
			saveToLocalWorkingDirectoryToolStripMenuItem.Click += saveToLocalWorkingDirectoryToolStripMenuItem_Click;
			// 
			// helpToolStripMenuItem
			// 
			helpToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { aboutToolStripMenuItem, databaseProvidersToolStripMenuItem });
			helpToolStripMenuItem.Name = "helpToolStripMenuItem";
			helpToolStripMenuItem.Size = new Size(44, 19);
			helpToolStripMenuItem.Text = "Help";
			// 
			// aboutToolStripMenuItem
			// 
			aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
			aboutToolStripMenuItem.Size = new Size(174, 22);
			aboutToolStripMenuItem.Text = "About";
			aboutToolStripMenuItem.Click += aboutToolStripMenuItem_Click;
			// 
			// databaseProvidersToolStripMenuItem
			// 
			databaseProvidersToolStripMenuItem.Name = "databaseProvidersToolStripMenuItem";
			databaseProvidersToolStripMenuItem.Size = new Size(174, 22);
			databaseProvidersToolStripMenuItem.Text = "Database Providers";
			databaseProvidersToolStripMenuItem.Click += databaseProvidersToolStripMenuItem_Click;
			// 
			// userControlCodeGenerationOptions1
			// 
			userControlCodeGenerationOptions1.AutoSize = true;
			userControlCodeGenerationOptions1.Dock = DockStyle.Fill;
			userControlCodeGenerationOptions1.Location = new Point(11, 12);
			userControlCodeGenerationOptions1.Margin = new Padding(11, 12, 11, 12);
			userControlCodeGenerationOptions1.Name = "userControlCodeGenerationOptions1";
			userControlCodeGenerationOptions1.Size = new Size(940, 402);
			userControlCodeGenerationOptions1.TabIndex = 20;
			// 
			// tableLayoutPanel1
			// 
			tableLayoutPanel1.AutoSize = true;
			tableLayoutPanel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			tableLayoutPanel1.ColumnCount = 2;
			tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 90F));
			tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
			tableLayoutPanel1.Controls.Add(tabControlDatabase, 0, 1);
			tableLayoutPanel1.Controls.Add(labelConnectionStatus, 1, 1);
			tableLayoutPanel1.Controls.Add(buttonTestConnectionString, 1, 0);
			tableLayoutPanel1.Controls.Add(userControlCodeGenerationOptions1, 0, 0);
			tableLayoutPanel1.Dock = DockStyle.Fill;
			tableLayoutPanel1.Location = new Point(0, 25);
			tableLayoutPanel1.Name = "tableLayoutPanel1";
			tableLayoutPanel1.RowCount = 2;
			tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 73.55372F));
			tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 26.44628F));
			tableLayoutPanel1.Size = new Size(1069, 580);
			tableLayoutPanel1.TabIndex = 24;
			// 
			// FormMain
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(1069, 605);
			Controls.Add(tableLayoutPanel1);
			Controls.Add(menuStrip1);
			Font = new Font("Times New Roman", 9F);
			FormBorderStyle = FormBorderStyle.FixedSingle;
			Name = "FormMain";
			SizeGripStyle = SizeGripStyle.Hide;
			StartPosition = FormStartPosition.CenterScreen;
			Text = "Karkas CodeGeneration WinApp";
			tabControlDatabase.ResumeLayout(false);
			tabPageTableRelated.ResumeLayout(false);
			tabPageViewRelated.ResumeLayout(false);
			tabPageStoredProcedures.ResumeLayout(false);
			tabPageSequences.ResumeLayout(false);
			menuStrip1.ResumeLayout(false);
			menuStrip1.PerformLayout();
			tableLayoutPanel1.ResumeLayout(false);
			tableLayoutPanel1.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private System.Windows.Forms.Button buttonTestConnectionString;
        private System.Windows.Forms.Label labelConnectionStatus;
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
        private System.Windows.Forms.ToolStripMenuItem openFromLocalDirectoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToLocalWorkingDirectoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem databaseProvidersToolStripMenuItem;
        private TableLayoutPanel tableLayoutPanel1;
    }
}

