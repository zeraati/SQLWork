using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Excel = Microsoft.Office.Interop.Excel;
using System.Windows.Forms;

namespace SQLWork
{
    public static class ExcelExport
    {
        public static void ExportToExcel(this DataTable tbl, string excelFilePath = null)
        {
            try
            {
                // nuled table
                if (tbl == null || tbl.Columns.Count == 0)
                { throw new Exception("ExportToExcel : Table is empty"); }


                // add Workbook & Worksheet
                var excelApp = new Excel.Application();
                excelApp.Workbooks.Add();

                Excel._Worksheet worksheet = excelApp.ActiveSheet;



                //  fill heade with column name
                for (var i = 0; i < tbl.Columns.Count; i++)
                    worksheet.Cells[1, i + 1] = tbl.Columns[i].ColumnName;


                //  fill rows
                for (var i = 0; i < tbl.Rows.Count; i++)
                    for (var j = 0; j < tbl.Columns.Count; j++)
                        worksheet.Cells[i + 2, j + 1] = tbl.Rows[i][j];



                // save file in path
                if (!string.IsNullOrEmpty(excelFilePath))
                {
                    try
                    {
                        worksheet.SaveAs(excelFilePath);
                        excelApp.Quit();
                        MessageBox.Show("Excel file save");
                    }

                    catch (Exception) { throw new Exception("ExportToExcel : file cound not be save"); }

                }

                else { excelApp.Visible = true; }

            }

            catch (Exception)
            { throw new Exception("ExportToExcel : Coud not run method"); }

        }
    }
}
