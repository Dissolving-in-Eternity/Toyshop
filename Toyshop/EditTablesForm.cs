using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Data.OleDb;
using System.IO;

namespace Toyshop
{
    public partial class EditTablesForm : Form
    {
        public DataSet ds { get; private set; }
        OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\toyshop.accdb");

        public EditTablesForm()
        {
            InitializeComponent();
        }

        private void EditTablesForm_Load(object sender, EventArgs e)
        {
            // Fill our dataSet
            ds = Utils.LoadDatabase();
            ds.EnforceConstraints = false;

            // Get tables name from combobox 
            cmbListOfTables.Items.Clear();
            cmbListOfTables.Items.AddRange((from DataTable table in ds.Tables.Cast<DataTable>()
                                            select table.TableName).ToArray());

            // Set the default table
            cmbListOfTables.SelectedIndex = 0;

            updateDeleteEditButtons();
        }

        private void ReloadDatabase()
        {
            dgvTables.DataSource = null;
            dgvTables.DataMember = null;
            ds = Utils.LoadDatabase();
            dgvTables.DataSource = ds.Tables[cmbListOfTables.SelectedItem.ToString()];
            AdjustTableProducts();
        }

        private void cmbListOfTables_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Display table in DataGridView 
            dgvTables.DataSource = ds.Tables[cmbListOfTables.SelectedItem.ToString()];

            UpdateColumnsListCombobox();

            // Set the default column          
            cmbColumns.SelectedIndex = 0;

            // Adjustments for table "Products"
            if ((string)cmbListOfTables.SelectedItem == "Products")
            {
                // Zooming images in "Photo" column
                
                DataGridViewColumn col = dgvTables.Columns["Photo"];
                (col as DataGridViewImageColumn).ImageLayout = DataGridViewImageCellLayout.Zoom;

                DataGridViewColumn col2 = dgvTables.Columns["Description"];
                col2.Width = 300;

                DataGridViewColumn col3 = dgvTables.Columns["ManufacturerCode"];
                col3.Width = 70;

                DataGridViewColumn col4 = dgvTables.Columns["ProductCode"];
                col4.Width = 55;
            }

            updateDeleteEditButtons();
        }

        // Depend on the current table generate list of its columns
        private void UpdateColumnsListCombobox()
        {
            int prevIndex = cmbColumns.SelectedIndex;
            cmbColumns.Items.Clear();

            foreach (DataColumn c in ds.Tables[cmbListOfTables.SelectedIndex].Columns)
                cmbColumns.Items.Add(c.ColumnName);

            cmbColumns.SelectedIndex = Math.Max(0, Math.Min(cmbColumns.Items.Count-1, prevIndex));
        }

        // Rebuild list of tables
        private void UpdateTablesListCombobox()
        {
            int prevIndex = cmbListOfTables.SelectedIndex;
            cmbListOfTables.Items.Clear();

            foreach (DataTable table in ds.Tables)
                cmbListOfTables.Items.Add(table.TableName);

            cmbListOfTables.SelectedIndex = Math.Max(0, Math.Min(cmbListOfTables.Items.Count - 1, prevIndex));
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

        private void btnAddRow_Click(object sender, EventArgs e)
        {
            var addForm = new AddEditRowForm(this);
            addForm.ShowDialog(this);
        }
        
        private void btnEditRow_Click(object sender, EventArgs e)
        {
            DataRow row = ds.Tables[cmbListOfTables.SelectedIndex].Rows[dgvTables.SelectedCells[0].RowIndex];
            Dictionary<string, object> data = new Dictionary<string, object>();

            foreach (DataColumn col in ds.Tables[cmbListOfTables.SelectedIndex].Columns)
                data.Add(col.ColumnName, row[col.ColumnName]);

            var editForm = new AddEditRowForm(this, data);
            editForm.ShowDialog(this);
        }

        public void EditRowInDatabase(Dictionary<string, object> data)
        {
            DataTable curTable = ds.Tables[cmbListOfTables.SelectedIndex];
            DataRow row = curTable.Rows[dgvTables.SelectedCells[0].RowIndex];

            DataColumn[] uniqueColumns = (from DataColumn col in curTable.Columns where col.Unique == true select col).ToArray();
            DataColumn[] unchangedColumns = (from DataColumn col in curTable.Columns where row[col].Equals(Convert.ChangeType(data[col.ColumnName], col.DataType)) select col).ToArray();

            if (curTable.Columns.Count > unchangedColumns.Length)
            {
                string updateString = Utils.FixReservedWords(string.Format("UPDATE {0} SET {1} WHERE {2}",
                    curTable.TableName,
                    string.Join(", ", from DataColumn col in curTable.Columns where !unchangedColumns.Contains(col) select col.ColumnName + " = ?"),
                    string.Join(" AND ", from DataColumn col in uniqueColumns select col.ColumnName + " = X")));

                OleDbCommand updateCommand = new OleDbCommand(updateString, con);
                foreach (DataColumn col in (from DataColumn col in curTable.Columns where !unchangedColumns.Contains(col) select col))
                    updateCommand.Parameters.Add("?", Utils.GetOleDbType(col.DataType)).Value = Utils.GetSafeValue(col.DataType, data[col.ColumnName]);
                foreach (DataColumn col in uniqueColumns)
                    updateCommand.Parameters.Add("X", Utils.GetOleDbType(col.DataType)).Value = row[col];

                con.Open();
                try
                {
                    updateCommand.ExecuteNonQuery();
                    foreach (DataColumn col in curTable.Columns)
                        row[col] = Utils.GetSafeValue(col.DataType, data[col.ColumnName]);
                    ds.Tables[cmbListOfTables.SelectedIndex].AcceptChanges();
                }
                catch (OleDbException ex)
                {
                    MessageBox.Show(this.Owner, ex.Message, "Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (FormatException)
                {
                    MessageBox.Show(this.Owner, "Wrong time format", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally { con.Close(); }
            }
        }
        
        public void AddRowToDatabase(Dictionary<string, object> data)
        {
            DataTable curTable = ds.Tables[cmbListOfTables.SelectedIndex];

            string insertString = Utils.FixReservedWords(string.Format("INSERT INTO {0}({1}) VALUES({2})",
                curTable.TableName,
                string.Join(",", (from DataColumn col in curTable.Columns select col.ColumnName)),
                string.Join(",", new String('?', curTable.Columns.Count).ToArray())));

            OleDbCommand insertCommand = new OleDbCommand(insertString, con);

            foreach (DataColumn col in curTable.Columns)
                insertCommand.Parameters.Add("?", Utils.GetOleDbType(col.DataType)).Value = Utils.GetSafeValue(col.DataType, data[col.ColumnName]);

            con.Open();
            try
            {
                insertCommand.ExecuteNonQuery();
                curTable.Rows.Add((from DataColumn col in curTable.Columns select Utils.GetSafeValue(col.DataType, data[col.ColumnName])).ToArray());
                ds.Tables[cmbListOfTables.SelectedIndex].AcceptChanges();
                updateDeleteEditButtons();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally { con.Close(); }
        }

        private void btnDeleteRow_Click(object sender, EventArgs e)
        {
            DataRow row = ds.Tables[cmbListOfTables.SelectedIndex].Rows[dgvTables.SelectedCells[0].RowIndex];
            if (MessageBox.Show(this.Owner, "Are you sure you want to delete selected row?", "Delete row?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                string deleteString = Utils.FixReservedWords(string.Format("DELETE FROM {0} WHERE {1}",
                    row.Table.TableName,
                    string.Join(" AND ", from DataColumn col in row.Table.Columns select string.Format("{0} = ?", col.ColumnName))));

                OleDbCommand deleteCommand = new OleDbCommand(deleteString, con);
                foreach (DataColumn col in row.Table.Columns)
                    deleteCommand.Parameters.Add("?", Utils.GetOleDbType(col.DataType)).Value = row[col];

                con.Open();
                try
                {
                    deleteCommand.ExecuteNonQuery();
                    row.Delete();
                    ds.Tables[cmbListOfTables.SelectedIndex].AcceptChanges();
                    updateDeleteEditButtons();
                }
                catch (OleDbException ex)
                {
                    MessageBox.Show(this.Owner, ex.Message, "Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally { con.Close(); }
            }
        }

        public bool AddColumnToTable(string colName, Type dataType)
        {
            return AddColumnToTable(colName, dataType, null);
        }

        private bool AddColumnToTable(string colName, Type dataType, OleDbTransaction transaction)
        {
            bool success = true;

            string commandString = Utils.FixReservedWords(string.Format("ALTER TABLE {0} ADD COLUMN {1} {2}",
                ds.Tables[cmbListOfTables.SelectedIndex].TableName,
                colName,
                Utils.GetSQLType(dataType)));

            OleDbCommand command;
            command = new OleDbCommand(commandString, con, transaction);

            if(con.State == ConnectionState.Closed) con.Open();
            try
            {
                command.ExecuteNonQuery();

                DataColumn newCol = new DataColumn(colName, dataType);
                newCol.DefaultValue = DBNull.Value;
                ds.Tables[cmbListOfTables.SelectedIndex].Columns.Add(newCol);

                if (transaction == null)
                    ds.Tables[cmbListOfTables.SelectedIndex].AcceptChanges();
            }
            catch (OleDbException ex)
            {
                MessageBox.Show(this.Owner, ex.Message, "Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);
                success = false;
            }
            finally { if(transaction == null) con.Close(); }

            UpdateColumnsListCombobox();

            return success;
        }

        public bool EditColumnInTable(string colName, Type dataType, bool allowNull, bool isUnique)
        {
            bool success = true;

            DataColumn currentCol = ds.Tables[cmbListOfTables.SelectedIndex].Columns[cmbColumns.SelectedIndex];

            con.Open();
            OleDbTransaction transaction = con.BeginTransaction();

            if (colName != currentCol.ColumnName)
                success = RenameColumn(colName, dataType, currentCol, transaction);

            if (dataType != currentCol.DataType || allowNull != currentCol.AllowDBNull)
                success = ChangeColumnTypeOrNullable(colName, dataType, allowNull, currentCol, transaction);

            if (isUnique != currentCol.Unique)
                success = ChangeUniqueColumnRestriction(colName, currentCol, isUnique, transaction);

            if (success)
                transaction.Commit();
            else
                transaction.Rollback();

            con.Close();
            ReloadDatabase();

            return success;
        }

        private bool ChangeUniqueColumnRestriction(string colName, DataColumn currentCol, bool isUnique, OleDbTransaction transaction = null)
        {
            bool success = true;

            string commandStringRemove = null, commandStringAdd;
            
            UniqueConstraint constraint = null;
            foreach (Constraint c in currentCol.Table.Constraints)
                if ((c as UniqueConstraint) != null)
                { constraint = c as UniqueConstraint; break; }

            commandStringRemove = Utils.FixReservedWords(string.Format("ALTER TABLE {0} DROP CONSTRAINT {1}",
                currentCol.Table.TableName,
                "PrimaryKey"));

            commandStringAdd = Utils.FixReservedWords(string.Format("ALTER TABLE {0} ADD CONSTRAINT {1} PRIMARY KEY ({2})",
                    currentCol.Table.TableName,
                    "PrimaryKey",
                    colName));

            OleDbCommand commandRemove = new OleDbCommand(commandStringRemove, con, transaction);
            OleDbCommand commandAdd = new OleDbCommand(commandStringAdd, con, transaction);

            if(con.State == ConnectionState.Closed) con.Open();
            try
            {
                commandRemove.ExecuteNonQuery();
                commandAdd.ExecuteNonQuery();
            }
            catch (OleDbException ex)
            {
                MessageBox.Show(this.Owner, ex.Message, "Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);
                success = false;
            }
            finally
            {
                if (transaction == null)
                {
                    if (success)
                        transaction.Commit();
                    else
                        transaction.Rollback();
                    con.Close();
                }
            }

            return success;
        }

        private bool ChangeColumnTypeOrNullable(string colName, Type dataType, bool allowNull, DataColumn currentCol, OleDbTransaction transaction = null)
        {
            bool success = true;

            string commandString = Utils.FixReservedWords(string.Format("ALTER TABLE {0} ALTER COLUMN {1} {2}{3}",
                ds.Tables[cmbListOfTables.SelectedIndex].TableName,
                colName,
                Utils.GetSQLType(dataType),
                allowNull != currentCol.AllowDBNull ? (allowNull ? " NULL" : " NOT NULL") : string.Empty));
            
            if(con.State == ConnectionState.Closed) con.Open();
            OleDbCommand command = new OleDbCommand(commandString, con, transaction);

            try
            {
                command.ExecuteNonQuery();
            }
            catch (OleDbException ex)
            {
                MessageBox.Show(Owner, ex.Message, "Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);
                success = false;
            }
            catch (DataException)
            {
                MessageBox.Show(Owner, "Column should not contain NULL values", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);
                success = false;
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(Owner, ex.Message, "Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);
                success = false;
            }
            finally
            {
                if (transaction == null)
                {
                    if (success)
                        transaction.Commit();
                    else
                        transaction.Rollback();

                    con.Close();
                }
            }

            return success;
        }

        // In order to change column's name we have to create new column, copy all data from original one and delete original column
        private bool RenameColumn(string colName, Type dataType, DataColumn currentCol, OleDbTransaction transaction = null)
        {
            bool success = true;

            if (con.State == ConnectionState.Closed) con.Open();

            // Create new column
            success = AddColumnToTable(colName, dataType, transaction);

            if (success)
            {
                // Copy data from old column to new one
                string commandString = Utils.FixReservedWords(string.Format("UPDATE {0} SET {1} = {2}",
                    ds.Tables[cmbListOfTables.SelectedIndex].TableName,
                    colName,
                    currentCol.ColumnName));

                OleDbCommand command = new OleDbCommand(commandString, con, transaction);

                try
                {
                    command.ExecuteNonQuery();

                    foreach (DataRow row in ds.Tables[cmbListOfTables.SelectedIndex].Rows)
                        row[colName] = row[currentCol.ColumnName];
                }
                catch (OleDbException ex)
                {
                    MessageBox.Show(this.Owner, ex.Message, "Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    success = false;
                    if (transaction == null) con.Close();
                }

                // If everything was ok so far, remove old column
                if (success)
                    success = DeleteCurrentColumn(transaction);
            }

            // If everything went well, then commit or else revert all changes
            if (transaction == null)
            {
                if (success)
                {
                    ds.AcceptChanges();
                }
                else
                {
                    ds.RejectChanges();
                    MessageBox.Show(this, "Something went wrong. Can't rename column.", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                con.Close();
            }

            return success;
        }

        public bool DeleteCurrentColumn()
        { return DeleteCurrentColumn(null); }

        private bool DeleteCurrentColumn(OleDbTransaction transaction)
        {
            bool success = true;

            string commandString = Utils.FixReservedWords(string.Format("ALTER TABLE {0} DROP COLUMN {1}",
                ds.Tables[cmbListOfTables.SelectedIndex].TableName,
                ds.Tables[cmbListOfTables.SelectedIndex].Columns[cmbColumns.SelectedIndex]));

            OleDbCommand command = new OleDbCommand(commandString, con, transaction);

            if(con.State == ConnectionState.Closed) con.Open();
            try
            {
                command.ExecuteNonQuery();
                ds.Tables[cmbListOfTables.SelectedIndex].Columns.RemoveAt(cmbColumns.SelectedIndex);

                if (transaction == null)
                    ds.Tables[cmbListOfTables.SelectedIndex].AcceptChanges();
            }
            catch (OleDbException ex)
            {
                MessageBox.Show(this.Owner, ex.Message, "Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);
                success = false;
            }
            finally { if(transaction == null) con.Close(); }

            UpdateColumnsListCombobox();

            return success;
        }

        private void updateDeleteEditButtons()
        {
            if (dgvTables.Rows.Count > 0)
            {
                btnDeleteRow.Enabled = true;
                btnEditRow.Enabled = true;
            }
            else
            {
                btnDeleteRow.Enabled = false;
                btnEditRow.Enabled = false;
            }

        }

        private void EditTablesForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            con.Dispose();
            ds.Dispose();
        }

        private void btnAddColumn_Click(object sender, EventArgs e)
        {
            AddEditColumnForm form = new AddEditColumnForm(this);
            form.ShowDialog(this);
        }

        private void btnEditColumn_Click(object sender, EventArgs e)
        {
            DataColumn col = ds.Tables[cmbListOfTables.SelectedIndex].Columns[cmbColumns.SelectedIndex];
            AddEditColumnForm form = new AddEditColumnForm(this, col.ColumnName, col.DataType, col.AllowDBNull, col.Unique);
            form.ShowDialog(this);
        }

        private void dgvTables_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            cmbColumns.SelectedIndex = e.ColumnIndex;
        }

        private void dgvTables_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            cmbColumns.SelectedIndex = e.ColumnIndex;
        }

        private void btnDeleteColumn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(Owner, "Are you sure you want to delete column " + ds.Tables[cmbListOfTables.SelectedIndex].Columns[cmbColumns.SelectedIndex] + "?", "Delete column?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                DeleteCurrentColumn();
        }
        
        private void btnAddTable_Click(object sender, EventArgs e)
        {
            var form = new AddNewTableForm(this);
            form.ShowDialog(this);
        }

        // Add new table
        internal void CreateTable(string tableName, List<AddNewTableForm.TableNameType> columnsData, int primaryColumnIndex)
        {
            string commandString = Utils.FixReservedWords(string.Format("CREATE TABLE {0} ({1}, CONSTRAINT PrimaryKey PRIMARY KEY ({2}))",
                tableName,
                string.Join(", ", from AddNewTableForm.TableNameType col in columnsData select string.Format("{0} {1}{2}", col.Name, Utils.GetSQLType(col.Type), col.AllowNull ? string.Empty : " NOT NULL")),
                columnsData[primaryColumnIndex].Name));

            OleDbCommand command = new OleDbCommand(commandString, con);
            
            try
            {
                con.Open();
                command.ExecuteNonQuery();
            }
            catch (OleDbException ex)
            {
                MessageBox.Show(Owner, ex.Message, "Failed to create table", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally { con.Close(); }

            ReloadDatabase();
            UpdateTablesListCombobox();
        }

        // DELETE TABLE
        private void btnDeleteTable_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(Owner, string.Format("Are you sure you want to delete table \"{0}\"?\nThis action CAN NOT be undone.",
                cmbListOfTables.SelectedItem), "Delete table?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                OleDbCommand command = new OleDbCommand("DROP TABLE " + cmbListOfTables.SelectedItem, con);

                if (con.State == ConnectionState.Closed) con.Open();
                try
                {
                    command.ExecuteNonQuery();
                }
                catch (OleDbException ex)
                {
                    MessageBox.Show(Owner, ex.Message, "Delete table fail", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally { con.Close(); }

                ReloadDatabase();
                UpdateTablesListCombobox();
            }
        }

        private void btnToXML_Click(object sender, EventArgs e)
        {
            try
            {
                FileStream fs = new FileStream("XmlDoc.xml", FileMode.Create);
                ds.WriteXml(fs);
                fs.Close();

                fs = new FileStream("XmlSchema.xml", FileMode.Create);
                ds.WriteXmlSchema(fs);
                fs.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            MessageBox.Show("Successufully written to XML.", "Success.", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnFromXML_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "XML Schema|*.xml";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    ds = new DataSet();
                    FileStream fs = new FileStream("XmlSchema.xml", FileMode.Open);
                    ds.ReadXmlSchema(fs);
                    fs.Close();

                    dialog.Filter = "XML Document|*.xml";
                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        fs = new FileStream("XmlDoc.xml", FileMode.Open);
                        ds.ReadXml(fs);
                        fs.Close();
                        dgvTables.DataSource = ds.Tables[0];

                        foreach (DataTable table in ds.Tables)
                            cmbListOfTables.Items.Add(table.TableName);
                        cmbListOfTables.SelectedIndex = 0;

                        MessageBox.Show("Successufully written from XML.", "Success.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
