using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Toyshop
{
    public partial class QueryForm : Form
    {
        ReportsAdvancedForm reportForm;

        public QueryForm(string columnName, ReportsAdvancedForm reportForm)
        {
            InitializeComponent();
            this.reportForm = reportForm;
            if (columnName == "Category")
            {
                labelLeft.Text = "Enter category:";
                var categories = from DataRow row in reportForm.ds.Tables["Category"].Rows select row["Category"];
                cmbQuery.Items.AddRange(categories.ToArray());
                cmbQuery.SelectedIndex = 0;
            }
            if (columnName == "ProductTitle")
            {
                labelLeft.Text = "Enter product title:";
                cmbQuery.DropDownStyle = ComboBoxStyle.Simple;
            }
            if (columnName == "ManufacturerCode")
            {
                labelLeft.Text = "Enter manufacturer code:";
                var manuCodes = from DataRow row in reportForm.ds.Tables["Manufacturers"].Rows select row["ManufacturerCode"];
                cmbQuery.Items.AddRange(manuCodes.ToArray());
                cmbQuery.SelectedIndex = 0;
            }
        }

        public QueryForm(string leftText, string rightText, ReportsAdvancedForm reportForm)
        {
            InitializeComponent();
            labelLeft.Text = leftText;
            labelRight.Text = rightText;
            this.reportForm = reportForm;
            cmbQuery.Visible = false;
            txtLow.Visible = true;
            txtHigh.Visible = true;
            labelRight.Visible = true;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (labelRight.Visible == false)
            {
                if (!string.IsNullOrEmpty(cmbQuery.Text))
                {
                    reportForm.ExecuteQuery(cmbQuery.Text);
                    Close();
                }
                else
                    MessageBox.Show("Please, enter some value.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                if (!string.IsNullOrEmpty(txtLow.Text) && !string.IsNullOrEmpty(txtHigh.Text))
                {
                    reportForm.ExecuteQuery(txtLow.Text, txtHigh.Text);
                    Close();
                }
                else
                    MessageBox.Show("Please, enter some value.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
