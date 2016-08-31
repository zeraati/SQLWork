namespace SQLWork
{
    partial class frmExportData
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
            this.cmbServerSecond = new System.Windows.Forms.ComboBox();
            this.cmbServerMain = new System.Windows.Forms.ComboBox();
            this.txtUserSecond = new System.Windows.Forms.TextBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.txtUserMain = new System.Windows.Forms.TextBox();
            this.txtPassSecond = new System.Windows.Forms.TextBox();
            this.txtPassMain = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnExport = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvTableInfo = new System.Windows.Forms.DataGridView();
            this.lstBxReport = new System.Windows.Forms.ListBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbDBSecond = new System.Windows.Forms.ComboBox();
            this.lblDBName = new System.Windows.Forms.Label();
            this.cmbDBMain = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lstBxColumnSecond = new System.Windows.Forms.ListBox();
            this.lstBxTableSecond = new System.Windows.Forms.ListBox();
            this.lstBxColumnMain = new System.Windows.Forms.ListBox();
            this.lstBxTableMain = new System.Windows.Forms.ListBox();
            this.grbSvrConn.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTableInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // grbSvrConn
            // 
            this.grbSvrConn.Controls.Add(this.cmbServerSecond);
            this.grbSvrConn.Controls.Add(this.cmbServerMain);
            this.grbSvrConn.Controls.Add(this.txtUserSecond);
            this.grbSvrConn.Controls.Add(this.btnConnect);
            this.grbSvrConn.Controls.Add(this.txtUserMain);
            this.grbSvrConn.Controls.Add(this.txtPassSecond);
            this.grbSvrConn.Controls.Add(this.txtPassMain);
            this.grbSvrConn.Controls.Add(this.label6);
            this.grbSvrConn.Controls.Add(this.label1);
            this.grbSvrConn.Controls.Add(this.label4);
            this.grbSvrConn.Controls.Add(this.label5);
            this.grbSvrConn.Controls.Add(this.label2);
            this.grbSvrConn.Controls.Add(this.label3);
            this.grbSvrConn.Location = new System.Drawing.Point(12, 13);
            this.grbSvrConn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grbSvrConn.Name = "grbSvrConn";
            this.grbSvrConn.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grbSvrConn.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.grbSvrConn.Size = new System.Drawing.Size(926, 106);
            this.grbSvrConn.TabIndex = 29;
            this.grbSvrConn.TabStop = false;
            this.grbSvrConn.Text = "Server Conn";
            // 
            // cmbServerSecond
            // 
            this.cmbServerSecond.FormattingEnabled = true;
            this.cmbServerSecond.Location = new System.Drawing.Point(389, 21);
            this.cmbServerSecond.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbServerSecond.Name = "cmbServerSecond";
            this.cmbServerSecond.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmbServerSecond.Size = new System.Drawing.Size(174, 21);
            this.cmbServerSecond.TabIndex = 11;
            this.cmbServerSecond.SelectedIndexChanged += new System.EventHandler(this.cmbServerSecond_SelectedIndexChanged);
            // 
            // cmbServerMain
            // 
            this.cmbServerMain.FormattingEnabled = true;
            this.cmbServerMain.Location = new System.Drawing.Point(661, 21);
            this.cmbServerMain.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbServerMain.Name = "cmbServerMain";
            this.cmbServerMain.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmbServerMain.Size = new System.Drawing.Size(174, 21);
            this.cmbServerMain.TabIndex = 1;
            this.cmbServerMain.SelectedIndexChanged += new System.EventHandler(this.cmbServerMain_SelectedIndexChanged);
            // 
            // txtUserSecond
            // 
            this.txtUserSecond.Location = new System.Drawing.Point(389, 50);
            this.txtUserSecond.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtUserSecond.Name = "txtUserSecond";
            this.txtUserSecond.Size = new System.Drawing.Size(174, 20);
            this.txtUserSecond.TabIndex = 12;
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(10, 23);
            this.btnConnect.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(103, 36);
            this.btnConnect.TabIndex = 7;
            this.btnConnect.Text = "اتصال (Ctrl+R)";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // txtUserMain
            // 
            this.txtUserMain.Location = new System.Drawing.Point(661, 50);
            this.txtUserMain.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtUserMain.Name = "txtUserMain";
            this.txtUserMain.Size = new System.Drawing.Size(174, 20);
            this.txtUserMain.TabIndex = 2;
            // 
            // txtPassSecond
            // 
            this.txtPassSecond.Location = new System.Drawing.Point(389, 78);
            this.txtPassSecond.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtPassSecond.Name = "txtPassSecond";
            this.txtPassSecond.PasswordChar = '*';
            this.txtPassSecond.Size = new System.Drawing.Size(174, 20);
            this.txtPassSecond.TabIndex = 13;
            // 
            // txtPassMain
            // 
            this.txtPassMain.Location = new System.Drawing.Point(661, 78);
            this.txtPassMain.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtPassMain.Name = "txtPassMain";
            this.txtPassMain.PasswordChar = '*';
            this.txtPassMain.Size = new System.Drawing.Size(174, 20);
            this.txtPassMain.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(569, 81);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(22, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "رمز";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(841, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "نام سرور اصلی";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(564, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "نام سرور دوم";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(579, 53);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "نام کاربری";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(841, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "نام کاربری";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(849, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(22, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "رمز";
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(21, 42);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(75, 23);
            this.btnExport.TabIndex = 31;
            this.btnExport.Text = "اکسپورت";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvTableInfo);
            this.groupBox2.Controls.Add(this.lstBxReport);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.cmbDBSecond);
            this.groupBox2.Controls.Add(this.lblDBName);
            this.groupBox2.Controls.Add(this.cmbDBMain);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.lstBxColumnSecond);
            this.groupBox2.Controls.Add(this.lstBxTableSecond);
            this.groupBox2.Controls.Add(this.lstBxColumnMain);
            this.groupBox2.Controls.Add(this.lstBxTableMain);
            this.groupBox2.Controls.Add(this.btnExport);
            this.groupBox2.Location = new System.Drawing.Point(12, 126);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox2.Size = new System.Drawing.Size(926, 364);
            this.groupBox2.TabIndex = 32;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Export";
            // 
            // dgvTableInfo
            // 
            this.dgvTableInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTableInfo.Location = new System.Drawing.Point(10, 208);
            this.dgvTableInfo.Name = "dgvTableInfo";
            this.dgvTableInfo.Size = new System.Drawing.Size(346, 150);
            this.dgvTableInfo.TabIndex = 47;
            // 
            // lstBxReport
            // 
            this.lstBxReport.FormattingEnabled = true;
            this.lstBxReport.Location = new System.Drawing.Point(10, 94);
            this.lstBxReport.Name = "lstBxReport";
            this.lstBxReport.Size = new System.Drawing.Size(166, 212);
            this.lstBxReport.TabIndex = 46;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(446, 23);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(26, 13);
            this.label7.TabIndex = 45;
            this.label7.Text = "بانک";
            // 
            // cmbDBSecond
            // 
            this.cmbDBSecond.FormattingEnabled = true;
            this.cmbDBSecond.Location = new System.Drawing.Point(182, 20);
            this.cmbDBSecond.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbDBSecond.Name = "cmbDBSecond";
            this.cmbDBSecond.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmbDBSecond.Size = new System.Drawing.Size(250, 21);
            this.cmbDBSecond.TabIndex = 44;
            this.cmbDBSecond.SelectedIndexChanged += new System.EventHandler(this.cmbDBSecond_SelectedIndexChanged);
            // 
            // lblDBName
            // 
            this.lblDBName.AutoSize = true;
            this.lblDBName.Location = new System.Drawing.Point(849, 23);
            this.lblDBName.Name = "lblDBName";
            this.lblDBName.Size = new System.Drawing.Size(26, 13);
            this.lblDBName.TabIndex = 43;
            this.lblDBName.Text = "بانک";
            // 
            // cmbDBMain
            // 
            this.cmbDBMain.FormattingEnabled = true;
            this.cmbDBMain.Location = new System.Drawing.Point(585, 20);
            this.cmbDBMain.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbDBMain.Name = "cmbDBMain";
            this.cmbDBMain.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmbDBMain.Size = new System.Drawing.Size(250, 21);
            this.cmbDBMain.TabIndex = 42;
            this.cmbDBMain.SelectedIndexChanged += new System.EventHandler(this.cmbDBMain_SelectedIndexChanged);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(463, 241);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(47, 13);
            this.label15.TabIndex = 41;
            this.label15.Text = "ستون ها";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(463, 115);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(35, 13);
            this.label14.TabIndex = 40;
            this.label14.Text = "جداول";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(849, 241);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(47, 13);
            this.label13.TabIndex = 39;
            this.label13.Text = "ستون ها";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(849, 115);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(35, 13);
            this.label12.TabIndex = 38;
            this.label12.Text = "جداول";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(463, 54);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(51, 13);
            this.label11.TabIndex = 37;
            this.label11.Text = "سرور دوم";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(849, 54);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(60, 13);
            this.label10.TabIndex = 36;
            this.label10.Text = "سرور اصلی";
            // 
            // lstBxColumnSecond
            // 
            this.lstBxColumnSecond.FormattingEnabled = true;
            this.lstBxColumnSecond.Location = new System.Drawing.Point(182, 189);
            this.lstBxColumnSecond.Name = "lstBxColumnSecond";
            this.lstBxColumnSecond.Size = new System.Drawing.Size(250, 121);
            this.lstBxColumnSecond.TabIndex = 35;
            // 
            // lstBxTableSecond
            // 
            this.lstBxTableSecond.FormattingEnabled = true;
            this.lstBxTableSecond.Location = new System.Drawing.Point(182, 60);
            this.lstBxTableSecond.Name = "lstBxTableSecond";
            this.lstBxTableSecond.Size = new System.Drawing.Size(250, 121);
            this.lstBxTableSecond.TabIndex = 34;
            this.lstBxTableSecond.SelectedIndexChanged += new System.EventHandler(this.lstBxTableSecond_SelectedIndexChanged);
            // 
            // lstBxColumnMain
            // 
            this.lstBxColumnMain.FormattingEnabled = true;
            this.lstBxColumnMain.Location = new System.Drawing.Point(585, 189);
            this.lstBxColumnMain.Name = "lstBxColumnMain";
            this.lstBxColumnMain.Size = new System.Drawing.Size(250, 121);
            this.lstBxColumnMain.TabIndex = 33;
            // 
            // lstBxTableMain
            // 
            this.lstBxTableMain.FormattingEnabled = true;
            this.lstBxTableMain.Location = new System.Drawing.Point(585, 60);
            this.lstBxTableMain.Name = "lstBxTableMain";
            this.lstBxTableMain.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lstBxTableMain.Size = new System.Drawing.Size(250, 121);
            this.lstBxTableMain.TabIndex = 32;
            this.lstBxTableMain.SelectedIndexChanged += new System.EventHandler(this.lstBxTableMain_SelectedIndexChanged);
            // 
            // frmExportData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(949, 502);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.grbSvrConn);
            this.Name = "frmExportData";
            this.Text = "ExportData";
            this.Load += new System.EventHandler(this.ExportData_Load);
            this.grbSvrConn.ResumeLayout(false);
            this.grbSvrConn.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTableInfo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grbSvrConn;
        private System.Windows.Forms.ComboBox cmbServerSecond;
        private System.Windows.Forms.ComboBox cmbServerMain;
        private System.Windows.Forms.TextBox txtUserSecond;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.TextBox txtUserMain;
        private System.Windows.Forms.TextBox txtPassSecond;
        private System.Windows.Forms.TextBox txtPassMain;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ListBox lstBxColumnSecond;
        private System.Windows.Forms.ListBox lstBxTableSecond;
        private System.Windows.Forms.ListBox lstBxColumnMain;
        private System.Windows.Forms.ListBox lstBxTableMain;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbDBSecond;
        private System.Windows.Forms.Label lblDBName;
        private System.Windows.Forms.ComboBox cmbDBMain;
        private System.Windows.Forms.ListBox lstBxReport;
        private System.Windows.Forms.DataGridView dgvTableInfo;
    }
}