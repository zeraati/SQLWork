using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace SqlWork
{
    class Functions
    {

        #region TestConn

        /// <summary>
        /// test sql connection
        /// </summary>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>open connection is true</returns>
        public Boolean TestConn(SqlConnection sqlConnection)
        {
            Boolean bolTestConn = false;


            //  test connection
            try
            {
                sqlConnection.Open();
                bolTestConn = true;
                sqlConnection.Close();
            }
            catch (Exception) { }


            return bolTestConn;
        }

        #endregion


        #region ComboBoxSource
        /// <summary>
        /// set combobox source
        /// </summary>
        /// <param name="ComboBox">combobox name</param>
        /// <param name="Table">table name</param>
        /// <param name="ColumnIndex">index of column show in combobox</param>
        /// <param name="State">show in problem massage</param>
        public void ComboBoxSource(ComboBox ComboBox, DataTable Table, int ColumnIndex = 0, string State = "State")
        {
            try
            {
                ComboBox.BindingContext = new BindingContext();
                ComboBox.DataSource = Table;
                ComboBox.ValueMember = Table.Columns[ColumnIndex].ColumnName;
            }

            catch (Exception e)
            {
                if (State != "State")
                    MessageBox.Show(State + Environment.NewLine + e.Message);
            }
        }
        public void ComboBoxSource(DataGridViewComboBoxColumn dgvcmbColumn, DataTable Table, int ColumnIndex = 0, string State = "State")
        {
            try
            {
                dgvcmbColumn.DataSource = Table;
                dgvcmbColumn.DisplayMember = Table.Columns[ColumnIndex].ColumnName;
                dgvcmbColumn.ValueMember = Table.Columns[ColumnIndex].ColumnName;
            }

            catch (Exception e)
            {
                if (State != "State")
                    MessageBox.Show(State + Environment.NewLine + e.Message);
            }
        }

        #endregion


        #region ReadTxt
        /// <summary>
        /// read text file
        /// </summary>
        /// <param name="Path">مسیر فایل متنی</param>
        /// <returns></returns>
        public List<string> ReadTxt(string Path)
        {

            //read text file
            FileStream fileStream = new FileStream(Path, FileMode.Open, FileAccess.Read);


            // read line & add to list
            List<string> lst = new List<string>();
            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
            {
                string strline;

                while ((strline = streamReader.ReadLine()) != null)
                { lst.Add(strline); }
            }


            //  return
            return lst;
        }

        #endregion


        #region IndexOfAll

        /// <summary>
        /// IndexOfAll
        /// </summary>
        /// <param name="txt">متن اصلی</param>
        /// <param name="search">عبارت جستجو</param>
        /// <returns></returns>
        public List<int> IndexOfAll(string txt, string search)
        {
            List<int> lst = new List<int>();

            for (int i = txt.IndexOf(search); i > -1; i = txt.IndexOf(search, i + 1))
            { lst.Add(i + 1); }

            return lst;
        }
        #endregion


        #region ListFind
        /// <summary>
        /// جستجو عبارت از لیست
        /// </summary>
        /// <param name="lst"></param>
        /// <param name="match">عبارت جستجو</param>
        /// <returns>ایندکس</returns>
        public int ListFind(List<string> lst, string match)
        {
            int intRtn = -1;

            //  find math
            for (int i = 0; i < lst.Count; i++)
                if (lst[i].Contains(match)) intRtn = i;


            return intRtn;
        }

        #endregion


        #region SaveListToText
        /// <summary>
        /// ذخیره اطلاعات لاگین از لیست
        /// </summary>
        /// <param name="lst"></param>
        /// <param name="Path">مسیر فایل</param>
        public void SaveListToText(List<string> lst, string Path)
        {
            File.WriteAllText(Path, lst[0]);
            for (int i = 1; i < lst.Count; i++)
            {
                File.WriteAllText(Path, File.ReadAllText(Path) + "\r\n" + lst[i]);
            }
        }
        #endregion


        #region CheckedListBoxSource


        public void CheckedListBoxSource(List<string> lstSource, CheckedListBox checkedListBox)
        {
            // clear list box
            checkedListBox.Items.Clear();

            // set list box source
            for (int i = 0; i < lstSource.Count; i++) checkedListBox.Items.Add(lstSource[i]);

        }

        #endregion


        #region GetQueryName
        /// <summary>
        ///  read querys name
        /// </summary>
        /// <param name="queryPath"></param>
        /// <param name="type"></param>
        /// <returns>list</returns>
        public List<string> GetQueryNameList(string strQueryPath, string strType)
        {
            List<string> lst = new List<string>();


            //  get all query file name
            string[] qryFileName = Directory.GetFiles(strQueryPath, "*.sql");


            //  file name with type
            foreach (string fileName in qryFileName)
            {
                //  type field
                if (strType != "جدول" && fileName.Contains("جدول") == false)
                { lst.Add(Path.GetFileNameWithoutExtension(fileName)); }

                //  type table
                if (strType == "جدول" && fileName.Contains("جدول"))
                { lst.Add(Path.GetFileNameWithoutExtension(fileName)); }
            }

            return lst;
        }

        public DataTable GetQueryNameeDatatable(string strQueryPath, string strType)
        {
            DataTable dt = new DataTable();
            string strFindTbName = "";

            dt.Columns.Add("FileQuery", typeof(string));
            dt.Columns.Add("TbName", typeof(string));

            //  get all query file name
            string[] qryFileName = Directory.GetFiles(strQueryPath, "*.sql");


            //  file name with type
            foreach (string fileName in qryFileName)
            {

                //  type field
                if (strType != "جدول" && fileName.Contains("جدول") == false)
                { dt.Rows.Add(Path.GetFileNameWithoutExtension(fileName)); }

                //  type table
                if (strType == "جدول" && fileName.Contains("جدول"))
                {
                    string strQry = File.ReadAllText(fileName);

                    //  tbl name index
                    int i = strQry.ToUpper().IndexOf("INTO [") + 6, b = strQry.ToUpper().IndexOf("] FROM") - i;

                    //  get table name
                    if (b > 0) strFindTbName = strQry.Substring(i, b);

                    //  add query file name
                    dt.Rows.Add(Path.GetFileNameWithoutExtension(fileName), strFindTbName);
                }
            }

            return dt;
        }

        public string GetQueryNameString(string strQuery, string strTbNmNew)
        {

            //  return query when substring
            string strQryRtn = "";
            int intStart = 0, intLen = 0;

            //  tbl name index
            if (strQryRtn == "" & strQuery.Contains("INTO ["))
            {
                intStart = strQuery.ToUpper().IndexOf("INTO [") + 6;
                intLen = strQuery.ToUpper().IndexOf("] FROM") - intStart;
                strQryRtn = strQuery.Substring(intStart, intLen);
            }

            if (strQryRtn == "" & strQuery.Contains("ALTER TABLE ["))
            {
                intStart = strQuery.ToUpper().IndexOf("ALTER TABLE [") + 13;
                intLen = strQuery.ToUpper().IndexOf("] ADD") - intStart;
                strQryRtn = strQuery.Substring(intStart, intLen);
            }

            if (strQryRtn == "" & strQuery.Contains("DROP TABLE ["))
            {
                intStart = strQuery.ToUpper().IndexOf("DROP TABLE [") + 12;
                intLen = strQuery.Length - (intStart + 1);

                strQryRtn = strQuery.Substring(intStart, intLen);
            }




            //  tb name new
            strQryRtn = strQuery.Substring(intStart, intLen);

            //  create query new
            strQryRtn = strQuery.Replace(strQryRtn, strTbNmNew);

            return strQryRtn;

        }

        #endregion


        #region TableNameOfQuery
        public string TableNameOfQuery(string strQuery)
        {
            string strName = "";
            int intStart = 0, intLen = 0;

            //  tbl name index
            if (strName == "" & strQuery.Contains("INTO ["))
            {
                intStart = strQuery.ToUpper().IndexOf("INTO [") + 6;
                intLen = strQuery.ToUpper().IndexOf("] FROM") - intStart;
                strName = strQuery.Substring(intStart, intLen);
            }

            if (strName == "" & strQuery.Contains("ALTER TABLE ["))
            {
                intStart = strQuery.ToUpper().IndexOf("ALTER TABLE [") + 13;
                intLen = strQuery.ToUpper().IndexOf("] ADD") - intStart;
                strName = strQuery.Substring(intStart, intLen);
            }
            if (strName == "" & strQuery.Contains("DROP TABLE ["))
            {
                intStart = strQuery.ToUpper().IndexOf("DROP TABLE [") + 12;
                intLen = strQuery.Length - (intStart + 1);

                strName = strQuery.Substring(intStart, intLen);
            }



            //  return tb name

            return strName = strQuery.Substring(intStart, intLen); ;
        }
        #endregion


        #region ChangeTableName

        //  change table name
        public DataTable ChangeTableName(DataGridView dgvQrys, DataTable dtSource)
        {

            DataTable dt = new DataTable();

            //  add columns
            dt.Columns.Add("QueryName", typeof(string));
            dt.Columns.Add("TbNameOld", typeof(string));
            dt.Columns.Add("TbNameNew", typeof(string));


            //  get row checked
            for (int i = 0; i < dgvQrys.Rows.Count; i++)
            {
                //  checked item
                if (Convert.ToBoolean(dgvQrys.Rows[i].Cells[0].Value) == true)
                {
                    //  add row
                    string ss = dtSource.Rows[i][1].ToString();           //  old table name 
                    dt.Rows.Add(
                                dgvQrys.Rows[i].Cells[1].Value.ToString(),//  query name
                                dtSource.Rows[i][1].ToString(),           //  old table name 
                                dgvQrys.Rows[i].Cells[2].Value.ToString() //  new table name
                              );

                }

            }


            return dt;
        }
        #endregion


        #region ListToDataTable
        public DataTable ListToDataTable(List<string> lst, string strColumnName=null)
        {
            if (strColumnName == "") { strColumnName = "ColumnName"; }
            DataTable dt = new DataTable();
            dt.Columns.Add(strColumnName, typeof(string));

            DataRow dr = null;
            for (int i = 0; i < lst.Count; i++)
            { dr = dt.NewRow(); dr[0] = lst[i];dt.Rows.Add(dr); }

            return dt;
        }
        #endregion


        #region DataTableToList
        public List<string> DataTableToList(DataTable dt, int IndexColumn = 0)
        {
            List<string> lst = new List<string>();

            //  convert data to list
            for (int i = 0; i < dt.Rows.Count; i++)
            { lst.Add(dt.Rows[i][IndexColumn].ToString()); }

            return lst;
        }
        #endregion


        #region ServerUserPass
        /// <summary>
        /// serverUserPass
        /// </summary>
        /// <param name="loginPath">مسیر فایل اطلاعات ورود به سرور</param>
        /// <param name="strServer">سرور</param>
        /// <returns>لیست شامل نام سرور ، نام کاربری و رمز عبور سرور</returns>
        public List<string> ServerUserPass(string loginPath, string strServer)
        {
            //  return list 
            List<string> lst = new List<string>();
            lst.Add(strServer); // add server



            //  all servers login info
            List<string> lstLogin = new List<string>();
            lstLogin = ReadTxt(loginPath);


            //  get this server user & pass add to lst
            for (int i = 0; i < lstLogin.Count; i++)
            {
                //  find this server info
                if (lstLogin[i].Contains(strServer))
                {
                    //  finde index of separator
                    List<int> lstIndexOf = new List<int>();
                    lstIndexOf = IndexOfAll(lstLogin[i], ",");

                    //  add user & pass to lst
                    lst.Add(lstLogin[i].Substring(lstIndexOf[0], (lstIndexOf[1] - lstIndexOf[0]) - 1));
                    lst.Add(lstLogin[i].Substring(lstIndexOf[1], lstLogin[i].Length - lstIndexOf[1]));
                }
            }


            //  set user & pass when server is local
            if (strServer == ".") lst[1] = lst[2] = "";

            //  decrypt pass
            try { lst[2] = CryptorEngine.Decrypt(lst[2], true); }
            catch (Exception) { }


            return lst;
        }

        #endregion


        #region ListServerName
        /// <summary>
        /// get server name from file
        /// </summary>
        /// <param name="strPathLogin">login file path</param>
        /// <returns>List</returns>
        public List<string> ListServerName(string strPathLogin)
        {
            List<string> lstSvrName = new List<string>();

            //  load server names into cmbServer
            if (File.Exists(strPathLogin))
            {
                lstSvrName = ReadTxt(strPathLogin);

                lstSvrName.Insert(0, "., ,");

                //  get server from read line
                for (int i = 0; i < lstSvrName.Count; i++)
                { lstSvrName[i] = lstSvrName[i].Substring(0, lstSvrName[i].IndexOf(",")); }

            }

            return lstSvrName;
        }
        #endregion


        #region GetListBoxSelectedItems

        public List<string> GetListBoxSelectedItemsText(ListBox listBox)
        {
            List<string> lstSelectedItems = new List<string>();

            foreach (var item in listBox.SelectedItems)
                lstSelectedItems.Add(listBox.GetItemText(item));

            return lstSelectedItems;
        }


        #endregion


        #region ListBoxSelectAllWithRollBack

        List<int> lstSelectedIndex = new List<int>();
        private void ListBoxSelectAllWithRollBack(bool bolCheckAll, ListBox listBox)
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


        #region ListToString

        public string ListToString(List<string> lst, string strSeperator, string strAddToRow = "", bool bolQuery = false, string strTable = "")
        {
            string strListRows = "";

            //  normal string
            for (int i = 0; i < lst.Count; i++)
            {
                //  just exist one row
                if (lst.Count == 1)
                { strListRows = strAddToRow + lst[0]; break; }



                //  multi row
                // first row
                if (i == 0)
                { strListRows = strAddToRow + lst[0] + strSeperator; }

                //  between first & last row
                if (i > 0 && i < lst.Count - 1)
                { strListRows = strListRows + strAddToRow + lst[i] + strSeperator; }

                //  last row
                if (i > 0 && i == lst.Count - 1)
                { strListRows = strListRows + strAddToRow + lst[i]; }
            }


            // query string
            if (bolQuery)
            {
                for (int i = 0; i < lst.Count; i++)
                {
                    if (lst.Count == 1)
                    { strListRows = strAddToRow + ".[" + lst[0] + "]"; break; }

                    if (i == 0)
                    { strListRows = strAddToRow + ".[" + lst[0] + "]" + strSeperator; }

                    if (i > 0 && i < lst.Count - 1)
                    { strListRows = strListRows + strAddToRow + ".[" + lst[i] + "]" + strSeperator; }

                    if (i > 0 && i == lst.Count - 1)
                    { strListRows = strListRows + strAddToRow + ".[" + lst[i] + "]"; }
                }
            }


            //  qury string with alies
            if (bolQuery == true && strTable != "")
            {


                for (int i = 0; i < lst.Count; i++)
                {
                    //  set alies
                    strTable = "] [" + lst[i] + "_" + strTable + "]";

                    if (lst.Count == 1)
                    { strListRows = strAddToRow + ".[" + lst[0] + strTable; break; }

                    if (i == 0)
                    { strListRows = strAddToRow + ".[" + lst[0] + strTable + strSeperator; }

                    if (i > 0 && i < lst.Count - 1)
                    { strListRows = strListRows + strAddToRow + ".[" + lst[i] + strTable + strSeperator; }

                    if (i > 0 && i == lst.Count - 1)
                    { strListRows = strListRows + strAddToRow + ".[" + lst[i] + strTable; }
                }
            }


            return strListRows;
        }

        #endregion


        //****************************  sql functin *****************************
        //**********************************************************************


        #region SqlGetDataTables

        public DataTable[] SqlGetDataTables(string[] tables, SqlConnection sqlConnection)
        {
            //Query all the server tables and stick 'em into DataTables           
            DataTable[] dataTables = new DataTable[tables.Length];

            for (int tableIndex = 0; tableIndex < tables.Length; tableIndex++)
            {
                string qry = "SELECT * FROM " + tables[tableIndex] + ";";
                DataTable dtTable = new DataTable();

                using (SqlConnection connection = new SqlConnection(sqlConnection.ConnectionString))
                {
                    if (connection.State != ConnectionState.Open) connection.Open();
                    using (SqlCommand cmd = new SqlCommand(qry, connection))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter();
                        adapter.SelectCommand = cmd;
                        adapter.Fill(dtTable);
                    }
                }
                dtTable.TableName = tables[tableIndex];
                dataTables[tableIndex] = dtTable;
                //                Console.WriteLine(" Rows: " + dtTable.Rows.Count);
            }
            return dataTables;
        }

        #endregion


        public DataTable SqlSelectAll(string strTableName, SqlConnection sqlConnection)
        {
            return SqlDataAdapter(sqlConnection, "SELECT * FROM [" + strTableName + "]");
        }

        #region SqlDataTableInfo
        public DataTable SqlTableInfo(string strTableName, SqlConnection sqlConnection)
        {
            string strQuery = "SELECT a.COLUMN_NAME , " +
                               "ORDINAL_POSITION , " +
                               "COLUMN_DEFAULT , " +
                               "CASE WHEN IS_NULLABLE='NO' THEN 'NOT NULL' ELSE 'NULL' END , " +
                               "CASE WHEN a.CHARACTER_MAXIMUM_LENGTH IS NULL THEN DATA_TYPE ELSE DATA_TYPE +' ('+CAST(CHARACTER_MAXIMUM_LENGTH AS VARCHAR(10))+')' END, " +
                               "COLUMNPROPERTY(object_id(a.TABLE_NAME), a.COLUMN_NAME, 'IsIdentity')IsIdentity " +
                               "FROM INFORMATION_SCHEMA.COLUMNS a " +
                               "WHERE a.TABLE_NAME=N'" + strTableName + "'";
            return SqlDataAdapter(sqlConnection, strQuery);
        }
        #endregion



        #region SqlConnection
        public SqlConnection SqlConnect(string server = ".", string user = "", string pass = "", string dbName = "")
        {
            string strconn, strdbName;


            //  set data base name
            if (dbName == "") { strdbName = "master"; } else { strdbName = dbName; }


            // create connection string
            if (user != "" && pass != "")
            { strconn = "Data Source=" + server + ";Initial Catalog=" + strdbName + ";Persist Security Info=True;User ID=" + user + ";Password=" + pass; }

            else strconn = "Data Source=.;Initial Catalog=" + strdbName + ";Integrated Security=True;Connect Timeout=5";


            SqlConnection sqlConnection = new SqlConnection(strconn);
            return sqlConnection;
        }
        #endregion



        #region SqlExcutCommand
        public string SqlExcutCommand(SqlConnection sqlConnection, string Query, string strState = "")
        {
            SqlCommand cmd = new SqlCommand(Query, sqlConnection);
            try
            {
                // conection timeoute
                cmd.CommandTimeout = 3600;

                //  open conection
                if (cmd.Connection.State == ConnectionState.Closed)
                { cmd.Connection.Open(); }

                // execute query
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();

                return "SqlExcutCommand => " + strState + " => Done";
            }

            catch (Exception) { return "SqlExcutCommand => " + strState + " => Error"; }
        }

        #endregion


        #region SqlExcutCommandWithGO
        public List<string> SqlExcutCommandWithGO(SqlConnection sqlConnection, string Query, string strState = "")
        {
            //  for substring
            int intStart, intLenght;

            List<string> lstQry = new List<string>();
            List<string> lstResult = new List<string>();


            // index of all GO in query
            List<int> lstIndexGo = IndexOfAll(Query, "GO");


            //  create evry query
            for (int i = 0; i < lstIndexGo.Count; i++)
            {

                //  first GO
                if (i == 0)
                { intLenght = lstIndexGo[0] - 1; lstQry.Add(Query.Substring(0, intLenght)); }


                //  midel Go    // GO between first & last 
                if (lstIndexGo.Count - 1 > i)
                {
                    intStart = lstIndexGo[i] + 2; intLenght = (lstIndexGo[i + 1] - 1) - (lstIndexGo[i] + 2);
                    lstQry.Add(Query.Substring(intStart, intLenght));
                }


                //  last GO
                if (lstIndexGo.Count - 1 == i)
                {
                    intStart = lstIndexGo[i] + 2; intLenght = Query.Length - intStart;
                    lstQry.Add(Query.Substring(intStart, intLenght));
                }

            }


            // run evry query & set result
            for (int i = 0; i < lstQry.Count; i++)
            { lstResult.Add(SqlExcutCommand(sqlConnection, lstQry[i], "lstQry[" + i.ToString() + "]")); }


            return lstResult;
        }
        #endregion


        #region SqlGetDBName
        /// <summary>
        /// بر روی سیستم SQL لیستی شامل تمام پایگاه  داده های
        /// </summary>
        /// <returns>DataTable</returns>

        public DataTable SqlGetDBName(SqlConnection sqlConnection)
        {
            string qry = "SELECT name FROM sys.databases WHERE database_id>0 order by name";
            DataTable dt = SqlDataAdapter(sqlConnection, qry);
            return dt;
        }

        #endregion


        #region SqlDataAdapter

        public DataTable SqlDataAdapter(SqlConnection sqlConnection, string strQuery, string stat = "SqlDataAdapter", string strTable = "", string strColumn = "")
        {
            DataTable dt = new DataTable();

            //  defult queries
            if (strQuery == "DISTINCT" && strTable != "")
            { strQuery = "SELECT DISTINCT [" + strColumn + "] FROM [" + strTable + "] ORDER BY [" + strColumn + "]"; }

            else if (strQuery == "SELECT" && strTable != "")
            { strQuery = "SELECT * FROM [" + strTable + "]"; }

            try
            {
                SqlDataAdapter da = new SqlDataAdapter(strQuery, sqlConnection);
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                if (stat != "SqlDataAdapter")
                    MessageBox.Show(stat + Environment.NewLine + ex.Message, "خطا");
                return dt;
            }
        }

        #endregion

        #region SqlDataAdapter

        public string SqlGetOneRow(SqlConnection sqlConnection, string strQuery)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(strQuery, sqlConnection);
            da.Fill(dt);
            return dt.Rows[0][0].ToString();
        }

        #endregion

        #region SqlTableName

        public List<string> SqlTableName(SqlConnection sqlConnection)
        {
            string Query = "SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE!='VIEW'";
            return DataTableToList(SqlDataAdapter(sqlConnection, Query));
        }

        #endregion


        #region SqlColumnsName

        /// <summary>
        /// list of columns name
        /// </summary>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="strTableName">TableName</param>
        /// <returns>List > string</returns>
        public List<string> SqlColumns(SqlConnection sqlConnection, string strTableName)
        {
            string Query = "SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS " + "WHERE TABLE_NAME = N'" + strTableName + "'";
            return DataTableToList(SqlDataAdapter(sqlConnection, Query));
        }

        #endregion


        #region RecoredCount
        public int RecoredCount(string query, string server)
        {
            SqlCommand cmd = new SqlCommand(query, SqlConnect(server));
            int count;
            cmd.Connection.Open();
            cmd.CommandTimeout = 3600;
            count = Convert.ToInt32(cmd.ExecuteScalar());
            cmd.Connection.Close();
            return count;
        }
        #endregion


        #region SqlConnectionChangeDB


        public SqlConnection SqlConnectionChangeDB(SqlConnection sqlConnection, string newDB)
        {
            sqlConnection.Close();

            SqlConnection sqlConn = new SqlConnection(sqlConnection.ConnectionString.Replace(sqlConnection.Database, newDB));

            return sqlConn;
        }


        #endregion


        #region SqlCheckUniqColumn
        public string SqlCheckUniqColumn(SqlConnection sqlConnection, string strTable, string strColumn, out string Query)
        {
            // create query
            string strQry = "SELECT [" + strColumn + "],COUNT(*)cnt FROM [" + strTable + "] GROUP BY [" + strColumn + "] HAVING COUNT(*) > 1 AND [" + strColumn + "] IS NOT NULL";

            // distinct column
            string strRowCount = SqlDataAdapter(sqlConnection, "SELECT DISTINCT [" + strColumn + "] FROM[" + strTable + "]").Rows.Count.ToString("#, ##0");

            // check result
            if (SqlDataAdapter(sqlConnection, strQry).Rows.Count > 0)
            { Query = strQry; return strTable + " ==>" + strColumn + " ==> its not uniq (" + strRowCount + ")"; }

            Query = strQry;
            return strTable + " ==>" + strColumn + " ==> its uniq (" + strRowCount + ")";
        }

        #endregion


        #region SqlDelTable
        public string SqlDelTable(SqlConnection sqlConnection, string strTableName)
        {
            string strQry = "DROP TABLE [" + strTableName + "]";

            string strResult = SqlExcutCommand(sqlConnection, strQry, "SqlDelTable");

            return strTableName + " ==> " + strResult;
        }
        #endregion


        #region SqlGetUniqData
        public string SqlGetUniqData(SqlConnection sqlConnection, string strTable, string strColumn, out string Query)
        {
            string strQry;




            //  remove new table if exist
            strQry =
                        "/* drop new table if exist */ \r\n" +
                        "IF OBJECT_ID('" + strTable + "_uniq', 'U') IS NOT NULL BEGIN DROP TABLE [" + strTable + "_uniq] END \r\n \r\n" +

                        "/* create new table    */ \r\n" +
                        "SELECT a.* INTO [" + strTable + "_uniq] FROM [" + strTable + "] a \r\n" +
                        "INNER JOIN(SELECT [" + strColumn + "], COUNT(*)cnt FROM [" + strTable + "] GROUP BY [" + strColumn + "] HAVING COUNT(*) = 1)b \r\n" +
                        "ON b.[" + strColumn + "] = a.[" + strColumn + "] \r\n";

            // run query and return result
            string strReturn = strTable + " ==> " + strColumn + " ==> " + SqlExcutCommand(sqlConnection, strQry, "GetUniqData");

            Query = strQry;
            return strReturn;

        }


        #region comment
        //public string SqlGetUniqData(SqlConnection sqlConnection, string strTable, string strColumn, out string strAllQuery)
        //{
        //    string strQry, strAllQry;


        //    //  remove old table
        //    strQry = " IF OBJECT_ID('t01', 'U') IS NOT NULL BEGIN DROP TABLE t01 END";
        //    strAllQry = strQry;

        //    //  remove old table
        //    strQry = " IF OBJECT_ID('" + strTable + "_uniq', 'U') IS NOT NULL BEGIN DROP TABLE [" + strTable + "_uniq] END";
        //    strAllQry = strAllQry + strQry;


        //    //  add RowNumber & uniq datat
        //    strQry =
        //                " SELECT c.* INTO t01 FROM"
        //                + " (SELECT [" + strColumn + "], MAX(RowNumber)RowNumber FROM(SELECT ROW_NUMBER() OVER(ORDER BY [" + strColumn + "])RowNumber, [" + strColumn + "] FROM [" + strTable + "])a GROUP BY [" + strColumn + "])b"
        //                + " JOIN(SELECT ROW_NUMBER() OVER(ORDER BY [" + strColumn + "])RowNumber, * FROM [" + strTable + "])c ON b.RowNumber = c.RowNumber";
        //    strAllQry = strAllQry + strQry;


        //    //  new table in to table orginal uniq
        //    strQry = " SELECT * INTO [" + strTable + "_uniq] FROM dbo.t01 DROP TABLE dbo.t01";
        //    strAllQry = strAllQry + strQry;

        //    // run query and return result
        //    string strReturn = strTable + " ==> " + strColumn + " ==> " + SqlExcutCommand(sqlConnection, strAllQry, "GetUniqData");


        //    //  remove RowNumber column
        //    strQry = " ALTER TABLE [" + strTable + "_uniq] DROP COLUMN RowNumber";
        //    SqlExcutCommand(sqlConnection, strQry, "GetUniqData");


        //    // strAllQuery  out
        //    strAllQuery = strAllQry + strQry;


        //    return strReturn;

        //}
        #endregion


        #endregion


        #region SqlDropColumn
        public string SqlDropColumn(SqlConnection sqlConnection, string strTable, string strColumn, out string Query)
        {
            string strQuery = Query = "ALTER TABLE [" + strTable + "] DROP COLUMN [" + strColumn + "]";

            return SqlExcutCommand(sqlConnection, strQuery, strColumn + " ==> DropColumn");
        }
        #endregion


        #region SqlJoin
        public DataTable SqlJoin(SqlConnection sqlConnection, string strFirstTable, string strSecendTable, string strJointColumn)
        {
            string strQuery = "SELECT * FROM [" + strFirstTable + "] a LEFT JOIN [" + strSecendTable + "] b ON b.[" + strJointColumn + "] = a.[" + strJointColumn + "]";

            return SqlDataAdapter(sqlConnection, strQuery, "SqlJoin");
        }

        public DataTable SqlJoin(SqlConnection sqlConnection, string strFirstTable, string strSecendTable, string strJointColumn, List<string> lstFirsTableColumn, List<string> lstSecendTableColumn, out string strQuery, bool bolCreat = false)
        {
            string strFirstColumn = ListToString(lstFirsTableColumn, ",", "a", true, strFirstTable);
            string strSecendColumn = ListToString(lstSecendTableColumn, ",", "b", true, strSecendTable);

            string Query = strQuery = "";

            if (bolCreat == true)
            { Query = strQuery = "SELECT " + strFirstColumn + "," + strSecendColumn + " INTO " + strFirstTable + "_" + strSecendTable + " FROM [" + strFirstTable + "] a LEFT JOIN [" + strSecendTable + "] b ON b.[" + strJointColumn + "] = a.[" + strJointColumn + "]"; }

            if (bolCreat == false)
            { Query = strQuery = "SELECT " + strFirstColumn + "," + strSecendColumn + " FROM [" + strFirstTable + "] a LEFT JOIN [" + strSecendTable + "] b ON b.[" + strJointColumn + "] = a.[" + strJointColumn + "]"; }

            return SqlDataAdapter(sqlConnection, Query, "SqlJoin");
        }


        #endregion


        #region SqlRename
        public string SqlRename(SqlConnection sqlConnection, string strType, string strOldName, string strNewName, string strTable, out string strQuery, string strState = "")
        {
            strQuery = "";

            // renam table
            if (strType.ToUpper() == "TABLE")
            { strQuery = "EXEC sp_rename '" + strOldName + "', '" + strNewName + "'"; }

            //  rename column
            if (strType.ToUpper() == "COLUMN" && strTable != "")
            { strQuery = "EXEC sp_rename '" + strTable + "." + strOldName + "', '" + strNewName + "' , 'COLUMN'"; }

            return SqlExcutCommand(sqlConnection, strQuery, strState + " => SqlRename");
        }
        #endregion


        #region SqlPivote

        public DataTable SqlPivote(SqlConnection sqlConnection, string strTable, string strValues, string strRows, string strColumns)
        {
            DataTable dt = SqlDataAdapter(sqlConnection, "DISTINCT", "", strTable, strColumns);

            string s = "";
            int intDtRowsCount = dt.Rows.Count;

            for (int i = 0; i < intDtRowsCount; i++)
            {
                if (i < intDtRowsCount - 1)
                    s = s + "[" + dt.Rows[i][0].ToString() + "],";

                if (i == intDtRowsCount - 1)
                    s = s + "[" + dt.Rows[i][0].ToString() + "]";
            }


            string strQuery = "SELECT * FROM (SELECT [" + strValues + "],[" + strRows + "],[" + strColumns + "] FROM [" + strTable + "])a"
                            + " PIVOT(COUNT([" + strValues + "]) FOR [" + strColumns + "] IN(" + s + "))b";

            return SqlDataAdapter(sqlConnection, strQuery);
        }

        #endregion

        #region messageDone
        public void messageDone() { MessageBox.Show("Done!"); }
        #endregion


        #region DistinctColumn
        public List<string> DistinctColumn(string strColumn, string strTable, SqlConnection Connection)
        {
            // distinct query
            string strQueryDistinct = string.Format("SELECT DISTINCT [{0}] FROM [{1}]", strColumn, strTable);

            // distinct column
            return DataTableToList(SqlDataAdapter(Connection, strQueryDistinct));
        }
        #endregion


        #region DistinctTable
        public DataTable DistinctTable(string strTable, SqlConnection Connection)
        {
            DataTable dt = new DataTable();

            // all columns
            List<string> lstAllColumns = SqlColumns(Connection, strTable);

            // distinct all columns
            int intCountRows = lstAllColumns.Count;
            for (int i = 0; i < intCountRows; i++)
            {
                string strColumn = lstAllColumns[i];
                dt.Columns.Add(strColumn, typeof(string));

                // distinct column
                List<string> lst = DistinctColumn(strColumn, strTable, Connection);

                // add to dt
                for (int j = 0; j < lst.Count; j++)
                {
                    DataRow dr = dt.NewRow();
                    dr[strColumn] = lst[j];
                    dt.Rows.Add(dr);
                }
            }

            return dt;
        }
        #endregion


        #region DataTableRemoveEmptyCell
        public DataTable DataTableRemoveEmptyCell(DataTable dt)
        {
            // retern dt
            DataTable dtRetrn = new DataTable();

            // evry column
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                string strColumn = dt.Columns[i].ColumnName;

                // add column to retern dt
                dtRetrn.Columns.Add(strColumn, typeof(string));

                // rows
                int k = 0;
                for (int j = 0; j < dt.Rows.Count; j++)
                {
                    string strRow = dt.Rows[j][i].ToString();

                    if (strRow != "")
                    {
                        k++;
                        int intdtRetrnRowsCount = dtRetrn.Rows.Count;

                        if (i == 0 || k > intdtRetrnRowsCount) { DataRow dr = dtRetrn.NewRow(); dr[i] = dt.Rows[j][i]; dtRetrn.Rows.Add(dr); }
                        else { dtRetrn.Rows[k - 1][i] = dt.Rows[j][i]; }
                    }

                }
            }


            // i Column
            // j Row old
            // k Row new
            return dtRetrn;
        }
        #endregion
    }
}
