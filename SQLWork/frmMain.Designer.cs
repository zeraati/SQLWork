namespace SqlWork
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.btnConnect = new System.Windows.Forms.Button();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.cmbServer = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbDB = new System.Windows.Forms.ComboBox();
            this.chbRemember = new System.Windows.Forms.CheckBox();
            this.grbSvrConn = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lstbxColumn = new System.Windows.Forms.ListBox();
            this.lstbxTable = new System.Windows.Forms.ListBox();
            this.btnRun = new System.Windows.Forms.Button();
            this.lstbxReport = new System.Windows.Forms.ListBox();
            this.checkbxSelectAllColumn = new System.Windows.Forms.CheckBox();
            this.checkbxSelectAllTable = new System.Windows.Forms.CheckBox();
            this.lstbxWorks = new System.Windows.Forms.ListBox();
            this.lstbxSecendTable = new System.Windows.Forms.ListBox();
            this.dgvResult = new System.Windows.Forms.DataGridView();
            this.lblDBName = new System.Windows.Forms.Label();
            this.cmbWork = new System.Windows.Forms.ComboBox();
            this.lstbxSecendColumn = new System.Windows.Forms.ListBox();
            this.btnCopy = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnExcel = new System.Windows.Forms.Button();
            this.grbSvrConn.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResult)).BeginInit();
            this.SuspendLayout();
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(6, 21);
            this.btnConnect.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(103, 27);
            this.btnConnect.TabIndex = 7;
            this.btnConnect.Text = "اتصال (Ctrl+R)";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(428, 21);
            this.txtUser.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(174, 27);
            this.txtUser.TabIndex = 2;
            // 
            // txtPass
            // 
            this.txtPass.Location = new System.Drawing.Point(215, 21);
            this.txtPass.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtPass.Name = "txtPass";
            this.txtPass.PasswordChar = '*';
            this.txtPass.Size = new System.Drawing.Size(174, 27);
            this.txtPass.TabIndex = 3;
            // 
            // cmbServer
            // 
            this.cmbServer.FormattingEnabled = true;
            this.cmbServer.Location = new System.Drawing.Point(694, 21);
            this.cmbServer.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.cmbServer.Name = "cmbServer";
            this.cmbServer.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmbServer.Size = new System.Drawing.Size(174, 27);
            this.cmbServer.TabIndex = 1;
            this.cmbServer.SelectedIndexChanged += new System.EventHandler(this.cmbServer_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(869, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 20);
            this.label1.TabIndex = 8;
            this.label1.Text = "نام سرور";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(608, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 20);
            this.label2.TabIndex = 9;
            this.label2.Text = "نام کاربری";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(395, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(23, 20);
            this.label3.TabIndex = 10;
            this.label3.Text = "رمز";
            // 
            // cmbDB
            // 
            this.cmbDB.FormattingEnabled = true;
            this.cmbDB.Location = new System.Drawing.Point(79, 89);
            this.cmbDB.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.cmbDB.Name = "cmbDB";
            this.cmbDB.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmbDB.Size = new System.Drawing.Size(174, 27);
            this.cmbDB.TabIndex = 5;
            this.cmbDB.SelectedIndexChanged += new System.EventHandler(this.cmbDB_SelectedIndexChanged);
            // 
            // chbRemember
            // 
            this.chbRemember.AutoSize = true;
            this.chbRemember.Location = new System.Drawing.Point(152, 24);
            this.chbRemember.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.chbRemember.Name = "chbRemember";
            this.chbRemember.Size = new System.Drawing.Size(55, 24);
            this.chbRemember.TabIndex = 6;
            this.chbRemember.Text = "ذخیره";
            this.chbRemember.UseVisualStyleBackColor = true;
            // 
            // grbSvrConn
            // 
            this.grbSvrConn.Controls.Add(this.button2);
            this.grbSvrConn.Controls.Add(this.cmbServer);
            this.grbSvrConn.Controls.Add(this.btnConnect);
            this.grbSvrConn.Controls.Add(this.txtUser);
            this.grbSvrConn.Controls.Add(this.txtPass);
            this.grbSvrConn.Controls.Add(this.label1);
            this.grbSvrConn.Controls.Add(this.chbRemember);
            this.grbSvrConn.Controls.Add(this.label2);
            this.grbSvrConn.Controls.Add(this.label3);
            this.grbSvrConn.Location = new System.Drawing.Point(12, 10);
            this.grbSvrConn.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.grbSvrConn.Name = "grbSvrConn";
            this.grbSvrConn.Padding = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.grbSvrConn.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.grbSvrConn.Size = new System.Drawing.Size(926, 62);
            this.grbSvrConn.TabIndex = 28;
            this.grbSvrConn.TabStop = false;
            this.grbSvrConn.Text = "Server Conn";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(608, -1);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 11;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(208, 135);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 20);
            this.label4.TabIndex = 12;
            this.label4.Text = "ستون";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(21, 135);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 20);
            this.label5.TabIndex = 12;
            this.label5.Text = "جدول";
            // 
            // lstbxColumn
            // 
            this.lstbxColumn.FormattingEnabled = true;
            this.lstbxColumn.ItemHeight = 19;
            this.lstbxColumn.Location = new System.Drawing.Point(211, 163);
            this.lstbxColumn.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.lstbxColumn.Name = "lstbxColumn";
            this.lstbxColumn.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lstbxColumn.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lstbxColumn.Size = new System.Drawing.Size(174, 517);
            this.lstbxColumn.Sorted = true;
            this.lstbxColumn.TabIndex = 36;
            // 
            // lstbxTable
            // 
            this.lstbxTable.FormattingEnabled = true;
            this.lstbxTable.ItemHeight = 19;
            this.lstbxTable.Location = new System.Drawing.Point(25, 163);
            this.lstbxTable.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.lstbxTable.Name = "lstbxTable";
            this.lstbxTable.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lstbxTable.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lstbxTable.Size = new System.Drawing.Size(174, 517);
            this.lstbxTable.Sorted = true;
            this.lstbxTable.TabIndex = 36;
            this.lstbxTable.SelectedIndexChanged += new System.EventHandler(this.lstbxTable_SelectedIndexChanged);
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(416, 395);
            this.btnRun.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(87, 29);
            this.btnRun.TabIndex = 7;
            this.btnRun.Text = "اجرا";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // lstbxReport
            // 
            this.lstbxReport.FormattingEnabled = true;
            this.lstbxReport.HorizontalScrollbar = true;
            this.lstbxReport.ItemHeight = 19;
            this.lstbxReport.Items.AddRange(new object[] {
            "********************    Report    **********************",
            "============================================"});
            this.lstbxReport.Location = new System.Drawing.Point(614, 78);
            this.lstbxReport.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.lstbxReport.Name = "lstbxReport";
            this.lstbxReport.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lstbxReport.Size = new System.Drawing.Size(324, 346);
            this.lstbxReport.TabIndex = 31;
            // 
            // checkbxSelectAllColumn
            // 
            this.checkbxSelectAllColumn.AutoSize = true;
            this.checkbxSelectAllColumn.Location = new System.Drawing.Point(302, 133);
            this.checkbxSelectAllColumn.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.checkbxSelectAllColumn.Name = "checkbxSelectAllColumn";
            this.checkbxSelectAllColumn.Size = new System.Drawing.Size(86, 24);
            this.checkbxSelectAllColumn.TabIndex = 32;
            this.checkbxSelectAllColumn.Text = "انتخاب همه";
            this.checkbxSelectAllColumn.UseVisualStyleBackColor = true;
            this.checkbxSelectAllColumn.CheckedChanged += new System.EventHandler(this.checkbxSelectAllColumn_CheckedChanged);
            // 
            // checkbxSelectAllTable
            // 
            this.checkbxSelectAllTable.AutoSize = true;
            this.checkbxSelectAllTable.Location = new System.Drawing.Point(115, 133);
            this.checkbxSelectAllTable.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.checkbxSelectAllTable.Name = "checkbxSelectAllTable";
            this.checkbxSelectAllTable.Size = new System.Drawing.Size(86, 24);
            this.checkbxSelectAllTable.TabIndex = 32;
            this.checkbxSelectAllTable.Text = "انتخاب همه";
            this.checkbxSelectAllTable.UseVisualStyleBackColor = true;
            this.checkbxSelectAllTable.CheckedChanged += new System.EventHandler(this.checkbxSelectAllTable_CheckedChanged);
            // 
            // lstbxWorks
            // 
            this.lstbxWorks.FormattingEnabled = true;
            this.lstbxWorks.ItemHeight = 19;
            this.lstbxWorks.Items.AddRange(new object[] {
            "DeletTable",
            "CheckUniqColumn",
            "GetUniqData",
            "DropColumn",
            "JoinTwoTable",
            "JoinTwoTableIntoNewTable",
            "RenameTable",
            "RenameColumn",
            "ReportDataBase",
            "ReportServer",
            "ReportDataBaseValue",
            "DistinctColumn",
            "DistinctTable"});
            this.lstbxWorks.Location = new System.Drawing.Point(416, 80);
            this.lstbxWorks.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.lstbxWorks.Name = "lstbxWorks";
            this.lstbxWorks.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lstbxWorks.Size = new System.Drawing.Size(191, 308);
            this.lstbxWorks.TabIndex = 33;
            this.lstbxWorks.SelectedIndexChanged += new System.EventHandler(this.lstbxWorks_SelectedIndexChanged);
            // 
            // lstbxSecendTable
            // 
            this.lstbxSecendTable.FormattingEnabled = true;
            this.lstbxSecendTable.ItemHeight = 19;
            this.lstbxSecendTable.Location = new System.Drawing.Point(25, 429);
            this.lstbxSecendTable.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.lstbxSecendTable.Name = "lstbxSecendTable";
            this.lstbxSecendTable.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lstbxSecendTable.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lstbxSecendTable.Size = new System.Drawing.Size(174, 251);
            this.lstbxSecendTable.Sorted = true;
            this.lstbxSecendTable.TabIndex = 31;
            this.lstbxSecendTable.SelectedIndexChanged += new System.EventHandler(this.lstbxSecendTable_SelectedIndexChanged);
            // 
            // dgvResult
            // 
            this.dgvResult.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResult.Location = new System.Drawing.Point(416, 433);
            this.dgvResult.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.dgvResult.Name = "dgvResult";
            this.dgvResult.RowHeadersVisible = false;
            this.dgvResult.Size = new System.Drawing.Size(522, 273);
            this.dgvResult.TabIndex = 37;
            // 
            // lblDBName
            // 
            this.lblDBName.AutoSize = true;
            this.lblDBName.Location = new System.Drawing.Point(41, 93);
            this.lblDBName.Name = "lblDBName";
            this.lblDBName.Size = new System.Drawing.Size(32, 20);
            this.lblDBName.TabIndex = 12;
            this.lblDBName.Text = "بانک";
            this.lblDBName.Click += new System.EventHandler(this.lblDBName_Click);
            // 
            // cmbWork
            // 
            this.cmbWork.FormattingEnabled = true;
            this.cmbWork.Location = new System.Drawing.Point(416, 351);
            this.cmbWork.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.cmbWork.Name = "cmbWork";
            this.cmbWork.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmbWork.Size = new System.Drawing.Size(191, 27);
            this.cmbWork.TabIndex = 5;
            // 
            // lstbxSecendColumn
            // 
            this.lstbxSecendColumn.FormattingEnabled = true;
            this.lstbxSecendColumn.ItemHeight = 19;
            this.lstbxSecendColumn.Location = new System.Drawing.Point(211, 429);
            this.lstbxSecendColumn.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.lstbxSecendColumn.Name = "lstbxSecendColumn";
            this.lstbxSecendColumn.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lstbxSecendColumn.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lstbxSecendColumn.Size = new System.Drawing.Size(174, 251);
            this.lstbxSecendColumn.Sorted = true;
            this.lstbxSecendColumn.TabIndex = 31;
            // 
            // btnCopy
            // 
            this.btnCopy.Enabled = false;
            this.btnCopy.Location = new System.Drawing.Point(509, 395);
            this.btnCopy.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(45, 29);
            this.btnCopy.TabIndex = 38;
            this.btnCopy.Text = "کوئری";
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Image")));
            this.btnRefresh.Location = new System.Drawing.Point(259, 89);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(30, 27);
            this.btnRefresh.TabIndex = 7;
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(302, 88);
            this.btnExport.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(56, 27);
            this.btnExport.TabIndex = 39;
            this.btnExport.Text = "اکسل";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(364, 91);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(49, 23);
            this.button1.TabIndex = 40;
            this.button1.Text = "Stnd";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnExcel
            // 
            this.btnExcel.Location = new System.Drawing.Point(560, 394);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(47, 30);
            this.btnExcel.TabIndex = 41;
            this.btnExcel.Text = "اکسل";
            this.btnExcel.UseVisualStyleBackColor = true;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(950, 713);
            this.Controls.Add(this.btnExcel);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.btnCopy);
            this.Controls.Add(this.checkbxSelectAllTable);
            this.Controls.Add(this.checkbxSelectAllColumn);
            this.Controls.Add(this.lstbxReport);
            this.Controls.Add(this.lstbxTable);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnRun);
            this.Controls.Add(this.grbSvrConn);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblDBName);
            this.Controls.Add(this.cmbDB);
            this.Controls.Add(this.dgvResult);
            this.Controls.Add(this.lstbxSecendTable);
            this.Controls.Add(this.lstbxWorks);
            this.Controls.Add(this.cmbWork);
            this.Controls.Add(this.lstbxColumn);
            this.Controls.Add(this.lstbxSecendColumn);
            this.Font = new System.Drawing.Font("IRANSans", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "frmMain";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "کار با اس کیو ال";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.grbSvrConn.ResumeLayout(false);
            this.grbSvrConn.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResult)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.TextBox txtPass;
        private System.Windows.Forms.ComboBox cmbServer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbDB;
        private System.Windows.Forms.CheckBox chbRemember;
        private System.Windows.Forms.GroupBox grbSvrConn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListBox lstbxColumn;
        private System.Windows.Forms.ListBox lstbxTable;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.ListBox lstbxReport;
        private System.Windows.Forms.CheckBox checkbxSelectAllColumn;
        private System.Windows.Forms.CheckBox checkbxSelectAllTable;
        private System.Windows.Forms.ListBox lstbxWorks;
        private System.Windows.Forms.ListBox lstbxSecendTable;
        private System.Windows.Forms.DataGridView dgvResult;
        private System.Windows.Forms.Label lblDBName;
        private System.Windows.Forms.ComboBox cmbWork;
        private System.Windows.Forms.ListBox lstbxSecendColumn;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnExcel;
    }
}

