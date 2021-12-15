namespace Karkas.CodeGeneration.WinApp.UserControls
{
    partial class UserControlStoredProcedureRelated
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonSeciliViewlariUret = new System.Windows.Forms.Button();
            this.buttonTumStoredProcedureUret = new System.Windows.Forms.Button();
            this.listBoxStoredProcedureListesi = new System.Windows.Forms.ListBox();
            this.labelStoredProcedureListesi = new System.Windows.Forms.Label();
            this.labelSchemaList = new System.Windows.Forms.Label();
            this.comboBoxSchemaList = new System.Windows.Forms.ComboBox();
            this.buttonSemaIcinTumStoredProcedureUret = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonSeciliViewlariUret
            // 
            this.buttonSeciliViewlariUret.Location = new System.Drawing.Point(373, 225);
            this.buttonSeciliViewlariUret.Margin = new System.Windows.Forms.Padding(2);
            this.buttonSeciliViewlariUret.Name = "buttonSeciliViewlariUret";
            this.buttonSeciliViewlariUret.Size = new System.Drawing.Size(119, 56);
            this.buttonSeciliViewlariUret.TabIndex = 23;
            this.buttonSeciliViewlariUret.Text = "Seçili Stored Procedure Üret";
            this.buttonSeciliViewlariUret.UseVisualStyleBackColor = true;
            this.buttonSeciliViewlariUret.Click += new System.EventHandler(this.buttonSeciliViewlariUret_Click);
            // 
            // buttonTumStoredProcedureUret
            // 
            this.buttonTumStoredProcedureUret.Location = new System.Drawing.Point(373, 65);
            this.buttonTumStoredProcedureUret.Margin = new System.Windows.Forms.Padding(2);
            this.buttonTumStoredProcedureUret.Name = "buttonTumStoredProcedureUret";
            this.buttonTumStoredProcedureUret.Size = new System.Drawing.Size(119, 56);
            this.buttonTumStoredProcedureUret.TabIndex = 22;
            this.buttonTumStoredProcedureUret.Text = "Tüm Stored Procedure Üret";
            this.buttonTumStoredProcedureUret.UseVisualStyleBackColor = true;
            this.buttonTumStoredProcedureUret.Click += new System.EventHandler(this.buttonTumStoredProcedureUret_Click);
            // 
            // listBoxStoredProcedureListesi
            // 
            this.listBoxStoredProcedureListesi.DisplayMember = "STORED_PROCEDURE_NAME";
            this.listBoxStoredProcedureListesi.FormattingEnabled = true;
            this.listBoxStoredProcedureListesi.Location = new System.Drawing.Point(151, 65);
            this.listBoxStoredProcedureListesi.Margin = new System.Windows.Forms.Padding(2);
            this.listBoxStoredProcedureListesi.Name = "listBoxStoredProcedureListesi";
            this.listBoxStoredProcedureListesi.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBoxStoredProcedureListesi.Size = new System.Drawing.Size(204, 160);
            this.listBoxStoredProcedureListesi.TabIndex = 21;
            // 
            // labelStoredProcedureListesi
            // 
            this.labelStoredProcedureListesi.AutoSize = true;
            this.labelStoredProcedureListesi.Location = new System.Drawing.Point(21, 63);
            this.labelStoredProcedureListesi.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelStoredProcedureListesi.Name = "labelStoredProcedureListesi";
            this.labelStoredProcedureListesi.Size = new System.Drawing.Size(122, 13);
            this.labelStoredProcedureListesi.TabIndex = 20;
            this.labelStoredProcedureListesi.Text = "Stored Procedure Listesi";
            // 
            // labelSchemaList
            // 
            this.labelSchemaList.AutoSize = true;
            this.labelSchemaList.Location = new System.Drawing.Point(21, 23);
            this.labelSchemaList.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelSchemaList.Name = "labelSchemaList";
            this.labelSchemaList.Size = new System.Drawing.Size(78, 13);
            this.labelSchemaList.TabIndex = 19;
            this.labelSchemaList.Text = "Schema Listesi";
            // 
            // comboBoxSchemaList
            // 
            this.comboBoxSchemaList.DisplayMember = "SCHEMA_NAME";
            this.comboBoxSchemaList.FormattingEnabled = true;
            this.comboBoxSchemaList.Location = new System.Drawing.Point(154, 25);
            this.comboBoxSchemaList.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxSchemaList.Name = "comboBoxSchemaList";
            this.comboBoxSchemaList.Size = new System.Drawing.Size(182, 21);
            this.comboBoxSchemaList.TabIndex = 18;
            this.comboBoxSchemaList.SelectedValueChanged += new System.EventHandler(this.comboBoxSchemaList_SelectedValueChanged);
            // 
            // buttonSemaIcinTumStoredProcedureUret
            // 
            this.buttonSemaIcinTumStoredProcedureUret.Location = new System.Drawing.Point(373, 137);
            this.buttonSemaIcinTumStoredProcedureUret.Margin = new System.Windows.Forms.Padding(2);
            this.buttonSemaIcinTumStoredProcedureUret.Name = "buttonSemaIcinTumStoredProcedureUret";
            this.buttonSemaIcinTumStoredProcedureUret.Size = new System.Drawing.Size(119, 56);
            this.buttonSemaIcinTumStoredProcedureUret.TabIndex = 24;
            this.buttonSemaIcinTumStoredProcedureUret.Text = "Şema için TÜM Stored Procedure Üret";
            this.buttonSemaIcinTumStoredProcedureUret.UseVisualStyleBackColor = true;
            this.buttonSemaIcinTumStoredProcedureUret.Click += new System.EventHandler(this.buttonSemaIcinTumStoredProcedureUret_Click);
            // 
            // UserControlStoredProcedureRelated
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonSemaIcinTumStoredProcedureUret);
            this.Controls.Add(this.buttonSeciliViewlariUret);
            this.Controls.Add(this.buttonTumStoredProcedureUret);
            this.Controls.Add(this.listBoxStoredProcedureListesi);
            this.Controls.Add(this.labelStoredProcedureListesi);
            this.Controls.Add(this.labelSchemaList);
            this.Controls.Add(this.comboBoxSchemaList);
            this.Name = "UserControlStoredProcedureRelated";
            this.Size = new System.Drawing.Size(524, 245);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonSeciliViewlariUret;
        private System.Windows.Forms.Button buttonTumStoredProcedureUret;
        private System.Windows.Forms.ListBox listBoxStoredProcedureListesi;
        private System.Windows.Forms.Label labelStoredProcedureListesi;
        private System.Windows.Forms.Label labelSchemaList;
        private System.Windows.Forms.ComboBox comboBoxSchemaList;
        private System.Windows.Forms.Button buttonSemaIcinTumStoredProcedureUret;
    }
}
