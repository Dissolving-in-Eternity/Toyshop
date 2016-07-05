using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Toyshop
{
    public partial class CustomQueryForm : Form
    {
        ReportsAdvancedForm reports;
        OleDbConnection con;
        List<OleDbParameter> paramsList;
        Dictionary<string, string> procedures = new Dictionary<string, string>();

        public CustomQueryForm(OleDbConnection connection, ReportsAdvancedForm form)
        {
            InitializeComponent();
            con = connection;
            reports = form;
        }

        private void CustomQueryForm_Load(object sender, EventArgs e)
        {
            detailsPanel.Text = string.Empty;
            RichtextReformat(richText);
            LoadProcedures();
            foreach (OleDbType t in Utils.OleDbDataTypes)
                cmbCustomParamType.Items.Add(t);
            cmbCustomParamType.SelectedIndex = 0;
        }

        private void LoadProcedures()
        {
            try
            {
                if(con.State == ConnectionState.Closed) con.Open();
                // Load procedures
                DataTable table = con.GetOleDbSchemaTable(OleDbSchemaGuid.Procedures, null);

                procedures.Clear();
                detailsPanel.Text = string.Empty;

                foreach (DataRow row in table.Rows)
                    procedures.Add(row["PROCEDURE_NAME"].ToString(), row["PROCEDURE_DEFINITION"].ToString());

                // load queries (procedures without parameters)
                table = con.GetOleDbSchemaTable(OleDbSchemaGuid.Views, null);
                foreach (DataRow row in table.Rows)
                    procedures.Add(row["TABLE_NAME"].ToString(), row["VIEW_DEFINITION"].ToString());

                tableParams.Controls.Clear();
                cmbProcedures.Items.Clear();
                cmbProcedures.Items.AddRange((from proc in procedures select proc.Key).ToArray());
                if (cmbProcedures.Items.Count > 0)
                    cmbProcedures.SelectedIndex = 0;
            }
            finally
            { if (con.State == ConnectionState.Open) con.Close(); }
        }

        private void richText_TextChanged(object sender, EventArgs e)
        {
            RichtextReformat(richText);
        }

        private void RichtextReformat(RichTextBox textBox)
        {
            int prevCarret = textBox.SelectionStart;
            textBox.SelectAll();
            textBox.SelectionColor = Color.Black;

            RichHighlightKeyword(textBox, @"\B\[@\D[a-zA-Z\d]*\]", Color.Maroon);
            RichHighlightKeyword(textBox, @"(SELECT|FROM|AS|WHERE|\bAND\b|\bOR\b|\bNOT\b|DISTINCT|GROUP BY|HAVING|BETWEEN|INSERT|INTO|VALUES)", Color.Blue);
            RichHighlightKeyword(textBox, @"(NULL|\b\d+\b|TRUE|FALSE)", Color.DarkCyan);
            RichHighlightKeyword(textBox, @"\B'[a-zA-Z\d]*'\B", Color.DarkMagenta);

            textBox.DeselectAll();
            textBox.SelectionStart = prevCarret;
            textBox.Focus();
        }

        private void RichHighlightKeyword(RichTextBox textBox, string pattern, Color color)
        {
            Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);
            Match matches = regex.Match(textBox.Text);
            while (matches.Success)
            {
                textBox.Select(matches.Index, matches.Length);
                textBox.SelectionColor = color;
                matches = matches.NextMatch();
            }
        }

        private void btnAddProcedure_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtProcName.Text))
            {
                try
                {
                    if (con.State == ConnectionState.Closed) con.Open();
                    OleDbCommand cmd = new OleDbCommand();
                    string commandText = "CREATE PROCEDURE " + txtProcName.Text + " AS " + richText.Text.Replace("\n", " ").Replace("\r", " ");
                    Regex regex = new Regex(@"^CREATE\s+PROCEDURE\s+\D[a-zA-Z\d]*\s+AS\s+SELECT\s+(\*|[a-zA-Z]*\.?[a-zA-Z]*(|,\s*[a-zA-Z]+.?[a-zA-Z]*)*)\s+FROM\s+[a-zA-z]*(|\s+AS\s+[a-zA-Z]+)(|,\s*[a-zA-Z]+(|\s+AS\s+[a-zA-Z]+))*($|\s+WHERE\s+.*)", RegexOptions.IgnoreCase);

                    // If regex validation passes or it's disabled, proceed to creation
                    if (regex.Match(commandText).Success || !checkValidation.Checked)
                    {
                        cmd.CommandText = commandText;
                        cmd.Connection = con;
                        cmd.ExecuteNonQuery();
                        LoadProcedures();
                        MessageBox.Show(this, "Procedure " + txtProcName.Text + " successfully created!", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                        MessageBox.Show(this, "Incorrect query string!", "Incorrect", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                { if (con.State == ConnectionState.Open) con.Close(); }
            }
            else
                MessageBox.Show(this, "Name your procedure!", "Name missing", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void cmbProcedures_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowProcedureDetails();
            CreateControlsForParams();
            paramsList = new List<OleDbParameter>();
        }

        private void CreateControlsForParams()
        {
            Regex regex = new Regex(@"\B\[@\D[a-zA-Z\d]*\]", RegexOptions.IgnoreCase);
            string commandString = procedures[cmbProcedures.SelectedItem.ToString()];
            MatchCollection matches = regex.Matches(commandString);
            
            tableParams.Controls.Clear();
            tableParams.RowCount = matches.Count;
            tableParams.Height = tableParams.RowCount * 27;     

            for(int i=0; i< tableParams.RowCount; i++)
            {
                Label lab = new Label();
                lab.Anchor = AnchorStyles.Top;
                lab.Margin = new Padding(0);
                lab.Text = matches[i].Value.Replace("[", string.Empty).Replace("]", string.Empty);
                tableParams.Controls.Add(lab, 0, i);

                ComboBox cmb = new ComboBox();
                cmb.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
                cmb.Margin = new Padding(3, 0, 3, 0);
                cmb.DropDownStyle = ComboBoxStyle.DropDownList;
                foreach (OleDbType t in Utils.OleDbDataTypes)
                    cmb.Items.Add(t);
                cmb.SelectedIndex = 0;
                tableParams.Controls.Add(cmb, 1, i);

                TextBox txt = new TextBox();
                txt.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
                txt.Margin = new Padding(3, 0, 3, 0);
                tableParams.Controls.Add(txt, 2, i);
            }
        }

        private void ShowProcedureDetails()
        {
            detailsPanel.Text = procedures[cmbProcedures.SelectedItem.ToString()];
            RichtextReformat(detailsPanel);
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            OleDbCommand cmd = new OleDbCommand(cmbProcedures.SelectedItem.ToString(), con);
            cmd.CommandType = CommandType.StoredProcedure;
            
            // Add parameters to command
            // Dynamic params...
            for(int i=0; i<tableParams.RowCount; i++)
            {
                Label lab = tableParams.GetControlFromPosition(0, i) as Label;
                ComboBox cmb = tableParams.GetControlFromPosition(1, i) as ComboBox;
                TextBox txt = tableParams.GetControlFromPosition(2, i) as TextBox;
                OleDbParameter param = new OleDbParameter(lab.Text, (OleDbType)cmb.SelectedItem);
                param.Value = Convert.ChangeType(txt.Text, Utils.OleDbTypeToType((OleDbType)cmb.SelectedItem));

                cmd.Parameters.Add(param);
            }
            // And user defined
            foreach (OleDbParameter param in paramsList)
                cmd.Parameters.Add(param);

            paramsList.Clear();

            try
            {
                OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
                adapter.Fill(dt);

                // Show query results in Reports form
                reports.dgvResult.DataSource = null;
                reports.dgvResult.DataSource = dt;
                reports.AdjustTableProducts();
            }
            catch(OleDbException ex)
            {
                MessageBox.Show(ex.Message, "Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            { if (con.State == ConnectionState.Open) con.Close(); }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show(this, "Are you sure you want to delete procedure " + cmbProcedures.SelectedItem.ToString() + "?", "Delete procedure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    OleDbCommand cmd = new OleDbCommand();
                    cmd.CommandText = "DROP PROCEDURE " + cmbProcedures.SelectedItem.ToString();
                    cmd.Connection = con;

                    if (con.State == ConnectionState.Closed) con.Open();
                    cmd.ExecuteNonQuery();

                    LoadProcedures();
                }
                finally
                { if (con.State == ConnectionState.Open) con.Close(); }
            }
        }

        private void btnAddCustomParam_Click(object sender, EventArgs e)
        {
            OleDbParameter param = new OleDbParameter(txtCustomParamName.Text, (OleDbType)cmbCustomParamType.SelectedItem);
            param.Value = Convert.ChangeType(txtCustomParamValue.Text, Utils.OleDbTypeToType((OleDbType)cmbCustomParamType.SelectedItem));
            paramsList.Add(param);

            txtCustomParamName.Text = string.Empty;
            txtCustomParamValue.Text = string.Empty;
        }

        private void txtCustomParamName_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtCustomParamName.ForeColor != Color.Black)
            {
                txtCustomParamName.ForeColor = Color.Black;
                txtCustomParamName.Text = string.Empty;
            }
        }

        private void txtCustomParamValue_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtCustomParamValue.ForeColor != Color.Black)
            {
                txtCustomParamValue.ForeColor = Color.Black;
                txtCustomParamValue.Text = string.Empty;
            }
        }
    }
}
