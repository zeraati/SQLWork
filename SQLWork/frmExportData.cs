﻿using SqlWork;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQLWork
{
    public partial class frmExport : Form
    {
        string strPathLoginFolder = @"..\Login.pos";

        Functions functions = new Functions();
        SqlConnection sqlConMain = new SqlConnection();
        SqlConnection sqlConSecond = new SqlConnection();

        public frmExport()
        {
            InitializeComponent();
        }


        #region form load

        private void ExportData_Load(object sender, EventArgs e)
        {
            //  load server name of login folder
            cmbServerMabda.DataSource = functions.ListServerName(strPathLoginFolder);
            cmbServerMaghsad.DataSource = functions.ListServerName(strPathLoginFolder);
        }

        #endregion


        private void cmbServerMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            //  server main
            string strServerMain = cmbServerMabda.Text;

            // server info ==> server , user , pass
            List<string> lstServerInfo = new List<string>();


            //  get server info
            lstServerInfo = functions.ServerUserPass(strPathLoginFolder, strServerMain);
            //txtUserMain.Text = lstServerInfo[1];
            //txtPassMain.Text = lstServerInfo[2];
        }

        private void cmbServerSecond_SelectedIndexChanged(object sender, EventArgs e)
        {
            //  server second
            string strServerSecond = cmbServerMaghsad.Text;

            // server info ==> server , user , pass
            List<string> lstServerInfo = new List<string>();


            //  get server info
            lstServerInfo = functions.ServerUserPass(strPathLoginFolder, strServerSecond);
            //txtUserSecond.Text = lstServerInfo[1];
            //txtPassSecond.Text = lstServerInfo[2];
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (cmbServerMabda.Text != cmbServerMaghsad.Text)
            {
                // get server info ==> servermain & serversecond , user , pass
                //string strServerMain = cmbServerMabda.Text, strUserMain = txtUserMain.Text, strPassMain = txtPassMain.Text;
                //string strServerSecond = cmbServerMaghsad.Text, strUserSecond = txtUserSecond.Text, strPassSecond = txtPassSecond.Text;

                //  create sql connection
                //sqlConMain = functions.SqlConnect(strServerMain, strUserMain, strPassMain);
                //sqlConSecond = functions.SqlConnect(strServerSecond, strUserSecond, strPassSecond);


                //  test sql connection //  result yes
                if (functions.TestConn(sqlConMain))
                {
                    //  load database name  // set source cmbDBNames 
                    functions.ComboBoxSource(cmbDBMabda, functions.SqlGetDBName(sqlConMain));
                    if (functions.TestConn(sqlConSecond))
                    {
                        //  load database name  // set source cmbDBNames 
                        functions.ComboBoxSource(cmbDBMaghsad, functions.SqlGetDBName(sqlConSecond));

                        // set btnConnect text
                        btnConnect.Text = "اتصال مجدد";
                    }
                    else
                    { btnConnect.Text = "اتصال"; MessageBox.Show("عدم برقراری ارتباط", "!هشدار"); }
                }
                //  test sql connection //  result no
                else
                { btnConnect.Text = "اتصال"; MessageBox.Show("عدم برقراری ارتباط", "!هشدار"); }
            }
            else { MessageBox.Show("The servername must be unequal"); }
        }

        private void cmbDBMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbDBMabda.Text != "System.Data.DataRowView")
            {
                //  change db
                sqlConMain = functions.SqlConnectionChangeDB(sqlConMain, cmbDBMabda.Text);

                //set tale name source
                lstBxTableMabda.DataSource = functions.SqlTableName(sqlConMain);
            }
        }

        private void cmbDBSecond_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbDBMaghsad.Text != "System.Data.DataRowView")
            {
                //  change db
                sqlConSecond = functions.SqlConnectionChangeDB(sqlConSecond, cmbDBMaghsad.Text);

                //set tale name source
                lstBxTableMaghsad.DataSource = functions.SqlTableName(sqlConSecond);
            }
        }

        private void lstBxTableMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            TableSelectedIndexChanged(sqlConMain, lstBxTableMabda, lstBxColumnMabda);
        }

        private void lstBxTableSecond_SelectedIndexChanged(object sender, EventArgs e)
        {
            //TableSelectedIndexChanged(sqlConSecond, lstBxTableMaghsad, lstBxColumnSecond);
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            List<string> lstSelectedTableNameMain = functions.GetSelectedItemsText(lstBxTableMabda);
            DataTable Table = new DataTable();

            //dgvTableInfo.DataSource = functions.SqlTableInfo(lstSelectedTableNameMain[0], sqlConMain);            

            SqlBulkCopyColumnMapping SCM = new SqlBulkCopyColumnMapping("a", "d");
            SqlBulkCopy SBC = new SqlBulkCopy(sqlConSecond);

            SBC.DestinationTableName = lstBxTableMaghsad.Items[0].ToString();
            DataTable dt = functions.SqlDataAdapter(sqlConMain, "SELECT", "", lstSelectedTableNameMain[0]);

            sqlConMain.Open();
            SBC.WriteToServer(dt);
            sqlConMain.Close();

            //
            //DialogResult dr = new DialogResult();

            //string strTableNames = string.Join(",", lstSelectedTableNameMain.ToArray());
            //string[] strTableNamesArray = strTableNames.Split(','); // Call Split method

            //for (int i = 0; i < lstSelectedTableNameMain.Count; i++)
            //{
            //for (int j = 0; j < lstBxTableSecond.Items.Count; j++)
            //{
            //    if (lstSelectedTableNameMain[i] == lstBxTableSecond.Items[j].ToString())
            //    {
            //        dr = MessageBox.Show("Replace [" + lstSelectedTableNameMain[i] + "] to [" + lstBxTableSecond.Items[j].ToString() + "]", "warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
            //        if (dr == DialogResult.Yes)
            //        { }
            //    }
            //    else
            //    {

            //InsertDataFromDataTables(functions.SqlSelectAll(lstSelectedTableNameMain[i], sqlConMain));
            //    }
            //}

            //}
        }


        #region TableSelectedIndexChanged

        private void TableSelectedIndexChanged(SqlConnection sqlConnection, ListBox lstbxTable, ListBox lstbxColumn)
        {
            string strTable = lstbxTable.GetItemText(lstbxTable.SelectedItem);

            // lstbxColumn source
            lstbxColumn.DataSource = functions.SqlColumns(sqlConnection, strTable);

        }

        #endregion


        #region InsertDataFromDataTables

        private void InsertDataFromDataTables(DataTable dtTables)
        {

            using (SqlBulkCopy bcp = new SqlBulkCopy(sqlConSecond.ConnectionString, SqlBulkCopyOptions.KeepIdentity & SqlBulkCopyOptions.KeepNulls))
            {
                for (int colIndex = 0; colIndex < dtTables.Columns.Count; colIndex++)
                {
                    bcp.ColumnMappings.Add(colIndex, colIndex);
                }
                bcp.WriteToServer(dtTables);
            }

        }

        #endregion


        private void CreateTable(DataTable dtTable, SqlConnection sqlConnection) 
        {
            

        }


        //static void bcp_SqlRowsCopied(object sender, SqlRowsCopiedEventArgs e)
        //{
        //    //Console.WriteLine("row written");
        //}


    }
}
