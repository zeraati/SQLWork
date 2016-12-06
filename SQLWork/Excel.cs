using System;
using System.Collections.Generic;
using System.Data;
using Excel = Microsoft.Office.Interop.Excel;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;

namespace SQLWork
{

    public static class ExcelExport
    {
        public static void ExportToExcel(this DataTable dtTable, string strExcelFilePath, string strSheetName = "Export", bool bolTemplate = false, string strTemplatePatch = null)
        {

            try
            {
                // nuled table
                if (dtTable == null || dtTable.Columns.Count == 0)
                { throw new Exception("!جدول خالی است"); }


                // create excel app
                Excel.Application xlApp = new Excel.Application();


                // check install excel
                if (xlApp == null)
                { throw new Exception("!ماکروسافت اکسل نصب نمی‌باشد"); }


                // create workbook
                Excel.Workbook xlWorkBook = null;

                if (bolTemplate == false)
                { xlWorkBook = xlApp.Workbooks.Add(); }

                else
                {
                    xlWorkBook = xlApp.Workbooks.Open(strTemplatePatch, 0, true, 5, "", "", true,
                       Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
                }


                // get sheet
                Excel.Worksheet xlWorkSheet= xlApp.ActiveSheet;


                // set sheet name
                if (strSheetName == "") { strSheetName = "Export"; }
                xlWorkSheet.Name = strSheetName;

                // set columns with
                xlWorkSheet.Columns.AutoFit();

                //  fill heade with column name
                for (var i = 0; i < dtTable.Columns.Count; i++)
                    xlWorkSheet.Cells[1, i + 1] = dtTable.Columns[i].ColumnName;


                //  fill rows
                for (var i = 0; i < dtTable.Rows.Count; i++)
                    for (var j = 0; j < dtTable.Columns.Count; j++)
                        xlWorkSheet.Cells[i + 2, j + 1] = dtTable.Rows[i][j];

                // save file
                if (!string.IsNullOrEmpty(strExcelFilePath))
                {
                    try
                    {
                        xlWorkBook.SaveAs(strExcelFilePath);
                        xlWorkBook.Close();
                        xlApp.Quit();
                        MessageBox.Show(".فایل اکسل ذخیره شد");
                    }

                    catch (Exception) { throw new Exception("!فایل ذخیره نشد"); }

                }

                else { xlApp.Visible = true; }

            }

            catch (Exception ex)
            { MessageBox.Show(ex.ToString()); }

        }
    }
}
