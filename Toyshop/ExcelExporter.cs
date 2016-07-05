using System;
using Microsoft.Office.Interop.Excel;
using System.Drawing;
using System.IO;

namespace Toyshop
{
    public static class ExcelExporter
    {
        private static Color headerColor = Color.FromArgb(200, 240, 166);
        private static Color rowColor = Color.FromArgb(240, 250, 240);
        private static Color rowAltColor = Color.FromArgb(220, 230, 220);
        
        public static void Export(System.Data.DataTable dataTable)
        {
            try
            {
                // Remove special hidden column if present
                if (dataTable.Columns.Contains("_RowString"))
                    dataTable.Columns.Remove("_RowString");

                // Summon Excel
                Application app = new Application();
                app.Visible = true;
                Workbook book = app.Workbooks.Add();
                //book.Activate();
                Worksheet sheet = (Worksheet)book.Worksheets[1];
                sheet.Cells.Style.HorizontalAlignment = XlHAlign.xlHAlignCenter;

                // Make table title
                Range range = sheet.Range[sheet.Cells[1, 1], sheet.Cells[1, dataTable.Columns.Count]];
                range.Merge();
                range.Font.Bold = 1;
                range.Font.Size = 14;
                sheet.Cells[1, 1] = dataTable.TableName;

                // Headers
                for (int j = 0; j < dataTable.Columns.Count; j++)
                {
                    Range r = sheet.Range[sheet.Cells[2, j + 1], sheet.Cells[2, j + 1]];
                    r.Font.Bold = 1;
                    r.Interior.Color = (XlRgbColor)(headerColor.R + 0x100 * headerColor.G + 0x10000 * headerColor.B);
                    sheet.Cells[2, j + 1] = dataTable.Columns[j].ColumnName;
                }

                    // Fill table with data
                    for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    Color color = i % 2 == 0 ? rowColor : rowAltColor;
                    for (int j = 0; j < dataTable.Columns.Count; j++)
                    {
                        // Save images to temp files and add to table
                        if (dataTable.Columns[j].DataType == typeof(byte[]) && dataTable.Rows[i][j] as byte[] != null)
                        {
                            Range r = sheet.Range[sheet.Cells[i + 3, j + 1], sheet.Cells[i + 3, j + 1]];
                            r.Interior.Color = (XlRgbColor)(color.R + 0x100 * color.G + 0x10000 * color.B);

                            string imgPath = Path.GetTempPath() + Path.GetRandomFileName();
                            var fs = new BinaryWriter(new FileStream(imgPath, FileMode.Append, FileAccess.Write));
                            fs.Write(dataTable.Rows[i][j] as byte[]);
                            fs.Close();
                            fs.Dispose();
                            
                            Pictures p = sheet.Pictures() as Pictures;
                            Picture pic = null;
                            pic = p.Insert(imgPath);
                            pic.Height= 60f;
                            pic.Left = Convert.ToDouble(r.Left);
                            pic.Top = r.Top;
                            pic.Placement = XlPlacement.xlMoveAndSize;
                        }
                        // If not image, then display as text
                        else
                        {
                            string data = dataTable.Rows[i][j].ToString();
                            sheet.Cells[i + 3, j + 1] = data;
                        }
                    }
                }
                
                // Borders and auto size
                range = sheet.Range[sheet.Cells[2, 1], sheet.Cells[dataTable.Rows.Count + 2, dataTable.Columns.Count]];
                range.Columns.AutoFit();
                range.Rows.AutoFit();
                range.Borders[XlBordersIndex.xlEdgeBottom].LineStyle =
                range.Borders[XlBordersIndex.xlEdgeLeft].LineStyle =
                range.Borders[XlBordersIndex.xlEdgeTop].LineStyle =
                range.Borders[XlBordersIndex.xlEdgeRight].LineStyle =
                range.Borders[XlBordersIndex.xlInsideHorizontal].LineStyle =
                range.Borders[XlBordersIndex.xlInsideVertical].LineStyle = XlLineStyle.xlContinuous;

            }
            catch (System.Runtime.InteropServices.COMException)
            {
                System.Windows.Forms.MessageBox.Show("Lost connection with MS Office. Export failed.", "Fail", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
        }
    }
}
