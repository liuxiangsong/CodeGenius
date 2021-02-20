using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;

namespace Paging
{
    class ExcelExport
    {
        #region 導出Excel
        public static void ExportExcel(System.Data.DataTable dt)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel 文件(*.xlsx)|*.xlsx|Excel 文件 (*.xls)|*.xls";
            sfd.FilterIndex = 0;
            sfd.RestoreDirectory = true;
            sfd.CreatePrompt = true;
            sfd.Title = "請選擇文檔保存路徑";
            sfd.ShowDialog();
            string strName = sfd.FileName; 
            if (strName.Length != 0)
            {
                System.Reflection.Missing miss = System.Reflection.Missing.Value;
                Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
                excel.Application.Workbooks.Add(true);
                excel.Visible = false;  //若是true，則在導出的時候會顯示EXcel介面。
                if (excel == null)
                {
                    MessageBox.Show("Excel無法啟動，請檢查是否安裝Excel", "提示", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    return; 
                }
                Workbooks books = (Microsoft.Office.Interop.Excel.Workbooks)excel.Workbooks;
                Workbook book = (Microsoft.Office.Interop.Excel.Workbook)books.Add(miss);
                Worksheet sheet = (Microsoft.Office.Interop.Excel.Worksheet)book.ActiveSheet;
                sheet.Name = "sheet1";

                int n = 0;
                //生成列名稱
                for (int i = 0; i <dt.Columns.Count; i++)
                {
                    //if (dgv.Columns[i].Visible == false) continue;
                    n++;
                    excel.Cells[1, n] =dt.Columns[i].Caption;
                }
                //填充數據
                for (int i = 0; i <dt.Rows.Count; i++)
                {
                    n = 0;
                    for (int j = 0; j < dt.Columns.Count; j++)
                    { 
                        n++;
                        if (dt.Rows[i][j].GetType() == typeof(string))
                        {
                            excel.Cells[i + 2, n] = "'" +dt.Rows[i][j].ToString();
                        }
                        else if(dt.Rows[i][j].GetType() == typeof(DateTime))
                        {
                             excel.Cells[i + 2, n] =Convert.ToDateTime(dt.Rows[i][j]).ToString("yyyy/MM/dd");
                        }
                        else
                        {
                            excel.Cells[i + 2, n] = dt.Rows[i][j].ToString();
                        }
                    }
                } 
                try
                {
                    sheet.SaveAs(strName, miss, miss, miss, miss, miss, XlSaveAsAccessMode.xlNoChange, miss, miss, miss);
                }
                catch (Exception ex)
                {
                    //throw new Exception(ex.Message, ex);
                    MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                book.Close(false, miss, miss);
                books.Close();
                excel.Quit();
                System.Runtime.InteropServices.Marshal.ReleaseComObject(sheet);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(book);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(books);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(excel);
                GC.Collect();
                if (MessageBox.Show("導出操作完成，您想打開該Excel文件嗎？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    System.Diagnostics.Process.Start(strName);
                } 
            }

        }
        #endregion
    }
}
