using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Microsoft.SqlServer.Management.Common;
using PersiaSL;
using System.Text.RegularExpressions;
using System.Data.SqlClient;
using System.Diagnostics;
using SQLWork;
using static System.Environment;
using Excel = Microsoft.Office.Interop.Excel;

namespace SqlWork
{
    public partial class frmMain : Form
    {
        DataTable dtExport;
        string CopyQuery = "";
        string strPathLoginFolder = @"..\Login.pos";
        List<string> lstAllDataBases;

        Functions functions = new Functions();
        SqlConnection sqlCon = new SqlConnection();


        public frmMain()
        { InitializeComponent(); }

        #region form load

        private void frmMain_Load(object sender, EventArgs e)
        {
            //  install font


            string fontName = "IRANSans";
            using (Font fontTester = new Font(fontName, 12, FontStyle.Regular, GraphicsUnit.Pixel))
            {
                if (fontTester.Name != fontName)
                { File.Copy("IRANSans.ttf", Path.Combine(GetFolderPath(SpecialFolder.Windows), "Fonts", "IRANSans.ttf")); }
            }



            cmbServer.DataSource = functions.ListServerName(strPathLoginFolder);


            //*********** defult!!!!!!
            cmbServer.Text = @"172.22.77.61";
            btnConnect_Click(null, null);
        }
        #endregion


        #region cmb change server
        private void cmbServer_SelectedIndexChanged(object sender, EventArgs e)
        {
            //  server
            string strServer = cmbServer.Text;

            // server info ==> server , user , pass
            List<string> lstServerInfo = new List<string>();


            //  get server info
            lstServerInfo = functions.ServerUserPass(strPathLoginFolder, strServer);
            txtUser.Text = lstServerInfo[1];
            txtPass.Text = lstServerInfo[2];
        }
        #endregion


        #region btn connect
        private void btnConnect_Click(object sender, EventArgs e)
        {

            // get server info ==> server , user , pass
            string strServer = cmbServer.Text, strUser = txtUser.Text, strPass = txtPass.Text;


            //  create sql connection
            sqlCon = functions.SqlConnect(strServer, strUser, strPass);


            //  test sql connection //  result yes
            if (functions.TestConn(sqlCon))
            {

                #region save login info with encrypt pass

                //  save login info with encrypt pass
                if (chbRemember.CheckState == CheckState.Checked)
                {
                    //  encrypt pass
                    string strPassEncrypt = CryptorEngine.Encrypt(strPass, true);

                    List<string> lst = functions.ReadTxt(strPathLoginFolder);


                    //  save login when login file info is empty
                    if (File.ReadAllText(strPathLoginFolder) == "")
                    { File.WriteAllText(strPathLoginFolder, strServer + "," + strUser + "," + strPassEncrypt); }


                    //  save or replace login when login file info is not empty
                    if (File.ReadAllText(strPathLoginFolder) != "")
                    {
                        int intFind = functions.ListFind(lst, strServer);

                        if (intFind != -1)
                        {
                            lst[intFind] = strServer + "," + strUser + "," + strPassEncrypt;
                            functions.SaveListToText(lst, strPathLoginFolder);
                        }

                        else File.WriteAllText(strPathLoginFolder, File.ReadAllText(strPathLoginFolder) + "\r\n" + strServer + "," + strUser + "," + strPassEncrypt);
                    }

                    //  load server name
                    cmbServer.DataSource = functions.ListServerName(strPathLoginFolder);
                }

                #endregion


                //  load all database name  // set source cmbDBNames 
                functions.ComboBoxSource(cmbDB, functions.SqlGetDBName(sqlCon));

                // list of all database name 
                lstAllDataBases = functions.DataTableToList(functions.SqlGetDBName(sqlCon));


                // set btnConnect text
                btnConnect.Text = "اتصال مجدد";
            }


            //  test sql connection //  result no
            else
            { btnConnect.Text = "اتصال"; MessageBox.Show("عدم برقراری ارتباط", "!هشدار"); }


            //*********** defult!!!!!!

            cmbDB.Text = "_Main";
        }
        #endregion


        #region btnExport_Click
        private void btnExport_Click(object sender, EventArgs e)
        {
            frmExport frmExportData = new frmExport();
            frmExportData.ShowDialog();
        }
        #endregion


        #region cmbDB_SelectedIndexChanged
        private void cmbDB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbDB.Text != "System.Data.DataRowView")
            {
                //  change db
                sqlCon = functions.SqlConnectionChangeDB(sqlCon, cmbDB.Text);

                //set tale name source
                lstbxTable.DataSource = functions.SqlTableName(sqlCon);
                lstbxSecendTable.DataSource = functions.SqlTableName(sqlCon);

                // unchecked selected all
                checkbxSelectAllTable.Checked = checkbxSelectAllColumn.Checked = false;
            }
        }
        #endregion



        #region btnRefresh_Click
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            string strDatabase = cmbDB.Text;
            cmbDB_SelectedIndexChanged(null, null);
            cmbDB.Text = strDatabase;
        }
        #endregion


        #region lstbxTable_SelectedIndexChanged

        //  change first table
        private void lstbxTable_SelectedIndexChanged(object sender, EventArgs e)
        {

            // uncheck selected all
            checkbxSelectAllColumn.Checked = false;


            TableSelectedIndexChanged(sqlCon, lstbxTable, lstbxColumn);


            //  show selected table in dgv
            if (lstbxTable.GetItemText(lstbxTable.SelectedItem) != "" && cmbDB.Text != "Najah")
            {
                string strTableName = lstbxTable.GetItemText(lstbxTable.SelectedItem);
                string strQuery = "SELECT TOP 200 * FROM [" + strTableName + "]";
                dgvResult.DataSource = functions.SqlDataAdapter(sqlCon, strQuery, "SqlDataAdapter", strTableName);
            }

        }

        //  change secend table
        private void lstbxSecendTable_SelectedIndexChanged(object sender, EventArgs e)
        {
            checkbxSelectAllColumn.Checked = false;

            TableSelectedIndexChanged(sqlCon, lstbxSecendTable, lstbxSecendColumn);
        }
        #endregion



        #region lstbxWorks_SelectedIndexChanged
        private void lstbxWorks_SelectedIndexChanged(object sender, EventArgs e)
        {
            // get work
            string strWork = lstbxWorks.GetItemText(lstbxWorks.SelectedItem);

            // get table
            string strTable = lstbxTable.GetItemText(lstbxTable.SelectedItem);

            // get column
            string strColumn = lstbxTable.GetItemText(lstbxColumn.SelectedItem);


            #region JoinTable
            if (strWork == "JoinTwoTable" || strWork == "JoinTwoTableIntoNewTable")
            {
                lstbxWorks.Height = lstbxTable.Height = lstbxColumn.Height = 251;

                cmbWork.DataSource = functions.SqlColumns(sqlCon, strTable);
            }
            #endregion


            #region RenameTable & RenameColumn
            else if (strWork == "RenameTable" || strWork == "RenameColumn")
            {
                if (strWork == "RenameTable") { cmbWork.Text = strTable; }

                if (strWork == "RenameColumn") { cmbWork.Text = strColumn; }


                lstbxWorks.Height = 251;
                lstbxTable.Height = lstbxColumn.Height = 517;
            }
            #endregion


            #region else // defult

            else
            {
                lstbxTable.Height = lstbxColumn.Height = 517;
                lstbxWorks.Height = 308;
            }

            #endregion

        }
        #endregion



        #region btnRun_Click    

        private void btnRun_Click(object sender, EventArgs e)
        {
            this.Enabled = false; this.Cursor = Cursors.WaitCursor;

            //  get all selected items text from lstbxWorks
            List<string> lstSelectedWorks = functions.GetSelectedItemsText(lstbxWorks);

            if (lstSelectedWorks.Count > 0)
            {
                //  get all selected items text from lstbxTable
                List<string> lstSelectedTable = functions.GetSelectedItemsText(lstbxTable);
                List<string> lstSelectedSeceendTable = functions.GetSelectedItemsText(lstbxSecendTable);

                //  get all selected items text from lstbxColumn
                List<string> lstSelectedColumn = functions.GetSelectedItemsText(lstbxColumn);
                List<string> lstSelectedSecendColumn = functions.GetSelectedItemsText(lstbxSecendColumn);

                string strDataBase = cmbDB.Text;
                string strWork = lstSelectedWorks[0];
                string strTable = lstbxTable.GetItemText(lstbxTable.SelectedItem);
                string strSecendTable = lstbxSecendTable.GetItemText(lstbxSecendTable.SelectedItem);
                string strColumn = lstbxColumn.GetItemText(lstbxColumn.SelectedItem);

                DeletTable(strWork, lstSelectedTable);

                CheckUniqColumn(strWork, strTable, lstSelectedColumn);

                GetUniqData(strWork, sqlCon, strTable, strColumn);

                DropColumn(strWork, strTable, lstSelectedColumn);

                JoinTwoTable(strWork, strTable, strSecendTable, cmbWork.Text, lstSelectedColumn, lstSelectedSecendColumn);

                RenameTable(strWork, strTable, cmbWork.Text);

                RenameColumn(strWork, strTable, strColumn, cmbWork.Text);

                ReportDataBase(strWork, strDataBase);

                ReportServer(strWork);

                DistinctTable(strWork,strTable, strDataBase);

                DistinctColumn(strWork, strColumn, strTable, strDataBase);

                dgvResult.DataSource = dtExport;
            }

            //  go end in lstbxReport
            lstbxReport.TopIndex = lstbxReport.Items.Count - 1;


            // enable btn copy
            if (CopyQuery != "") { btnCopy.Enabled = true; }
            else { btnCopy.Enabled = false; }

            this.Enabled = true; this.Cursor = Cursors.Default;

        }
        #endregion


        #region btn copy
        private void btnCopy_Click(object sender, EventArgs e)
        {
            if (CopyQuery != "")
            {
                //  copy to cliboard
                Clipboard.SetText(CopyQuery);

                MessageBox.Show(CopyQuery);

                // change btnCopy text
                btnCopy.Text = "کپی";

                // create timer for change btnCopy text
                Timer t = new Timer();
                t.Interval = 1500;
                t.Enabled = true;
                t.Tick += new System.EventHandler(OnTimerEvent);
            }
        }

        // event for timer
        private void OnTimerEvent(object sender, EventArgs e)
        { btnCopy.Text = "کوئری"; }
        #endregion


        #region SelectAllTable
        private void checkbxSelectAllTable_CheckedChanged(object sender, EventArgs e)
        { SelectAllWithRollBack(checkbxSelectAllTable.Checked, lstbxTable); }

        private void checkbxSelectAllColumn_CheckedChanged(object sender, EventArgs e)
        { SelectAllWithRollBack(checkbxSelectAllColumn.Checked, lstbxColumn); }
        #endregion


        //**********************************************************************************
        //**********************************************************************************
        //**********************************************************************************
        //**********************************************************************************
        //**********************************************************************************


        #region TableSelectedIndexChanged

        private void TableSelectedIndexChanged(SqlConnection sqlConnection, ListBox lstbxTable, ListBox lstbxColumn)
        {
            string strWork = lstbxWorks.GetItemText(lstbxWorks.SelectedItem);
            string strTable = lstbxTable.GetItemText(lstbxTable.SelectedItem);


            // lstbxColumn source
            lstbxColumn.DataSource = functions.SqlColumns(sqlConnection, strTable);




        }

        #endregion


        #region SelectAllWithRollBack

        List<int> lstSelectedIndex = new List<int>();
        private void SelectAllWithRollBack(bool bolCheckAll, ListBox listBox)
        {

            //  select all
            if (bolCheckAll == true)
            {
                //  for roll back
                foreach (var item in listBox.SelectedItems)
                { lstSelectedIndex.Add(listBox.Items.IndexOf(item)); }

                //  select all
                for (int i = 0; i < listBox.Items.Count; i++)
                { listBox.SetSelected(i, true); }
            }



            // select roll back
            else
            {
                //  unselect all
                for (int i = 0; i < listBox.Items.Count; i++)
                    listBox.SetSelected(i, false);

                //  roll back
                for (int i = 0; i < lstSelectedIndex.Count; i++)
                    listBox.SetSelected(lstSelectedIndex[i], true);

                // clear roll back items
                lstSelectedIndex.Clear();
            }
        }

        #endregion


        #region DeletTable
        public void DeletTable(string Work, List<string> lstSelectedTable)
        {
            if (Work == "DeletTable")
            {
                string strTablesName = "";

                for (int i = 0; i < lstSelectedTable.Count; i++)
                { strTablesName = strTablesName + ("  ** " + lstSelectedTable[i] + "  ** "); }

                DialogResult dr = MessageBox.Show("Delete Table" + strTablesName, "confirm delete", MessageBoxButtons.YesNo);

                if (dr == DialogResult.Yes)
                {
                    for (int i = 0; i < lstSelectedTable.Count; i++)
                    { lstbxReport.Items.Add(functions.SqlDelTable(sqlCon, lstSelectedTable[i])); }
                }

                lstbxReport.Items.Add("");

                btnRefresh_Click(null, null);
            }
        }
        #endregion


        #region CheckUniqColumn
        public void CheckUniqColumn(string strWork, string strTable, List<string> lstSelectedColumn)
        {
            if (strWork == "CheckUniqColumn")
            {
                string strQuery = "";

                for (int i = 0; i < lstSelectedColumn.Count; i++)
                { lstbxReport.Items.Add(functions.SqlCheckUniqColumn(sqlCon, strTable, lstSelectedColumn[i], out strQuery)); }

                lstbxReport.Items.Add("");

                CopyQuery = strQuery;
            }
        }
        #endregion


        #region GetUniqData
        public void GetUniqData(string strWork, SqlConnection sqlConnection, string strTable, string strColumn)
        {

            if (strWork == "GetUniqData")
            {
                string strQry, result;

                result = functions.SqlGetUniqData(sqlConnection, strTable, strColumn, out strQry);


                lstbxReport.Items.Add(result);
                lstbxReport.Items.Add("");

                CopyQuery = strQry;
            }
        }
        #endregion


        #region DropColumn
        public void DropColumn(string Work, string strTable, List<string> lstSelectedColumn)
        {

            if (Work == "DropColumn")
            {
                string strColumn = "", strQuery = "";

                for (int i = 0; i < lstSelectedColumn.Count; i++)
                { strColumn = strColumn + ("  ** " + lstSelectedColumn[i] + "  ** "); }

                DialogResult dr = MessageBox.Show("Drop Column" + strColumn, "confirm delete", MessageBoxButtons.YesNo);

                if (dr == DialogResult.Yes)
                {
                    for (int i = 0; i < lstSelectedColumn.Count; i++)
                    { lstbxReport.Items.Add(functions.SqlDropColumn(sqlCon, strTable, lstSelectedColumn[i], out strQuery)); }
                }

                lstbxReport.Items.Add("");
                CopyQuery = strQuery;
            }

        }
        #endregion


        #region JoinTwoTable
        public void JoinTwoTable(string strWork, string strFirstTable, string strSecendTable, string strJoinColumn, List<string> lstFirsTableColumn, List<string> lstSecendTableColumn)
        {
            DataTable dt = new DataTable();
            string strQuery = "";


            //  join table just show - its select
            if (strWork == "JoinTwoTable")
            { dt = functions.SqlJoin(sqlCon, strFirstTable, strSecendTable, strJoinColumn, lstFirsTableColumn, lstSecendTableColumn, out strQuery); }

            //  join table & create new table
            if (strWork == "JoinTwoTableIntoNewTable")
            { dt = functions.SqlJoin(sqlCon, strFirstTable, strSecendTable, strJoinColumn, lstFirsTableColumn, lstSecendTableColumn, out strQuery, true); }


            //  copy query
            if (strQuery != "") { CopyQuery = strQuery; }

            //  show result in data grid view
            dgvResult.DataSource = dt;
        }
        #endregion


        #region Rename


        public string RenameTable(string Work, string strOldName, string strNewName)
        {
            string strQuery = "", strResult = "";


            if (Work == "RenameTable")
            {
                //  rename
                strResult = functions.SqlRename(sqlCon, "Table", strOldName, strNewName, "", out strQuery);

                //  add report
                lstbxReport.Items.Add(strResult + strOldName + " => " + strNewName);
                lstbxReport.Items.Add("");

                CopyQuery = strQuery;
            }



            return strResult;
        }


        public string RenameColumn(string Work, string strTable, string strOldName, string strNewName)
        {
            string strQuery = "", strResult = "";

            if (Work == "RenameColumn")
            {
                //  rename
                strResult = functions.SqlRename(sqlCon, "Column", strOldName, strNewName, strTable, out strQuery);

                //  add report
                lstbxReport.Items.Add(strResult + " => " + strTable + strOldName + " => " + strNewName);
                lstbxReport.Items.Add("");

                CopyQuery = strQuery;
            }


            return strResult;
        }

        #endregion


        #region ReportDataBase

        public void ReportDataBase(string Work, string strDataBase)
        {
            DataTable dtReport = new DataTable();

            if (Work == "ReportDataBase")
            {

                dtReport.Columns.Add("پایگاه داده", typeof(string));//0
                dtReport.Columns.Add("جدول", typeof(string));//1
                dtReport.Columns.Add("ستون", typeof(string));//2
                dtReport.Columns.Add("کل", typeof(float));//3
                dtReport.Columns.Add("رکورد پر", typeof(float));//4
                dtReport.Columns.Add("رکورد خالی", typeof(float));//5
                dtReport.Columns.Add("درصد پر", typeof(float));//6
                dtReport.Columns.Add("درصد خالی", typeof(float));//7

                // change connection for evry databases and  list of all table for evry databases

                // change conection db
                SqlConnection sqlCN = sqlCon;
                functions.SqlConnectionChangeDB(sqlCN, strDataBase);


                // list of all table for this connection
                List<string> lstAllTables = functions.SqlTableName(sqlCN);


                // list of all column of every table
                int intCntTB = lstAllTables.Count;
                for (int j = 0; j < intCntTB; j++)
                {
                    //  list of all column of this table
                    List<string> lstAllcolumn = functions.SqlColumns(sqlCN, lstAllTables[j]);


                    // count empty recoreds for evry column
                    int intCntCL = lstAllcolumn.Count;
                    for (int k = 0; k < intCntCL; k++)
                    {
                        DataTable dt;

                        // count all recored for table
                        string qAllRows = "SELECT COUNT(*) FROM [" + lstAllTables[j] + "]";
                        float intAllRows = 0;

                        dt = functions.SqlDataAdapter(sqlCN, qAllRows);
                        if (dt.Rows.Count > 0)
                        {
                            if (!float.TryParse(dt.Rows[0][0].ToString(), out intAllRows))
                            { intAllRows = -99999; }
                        }


                        //  count all null rows from table
                        string qNullRows = "SELECT COUNT(*) FROM" +
                        " (SELECT * FROM [" + lstAllTables[j] + "] WHERE [" + lstAllcolumn[k] + "] IS NULL OR RTRIM(LTRIM([" + lstAllcolumn[k] + "])) = '')a";
                        float intNullRows = 0;

                        dt = functions.SqlDataAdapter(sqlCN, qNullRows);

                        if (dt.Rows.Count > 0)
                        {
                            if (!float.TryParse(dt.Rows[0][0].ToString(), out intNullRows))
                            { intNullRows = -99999; }
                        }


                        // add new rows
                        DataRow dr = dtReport.NewRow();

                        dr[0] = strDataBase;
                        dr[1] = lstAllTables[j];
                        dr[2] = lstAllcolumn[k];
                        dr[3] = intAllRows;
                        dr[4] = intNullRows;
                        dr[5] = intAllRows - intNullRows;
                        if (intAllRows > 0)
                        {
                            float a = (intAllRows - intNullRows) / intAllRows;
                            float b = intNullRows / intAllRows;

                            dr[6] = (intAllRows - intNullRows) / intAllRows;
                            dr[7] = intNullRows / intAllRows;
                        }

                        dtReport.Rows.Add(dr);
                    }
                }

                dtExport = dtReport;                
            }
        }

        #endregion


        #region DistinctColumn
        public void DistinctColumn(string Work, string strColumn, string strTable, string strDataBase)
        {
            DataTable dt;

            if (Work == "DistinctColumn")
            {
                functions.SqlConnectionChangeDB(sqlCon, strDataBase);
               
                dt = functions.ListToDataTable(functions.DistinctColumn(strColumn, strTable, sqlCon), strColumn);

                dtExport = dt;
            }
        }
        #endregion


        #region DistinctTable
        public void DistinctTable(string Work, string strTable, string strDataBase)
        {
            DataTable dt;

            if (Work == "DistinctTable")
            {
                functions.SqlConnectionChangeDB(sqlCon, strDataBase);

                dt=functions.DataTableRemoveEmptyCell( functions.DistinctTable(strTable, sqlCon));

                dtExport = dt;
            }
        }
        #endregion
       

        #region ReportServer
        public void ReportServer(string Work)
        {
        }
        #endregion


        #region cmbWorkSource

        public void cmbWorkSource()
        {
            string strWork = lstbxWorks.GetItemText(lstbxWorks.SelectedItem);
            string strTable = lstbxTable.GetItemText(lstbxTable.SelectedItem);


            //  cmbWork sorce
            if (strWork == "JoinTwoTable" || strWork == "JoinTwoTableIntoNewTable")
            { cmbWork.DataSource = functions.SqlColumns(sqlCon, strTable); }


            //  cmbWork sorce
            if (strWork == "RenameTable")
            {
                cmbWork.DataSource = functions.SqlTableName(sqlCon);
                cmbWork.Text = strTable;
            }

            //  cmbWork sorce
            if (strWork == "RenameColumn")
            { cmbWork.DataSource = functions.SqlColumns(sqlCon, strTable); }
        }




        #endregion

        private void lblDBName_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Enabled = false; Cursor = Cursors.WaitCursor;

         


            Enabled = true; Cursor = Cursors.Default;
        }

        private void button2_Click(object sender, EventArgs e)
        {


        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            Enabled = false;

            string strSavePatch, strTempePatch;
            //string strSavePatch = string.Format("{0}\\{1}.xlsx", Directory.GetCurrentDirectory(), strTable + "_Distinct");
            //string strTempePatch = string.Format("{0}\\tmpReportDistict.xlsx", Directory.GetCurrentDirectory());
            //dtExport.ExportToExcel(strSavePatch, strTable);


            //string strSavePatch = string.Format("{0}\\{1}.xlsx", Directory.GetCurrentDirectory(), strTable + "_Distinct");
            //string strTempePatch = string.Format("{0}\\tmpReportDistict.xlsx", Directory.GetCurrentDirectory());
            //dt.ExportToExcel(strSavePatch, strTable);

            
            strSavePatch = string.Format("{0}\\{1}.xlsx", Directory.GetCurrentDirectory(), "Export");
            strTempePatch = string.Format("{0}\\tmpDefult.xlsx", Directory.GetCurrentDirectory());
            dtExport.ExportToExcel(strSavePatch);

            Enabled = true;
        }
    }

}

