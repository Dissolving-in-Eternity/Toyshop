using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Toyshop
{
    public partial class AddEditColumnForm : Form
    {
        EditTablesForm editForm;
        public bool IsEditMode { get; private set; }

        /// Use this constructor to initialize form to ADD new column
        public AddEditColumnForm(EditTablesForm form)
        {
            InitializeComponent();
            cmbType.Items.AddRange(Utils.DataTypes);
            cmbType.SelectedIndex = 0;
            allowNull.Enabled = false;
            isUnique.Enabled = false;
            editForm = form;
            Text = "Add new column to " + editForm.ds.Tables[editForm.cmbListOfTables.SelectedIndex].TableName;
        }

        /// <summary>
        /// Use this constructor to initialize form to EDIT edixsting column
        /// </summary>
        /// <param name="form">Form from which call is made</param>
        /// <param name="data">Data of row to be edited [ColumnName, ObjectData]</param>
        public AddEditColumnForm(EditTablesForm form, string colName, Type colType, bool allowNull, bool isUnique)
        {
            InitializeComponent();
            editForm = form;
            txtName.Text = colName;
            cmbType.Items.AddRange(Utils.DataTypes);
            cmbType.SelectedItem = colType.Name;
            this.isUnique.Checked = isUnique;
            this.allowNull.Checked = allowNull;
            if (isUnique)
            {
                this.allowNull.Enabled = false;
                this.isUnique.Enabled = false;
            }

            IsEditMode = true;
            Text = string.Format("Edit column {0} in {1}", 
                editForm.ds.Tables[editForm.cmbListOfTables.SelectedIndex].Columns[editForm.cmbColumns.SelectedIndex].ColumnName, 
                editForm.ds.Tables[editForm.cmbListOfTables.SelectedIndex].TableName);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtName.Text))
                MessageBox.Show(this, "Name can not be empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if ((from DataColumn col in editForm.ds.Tables[editForm.cmbListOfTables.SelectedIndex].Columns select col.ColumnName).Contains(txtName.Text) &&
                     txtName.Text != editForm.ds.Tables[editForm.cmbListOfTables.SelectedIndex].Columns[editForm.cmbColumns.SelectedIndex].ColumnName)
                MessageBox.Show(this, "This name is already taken", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                if (IsEditMode)
                    editForm.EditColumnInTable(txtName.Text, Type.GetType("System." + cmbType.SelectedItem.ToString(), true, true), allowNull.Checked, isUnique.Checked);
                else
                    editForm.AddColumnToTable(txtName.Text, Type.GetType("System." + cmbType.SelectedItem.ToString(), true, true));
                Close();
            }
        }

        private void isUnique_CheckedChanged(object sender, EventArgs e)
        {
            if (isUnique.Checked)
                allowNull.Checked = false;
        }

        private void isUnique_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "This will remove existing primary key and make this column new primary key. Proceed?", "Change primary key?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                isUnique.Checked = !isUnique.Checked;
        }

        private void allowNull_CheckedChanged(object sender, EventArgs e)
        {
            if (allowNull.Checked)
                isUnique.Checked = false;
        }
    }
}
