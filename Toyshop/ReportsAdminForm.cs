using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Windows.Forms.DataVisualization.Charting;

namespace Toyshop
{
    public partial class ReportsAdminForm : Form
    {
        OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\toyshop.accdb");
        OleDbDataAdapter ad;
        DataTable dt = new DataTable();

        public ReportsAdminForm()
        {
            InitializeComponent();
        }

        private void ReportsAdminForm_Load(object sender, EventArgs e)
        {
            dgvAmount.Rows.Add();

            LoadSellersList();

            PopulateComboboxWithYear();
            PopulateComboboxWithMonth();
            PopulateComboboxWithWeek();
            PopulateComboboxWithDay();

            cmbYear.SelectedIndex = cmbYear.Items.Count - 1;
            cmbMonth.SelectedIndex = cmbMonth.Items.Count - 1;
            cmbWeek.SelectedIndex = cmbWeek.Items.Count - 1;
            cmbDay.SelectedIndex = cmbDay.Items.Count - 1;
        }

        private void UpdateSalesHistoryChart(DateTime firstDate, DateTime secondDate)
        {
            chrtSalesHistory.Series.Clear();
            chrtSalesHistory.Titles[0].Text = firstDate.ToString("MMMM yyyy", new System.Globalization.CultureInfo("en-US"));

            DataTable dataTable = new DataTable();
            ad = new OleDbDataAdapter($@"SELECT Sales.SellerName AS [Seller], SUM(Sales.Amount) AS [Amount], FORMAT([Sales.Date],'yyyy.MM.dd') AS [Date] 
                                         FROM Sales 
                                         WHERE Sales.Date >= FORMAT('{firstDate}', 'dd/MM/yyyy') AND Sales.Date <= FORMAT('{secondDate}', 'dd/MM/yyyy')
                                         GROUP BY FORMAT([Sales.Date],'yyyy.MM.dd'), Sales.SellerName
                                         ORDER BY FORMAT([Sales.Date],'yyyy.MM.dd') ASC", con);
            ad.Fill(dataTable);
            foreach (DataRow row in dataTable.Rows)
                row["Date"] = Convert.ToDateTime(row["Date"]).ToString("dd.MM.yyyy");

            foreach (string seller in (from DataRowView item in cmbSellers.Items select item["Name"]))
            {
                DataTable data = dataTable.Copy();
                if (data.Rows.Count > 0)
                {
                    Series series = new Series(seller);
                    series.ChartType = SeriesChartType.StackedArea;

                    foreach (DataRow row in data.Rows)
                        if (row["Seller"].ToString().ToLower() != seller.ToLower())
                            row["Amount"] = 0;

                    series.Points.DataBind(data.Rows, "Date", "Amount", null);
                    chrtSalesHistory.Series.Add(series);
                }
            }
        }

        private void UpdateSalesSharePie(DateTime firstDate, DateTime secondDate)
        {
            chrtSalesShare.Series.Clear();
            chrtSalesShare.Titles[0].Text = "Sales share for " + firstDate.ToString("MMMM", new System.Globalization.CultureInfo("en-US"));

            DataTable data = new DataTable();
            ad = new OleDbDataAdapter($@"SELECT Sales.SellerName AS [Seller], SUM(Sales.Amount) AS [Amount]
                                         FROM Sales 
                                         WHERE Sales.Date >= FORMAT('{firstDate}', 'dd/MM/yyyy') AND Sales.Date <= FORMAT('{secondDate}', 'dd/MM/yyyy')
                                         GROUP BY Sales.SellerName", con);
            ad.Fill(data);
            
            if (data.Rows.Count > 0)
            {
                Series series = new Series();
                series.ChartType = SeriesChartType.Pie;
                series["PieLabelStyle"] = "Disabled";

                series.Points.DataBind(data.Rows, "Seller", "Amount", null);
                chrtSalesShare.Series.Add(series);

                string bestSeller = data.Rows[0]["Seller"].ToString();
                int bestAmount = Convert.ToInt32(data.Rows[0]["Amount"]);
                foreach (DataRow row in data.Rows)
                    if(Convert.ToInt32(row["Amount"]) > bestAmount)
                    {
                        bestAmount = Convert.ToInt32(row["Amount"]);
                        bestSeller = row["Seller"].ToString();
                    }
                chrtSalesShare.Titles[1].Text = $"Employee of the month is {bestSeller}";
            }
        }

        private void UpdateSellersStatsRadar(DateTime firstDate, DateTime secondDate)
        {
            chrtRadar.Series.Clear();
            chrtRadar.Titles[0].Text = "Sellers stats for " + firstDate.ToString("MMMM", new System.Globalization.CultureInfo("en-US"));

            DataTable data = new DataTable();
            ad = new OleDbDataAdapter($@"SELECT Sales.SellerName AS [Seller], 
                                                SUM(Sales.Amount) / 10 AS [Amount],
                                                SUM(Sales.Amount * Products.Price) / 100 AS [Total],
                                                '1' AS [Days]
                                         FROM Sales, Products 
                                         WHERE Sales.ProductCode = Products.ProductCode AND
                                               Sales.Date >= FORMAT('{firstDate}', 'dd/MM/yyyy') AND 
                                               Sales.Date <= FORMAT('{secondDate}', 'dd/MM/yyyy')
                                         GROUP BY Sales.SellerName", con);
            ad.Fill(data);

            DataTable dataDateCount = new DataTable();
            ad = new OleDbDataAdapter($@"SELECT Seller, COUNT(Days) AS [Days]
                                         FROM(SELECT Sales.SellerName AS [Seller], 
                                                     FORMAT([Sales.Date],'yyyy.MM.dd') AS [Days]
                                              FROM Sales
                                              WHERE Sales.Date >= FORMAT('{firstDate}', 'dd/MM/yyyy') AND 
                                                    Sales.Date <= FORMAT('{secondDate}', 'dd/MM/yyyy')
                                              GROUP BY Sales.SellerName, FORMAT([Sales.Date],'yyyy.MM.dd'))
                                         GROUP BY Seller", con);
            ad.Fill(dataDateCount);

            foreach(DataRow row in data.Rows)
            {
                foreach (DataRow countRow in dataDateCount.Rows)
                    if (row["Seller"].Equals(countRow["Seller"]))
                        row["Days"] = countRow["Days"];
            }

            foreach(DataRow row in data.Rows)
            {
                Series series = new Series(row["Seller"].ToString());
                series.ChartType = SeriesChartType.Radar;

                series.Points.Add(Convert.ToInt32(row["Amount"])).AxisLabel = "Items x10";
                series.Points.Add(Convert.ToDouble(row["Total"])).AxisLabel = "Money x100";
                series.Points.Add(Convert.ToInt32(row["Days"])).AxisLabel = "Days";

                chrtRadar.Series.Add(series);
            }
        }

        private void LoadSellersList()
        {
            DataTable sellersList = new DataTable();
            ad = new OleDbDataAdapter($@"SELECT FullName AS [Name] FROM Sellers", con);
            ad.Fill(sellersList);
            cmbSellers.ValueMember = "Name";
            cmbSellers.DataSource = sellersList;
        }

        private void FillOutDataGridView()
        {
            // TOTAL
            DataTable dtTotal = new DataTable();
            ad = new OleDbDataAdapter($@"SELECT SUM(Products.Price * Sales.Amount) AS Total
                                         FROM Products, Sales WHERE Products.ProductCode = Sales.ProductCode", con);
            ad.Fill(dtTotal);

            // YEAR TOTAL
            DataTable dtYear = new DataTable();
            ad = new OleDbDataAdapter($@"SELECT SUM(Products.Price * Sales.Amount) AS [Year]
                                         FROM Products, Sales WHERE Products.ProductCode = Sales.ProductCode
                                         AND DatePart('yyyy', [Sales.Date]) = '{cmbYear.SelectedValue}'", con);
            ad.Fill(dtYear);

            // MONTH TOTAL
            DataTable dtMonth = new DataTable();
            ad = new OleDbDataAdapter($@"SELECT SUM(Products.Price * Sales.Amount) AS [Month]
                                         FROM Products, Sales WHERE Products.ProductCode = Sales.ProductCode
                                         AND DatePart('yyyy', [Sales.Date]) = '{cmbYear.SelectedValue}'
                                         AND DatePart('m', [Sales.Date]) = '{cmbMonth.SelectedValue}'", con);
            ad.Fill(dtMonth);

            // WEEK TOTAL
            DataTable dtWeek = new DataTable();
            ad = new OleDbDataAdapter($@"SELECT SUM(Products.Price * Sales.Amount) AS [Week]
                                         FROM Products, Sales WHERE Products.ProductCode = Sales.ProductCode
                                         AND DatePart('yyyy', [Sales.Date]) = '{cmbYear.SelectedValue}'
                                         AND DatePart('ww', [Sales.Date]) = '{cmbWeek.SelectedValue}'", con);
            ad.Fill(dtWeek);

            // DAY TOTAL
            DataTable dtDay = new DataTable();
            ad = new OleDbDataAdapter($@"SELECT SUM(Products.Price * Sales.Amount) AS [Day]
                                         FROM Products, Sales WHERE Products.ProductCode = Sales.ProductCode
                                         AND DatePart('yyyy', [Sales.Date]) = '{cmbYear.SelectedValue}'
                                         AND DatePart('m', [Sales.Date]) = '{cmbMonth.SelectedValue}'
                                         AND DatePart('d', [Sales.Date]) = '{cmbDay.SelectedValue}'", con);
            ad.Fill(dtDay);
            
            dgvAmount.Rows[0].Cells[0].Value = dtTotal.Rows[0][0].ToString();
            dgvAmount.Rows[0].Cells[1].Value = dtYear.Rows[0][0].ToString();
            dgvAmount.Rows[0].Cells[2].Value = dtMonth.Rows[0][0].ToString();
            dgvAmount.Rows[0].Cells[3].Value = dtWeek.Rows[0][0].ToString();
            dgvAmount.Rows[0].Cells[4].Value = dtDay.Rows[0][0].ToString();
        }

        private void PopulateComboboxWithYear()
        {
            dt = new DataTable();

            ad = new OleDbDataAdapter("SELECT DISTINCT DatePart('yyyy',[Date]) AS [Year] FROM Sales", con);
            ad.Fill(dt);

            cmbYear.ValueMember = "Year";
            cmbYear.DataSource = dt;
        }

        private void PopulateComboboxWithMonth()
        {
            dt = new DataTable();

            ad = new OleDbDataAdapter($@"SELECT DISTINCT DatePart('m',[Date]) AS [Month] FROM Sales 
                                         WHERE DatePart('yyyy', [Date]) = '{cmbYear.SelectedValue}'", con);
            ad.Fill(dt);

            cmbMonth.ValueMember = "Month";
            cmbMonth.DataSource = dt;
        }

        private void PopulateComboboxWithWeek()
        {
            dt = new DataTable();

            ad = new OleDbDataAdapter($@"SELECT DISTINCT DatePart('ww',[Date]) AS [Week] FROM Sales
                                         WHERE DatePart('yyyy', [Date]) = '{cmbYear.SelectedValue}'
                                         AND DatePart('m', [Date]) = '{cmbMonth.SelectedValue}'", con);
            ad.Fill(dt);
            
            cmbWeek.ValueMember = "Week";
            cmbWeek.DataSource = dt;
        }

        private void PopulateComboboxWithDay()
        {
            dt = new DataTable();

            ad = new OleDbDataAdapter($@"SELECT DISTINCT DatePart('d',[Date]) AS [Day] FROM Sales
                                         WHERE DatePart('yyyy', [Date]) = '{cmbYear.SelectedValue}'
                                         AND DatePart('m', [Date]) = '{cmbMonth.SelectedValue}'
                                         AND DatePart('ww',[Date]) = '{cmbWeek.SelectedValue}'", con);
            ad.Fill(dt);
            
            cmbDay.ValueMember = "Day";
            cmbDay.DataSource = dt;
        }
        
        private void btnWeekReport_Click(object sender, EventArgs e)
        {
            WeekReportForm wrform = new WeekReportForm(cmbSellers.SelectedValue.ToString(), Convert.ToInt32(cmbYear.SelectedValue), Convert.ToInt32(cmbWeek.SelectedValue));
            wrform.MdiParent = MdiParent;
            wrform.Show();
        }

        private void cmbYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulateComboboxWithMonth();
        }

        private void cmbMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulateComboboxWithWeek();

            DateTime firstDate = new DateTime(Convert.ToInt32(cmbYear.SelectedValue), Convert.ToInt32(cmbMonth.SelectedValue), 1);
            DateTime secondDate = new DateTime(firstDate.Year, firstDate.Month, DateTime.DaysInMonth(firstDate.Year, firstDate.Month));
            UpdateSalesHistoryChart(firstDate, secondDate);
            UpdateSalesSharePie(firstDate, secondDate);
            UpdateSellersStatsRadar(firstDate, secondDate);
        }

        private void cmbWeek_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulateComboboxWithDay();
        }

        private void cmbDay_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillOutDataGridView();
        }

        private void cmbSellers_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnWeekReport.Text = $"Open {cmbSellers.SelectedValue}'s Week Report";
        }

        private void btnAdvanced_Click(object sender, EventArgs e)
        {
            ReportsAdvancedForm form = new ReportsAdvancedForm();
            form.MdiParent = MdiParent;
            form.Show();
        }
    }
}
