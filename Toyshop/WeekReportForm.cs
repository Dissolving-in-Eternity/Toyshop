using System;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace Toyshop
{
    public partial class WeekReportForm : Form
    {
        private DateTime firstDate, secondDate;
        private int year, week;
        private int itemsSold;
        private decimal total;
        private string login;
        OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\toyshop.accdb");
        OleDbDataAdapter ad;

        public WeekReportForm(string login, int year, int week)
        {
            InitializeComponent();
            this.year = year;
            this.week = week;
            this.login = login;

            firstDate = FirstDateOfWeekISO8601(year, week);
            secondDate = firstDate.AddDays(6);
        }
        
        private DateTime FirstDateOfWeekISO8601(int year, int weekOfYear)
        {
            DateTime jan1 = new DateTime(year, 1, 1);
            int daysOffset = DayOfWeek.Thursday - jan1.DayOfWeek;

            DateTime firstThursday = jan1.AddDays(daysOffset);
            var cal = CultureInfo.CurrentCulture.Calendar;
            int firstWeek = cal.GetWeekOfYear(firstThursday, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);

            var weekNum = weekOfYear;
            if (firstWeek <= 1)
            {
                weekNum -= 1;
            }
            var result = firstThursday.AddDays(weekNum * 7);
            return result.AddDays(-3);
        }

        private void btnExportWordReport_Click(object sender, EventArgs e)
        {
            WordExporter.ExprortReport(dgvReport.DataSource as DataTable, dgvResidue.DataSource as DataTable, firstDate, secondDate, AccountManager.GetNameFromLogin(login), itemsSold, total);
        }

        private void WeekReportForm_Load(object sender, EventArgs e)
        {
            labLoginReport.Text = labLoginResidue.Text = AccountManager.GetNameFromLogin(login);
            labDateReport.Text = labDateResidue.Text = firstDate.ToShortDateString() + " - " + secondDate.ToShortDateString();
            
            dgvReport.Columns.Clear();
            DataTable dataTable = new DataTable();
            ad = new OleDbDataAdapter($@"SELECT '1' AS [№], 
                                                FORMAT([Sales.Date],'dd.MM.yyyy') as [Date],
                                                Products.ProductTitle AS [Product Title],
                                                Products.Price AS Price,
                                                SUM(Sales.Amount) AS Quantity,
                                                SUM(Sales.Amount * Products.Price) AS Subtotal
                                         FROM Sales, Products 
                                         WHERE Products.ProductCode = Sales.ProductCode AND DatePart('ww', [Sales.Date]) = '{week}' AND 
                                               Sales.SellerName LIKE '{AccountManager.GetNameFromLogin(login)}'
                                         GROUP BY FORMAT([Sales.Date],'dd.MM.yyyy'), Products.ProductTitle, Products.Price", con);
            ad.Fill(dataTable);
            for (int i = 0; i < dataTable.Rows.Count; i++)
                dataTable.Rows[i][0] = i + 1;
            dgvReport.DataSource = dataTable;
            
            itemsSold = 0;
            foreach (DataRow row in dataTable.Rows)
                itemsSold += int.Parse(row["Quantity"].ToString());
            labItemsSoldReport.Text = labItemsSoldResidue.Text = itemsSold.ToString() + $" item{(itemsSold == 1 ? "" : "s")} sold";

            total = 0;
            foreach (DataRow row in dataTable.Rows)
                total += decimal.Parse(row["Price"].ToString()) * int.Parse(row["Quantity"].ToString());
            labTotal.Text = "$" + total.ToString();

            dgvResidue.Columns.Clear();
            dataTable = new DataTable();
            ad = new OleDbDataAdapter($@"SELECT '1' AS [№], 
                                                Products.ProductTitle AS [Product Title],
                                                SUM(Sales.Amount) AS [Sold],
                                                '0' as [Residue]
                                         FROM Sales, Products                                              
                                         WHERE Products.ProductCode = Sales.ProductCode AND DatePart('ww', [Sales.Date]) = '{week}' AND 
                                               Sales.SellerName LIKE '{AccountManager.GetNameFromLogin(login)}'
                                         GROUP BY Products.ProductTitle", con);
            ad.Fill(dataTable);

            DataTable residue = new DataTable();
            ad = new OleDbDataAdapter($@"SELECT Sup.ProductTitle AS [Product Title],
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

            ad.Fill(residue);

            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                dataTable.Rows[i][0] = i + 1;
                int itemsLeft = -1;
                foreach (DataRow row in residue.Rows)
                    if (row["Product Title"].Equals(dataTable.Rows[i]["Product Title"]))
                        itemsLeft = Convert.ToInt32(row["Residue"]);
                dataTable.Rows[i]["Residue"] = itemsLeft;
            }
            dgvResidue.DataSource = dataTable;
            dgvResidue.Columns["Product Title"].Width = 300;
        }

        void dgvResidue_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 3)
            {
                DataGridViewCell cell = dgvResidue.Rows[e.RowIndex].Cells[e.ColumnIndex];
                if (Convert.ToInt32(cell.Value) <= 3)
                {
                    e.CellStyle.BackColor = Color.LightPink;
                    e.CellStyle.SelectionBackColor = Color.DeepPink;
                }
            }
        }
    }
}
