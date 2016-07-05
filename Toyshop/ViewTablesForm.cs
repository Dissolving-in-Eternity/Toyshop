using System;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Toyshop
{
    public partial class ViewTablesForm : Form
    {
        DataSet ds;
        OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\toyshop.accdb");

        public ViewTablesForm()
        {
            InitializeComponent();
        }

        private void ViewTablesForm_Load(object sender, EventArgs e)
        {
            // Fill our dataSet
            ds = Utils.LoadDatabase();

            // Get tables name from combobox 
            cmbListOfTables.Items.Clear();
            cmbListOfTables.Items.AddRange((from DataTable table in ds.Tables.Cast<DataTable>()
                                            select table.TableName).ToArray());
                        
            // Create special hidden column in every table for filtering
            foreach (DataTable table in ds.Tables)
            {
                DataColumn dcRowString = table.Columns.Add("_RowString", typeof(string));
                foreach (DataRow dataRow in table.Rows)
                {
                    StringBuilder sb = new StringBuilder();
                    for (int i = 0; i < table.Columns.Count - 1; i++)
                    {
                        if (table.Columns[i].DataType != typeof(byte[]))
                        {
                            sb.Append(dataRow[i].ToString());
                            sb.Append("\t");
                        }
                    }
                    dataRow[dcRowString] = sb.ToString();
                }
            }

            // Set the default table
            cmbListOfTables.SelectedIndex = 0;
        }

        private void cmbListOfTables_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Display table in DataGridView 
            dgvTables.DataSource = ds.Tables[cmbListOfTables.SelectedItem.ToString()];
            if (dgvTables.Columns.Contains("_RowString"))
                dgvTables.Columns["_RowString"].Visible = false;                  

            // Depends on current table generate list of its columns
            cmbColumns.Items.Clear();
            foreach (DataColumn c in ds.Tables[cmbListOfTables.SelectedItem.ToString()].Columns)
            {
                if (c.ColumnName != "_RowString")
                    cmbColumns.Items.Add(c.ColumnName);
            }

            // Set the default column          
            cmbColumns.SelectedIndex = 0;

            applyFilter();

            // Adjustments for table "Products"
            AdjustTableProducts();
        }

        public void AdjustTableProducts()
        {
            if ((string)cmbListOfTables.SelectedItem == "Products")
            {
                if (dgvTables.Columns.Contains("Photo"))
                {
                    DataGridViewColumn col = dgvTables.Columns["Photo"];
                    (col as DataGridViewImageColumn).ImageLayout = DataGridViewImageCellLayout.Zoom;
                }
                if (dgvTables.Columns.Contains("Description"))
                {
                    DataGridViewColumn col2 = dgvTables.Columns["Description"];
                    col2.Width = 300;
                }
                if (dgvTables.Columns.Contains("ManufacturerCode"))
                {
                    DataGridViewColumn col3 = dgvTables.Columns["ManufacturerCode"];
                    col3.Width = 70;
                }
                if (dgvTables.Columns.Contains("ProductCode"))
                {
                    DataGridViewColumn col4 = dgvTables.Columns["ProductCode"];
                    col4.Width = 55;
                }
            }
        }

        private void txbFilter_TextChanged(object sender, EventArgs e)
        {
            applyAllColumnsFilter();
        }

        private void applyFilter()
        {
            if (txbFilter.Text.Length > 0)
            {
                applyAllColumnsFilter();
            }
            else if (txtFilterValue.Text.Length > 0)
            {
                applyColumnFilter();
            }
        }

        // Actions to perform when column of current table is chosen
        private void cmbColumns_SelectedIndexChanged(object sender, EventArgs e)
        {
            applyFilter();
            cmbOperator.Items.Clear();
            Type colType = ds.Tables[cmbListOfTables.SelectedIndex].Columns[cmbColumns.SelectedIndex].DataType;
            if (colType == typeof(string))
                cmbOperator.Items.AddRange(new string[] { "LIKE", "NOT LIKE" });
            else if (colType == typeof(byte[]))
                cmbOperator.Items.Add("N/A");
            else
                cmbOperator.Items.AddRange(new string[] { "=", "<>", ">", ">=", "<", "<=" });
            cmbOperator.SelectedIndex = 0;
        }

        // Remove Filter Button
        private void btnRemoveFilter_Click(object sender, EventArgs e)
        {
            txbFilter.Clear();
        }

        private void btnAscendingSort_Click(object sender, EventArgs e)
        {
            if ((string)cmbColumns.SelectedItem != "All Columns")
            {
                ListSortDirection lsd = ListSortDirection.Ascending;
                dgvTables.Sort(dgvTables.Columns[cmbColumns.SelectedItem.ToString()], lsd);
            }
            else
            {
                MessageBox.Show("Please, select one column.", "Choose column", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnDescendingSort_Click(object sender, EventArgs e)
        {
            if ((string)cmbColumns.SelectedItem != "All Columns")
            {
                ListSortDirection lsd = ListSortDirection.Descending;
                dgvTables.Sort(dgvTables.Columns[cmbColumns.SelectedItem.ToString()], lsd);
            }
            else
            {
                MessageBox.Show("Please, select one column.", "Choose column", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ViewTablesForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            con.Dispose();
            ds.Dispose();
        }

        private void derp_Click(object sender, EventArgs e)
        {
            Console.Beep(800, 200);
            Console.Beep(600, 100);
            WordExporter.Export(ds.Tables[cmbListOfTables.SelectedIndex]);
        }

        private void durp_Click(object sender, EventArgs e)
        {
            Console.Beep(400, 200);
            Console.Beep(600, 100);
            ExcelExporter.Export(ds.Tables[cmbListOfTables.SelectedIndex]);
        }

        private void dgvTables_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            cmbColumns.SelectedIndex = e.ColumnIndex;
        }

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            applyColumnFilter();
        }

        private void applyColumnFilter()
        {
            string tableName = cmbListOfTables.SelectedItem.ToString();
            if (txtFilterValue.Text.Length > 0)
            {
                try
                {
                    DataColumn col = ds.Tables[tableName].Columns[cmbColumns.SelectedIndex];
                    if (col.DataType != typeof(byte[]))
                        ds.Tables[tableName].DefaultView.RowFilter = string.Format("{0} {1} {2}", 
                            col.ColumnName, cmbOperator.SelectedItem, 
                            col.DataType == typeof(string) ? "'%" + txtFilterValue.Text.Replace("*", "%") + "%'" : txtFilterValue.Text);
                }
                catch (Exception)
                {
                    //txtFilterValue.Text = string.Empty;
                }
            }
            else
                ds.Tables[tableName].DefaultView.RowFilter = string.Empty;
        }

        private void applyAllColumnsFilter()
        {
            string tableName = cmbListOfTables.SelectedItem.ToString();
            if (txbFilter.Text.Length > 0)
                ds.Tables[tableName].DefaultView.RowFilter = string.Format("[_RowString] LIKE '%{0}%'", txbFilter.Text);
            else
                ds.Tables[tableName].DefaultView.RowFilter = string.Empty;
        }

        private void cmbOperator_SelectedIndexChanged(object sender, EventArgs e)
        {
            applyColumnFilter();
        }
    }

}
