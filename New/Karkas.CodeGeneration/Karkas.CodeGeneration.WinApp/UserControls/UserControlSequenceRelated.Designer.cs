namespace Karkas.CodeGeneration.WinApp.UserControls
{
    partial class UserControlSequenceRelated
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
            this.buttonSeciliSequenceUret = new System.Windows.Forms.Button();
            this.buttonTumSequencesUret = new System.Windows.Forms.Button();
            this.listBoxSequenceListesi = new System.Windows.Forms.ListBox();
            this.labelSequenceListesi = new System.Windows.Forms.Label();
            this.labelSchemaList = new System.Windows.Forms.Label();
            this.comboBoxSchemaList = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // buttonSeciliSequenceUret
            // 
            this.buttonSeciliSequenceUret.Location = new System.Drawing.Point(383, 128);
            this.buttonSeciliSequenceUret.Margin = new System.Windows.Forms.Padding(2);
            this.buttonSeciliSequenceUret.Name = "buttonSeciliSequenceUret";
            this.buttonSeciliSequenceUret.Size = new System.Drawing.Size(121, 31);
            this.buttonSeciliSequenceUret.TabIndex = 23;
            this.buttonSeciliSequenceUret.Text = "Seçili Sequence Üret";
            this.buttonSeciliSequenceUret.UseVisualStyleBackColor = true;
            this.buttonSeciliSequenceUret.Click += new System.EventHandler(this.buttonSeciliSequenceUret_Click);
            // 
            // buttonTumSequencesUret
            // 
            this.buttonTumSequencesUret.Location = new System.Drawing.Point(383, 65);
            this.buttonTumSequencesUret.Margin = new System.Windows.Forms.Padding(2);
            this.buttonTumSequencesUret.Name = "buttonTumSequencesUret";
            this.buttonTumSequencesUret.Size = new System.Drawing.Size(121, 23);
            this.buttonTumSequencesUret.TabIndex = 22;
            this.buttonTumSequencesUret.Text = "Tüm Sequenceları Üret";
            this.buttonTumSequencesUret.UseVisualStyleBackColor = true;
            this.buttonTumSequencesUret.Click += new System.EventHandler(this.buttonTumSequencesUret_Click);
            // 
            // listBoxSequenceListesi
            // 
            this.listBoxSequenceListesi.DisplayMember = "SEQUENCE_NAME";
            this.listBoxSequenceListesi.FormattingEnabled = true;
            this.listBoxSequenceListesi.Location = new System.Drawing.Point(151, 65);
            this.listBoxSequenceListesi.Margin = new System.Windows.Forms.Padding(2);
            this.listBoxSequenceListesi.Name = "listBoxSequenceListesi";
            this.listBoxSequenceListesi.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBoxSequenceListesi.Size = new System.Drawing.Size(204, 160);
            this.listBoxSequenceListesi.TabIndex = 21;
            // 
            // labelSequenceListesi
            // 
            this.labelSequenceListesi.AutoSize = true;
            this.labelSequenceListesi.Location = new System.Drawing.Point(21, 63);
            this.labelSequenceListesi.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelSequenceListesi.Name = "labelSequenceListesi";
            this.labelSequenceListesi.Size = new System.Drawing.Size(88, 13);
            this.labelSequenceListesi.TabIndex = 20;
            this.labelSequenceListesi.Text = "Sequence Listesi";
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
            // UserControlSequenceRelated
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonSeciliSequenceUret);
            this.Controls.Add(this.buttonTumSequencesUret);
            this.Controls.Add(this.listBoxSequenceListesi);
            this.Controls.Add(this.labelSequenceListesi);
            this.Controls.Add(this.labelSchemaList);
            this.Controls.Add(this.comboBoxSchemaList);
            this.Name = "UserControlSequenceRelated";
            this.Size = new System.Drawing.Size(524, 245);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonSeciliSequenceUret;
        private System.Windows.Forms.Button buttonTumSequencesUret;
        private System.Windows.Forms.ListBox listBoxSequenceListesi;
        private System.Windows.Forms.Label labelSequenceListesi;
        private System.Windows.Forms.Label labelSchemaList;
        private System.Windows.Forms.ComboBox comboBoxSchemaList;
    }
}
