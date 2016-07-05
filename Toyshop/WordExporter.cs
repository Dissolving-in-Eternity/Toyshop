using System;
using Microsoft.Office.Interop.Word;
using System.Drawing;
using System.IO;
using System.Globalization;

namespace Toyshop
{
    public static class WordExporter
    {
        private static Color headerColor = Color.FromArgb(166, 228, 247);
        private static Color rowColor = Color.FromArgb(250, 250, 255);
        private static Color rowAltColor = Color.FromArgb(230, 240, 245);
        private static Color rowWarningColor = Color.FromArgb(250, 218, 221);
        private static Color rowWarningAltColor = Color.FromArgb(255, 182, 193);

        public static void Export(System.Data.DataTable dataTable)
        {
            try
            {
                // Remove special hidden column if present
                if (dataTable.Columns.Contains("_RowString"))
                    dataTable.Columns.Remove("_RowString");

                // Summon Word
                Application app = new Application();
                app.Visible = true;
                Document document = app.Documents.Add();
                document.PageSetup.Orientation = WdOrientation.wdOrientLandscape;
                document.Activate();
                Selection doc = document.ActiveWindow.Selection;    

                doc.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                doc.Font.Size = 20;
                doc.Font.Bold = 1;

                // Type table name
                doc.TypeText(dataTable.TableName);
                doc.TypeParagraph();
                doc.Font.Size = 12;
                doc.Font.Bold = 0;

                // Create table and make all borders visible
                Table table = document.Tables.Add(doc.Range, dataTable.Rows.Count + 1, dataTable.Columns.Count);
                table.Rows.Alignment = WdRowAlignment.wdAlignRowCenter;
                table.Borders[WdBorderType.wdBorderTop].LineStyle =
                table.Borders[WdBorderType.wdBorderBottom].LineStyle =
                table.Borders[WdBorderType.wdBorderLeft].LineStyle =
                table.Borders[WdBorderType.wdBorderRight].LineStyle =
                table.Borders[WdBorderType.wdBorderHorizontal].LineStyle =
                table.Borders[WdBorderType.wdBorderVertical].LineStyle = WdLineStyle.wdLineStyleSingle;
                table.Borders[WdBorderType.wdBorderTop].LineWidth =
                table.Borders[WdBorderType.wdBorderRight].LineWidth =
                table.Borders[WdBorderType.wdBorderBottom].LineWidth =
                table.Borders[WdBorderType.wdBorderLeft].LineWidth = WdLineWidth.wdLineWidth150pt;

                // Headers bold
                for (int j = 0; j < dataTable.Columns.Count; j++)
                {
                    table.Cell(1, j + 1).Borders[WdBorderType.wdBorderLeft].LineWidth =
                    table.Cell(1, j + 1).Borders[WdBorderType.wdBorderRight].LineWidth =
                    table.Cell(1, j + 1).Borders[WdBorderType.wdBorderBottom].LineWidth = WdLineWidth.wdLineWidth150pt;
                    table.Cell(1, j + 1).Range.Shading.BackgroundPatternColor = (WdColor)(headerColor.R + 0x100 * headerColor.G + 0x10000 * headerColor.B); ;
                    table.Cell(1, j + 1).Range.Font.Bold = 1;
                    table.Cell(1, j + 1).Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                    table.Cell(1, j + 1).VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                    table.Cell(1, j + 1).Range.Text = dataTable.Columns[j].ColumnName;
                }

                // Fill table with data
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    Color color = i % 2 == 0 ? rowColor : rowAltColor;
                    for (int j = 0; j < dataTable.Columns.Count; j++)
                    {
                        table.Cell(i + 2, j + 1).Range.Shading.BackgroundPatternColor = (WdColor)(color.R + 0x100 * color.G + 0x10000 * color.B); ;
                        table.Cell(i + 2, j + 1).Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                        table.Cell(i + 2, j + 1).VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter;

                        // Save images to temp files and add to table
                        if (dataTable.Columns[j].DataType == typeof(byte[]) && dataTable.Rows[i][j] as byte[] != null)
                        {
                            string imgPath = Path.GetTempPath() + Path.GetRandomFileName();
                            var fs = new BinaryWriter(new FileStream(imgPath, FileMode.Append, FileAccess.Write));
                            fs.Write(dataTable.Rows[i][j] as byte[]);
                            fs.Close();

                            table.Cell(i + 2, j + 1).Range.InlineShapes.AddPicture(imgPath);
                        }
                        // If not image, then display as text
                        else
                        {
                            string data = dataTable.Rows[i][j].ToString();
                            table.Cell(i + 2, j + 1).Range.Text = data;
                            // If string is long enough, then make column wider (default value is about 72 points)
                            if (data.Length > 40)
                                table.Cell(i + 2, j + 1).Column.Width = 120f;
                        }
                    }
                }

                // Auto resize columns
                foreach (Column col in table.Columns)
                    col.AutoFit();

                foreach (Range range in document.Words)
                {
                    range.LanguageID = WdLanguageID.wdEnglishUS;
                }
            }
            catch(System.Runtime.InteropServices.COMException)
            {
                System.Windows.Forms.MessageBox.Show("Lost connection with MS Office. Export failed.", "Fail", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
        }

        public static void ExprortReport(System.Data.DataTable reportTable, System.Data.DataTable residueTable, DateTime firstDate, DateTime secondDate, string sellerName, int itemsSold, decimal totalIncome)
        {
            try
            {
                // Summon Word
                Application app = new Application();
                app.Visible = true;
                Document document = app.Documents.Add();
                document.PageSetup.Orientation = WdOrientation.wdOrientPortrait;
                document.Activate();
                Selection doc = document.ActiveWindow.Selection;    // 2 lazy 2 type whole thing

                // Type caption
                doc.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                doc.Font.Size = 20;
                doc.Font.Bold = 1;
                doc.TypeText("Week report");
                doc.TypeParagraph();

                //Type details
                //doc.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                doc.Font.Size = 12;
                doc.Font.Bold = 0;
                doc.TypeText(firstDate.ToString("d MMM yyy", new CultureInfo("en-US")) + " - " + secondDate.ToString("d MMM yyy", new CultureInfo("en-US")));
                doc.TypeParagraph();
                //doc.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                doc.TypeText("Seller: " + sellerName);
                doc.TypeParagraph();
                doc.TypeParagraph();

                //----------------------------------------------------
                //----------------------Sales-------------------------
                //----------------------------------------------------

                //Type Sales table name
                //doc.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                doc.Font.Size = 16;
                doc.Font.Bold = 1;
                doc.TypeText("Sales");
                doc.TypeParagraph();

                doc.Font.Size = 12;

                // Create Sales table and make all borders visible
                Table table = document.Tables.Add(doc.Range, reportTable.Rows.Count + 1, reportTable.Columns.Count);
                table.Rows.Alignment = WdRowAlignment.wdAlignRowCenter;
                table.Borders[WdBorderType.wdBorderTop].LineStyle =
                table.Borders[WdBorderType.wdBorderBottom].LineStyle =
                table.Borders[WdBorderType.wdBorderLeft].LineStyle =
                table.Borders[WdBorderType.wdBorderRight].LineStyle =
                table.Borders[WdBorderType.wdBorderHorizontal].LineStyle =
                table.Borders[WdBorderType.wdBorderVertical].LineStyle = WdLineStyle.wdLineStyleSingle;
                table.Borders[WdBorderType.wdBorderTop].LineWidth =
                table.Borders[WdBorderType.wdBorderRight].LineWidth =
                table.Borders[WdBorderType.wdBorderBottom].LineWidth =
                table.Borders[WdBorderType.wdBorderLeft].LineWidth = WdLineWidth.wdLineWidth150pt;

                // Headers bold
                for (int j = 0; j < reportTable.Columns.Count; j++)
                {
                    table.Cell(1, j + 1).Borders[WdBorderType.wdBorderLeft].LineWidth =
                    table.Cell(1, j + 1).Borders[WdBorderType.wdBorderRight].LineWidth =
                    table.Cell(1, j + 1).Borders[WdBorderType.wdBorderBottom].LineWidth = WdLineWidth.wdLineWidth150pt;
                    table.Cell(1, j + 1).Range.Shading.BackgroundPatternColor = (WdColor)(headerColor.R + 0x100 * headerColor.G + 0x10000 * headerColor.B); ;
                    table.Cell(1, j + 1).Range.Font.Bold = 1;
                    table.Cell(1, j + 1).Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                    table.Cell(1, j + 1).VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                    table.Cell(1, j + 1).Range.Text = reportTable.Columns[j].ColumnName;
                }

                doc.Font.Bold = 0;

                // Fill table with data
                for (int i = 0; i < reportTable.Rows.Count; i++)
                {
                    Color color = i % 2 == 0 ? rowColor : rowAltColor;
                    for (int j = 0; j < reportTable.Columns.Count; j++)
                    {
                        table.Cell(i + 2, j + 1).Range.Shading.BackgroundPatternColor = (WdColor)(color.R + 0x100 * color.G + 0x10000 * color.B); ;
                        table.Cell(i + 2, j + 1).Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                        table.Cell(i + 2, j + 1).VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                        table.Cell(i + 2, j + 1).Range.Font.Bold = 0;

                        string data = reportTable.Rows[i][j].ToString();
                        table.Cell(i + 2, j + 1).Range.Text = data;
                    }
                }
                
                // Auto resize columns in Sales
                foreach (Column col in table.Columns)
                    col.AutoFit();

                foreach (Column col in table.Columns)
                    col.AutoFit();

                doc.SetRange(doc.StoryLength, doc.StoryLength);
                //doc.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                doc.Font.Size = 5;
                doc.Font.Bold = 0;
                doc.TypeParagraph();
                doc.Font.Size = 12;
                doc.TypeText($"In total sold {itemsSold} item{(itemsSold == 1 ? "" : "s")} for ${totalIncome}");
                doc.TypeParagraph();
                doc.TypeParagraph();

                //----------------------------------------------------
                //---------------------Residue------------------------
                //----------------------------------------------------


                //Type Residue table name
                //doc.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                doc.Font.Size = 16;
                doc.Font.Bold = 1;
                doc.TypeText("Residue");
                doc.TypeParagraph();

                doc.Font.Size = 12;

                // Create Residue table and make all borders visible
                table = document.Tables.Add(doc.Range, residueTable.Rows.Count + 1, residueTable.Columns.Count);
                table.Rows.Alignment = WdRowAlignment.wdAlignRowCenter;
                table.Borders[WdBorderType.wdBorderTop].LineStyle =
                table.Borders[WdBorderType.wdBorderBottom].LineStyle =
                table.Borders[WdBorderType.wdBorderLeft].LineStyle =
                table.Borders[WdBorderType.wdBorderRight].LineStyle =
                table.Borders[WdBorderType.wdBorderHorizontal].LineStyle =
                table.Borders[WdBorderType.wdBorderVertical].LineStyle = WdLineStyle.wdLineStyleSingle;
                table.Borders[WdBorderType.wdBorderTop].LineWidth =
                table.Borders[WdBorderType.wdBorderRight].LineWidth =
                table.Borders[WdBorderType.wdBorderBottom].LineWidth =
                table.Borders[WdBorderType.wdBorderLeft].LineWidth = WdLineWidth.wdLineWidth150pt;

                // Headers bold
                for (int j = 0; j < residueTable.Columns.Count; j++)
                {
                    table.Cell(1, j + 1).Borders[WdBorderType.wdBorderLeft].LineWidth =
                    table.Cell(1, j + 1).Borders[WdBorderType.wdBorderRight].LineWidth =
                    table.Cell(1, j + 1).Borders[WdBorderType.wdBorderBottom].LineWidth = WdLineWidth.wdLineWidth150pt;
                    table.Cell(1, j + 1).Range.Shading.BackgroundPatternColor = (WdColor)(headerColor.R + 0x100 * headerColor.G + 0x10000 * headerColor.B); ;
                    table.Cell(1, j + 1).Range.Font.Bold = 1;
                    table.Cell(1, j + 1).Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                    table.Cell(1, j + 1).VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                    table.Cell(1, j + 1).Range.Text = residueTable.Columns[j].ColumnName;
                }

                // Fill table with data
                for (int i = 0; i < residueTable.Rows.Count; i++)
                {
                    Color color = i % 2 == 0 ? rowColor : rowAltColor;
                    for (int j = 0; j < residueTable.Columns.Count; j++)
                    {
                        if (residueTable.Columns[j].ColumnName == "Residue" && Convert.ToInt32(residueTable.Rows[i][j]) <= 3)
                            color = i % 2 == 0 ? rowWarningColor : rowWarningAltColor;

                        table.Cell(i + 2, j + 1).Range.Shading.BackgroundPatternColor = (WdColor)(color.R + 0x100 * color.G + 0x10000 * color.B); ;
                        table.Cell(i + 2, j + 1).Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                        table.Cell(i + 2, j + 1).VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                        table.Cell(i + 2, j + 1).Range.Font.Bold = 0;

                        string data = residueTable.Rows[i][j].ToString();
                        table.Cell(i + 2, j + 1).Range.Text = data;
                    }
                }

                // Auto resize columns in Sales
                foreach (Column col in table.Columns)
                    col.AutoFit();

                doc.SetRange(doc.StoryLength, doc.StoryLength);

                foreach (Range range in document.Words)
                {
                    range.LanguageID = WdLanguageID.wdEnglishUS;
                }
            }
            catch (System.Runtime.InteropServices.COMException)
            {
                System.Windows.Forms.MessageBox.Show("Lost connection with MS Office. Export failed.", "Fail", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
        }
    }
}
