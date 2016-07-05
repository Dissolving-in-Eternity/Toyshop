using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Toyshop
{
    public partial class AddEditRowForm : Form
    {
        EditTablesForm editForm;
        Dictionary<string, object> data = new Dictionary<string, object>();
        public bool IsEditMode { get; private set; }

        private void addData(string key, object value)
        {
            if (data.ContainsKey(key))
                data[key] = value;
            else
                data.Add(key, value);
        }

        /// Use this constructor to initialize form to ADD new row
        public AddEditRowForm(EditTablesForm form)
        {
            InitializeComponent();
            editForm = form;
            Text = "Add new row to " + editForm.ds.Tables[editForm.cmbListOfTables.SelectedIndex].TableName;
        }

        /// <summary>
        /// Use this constructor to initialize form to EDIT a row
        /// </summary>
        /// <param name="form">Form from which call should be made</param>
        /// <param name="data">Data of row to be edited [ColumnName, ObjectData]</param>
        public AddEditRowForm(EditTablesForm form, Dictionary<string, object> data)
        {
            InitializeComponent();
            editForm = form;
            this.data = data;
            IsEditMode = true;
            Text = "Edit row in " + editForm.ds.Tables[editForm.cmbListOfTables.SelectedIndex].TableName;
        }

        private void AddEditRowForm_Load(object sender, EventArgs e)
        {
            tableContainer.ColumnCount = editForm.ds.Tables[editForm.cmbListOfTables.SelectedIndex].Columns.Count;
            this.Width = Math.Max(tableContainer.ColumnCount * 120, 200);   // FIXME D====---o 

            // Create textboxes & labels
            tableContainer.Controls.Clear();
            for (int i = 0; i < editForm.ds.Tables[editForm.cmbListOfTables.SelectedIndex].Columns.Count; i++)
            {
                DataColumn col = editForm.ds.Tables[editForm.cmbListOfTables.SelectedIndex].Columns[i];

                // Labels
                Label lab = new Label();
                lab.Text = col.ColumnName + ":";
                lab.Margin = new Padding(0, 5, 0, 0);
                tableContainer.Controls.Add(lab, i, 0);

                Control dataControl = null;

                // If it's dependant column, then create combobox for possible values
                if (ColumnIsForeignKey(col))
                {
                    object[] foreignKeyValues = GetForeignKeyValues(col);
                    ComboBox cmbox = new ComboBox();
                    foreach (object value in foreignKeyValues)
                        cmbox.Items.Add(value);
                    cmbox.SelectedIndex = 0;
                    cmbox.DropDownStyle = ComboBoxStyle.DropDownList;

                    if (IsEditMode)
                        cmbox.SelectedItem = data[col.ColumnName];

                    dataControl = cmbox;
                }
                // If it's normal column, then create control depending on data type
                else
                {
                    // For Images (byte[]) create button
                    if (col.DataType == typeof(byte[]))
                    {
                        Button btnBrowse = new Button();
                        btnBrowse.Text = "Browse...";
                        btnBrowse.Click += (clickSender, clickE) =>
                        {
                            if (openFile.ShowDialog(this) == DialogResult.OK)
                            {
                                Image img = new Bitmap(openFile.FileName);
                                addData(col.ColumnName, Utils.ConvertImageToByteArray(img));
                            }
                        };

                        dataControl = btnBrowse;
                    }
                    // For boolean checkbox
                    else if (col.DataType == typeof(bool))
                    {
                        CheckBox chBox = new CheckBox();

                        if (IsEditMode)
                            chBox.Checked = (bool)Utils.GetSafeValue(col.DataType, data[col.ColumnName]);

                        dataControl = chBox;
                    }
                    // for others masked textbox
                    else
                    {
                        MaskedTextBox tbox = new MaskedTextBox();
                        // Only numbers for Integer
                        if (col.DataType == typeof(int))
                        {
                            tbox.Mask = "999999";
                            if (IsEditMode)
                                tbox.Text = data[col.ColumnName].ToString();
                        }
                        // Date and time for DateTime
                        else if (col.DataType == typeof(DateTime))
                        {
                            tbox.Mask = "00/00/0000 90:00";
                            if (IsEditMode)
                                tbox.Text = ((DateTime)data[col.ColumnName]).ToString();
                        }
                        // And no mask for String and Decimal
                        else
                        {
                            if (IsEditMode)
                                tbox.Text = data[col.ColumnName].ToString();
                        }

                        // If field can't be empty, the hughligt it
                        if (!col.AllowDBNull)
                            tbox.BackColor = Color.LightPink;

                        dataControl = tbox;
                    }
                }

                tableContainer.Controls.Add(dataControl, i, 1);
            }
        }

        // Returns array of all possible values for column based on it's ParentColumn
        private object[] GetForeignKeyValues(DataColumn column)
        {
            // Ensure a valid column was received that actually belongs to a table
            if (column == null)
                throw new ArgumentNullException("column");
            if (column.Table == null)
                throw new ArgumentException("Column provided must belong to a table", "column");

            // Loop through ALL constraints
            for (int i = 0; i < column.Table.ParentRelations.Count; i++)
            {
                DataRelation parentRel = column.Table.ParentRelations[i];
                if (parentRel.ChildColumns.Contains(column))
                {
                    DataColumn parCol = parentRel.ParentColumns.First();
                    return (from DataRow row in parCol.Table.Rows
                            select row.ItemArray[parCol.Ordinal]).ToArray();
                }
            }

            return null;
        }

        private bool ColumnIsForeignKey(DataColumn column)
        {
            // Ensure a valid column was received that actually belongs to a table
            if (column == null)
                throw new ArgumentNullException("column");
            if (column.Table == null)
                throw new ArgumentException("Column provided must belong to a table", "column");

            // Loop through ALL constraints
            for (int i = 0; i < column.Table.ParentRelations.Count; i++)
            {
                DataRelation parentRel = column.Table.ParentRelations[i];
                if (parentRel.ChildColumns.Contains(column))
                    return true;
            }

            return false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            bool everythingIsOk = true;
            for (int i = 0; i < editForm.ds.Tables[editForm.cmbListOfTables.SelectedIndex].Columns.Count; i++)
            {
                DataColumn col = editForm.ds.Tables[editForm.cmbListOfTables.SelectedIndex].Columns[i];
                Control control = tableContainer.GetControlFromPosition(i, 1);

                if (control as MaskedTextBox != null)
                {
                    if (!col.AllowDBNull && string.IsNullOrWhiteSpace((control as MaskedTextBox).Text))
                    {
                        MessageBox.Show(Owner, string.Format("{0} can not be empty.", col.ColumnName), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        everythingIsOk = false;
                        break;
                    }

                    addData(col.ColumnName, (control as MaskedTextBox).Text);
                }
                else if (control as ComboBox != null)
                    addData(col.ColumnName, (control as ComboBox).SelectedItem.ToString());
                else if (control as CheckBox != null)
                    addData(col.ColumnName, (control as CheckBox).Checked);
                else if (control as Button != null)
                    if (!data.ContainsKey(col.ColumnName))
                        addData(col.ColumnName, Utils.ConvertImageToByteArray(Properties.Resources.noImage));
            }

            if (everythingIsOk)
            {
                if (IsEditMode)
                    editForm.EditRowInDatabase(data);
                else
                    editForm.AddRowToDatabase(data);
                Close();
            }
        }
    }
}
