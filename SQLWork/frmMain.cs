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
using Persia;
using PersiaSL;
using System.Text.RegularExpressions;
using System.Data.SqlClient;
using System.Diagnostics;

namespace SqlWork
{
    public partial class frmMain : Form
    {
        string CopyQuery = "";
        string strPathLoginFolder = @"..\Login.pos";

        Functions func = new Functions();
        Dictionary<int, string> dicDBName = new Dictionary<int, string>();
        SqlConnection sqlCon = new SqlConnection();


        public frmMain()
        { InitializeComponent(); }

        #region form load

        private void frmMain_Load(object sender, EventArgs e)
        {

            cmbServer.DataSource = func.ListServerName(strPathLoginFolder);


            //*********** defult!!!!!!
            cmbServer.Text = @"172.20.18.53";
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
            lstServerInfo = func.ServerUserPass(strPathLoginFolder, strServer);
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
            sqlCon = func.SqlConnect(strServer, strUser, strPass);


            //  test sql connection //  result yes
            if (func.TestConn(sqlCon))
            {

                #region save login info with encrypt pass

                //  save login info with encrypt pass
                if (chbRemember.CheckState == CheckState.Checked)
                {
                    //  encrypt pass
                    string strPassEncrypt = CryptorEngine.Encrypt(strPass, true);

                    List<string> lst = func.ReadTxt(strPathLoginFolder);


                    //  save login when login file info is empty
                    if (File.ReadAllText(strPathLoginFolder) == "")
                    { File.WriteAllText(strPathLoginFolder, strServer + "," + strUser + "," + strPassEncrypt); }


                    //  save or replace login when login file info is not empty
                    if (File.ReadAllText(strPathLoginFolder) != "")
                    {
                        int intFind = func.ListFind(lst, strServer);

                        if (intFind != -1)
                        {
                            lst[intFind] = strServer + "," + strUser + "," + strPassEncrypt;
                            func.SaveListToText(lst, strPathLoginFolder);
                        }

                        else File.WriteAllText(strPathLoginFolder, File.ReadAllText(strPathLoginFolder) + "\r\n" + strServer + "," + strUser + "," + strPassEncrypt);
                    }

                    //  load server name
                    cmbServer.DataSource = func.ListServerName(strPathLoginFolder);
                }

                #endregion


                //  load database name  // set source cmbDBNames 
                func.ComboBoxSource(cmbDB, func.SqlGetDBName(sqlCon));


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


        #region cmb change db
        private void cmbDB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbDB.Text != "System.Data.DataRowView")
            {
                //  change db
                sqlCon = func.SqlConnectionChangeDB(sqlCon, cmbDB.Text);

                //set tale name source
                lstbxTable.DataSource = func.SqlTableName(sqlCon);
                lstbxSecendTable.DataSource = func.SqlTableName(sqlCon);

                // unchecked selected all
                checkbxSelectAllTable.Checked = checkbxSelectAllColumn.Checked = false;
            }
        }
        #endregion



        #region btn refresh
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            string strDatabase = cmbDB.Text;
            cmbDB_SelectedIndexChanged(null, null);
            cmbDB.Text = strDatabase;
        }
        #endregion


        #region lstbx change table

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
                dgvResult.DataSource = func.SqlDataAdapter(sqlCon, strQuery, "SqlDataAdapter", strTableName);
            }

        }

        //  change secend table
        private void lstbxSecendTable_SelectedIndexChanged(object sender, EventArgs e)
        {
            checkbxSelectAllColumn.Checked = false;

            TableSelectedIndexChanged(sqlCon, lstbxSecendTable, lstbxSecendColumn);
        }
        #endregion



        #region select work
        private void lstbxWorks_SelectedIndexChanged(object sender, EventArgs e)
        {
            string strWork = lstbxWorks.GetItemText(lstbxWorks.SelectedItem);
            string strTable = lstbxTable.GetItemText(lstbxTable.SelectedItem);
            string strColumn = lstbxTable.GetItemText(lstbxColumn.SelectedItem);

            #region JoinTable
            if (strWork == "JoinTwoTable" || strWork == "JoinTwoTableIntoNewTable")
            {
                lstbxWorks.Height = lstbxTable.Height = lstbxColumn.Height = 204;

                cmbWork.DataSource = func.SqlColumns(sqlCon, strTable);
            }
            #endregion


            #region RenameTable & RenameColumn
            else if (strWork == "RenameTable" || strWork == "RenameColumn")
            {
                if (strWork == "RenameTable") { cmbWork.Text = strTable; }

                if (strWork == "RenameColumn") { cmbWork.Text = strColumn; }


                lstbxWorks.Height = 204;
                lstbxTable.Height = lstbxColumn.Height = 424;
            }
            #endregion


            #region else // defult

            else
            {
                lstbxTable.Height = lstbxColumn.Height = 424;
                lstbxWorks.Height = 244;
            }

            #endregion

        }
        #endregion



        #region btn run     

        private void btnRun_Click(object sender, EventArgs e)
        {
            this.Enabled = false; this.Cursor = Cursors.WaitCursor;

            //  get all selected items text from lstbxWorks
            List<string> lstSelectedWorks = GetSelectedItemsText(lstbxWorks);


            if (lstSelectedWorks.Count > 0)
            {

                //  get all selected items text from lstbxTable
                List<string> lstSelectedTable = GetSelectedItemsText(lstbxTable);
                List<string> lstSelectedSeceendTable = GetSelectedItemsText(lstbxSecendTable);

                //  get all selected items text from lstbxColumn
                List<string> lstSelectedColumn = GetSelectedItemsText(lstbxColumn);
                List<string> lstSelectedSecendColumn = GetSelectedItemsText(lstbxSecendColumn);

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
            lstbxColumn.DataSource = func.SqlColumns(sqlConnection, strTable);




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


        #region GetSelectedItemsText
        public List<string> GetSelectedItemsText(ListBox listBox)
        {
            int intSelectedIndex = 0;
            string strSelectedText = "";
            List<string> lstSelectedItemsText = new List<string>();


            foreach (var item in listBox.SelectedItems)
            {
                // index of select
                intSelectedIndex = listBox.Items.IndexOf(item);

                // text of select
                strSelectedText = listBox.GetItemText(listBox.Items[intSelectedIndex]);

                //  add selected text to list
                lstSelectedItemsText.Add(strSelectedText);
            }

            return lstSelectedItemsText;
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
                    { lstbxReport.Items.Add(func.SqlDelTable(sqlCon, lstSelectedTable[i])); }
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
                { lstbxReport.Items.Add(func.SqlCheckUniqColumn(sqlCon, strTable, lstSelectedColumn[i], out strQuery)); }

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

                result = func.SqlGetUniqData(sqlConnection, strTable, strColumn, out strQry);


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
                    { lstbxReport.Items.Add(func.SqlDropColumn(sqlCon, strTable, lstSelectedColumn[i], out strQuery)); }
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
            { dt = func.SqlJoin(sqlCon, strFirstTable, strSecendTable, strJoinColumn, lstFirsTableColumn, lstSecendTableColumn, out strQuery); }

            //  join table & create new table
            if (strWork == "JoinTwoTableIntoNewTable")
            { dt = func.SqlJoin(sqlCon, strFirstTable, strSecendTable, strJoinColumn, lstFirsTableColumn, lstSecendTableColumn, out strQuery, true); }


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
                strResult = func.SqlRename(sqlCon, "Table", strOldName, strNewName, "", out strQuery);

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
                strResult = func.SqlRename(sqlCon, "Column", strOldName, strNewName, strTable, out strQuery);

                //  add report
                lstbxReport.Items.Add(strResult + " => " + strTable + strOldName + " => " + strNewName);
                lstbxReport.Items.Add("");

                CopyQuery = strQuery;
            }


            return strResult;
        }


        #endregion


        #region cmbWorkSource

        public void cmbWorkSource()
        {
            string strWork = lstbxWorks.GetItemText(lstbxWorks.SelectedItem);
            string strTable = lstbxTable.GetItemText(lstbxTable.SelectedItem);


            //  cmbWork sorce
            if (strWork == "JoinTwoTable" || strWork == "JoinTwoTableIntoNewTable")
            { cmbWork.DataSource = func.SqlColumns(sqlCon, strTable); }


            //  cmbWork sorce
            if (strWork == "RenameTable")
            {
                cmbWork.DataSource = func.SqlTableName(sqlCon);
                cmbWork.Text = strTable;
            }

            //  cmbWork sorce
            if (strWork == "RenameColumn")
            { cmbWork.DataSource = func.SqlColumns(sqlCon, strTable); }
        }




        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
        }
    }

}

