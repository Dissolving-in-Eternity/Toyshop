using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Data.OleDb;
using System.IO;

namespace Toyshop
{
    public partial class ViewCatalogForm : Form
    {
        DataSet ds;
        OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\toyshop.accdb");
        OleDbDataAdapter da;

        int[] productCodes;
        int currentProduct = 0;
        DataTable dt;

        List<int> orders = new List<int>();

        public Image OrderButton
        {
            get { return btnOrder.BackgroundImage; }
            set { btnOrder.BackgroundImage = value; }
        }

        public ViewCatalogForm()
        {
            InitializeComponent();
        }

        private void ViewCatalogForm_Load(object sender, EventArgs e)
        {
            #region DB, Table load, comboboxes

            UpdateProductsAvailability();

            // Fill out dataSet
            ds = Utils.LoadDatabase();

            pctbxInStock.BringToFront();
            lblCurrentNumber.BringToFront();

            // Fill out combobox Categories
            var categories = from DataRow row in ds.Tables["Category"].Rows select row["Category"];
            cmbCategory.Items.AddRange(categories.ToArray());
            cmbCategory.Items.Add("All");
            cmbCategory.SelectedItem = "All";

            // Fill out combobox Age Groups
            var ageGroups = from DataRow row in ds.Tables["Products"].Rows select row["AgeGroup"];
            for (int i = 0; i < ageGroups.ToArray().Length; i++)
            {
                if (!cmbAgeGroup.Items.Contains(ageGroups.ElementAt(i).ToString()))
                    cmbAgeGroup.Items.Add(ageGroups.ElementAt(i).ToString());
            }
            cmbAgeGroup.Items.Add("All");
            cmbAgeGroup.SelectedItem = "All";

            // Fill out combobox Manufactorers
            var manufactorers = from DataRow row in ds.Tables["Manufacturers"].Rows select row["ManufacturerTitle"];
            cmbManufacturer.Items.AddRange(manufactorers.ToArray());
            cmbManufacturer.Items.Add("All");
            cmbManufacturer.SelectedItem = "All";          

            // Get whole Products table
            da = new OleDbDataAdapter("SELECT * FROM Products", con);
            dt = new DataTable();
            da.Fill(dt);

            // Get ALL Product Codes
            GetProductCodes();

            FillOutProduct(productCodes[0]);

            #endregion

            #region Tree load

            int currentImageIndex = 0;
            DataView dv = new DataView(ds.Tables["Products"]);

            // Load categories
            var categoriesForTree = (from DataRow row in ds.Tables["Category"].Rows select row).ToArray();
            for (int i = 0; i < ds.Tables["Category"].Rows.Count; i++)
            {
                TreeNode node = new TreeNode(ds.Tables["Category"].Rows[i]["Category"].ToString());
                node.Tag = "Category";
                node.ImageIndex = currentImageIndex++ % imageList.Images.Count;
                node.SelectedImageIndex = node.ImageIndex;
                //root.Nodes.Add(node);
                tree.Nodes.Add(node);

                // Load products in those categories
                dv.RowFilter = "Category='" + node.Text + "'";
                for (int j = 0; j < dv.Count; j++)
                {
                    TreeNode n = new TreeNode(dv[j]["ProductTitle"].ToString());
                    n.Tag = "Product";
                    n.ImageIndex = currentImageIndex++ % imageList.Images.Count;
                    n.SelectedImageIndex = n.ImageIndex;
                    node.Nodes.Add(n);
                }
            }

            #endregion
        }

        public void UpdateProductsAvailability()
        {
            DataTable residue = new DataTable();
            da = new OleDbDataAdapter($@"SELECT Sup.ProductTitle AS [ProductTitle],
                                                [Sup.Data] - [Sal.Data] AS [Residue] 
                                         FROM (SELECT Products.ProductTitle,
                                               SUM(Supplies.Amount) AS [Data] 
                                               FROM Supplies, Products
                                               WHERE Supplies.ProductCode = Products.ProductCode
                                               GROUP BY Products.ProductTitle) AS Sup,
                                               
                                               (SELECT Products.ProductTitle,
                                                SUM(Sales.Amount) AS [Data] 
                                                FROM Sales, Products
                                                WHERE Sales.ProductCode = Products.ProductCode
                                                GROUP BY Products.ProductTitle) AS Sal
                                         WHERE Sup.ProductTitle = Sal.ProductTitle", con);

            da.Fill(residue);

            foreach(DataRow row in residue.Rows)
            {
                bool available = true;
                if (Convert.ToInt32(row["Residue"]) <= 0)
                    available = false;

                string updateString = $@"UPDATE Products
                                         SET InStock={available}
                                         WHERE ProductTitle LIKE '{row["ProductTitle"]}'";
                OleDbCommand updateCommand = new OleDbCommand(updateString, con);
                
                try
                {
                    con.Open();
                    updateCommand.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this.Owner, ex.Message, "Update Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally { con.Close(); }
            }

            // Get whole Products table
            da = new OleDbDataAdapter("SELECT * FROM Products", con);
            dt = new DataTable();
            da.Fill(dt);

            // Mega crutch
            if (lblName.Text != "Product Name")
            {
                // If product available\not available, show corresponding image
                var prod = from DataRow x in dt.Rows where x["ProductTitle"].ToString() == lblName.Text select x[9];
                if (Convert.ToBoolean(prod.ElementAt(0)) == true)
                    pctbxInStock.Image = Properties.Resources.ok_check_yes_tick_accept_success_512;
                else
                    pctbxInStock.Image = Properties.Resources.not_avaliable;
            }
        }

        #region Products filling

        private void FillOutProduct(int id)
        {
            da = new OleDbDataAdapter("SELECT * FROM Products WHERE ProductCode = " + id, con);
            DataTable table = new DataTable();
            da.Fill(table);

            // Retrieving current product code, name, description, price and applying to specified controls
            lblCurrentNumber.Text = "id: " + table.Rows[0][0].ToString();
            lblName.Text = table.Rows[0][1].ToString();
            txbDescription.Text = table.Rows[0][6].ToString();
            lblPrice.Text = "$" + table.Rows[0][8].ToString();

            // If product available\not available, show corresponding image
            if ((bool)table.Rows[0][9] == true)
                pctbxInStock.Image = Properties.Resources.ok_check_yes_tick_accept_success_512;
            else
                pctbxInStock.Image = Properties.Resources.not_avaliable;

            // Retrieving image to picturebox
            byte[] img = (byte[])table.Rows[0][7];
            MemoryStream ms = new MemoryStream(img);
            pctbxCatalogImage.Image = Image.FromStream(ms);

            // listView
            listView.Items.Clear();
            listView.Items.Add(new ListViewItem("Age group: " + table.Rows[0][4].ToString()));
            listView.Items.Add(new ListViewItem("Size: " + table.Rows[0][5].ToString()));

            // Get manufacturer
            da = new OleDbDataAdapter($@"SELECT ManufacturerTitle FROM Products, Manufacturers WHERE 
                                Manufacturers.ManufacturerCode LIKE '{table.Rows[0][2].ToString()}' 
                                AND Products.ManufacturerCode = Manufacturers.ManufacturerCode", con);
            DataTable tbl = new DataTable();
            da.Fill(tbl);

            listView.Items.Add(new ListViewItem("Manufacturer: " + tbl.Rows[0][0].ToString()));
            listView.Items.Add(new ListViewItem("Category: " + table.Rows[0][3].ToString()));

            // label Count
            lblCount.Text = $"{currentProduct+1}/{dt.Rows.Count.ToString()}";

            if (orders.Contains(productCodes[currentProduct]))
                btnOrder.BackgroundImage = Properties.Resources.full_cart;
            else
                btnOrder.BackgroundImage = Properties.Resources.empty_cart;

            da.Dispose();
        }

        private void NoMatchingProductAvailable()
        {
            // Clear current product code, name, description, price and applying to specified controls
            lblCurrentNumber.Text = "0";
            lblName.Text = "No matches.";
            txbDescription.Text = "No products corresponding to your filter settings. Please, DO NOT overuse filters and try again.";
            lblPrice.Text = "0.00$";

            pctbxInStock.Image = Properties.Resources.not_avaliable;
            pctbxCatalogImage.Image = pctbxCatalogImage.ErrorImage;
            listView.Clear();

            lblCount.Text = "0/0";
        }

        #endregion

        #region Queries/Filters

        private void btnQuery_Click(object sender, EventArgs e)
        {
            currentProduct = 0;

            dt = new DataTable();

            string category = cmbCategory.SelectedItem.ToString();
            string ageGroup = cmbAgeGroup.SelectedItem.ToString();
            string manufacturer = cmbManufacturer.SelectedItem.ToString();
            string query = "";

            if (category != "All" || ageGroup != "All" || manufacturer != "All")
            {
                // CATEGORY
                if (category != "All")
                {
                    query = $"SELECT * FROM Products WHERE Category LIKE '{category}'";

                    if (ageGroup != "All")
                        query = $"SELECT * FROM Products WHERE Category LIKE '{category}' AND AgeGroup LIKE '{ageGroup}'";

                    if (manufacturer != "All")
                        query = $@"SELECT * FROM Products, Manufacturers WHERE Products.Category LIKE '{category}' 
                                AND Manufacturers.ManufacturerTitle LIKE '{manufacturer}' 
                                AND Products.ManufacturerCode = Manufacturers.ManufacturerCode";

                    if (ageGroup != "All" && manufacturer != "All")
                        query = $@"SELECT * FROM Products, Manufacturers WHERE Products.Category LIKE '{category}'
                                AND Manufacturers.ManufacturerTitle LIKE '{manufacturer}'
                                AND Products.AgeGroup LIKE '{ageGroup}' 
                                AND Products.ManufacturerCode = Manufacturers.ManufacturerCode";
                }

                // AGE GROUP
                else if (ageGroup != "All")
                {
                    query = $"SELECT * FROM Products WHERE AgeGroup LIKE '{ageGroup}'";

                    if (manufacturer != "All")
                        query = $@"SELECT * FROM Products, Manufacturers WHERE Products.AgeGroup LIKE '{ageGroup}' 
                                AND Manufacturers.ManufacturerTitle LIKE '{manufacturer}' 
                                AND Products.ManufacturerCode = Manufacturers.ManufacturerCode";
                }

                // MANUFACTURER
                else if (manufacturer != "All")
                {
                    query = $@"SELECT * FROM Products, Manufacturers WHERE Manufacturers.ManufacturerTitle LIKE '{manufacturer}'
                            AND Products.ManufacturerCode = Manufacturers.ManufacturerCode";
                }               
            }
            else
            {
                query = $"SELECT * FROM Products";            
            }

            da = new OleDbDataAdapter(query, con);
            dt = new DataTable();
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                GetProductCodes();
                FillOutProduct(productCodes[0]);
            }
            else
                NoMatchingProductAvailable();
        }

        // Choose product by price range
        private void btnPriceFilter_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(txbPriceFrom.Text) && !String.IsNullOrWhiteSpace(txbPriceTo.Text))
            {
                da = new OleDbDataAdapter($"SELECT * FROM Products WHERE Price BETWEEN {txbPriceFrom.Text} AND {txbPriceTo.Text}", con);
                dt = new DataTable();
                da.Fill(dt);
                GetProductCodes();
                FillOutProduct(productCodes[0]);
            }
            else
                MessageBox.Show("Please, enter valid values.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        // Method, used for filtering by name/description, occurs when user types smth is the texbox
        private void txbFilter_TextChanged(object sender, EventArgs e)
        {
            if (txbFilter.Text.Length > 0)
            {
                for (int i = 0; i < dt.Rows.Count - 1; i++)
                {
                    string name = (string)dt.Rows[i][1];
                    string description = (string)dt.Rows[i][6];

                    if (name.Contains(txbFilter.Text, StringComparison.CurrentCultureIgnoreCase) ||
                        description.Contains(txbFilter.Text, StringComparison.CurrentCultureIgnoreCase))
                    {
                        FillOutProduct(productCodes[i]);
                    }
                }
            }
            else
                FillOutProduct(productCodes[0]);
        }

        private void btnRemoveFilter_Click(object sender, EventArgs e)
        {
            txbFilter.Clear();
        }

        #endregion

        #region GetProductCodes/Prev/Next

        private void GetProductCodes()
        {            
            productCodes = new int[dt.Rows.Count];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                productCodes[i] = (int)dt.Rows[i][0];
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (currentProduct < dt.Rows.Count - 1)
            {
                currentProduct++;
                FillOutProduct(productCodes[currentProduct]);
            }
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            if (currentProduct > 0)
            {
                currentProduct--;
                FillOutProduct(productCodes[currentProduct]);
            }
        }

        #endregion

        #region Tree

        private void categoryTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            listView.Items.Clear();
            TreeNode node = tree.SelectedNode;

            if (node != null && node.Tag.ToString() != "Root")
            {
                DataView dv = new DataView(ds.Tables["Products"]);

                // Show product details if selected product in tree
                if (node.Tag.ToString() == "Product")
                {
                    dv.RowFilter = "Category='" + node.Parent.Text + "'";
                    FillOutProduct((int)dv[node.Index]["ProductCode"]);
                }
            }
        }

        private void listView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tree.SelectedNode.Tag.ToString() == "Category")
                tree.SelectedNode = tree.SelectedNode.Nodes[listView.SelectedItems[0].Index];
        }

        #endregion

        #region Order

        bool firstClick = true;
        private void btnOrder_Click(object sender, EventArgs e)
        {
            //If admin then ask to re-login as seller
            if (AccountManager.GetRights() == AccountManager.AccountType.ADMIN)
            {
                MessageBox.Show("You can not place order as admin. Please, log in as seller to proceed.",
                            "Please re-log", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                // If product available
                if ((bool)dt.Rows[currentProduct][9] == true)
                {
                    if (firstClick)
                    {
                        ProcessOrderClick();
                        firstClick = false;
                        MessageBox.Show("Product successufuly added to the cart. You can click on the cart icon again to remove a product. \n\nTo proceed with the order, click 'Place an order'.",
                            "Product successufuly added.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                        ProcessOrderClick();
                }
                else
                    MessageBox.Show("Product is not avaliable. Please, make sure that the check mark is green before thoughtlessly clicking and try again.",
                        "Product is not avaliable.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ProcessOrderClick()
        {
            if (!orders.Contains(productCodes[currentProduct]))
            {
                // Add product ID to orders
                orders.Add(productCodes[currentProduct]);
                // Change button Image
                btnOrder.BackgroundImage = Properties.Resources.full_cart;
            }
            else
            {
                orders.Remove(productCodes[currentProduct]);
                btnOrder.BackgroundImage = Properties.Resources.empty_cart;
            } 
        }

        private void btnPlaceOrder_Click(object sender, EventArgs e)
        {
            if (orders.Count > 0)
            {
                PlaceOrderForm form = new PlaceOrderForm(orders, this);
                form.Show(this);
            }
            else
                MessageBox.Show("You haven't added any products. Please, add some and try again.",
                    "No products in the cart.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        #endregion
    }
}
