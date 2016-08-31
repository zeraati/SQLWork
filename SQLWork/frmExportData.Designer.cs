namespace SQLWork
{
    partial class frmExport
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
            this.grbSvrConn = new System.Windows.Forms.GroupBox();
            this.cmbServerMaghsad = new System.Windows.Forms.ComboBox();
            this.cmbServerMabda = new System.Windows.Forms.ComboBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnExport = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lstBxReport = new System.Windows.Forms.ListBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbDBMaghsad = new System.Windows.Forms.ComboBox();
            this.lblDBName = new System.Windows.Forms.Label();
            this.cmbDBMabda = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lstBxTableMaghsad = new System.Windows.Forms.ListBox();
            this.lstBxColumnMabda = new System.Windows.Forms.ListBox();
            this.lstBxTableMabda = new System.Windows.Forms.ListBox();
            this.grbSvrConn.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbSvrConn
            // 
            this.grbSvrConn.Controls.Add(this.cmbServerMaghsad);
            this.grbSvrConn.Controls.Add(this.cmbServerMabda);
            this.grbSvrConn.Controls.Add(this.btnConnect);
            this.grbSvrConn.Controls.Add(this.label1);
            this.grbSvrConn.Controls.Add(this.label4);
            this.grbSvrConn.Location = new System.Drawing.Point(14, 19);
            this.grbSvrConn.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.grbSvrConn.Name = "grbSvrConn";
            this.grbSvrConn.Padding = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.grbSvrConn.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.grbSvrConn.Size = new System.Drawing.Size(804, 82);
            this.grbSvrConn.TabIndex = 29;
            this.grbSvrConn.TabStop = false;
            this.grbSvrConn.Text = "Server Conn";
            // 
            // cmbServerMaghsad
            // 
            this.cmbServerMaghsad.FormattingEnabled = true;
            this.cmbServerMaghsad.Location = new System.Drawing.Point(227, 33);
            this.cmbServerMaghsad.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.cmbServerMaghsad.Name = "cmbServerMaghsad";
            this.cmbServerMaghsad.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmbServerMaghsad.Size = new System.Drawing.Size(217, 27);
            this.cmbServerMaghsad.TabIndex = 11;
            this.cmbServerMaghsad.SelectedIndexChanged += new System.EventHandler(this.cmbServerSecond_SelectedIndexChanged);
            // 
            // cmbServerMabda
            // 
            this.cmbServerMabda.FormattingEnabled = true;
            this.cmbServerMabda.Location = new System.Drawing.Point(516, 33);
            this.cmbServerMabda.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.cmbServerMabda.Name = "cmbServerMabda";
            this.cmbServerMabda.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmbServerMabda.Size = new System.Drawing.Size(217, 27);
            this.cmbServerMabda.TabIndex = 1;
            this.cmbServerMabda.SelectedIndexChanged += new System.EventHandler(this.cmbServerMain_SelectedIndexChanged);
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(12, 26);
            this.btnConnect.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(193, 38);
            this.btnConnect.TabIndex = 7;
            this.btnConnect.Text = "اتصال (Ctrl+R)";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(739, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 20);
            this.label1.TabIndex = 8;
            this.label1.Text = "سرور مبدا";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(450, 36);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 20);
            this.label4.TabIndex = 15;
            this.label4.Text = "سرور مقصد";
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(12, 22);
            this.btnExport.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(193, 34);
            this.btnExport.TabIndex = 31;
            this.btnExport.Text = "انتقال";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lstBxReport);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.cmbDBMaghsad);
            this.groupBox2.Controls.Add(this.lblDBName);
            this.groupBox2.Controls.Add(this.cmbDBMabda);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.lstBxTableMaghsad);
            this.groupBox2.Controls.Add(this.lstBxColumnMabda);
            this.groupBox2.Controls.Add(this.lstBxTableMabda);
            this.groupBox2.Controls.Add(this.btnExport);
            this.groupBox2.Location = new System.Drawing.Point(14, 111);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox2.Size = new System.Drawing.Size(804, 441);
            this.groupBox2.TabIndex = 32;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Export";
            // 
            // lstBxReport
            // 
            this.lstBxReport.FormattingEnabled = true;
            this.lstBxReport.ItemHeight = 19;
            this.lstBxReport.Location = new System.Drawing.Point(12, 74);
            this.lstBxReport.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lstBxReport.Name = "lstBxReport";
            this.lstBxReport.Size = new System.Drawing.Size(193, 346);
            this.lstBxReport.TabIndex = 46;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(450, 25);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(32, 20);
            this.label7.TabIndex = 45;
            this.label7.Text = "بانک";
            // 
            // cmbDBMaghsad
            // 
            this.cmbDBMaghsad.FormattingEnabled = true;
            this.cmbDBMaghsad.Location = new System.Drawing.Point(227, 20);
            this.cmbDBMaghsad.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.cmbDBMaghsad.Name = "cmbDBMaghsad";
            this.cmbDBMaghsad.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmbDBMaghsad.Size = new System.Drawing.Size(217, 27);
            this.cmbDBMaghsad.TabIndex = 44;
            this.cmbDBMaghsad.SelectedIndexChanged += new System.EventHandler(this.cmbDBSecond_SelectedIndexChanged);
            // 
            // lblDBName
            // 
            this.lblDBName.AutoSize = true;
            this.lblDBName.Location = new System.Drawing.Point(739, 27);
            this.lblDBName.Name = "lblDBName";
            this.lblDBName.Size = new System.Drawing.Size(32, 20);
            this.lblDBName.TabIndex = 43;
            this.lblDBName.Text = "بانک";
            // 
            // cmbDBMabda
            // 
            this.cmbDBMabda.FormattingEnabled = true;
            this.cmbDBMabda.Location = new System.Drawing.Point(516, 22);
            this.cmbDBMabda.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.cmbDBMabda.Name = "cmbDBMabda";
            this.cmbDBMabda.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmbDBMabda.Size = new System.Drawing.Size(217, 27);
            this.cmbDBMabda.TabIndex = 42;
            this.cmbDBMabda.SelectedIndexChanged += new System.EventHandler(this.cmbDBMain_SelectedIndexChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(450, 164);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(41, 20);
            this.label14.TabIndex = 40;
            this.label14.Text = "جداول";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(739, 323);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(50, 20);
            this.label13.TabIndex = 39;
            this.label13.Text = "ستون ها";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(739, 139);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(41, 20);
            this.label12.TabIndex = 38;
            this.label12.Text = "جداول";
            // 
            // lstBxTableMaghsad
            // 
            this.lstBxTableMaghsad.FormattingEnabled = true;
            this.lstBxTableMaghsad.ItemHeight = 19;
            this.lstBxTableMaghsad.Location = new System.Drawing.Point(227, 57);
            this.lstBxTableMaghsad.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lstBxTableMaghsad.Name = "lstBxTableMaghsad";
            this.lstBxTableMaghsad.Size = new System.Drawing.Size(217, 365);
            this.lstBxTableMaghsad.TabIndex = 34;
            this.lstBxTableMaghsad.SelectedIndexChanged += new System.EventHandler(this.lstBxTableSecond_SelectedIndexChanged);
            // 
            // lstBxColumnMabda
            // 
            this.lstBxColumnMabda.FormattingEnabled = true;
            this.lstBxColumnMabda.ItemHeight = 19;
            this.lstBxColumnMabda.Location = new System.Drawing.Point(516, 266);
            this.lstBxColumnMabda.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lstBxColumnMabda.Name = "lstBxColumnMabda";
            this.lstBxColumnMabda.Size = new System.Drawing.Size(217, 156);
            this.lstBxColumnMabda.TabIndex = 33;
            // 
            // lstBxTableMabda
            // 
            this.lstBxTableMabda.FormattingEnabled = true;
            this.lstBxTableMabda.ItemHeight = 19;
            this.lstBxTableMabda.Location = new System.Drawing.Point(516, 59);
            this.lstBxTableMabda.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lstBxTableMabda.Name = "lstBxTableMabda";
            this.lstBxTableMabda.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lstBxTableMabda.Size = new System.Drawing.Size(217, 194);
            this.lstBxTableMabda.TabIndex = 32;
            this.lstBxTableMabda.SelectedIndexChanged += new System.EventHandler(this.lstBxTableMain_SelectedIndexChanged);
            // 
            // frmExport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(827, 564);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.grbSvrConn);
            this.Font = new System.Drawing.Font("IRANSans", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmExport";
            this.Text = "انتقال اطلاعات";
            this.Load += new System.EventHandler(this.ExportData_Load);
            this.grbSvrConn.ResumeLayout(false);
            this.grbSvrConn.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grbSvrConn;
        private System.Windows.Forms.ComboBox cmbServerMaghsad;
        private System.Windows.Forms.ComboBox cmbServerMabda;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ListBox lstBxTableMaghsad;
        private System.Windows.Forms.ListBox lstBxColumnMabda;
        private System.Windows.Forms.ListBox lstBxTableMabda;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbDBMaghsad;
        private System.Windows.Forms.Label lblDBName;
        private System.Windows.Forms.ComboBox cmbDBMabda;
        private System.Windows.Forms.ListBox lstBxReport;
    }
}