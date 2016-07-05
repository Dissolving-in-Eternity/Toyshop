using System;
using System.Data;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Toyshop
{
    public partial class ReportsAdvancedForm : Form
    {
        public DataSet ds { get; private set; }
        OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\toyshop.accdb");
        OleDbCommand cmd;
        OleDbDataAdapter ad;

        public ReportsAdvancedForm()
        {
            InitializeComponent();
        }

        private void ReportsForm_Load(object sender, EventArgs e)
        {
            // Fill our dataSet
            ds = Utils.LoadDatabase();
            dgvResult.DataSource = ds.Tables["Products"];
            AdjustTableProducts();
        }

        private void btnQueryProducts_Click(object sender, EventArgs e)
        {
            // If specific button is checked
            if (radioInStock.Checked)
            {
                CreateProcedureProductsInStock();
                ExecuteProcedureProductsInStock();
                AdjustTableProducts();
            }
            else if (radioByCategory.Checked)
            {
                QueryForm queryForm = new QueryForm("Category", this);
                queryForm.Show(this);                
            }
            else if (radioByName.Checked)
            {
                QueryForm queryForm = new QueryForm("ProductTitle", this);
                queryForm.Show(this);
            }
            else if (radioByManufacturer.Checked)
            {
                QueryForm queryForm = new QueryForm("ManufacturerCode", this);
                queryForm.Show(this);
            }
            else if (radioByPriceRange.Checked)
            {
                QueryForm queryForm = new QueryForm("Lower value", "Upper value", this);
                queryForm.Show(this);

            }
        }

        public void ExecuteQuery(string data)
        {
            DataTable table = new DataTable();
            try
            {
                if(radioByCategory.Checked)
                    ad = new OleDbDataAdapter("SELECT * FROM Products WHERE Category LIKE " + "'%" + data + "%'", con);
                else if (radioByName.Checked)
                    ad = new OleDbDataAdapter("SELECT * FROM Products WHERE ProductTitle LIKE " + "'%" + data + "%'", con);
                else if (radioByManufacturer.Checked)
                    ad = new OleDbDataAdapter("SELECT * FROM Products WHERE ManufacturerCode = "  + data, con);

                ad.Fill(table);
                dgvResult.DataSource = null;
                dgvResult.DataSource = table;
                AdjustTableProducts();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void ExecuteQuery(string low, string high)
        {
            DataTable table = new DataTable();
            try
            {
                ad = new OleDbDataAdapter("SELECT * FROM Products WHERE Price > " + low + " AND Price < " + high, con);
                ad.Fill(table);
                dgvResult.DataSource = null;
                dgvResult.DataSource = table;
                AdjustTableProducts();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CreateProcedureProductsInStock()
        {
            // Create stored procedure
            try
            {
                con.Open();
                string commandText = "CREATE PROCEDURE [SelectFromProductsInStock] AS SELECT * FROM [Products] WHERE [InStock] = true";
                cmd = new OleDbCommand(commandText, con);
                cmd.ExecuteNonQuery();
            }
            catch(Exception ex)
            { MessageBox.Show(ex.Message); }
            finally
            { con.Close(); }
        }

        private void ExecuteProcedureProductsInStock()
        {
            try
            {
                cmd = new OleDbCommand("SelectFromProductsInStock", con);
                cmd.CommandType = CommandType.StoredProcedure;
                OleDbDataAdapter da = new OleDbDataAdapter(cmd);

                DataTable table = new DataTable("ProductsInStock");
                da.Fill(table);
                dgvResult.DataSource = table;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (con.State == ConnectionState.Open) con.Close();
            }
        }

        public void AdjustTableProducts()
        {
            if (ds.Tables["Products"] != null)
            {
                if (dgvResult.Columns.Contains("Photo"))
                {
                    DataGridViewColumn col = dgvResult.Columns["Photo"];
                    (col as DataGridViewImageColumn).ImageLayout = DataGridViewImageCellLayout.Zoom;
                }
                if (dgvResult.Columns.Contains("Description"))
                {
                    DataGridViewColumn col2 = dgvResult.Columns["Description"];
                    col2.Width = 300;
                }
                if (dgvResult.Columns.Contains("ManufacturerCode"))
                {
                    DataGridViewColumn col3 = dgvResult.Columns["ManufacturerCode"];
                    col3.Width = 70;
                }
                if (dgvResult.Columns.Contains("ProductCode"))
                {
                    DataGridViewColumn col4 = dgvResult.Columns["ProductCode"];
                    col4.Width = 55;
                }
            }
        }

        private void ReportsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            con.Dispose();
            ds.Dispose();
        }

        private void btnMultiTable_Click(object sender, EventArgs e)
        {
            DataTable table = new DataTable();
            try
            {
                ad = new OleDbDataAdapter("SELECT DISTINCT p.ProductTitle, p.Category, p.Price, p.InStock FROM Products AS p, Supplies AS s " +
                    "WHERE p.ProductCode = s.ProductCode AND s.WarehouseNumber = " + int.Parse(txtMultitable.Text), con);
                ad.Fill(table);
                dgvResult.DataSource = null;
                dgvResult.DataSource = table;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnsalesThisMonth_Click(object sender, EventArgs e)
        {
            DataTable table = new DataTable();
            try
            {
                ad = new OleDbDataAdapter("SELECT count(*) as 'Total sales', sum(p.Price) as 'Profit' FROM Products AS p, Sales AS s " +
                    "WHERE p.ProductCode = s.ProductCode", con);
                ad.Fill(table);
                dgvResult.DataSource = null;
                dgvResult.DataSource = table;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnTotalUnitsSold_Click(object sender, EventArgs e)
        {
            DataTable sales = ds.Tables["Sales"];
            if (!sales.Columns.Contains("SalesSharePercent"))
            {
                DataColumn col = new DataColumn("SalesSharePercent", typeof(int));
                col.Expression = "Amount/Sum(Amount)*100";
                sales.Columns.Add(col);
            }

            dgvResult.DataSource = null;
            dgvResult.DataSource = sales;
        }

        private void btnDiscountAndDeviance_Click(object sender, EventArgs e)
        {
            DataTable prod = ds.Tables["Products"];
            if (!(prod.Columns.Contains("NewPrice") || prod.Columns.Contains("Deviance")))
            {
                DataColumn col1 = new DataColumn("NewPrice", typeof(decimal));
                col1.Expression = "IIF(Price>10, Price*0.8, Price)";
                DataColumn col2 = new DataColumn("Deviance", typeof(decimal));
                col2.Expression = "Price-avg(Price)";
                prod.Columns.Add(col1);
                prod.Columns.Add(col2);
            }

            dgvResult.DataSource = null;
            dgvResult.DataSource = prod;
            AdjustTableProducts();
        }

        private void btnToWord_Click(object sender, EventArgs e)
        {
            WordExporter.Export(dgvResult.DataSource as DataTable);
        }

        private void btnToExcel_Click(object sender, EventArgs e)
        {
            ExcelExporter.Export(dgvResult.DataSource as DataTable);
        }

        private void btnProcedures_Click(object sender, EventArgs e)
        {
            CustomQueryForm form = new CustomQueryForm(con, this);
            form.Show(this);
        }
    }
}
