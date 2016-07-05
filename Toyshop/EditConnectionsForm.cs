using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Toyshop
{
    public partial class EditConnectionsForm : Form
    {
        DataSet ds;
        OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\toyshop.accdb");

        public EditConnectionsForm()
        {
            InitializeComponent();
        }

        private void EditConnectionsForm_Load(object sender, EventArgs e)
        {
            // Fill our dataSet
            ds = Utils.LoadDatabase();

            // Get tables name from combobox 
            foreach (DataTable table in ds.Tables)
            {
                cmbParentTable.Items.Add(table.TableName);
                cmbChildTable.Items.Add(table.TableName);
            }

            ShowCurrentConnections();

            cmbParentTable.SelectedIndex = 0;
            cmbParentColumns.SelectedIndex = 0;
        }

        private void ShowCurrentConnections()
        {
            lstbConnections.Items.Clear();
            foreach (DataRelation relation in ds.Relations)
            {
                lstbConnections.Items.Add(string.Format("{0}.{1} - {2}.{3}",
                    relation.ParentTable.TableName,
                    relation.ParentColumns.First().ColumnName,
                    relation.ChildTable.TableName,
                    relation.ChildColumns.First().ColumnName));
            }
        }

        private void cmbTable1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Depend on the current table generate list of its columns
            cmbParentColumns.Items.Clear();
            foreach (DataColumn c in ds.Tables[cmbParentTable.SelectedIndex].Columns)
            {
                if(c.Unique)
                {
                    cmbParentColumns.Items.Add(c.ColumnName);
                }
            }
        }

        private void cmbTable2_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataColumn parentColumn = ds.Tables[cmbParentTable.SelectedIndex].Columns[cmbParentColumns.SelectedIndex];
            // Depend on the current table generate list of its columns
            cmbChildColumns.Items.Clear();
            foreach (DataColumn c in ds.Tables[cmbChildTable.SelectedIndex].Columns)
            {
                // If type corresponding the type of already selected parent column
                if(c.DataType == parentColumn.DataType)
                    cmbChildColumns.Items.Add(c.ColumnName);
            }
        }

        private void btnCreateConnection_Click(object sender, EventArgs e)
        {
            if (cmbChildTable.SelectedIndex != -1 && cmbChildColumns.SelectedIndex != -1)
            {
                DataColumn column1 = ds.Tables[cmbParentTable.SelectedIndex].Columns[cmbParentColumns.SelectedIndex];
                DataColumn column2 = ds.Tables[cmbChildTable.SelectedIndex].Columns[cmbChildColumns.SelectedIndex];
                string relationName = cmbParentTable.SelectedItem.ToString() + cmbChildTable.SelectedItem.ToString();

                OleDbCommand cmd = new OleDbCommand(string.Format("ALTER TABLE {0} ADD CONSTRAINT {1} FOREIGN KEY ({2}) REFERENCES {3}({4})",
                    column2.Table.TableName, column1.Table.TableName + column2.Table.TableName, column2.ColumnName, column1.Table.TableName, column1.ColumnName), con);

                con.Open();
                try
                {
                    if (column1.DataType == column2.DataType)
                    {
                        DataRelation dr = new DataRelation(relationName, column1, column2);
                        if (!ds.Relations.Contains(relationName))
                        {
                            cmd.ExecuteNonQuery();

                            ds.Relations.Add(dr);
                            MessageBox.Show("Connection created successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                        MessageBox.Show("You can add connection only for columns of the same type. Please, try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    // Update connections in listbox
                    ShowCurrentConnections();
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show(ex.Message, "Failed attempted create a connection.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally { con.Close(); }
            }
            else
                MessageBox.Show("Select all tables\\columns from all comboboxes FIRST to have ability make connection.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void btnDeleteConnection_Click(object sender, EventArgs e)
        {
            // If item in listbox is selected
            if (!(lstbConnections.SelectedIndex == -1))
            {
                OleDbCommand cmd = new OleDbCommand(string.Format("ALTER TABLE {0} DROP CONSTRAINT {1}",
               ds.Relations[lstbConnections.SelectedIndex].ChildTable.TableName,
               ds.Relations[lstbConnections.SelectedIndex].RelationName), con);

                con.Open();
                try
                {
                    cmd.ExecuteNonQuery();
                    // Просто берёшь и удаляешь по индексу. (с) напоминание о том какая я лошара, час сидевшая над костылями
                    ds.Relations.RemoveAt(lstbConnections.SelectedIndex);
                    MessageBox.Show("Connection successfully deleted.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ShowCurrentConnections();
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show(ex.Message, "Failed attempted delete a connection.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    con.Close();
                }                                
            }
            else
                MessageBox.Show("Select connection which you want to delete FIRST.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

        }

        private void EditConnectionsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            con.Dispose();
        }
    }
}
