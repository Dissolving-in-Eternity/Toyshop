using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Toyshop
{
    public partial class AddNewTableForm : Form
    {
        const int ROW_HEIGTH = 28;  
        EditTablesForm editForm;

        public class TableNameType
        {
            public string Name { get; set; }
            public Type Type { get; set; }
            public bool AllowNull { get; set; }

            public TableNameType(string name, Type type, bool allowNull)
            {
                Name = name;
                Type = type;
                AllowNull = allowNull;
            }
        }
        
        public AddNewTableForm(EditTablesForm form)
        {
            InitializeComponent();
            editForm = form;
            cmbColumn1.Items.AddRange(Utils.DataTypes);
            cmbColumn1.SelectedIndex = 0;
        }

        private void btnNewColumn_Click(object sender, EventArgs e)
        {
            int row = tablePanel.RowCount++;

            // Add label
            Label lab = new Label();
            lab.Text = "C" + row + ":";
            lab.Anchor = AnchorStyles.Right;
            lab.Margin = new Padding(0);
            lab.AutoSize = true;
            tablePanel.Controls.Add(lab, 0, row);

            // Add primary key radiobutton
            RadioButton rb = new RadioButton();
            rb.Text = string.Empty;
            rb.AutoSize = true;
            rb.Margin = new Padding(0);
            rb.Click += radioButton_Click;
            rb.Anchor = AnchorStyles.None;
            tablePanel.Controls.Add(rb, 1, row);

            // Add allow null checkbox
            CheckBox cb = new CheckBox();
            cb.Text = string.Empty;
            cb.Checked = true;
            cb.AutoSize = true;
            cb.Margin = new Padding(0);
            cb.Anchor = AnchorStyles.None;
            tablePanel.Controls.Add(cb, 2, row);

            // Add Name textbox
            TextBox txt = new TextBox();
            txt.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txt.Margin = new Padding(0);
            tablePanel.Controls.Add(txt, 3, row);

            // Add Type combobox
            ComboBox box = new ComboBox();
            box.Items.AddRange(Utils.DataTypes);
            box.SelectedIndex = 0;
            box.DropDownStyle = ComboBoxStyle.DropDownList;
            box.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            box.Margin = new Padding(3, 0, 3, 0);
            tablePanel.Controls.Add(box, 4, row);

            // Add Delete Column button
            Button btn = new Button();
            btn.Click += btnRemoveRow_Click;
            btn.Anchor = AnchorStyles.None;
            btn.Size = new Size(19, 22);
            btn.Text = "X";
            tablePanel.Controls.Add(btn, 5, row);

            // Increase window's height to fit new row
            Height += ROW_HEIGTH;

            UpdateRemoveButton();
        }

        private void btnRemoveRow_Click(object sender, EventArgs e)
        {
            int row = tablePanel.GetRow(sender as Button);

            // If this row was marked as primary move marker to first row
            if ((tablePanel.GetControlFromPosition(1, row) as RadioButton).Checked)
                (tablePanel.GetControlFromPosition(1, 1) as RadioButton).Checked = true;

            // Remove controls from that row
            for (int i = 0; i < tablePanel.ColumnCount; i++)
                tablePanel.Controls.Remove(tablePanel.GetControlFromPosition(i, row));

            // Move all following controls one row up
            for (int i = row + 1; i < tablePanel.RowCount; i++)
            {
                for (int j = 0; j < tablePanel.ColumnCount; j++)
                {
                    Control contr = tablePanel.GetControlFromPosition(j, i);
                    if (contr as Label != null)
                        (contr as Label).Text = "C" + (i - 1) + ":";    // also change label, because row is changed
                    tablePanel.SetRow(contr, i - 1);
                }
            }

            // Remove row and resize form
            tablePanel.RowCount--;
            Height -= ROW_HEIGTH;

            UpdateRemoveButton();
        }

        // Disable delete button from last only row
        private void UpdateRemoveButton()
        { tablePanel.GetControlFromPosition(5, 1).Enabled = tablePanel.RowCount > 2; }

        // On primary radiobutton click uncheck every other radiobutton
        // Also enable back all NOT NULL checkboxes and uncheck & disable the one from the same row as clicked radiobutton
        private void radioButton_Click(object sender, EventArgs e)
        {
            foreach (Control contr in tablePanel.Controls)
            {
                if (contr as RadioButton != null && contr != sender as Control)
                    (contr as RadioButton).Checked = false;

                if (contr as CheckBox != null)
                    (contr as CheckBox).Enabled = true;
            }

            CheckBox cb = tablePanel.GetControlFromPosition(2, (tablePanel.GetRow(sender as Control))) as CheckBox;
            cb.Checked = false;
            cb.Enabled = false;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            List<TableNameType> columns = new List<TableNameType>();

            bool everythingIsOk = true;

            for(int i=1; i<tablePanel.RowCount; i++)
            {
                TextBox txt = tablePanel.GetControlFromPosition(3, i) as TextBox;
                if(string.IsNullOrEmpty(txt.Text))
                {
                    everythingIsOk = false;
                    MessageBox.Show(this, "Column name can not be empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                }

                ComboBox cmb = tablePanel.GetControlFromPosition(4, i) as ComboBox;
                CheckBox cb = tablePanel.GetControlFromPosition(2, i) as CheckBox;

                columns.Add(new TableNameType(txt.Text.Trim(), Type.GetType("System." + cmb.SelectedItem.ToString()), cb.Checked));
            }

            if (string.IsNullOrEmpty(txtTableName.Text))
            {
                everythingIsOk = false;
                MessageBox.Show(this, "Table name can not be empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            int primaryIndex = 0;
            foreach(Control contr in tablePanel.Controls)
                if(contr as RadioButton != null && (contr as RadioButton).Checked)
                {
                    primaryIndex = tablePanel.GetRow(contr) - 1;
                    break;
                }

            if (everythingIsOk)
            {
                editForm.CreateTable(txtTableName.Text.Trim(), columns, primaryIndex);
                Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
