using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Toyshop
{
    public partial class PlaceOrderForm : Form
    {
        DataTable dt = new DataTable();
        OleDbDataAdapter da;

        // Store order codes passed from VievCatalogForm here
        List<int> orderCodes;

        // Being used for storing combobox values
        List<int> orderQuanities = new List<int>();

        public PlaceOrderForm()
        {
            InitializeComponent();
        }

        // Get ViewCatalogForm and order codes
        private ViewCatalogForm viewCatalogForm = null;
        public PlaceOrderForm(List<int> orders, Form ViewCatalog)
        {
            InitializeComponent();
            orderCodes = orders;
            viewCatalogForm = ViewCatalog as ViewCatalogForm;
        }

        private void PlaceOrderForm_Load(object sender, EventArgs e)
        {
            dgvOrders.DataSource = dt;

            // Column Number
            DataColumn col = new DataColumn("№", typeof(int));
            col.AutoIncrement = true;
            col.AutoIncrementSeed = 1;
            dt.Columns.Add(col);
            
            // ProductTitle, Price
            FillOutTitleAndPrice();

            // Combobox "Quantity"
            CreateComboBoxColumn();

            // Column TOTAL
            col = new DataColumn("Total", typeof(decimal));
            dt.Columns.Add(col);                     

            // "Delete" button
            AddButtonColumn();

            UpdateCombobox();
            UpdatePrices();
            AdjustControls();          
        }

        #region Info Updates

        private void UpdatePrices()
        {
            // Get currently displayed values in combobox, multiply by Price and assign to "Total" column
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dgvOrders.Rows[i].Cells["Quantity"].Value = dgvOrders.Rows[i].Cells["Quantity"].EditedFormattedValue;
                dt.Rows[i][3] = Convert.ToInt32(dgvOrders.Rows[i].Cells["Quantity"].FormattedValue) * (decimal)dt.Rows[i][2];

                // Update Number
                dt.Rows[i][0] = i + 1;
            }

            // Update Subtotal
            lblOrderSubtotal.Text = $"Order subtotal:  ${dt.Compute("Sum(Total)", string.Empty)}";

            // Update orders count
            lblOrdersCount.Text = $"{dt.Rows.Count} items added to Cart:";
        }

        private void FillOutTitleAndPrice()
        {
            dt.Clear();

            foreach (int code in orderCodes)
            {
                da = new OleDbDataAdapter($"SELECT ProductTitle, Price FROM Products WHERE ProductCode = {code}", Utils.connection);
                da.Fill(dt);
            }       
        }

        #endregion

        #region AdjustControls

        private void AdjustControls()
        {
            // CONTROLS ADJUSTMENTS

            DataGridViewColumn col = dgvOrders.Columns["№"];
            col.Width = 30;
            col.ReadOnly = true;

            col = dgvOrders.Columns["ProductTitle"];
            col.Width = 264;
            col.ReadOnly = true;

            col = dgvOrders.Columns["Price"];
            col.Width = 100;
            col.ReadOnly = true;

            col = dgvOrders.Columns["Total"];
            col.Width = 100;
            col.ReadOnly = true;
        }

        #endregion

        #region ComboBoxColumn, ButtonColumn

        private void CreateComboBoxColumn()
        {
            DataGridViewComboBoxColumn column = new DataGridViewComboBoxColumn();

            column.DataPropertyName = "Quantity";
            column.HeaderText = "Quantity";
            column.Width = 50;
            column.MaxDropDownItems = 10;
            column.FlatStyle = FlatStyle.Popup;
            column.Name = "Quantity";
            column.HeaderText = "Quantity";
            column.DefaultCellStyle.NullValue = "1";

            dgvOrders.Columns.Add(column);
        }

        private void UpdateCombobox()
        {
            DataTable dtSuppliesAmount = new DataTable();
            DataTable dtSalesAmount = new DataTable();

            for (int i = 0; i < orderCodes.Count; i++)
            {
                dtSuppliesAmount.Clear();
                dtSalesAmount.Clear();

                da = new OleDbDataAdapter($@"SELECT SUM(Amount) AS SuppliesAmount FROM Supplies WHERE ProductCode = {orderCodes[i]}", Utils.connection);
                da.Fill(dtSuppliesAmount);
                da = new OleDbDataAdapter($@"SELECT SUM(Amount) AS SalesAmount FROM Sales WHERE ProductCode = {orderCodes[i]}", Utils.connection);
                da.Fill(dtSalesAmount);

                int sup = 0;
                int.TryParse(dtSuppliesAmount.Rows[0][0].ToString(), out sup);
                int sal = 0;
                int.TryParse(dtSalesAmount.Rows[0][0].ToString(), out sal);
                int availableAmount = Math.Max(0, sup - sal);

                DataGridViewComboBoxCell cell = dgvOrders.Rows[i].Cells["Quantity"] as DataGridViewComboBoxCell;
                cell.Items.AddRange((from x in Enumerable.Range(1, availableAmount) select x.ToString()).ToArray());
            }
        }

        private void StoreComboboxValues(int deleteRowIndex)
        {
            orderQuanities.Clear();
            foreach (DataGridViewRow row in dgvOrders.Rows)
                if (row.Index != deleteRowIndex)
                    orderQuanities.Add(Convert.ToInt32(row.Cells["Quantity"].FormattedValue));
        }

        private void SetComboboxValues()
        {
            for (int i = 0; i < dgvOrders.RowCount; i++)
            {
                dgvOrders.Rows[i].Cells["Quantity"].Value = orderQuanities[i].ToString();
            }
        }

        private void AddButtonColumn()
        {
            DataGridViewButtonColumn buttons = new DataGridViewButtonColumn();
            {
                buttons.Text = "Delete";
                buttons.UseColumnTextForButtonValue = true;
                buttons.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                buttons.FlatStyle = FlatStyle.Standard;
                buttons.CellTemplate.Style.BackColor = Color.Honeydew;
            }
            dgvOrders.Columns.Add(buttons);
        }

        #endregion

        #region Cell Click && Cell Dirty State Changed

        private void dgvOrders_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            // If button Delete clicked
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                if(orderCodes.Count > 1)
                {
                    StoreComboboxValues(e.RowIndex);
                    orderCodes.RemoveAt(e.RowIndex);
                    FillOutTitleAndPrice();
                    UpdateCombobox();
                    SetComboboxValues();
                    UpdatePrices();
                }
                else
                {
                    orderCodes.Clear();
                    Close();
                    this.viewCatalogForm.OrderButton = Properties.Resources.empty_cart;
                }
            }
        }       

        private void dgvOrders_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            UpdatePrices();
        }

        #endregion

        #region Confirm Order

        private void btnConfirmOrder_Click(object sender, EventArgs e)
        {
            AddRowToSales();

            MessageBox.Show("Order successfully completed.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Close();
            orderCodes.Clear();
            viewCatalogForm.OrderButton = Properties.Resources.empty_cart;
            viewCatalogForm.UpdateProductsAvailability();
        }

        public void AddRowToSales()
        {
            for (int i = 0; i < orderCodes.Count; i++)
            {
                string insertString = $@"INSERT INTO Sales (ProductCode, Date, Amount, SellerName) 
                        VALUES ({orderCodes[i]}, '{DateTime.Now}', {dgvOrders.Rows[i].Cells["Quantity"].FormattedValue}, '{AccountManager.Name}')";

                OleDbCommand insertCommand = new OleDbCommand(Utils.FixReservedWords(insertString), Utils.connection);

                Utils.connection.Open();
                try
                {
                    insertCommand.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally { Utils.connection.Close(); }
            }
        }

        #endregion        
    }
}
