using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Excel = Microsoft.Office.Interop.Excel;
using System.Windows.Forms;
using System.IO;

namespace SQLWork
{
    public static class ExcelExport
    {
        public static void ExportToExcel(this DataTable tbl, string excelFilePath, string strSheetName = "Export", bool template = false, string templatePatch = null)
        {

            try
            {
                // nuled table
                if (tbl == null || tbl.Columns.Count == 0)
                { throw new Exception("!جدول خالی است"); }


                // ساخت نرم افزار اکسل
                Excel.Application xlApp = new Excel.Application();


                // برسی نصب بودن اکسل
                if (xlApp == null)
                { throw new Exception("!ماکروسافت اکسل نصب نمی‌باشد"); }


                // ساخت ورک بوک جدید
                Excel.Workbook xlWorkBook = null;

                if (template == false)
                { xlWorkBook = xlApp.Workbooks.Add(); }

                else
                {
                    xlWorkBook = xlApp.Workbooks.Open(templatePatch, 0, true, 5, "", "", true,
                       Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
                }


                // get sheet
                Excel.Worksheet xlWorkSheet = xlApp.ActiveSheet;


                // set sheet name
                if (strSheetName != "") { strSheetName = "Export"; }
                xlWorkSheet.Name = strSheetName;

                // set columns with
                xlWorkSheet.Columns.AutoFit();

                //  fill heade with column name
                for (var i = 0; i < tbl.Columns.Count; i++)
                    xlWorkSheet.Cells[1, i + 1] = tbl.Columns[i].ColumnName;


                //  fill rows
                for (var i = 0; i < tbl.Rows.Count; i++)
                    for (var j = 0; j < tbl.Columns.Count; j++)
                        xlWorkSheet.Cells[i + 2, j + 1] = tbl.Rows[i][j];

                // save file
                if (!string.IsNullOrEmpty(excelFilePath))
                {
                    try
                    {
                        xlWorkBook.SaveAs(excelFilePath);
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
