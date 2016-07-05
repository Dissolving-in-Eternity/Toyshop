namespace Toyshop
{
    partial class ViewTablesForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewTablesForm));
            this.cmbListOfTables = new System.Windows.Forms.ComboBox();
            this.dgvTables = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.txbFilter = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbColumns = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnRemoveFilter = new System.Windows.Forms.Button();
            this.btnAscendingSort = new System.Windows.Forms.Button();
            this.btnDescendingSort = new System.Windows.Forms.Button();
            this.btnWordExport = new System.Windows.Forms.Button();
            this.btnExcelExport = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cmbOperator = new System.Windows.Forms.ComboBox();
            this.txtFilterValue = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTables)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbListOfTables
            // 
            this.cmbListOfTables.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbListOfTables.FormattingEnabled = true;
            this.cmbListOfTables.Location = new System.Drawing.Point(12, 60);
            this.cmbListOfTables.Name = "cmbListOfTables";
            this.cmbListOfTables.Size = new System.Drawing.Size(167, 21);
            this.cmbListOfTables.TabIndex = 0;
            this.cmbListOfTables.SelectedIndexChanged += new System.EventHandler(this.cmbListOfTables_SelectedIndexChanged);
            // 
            // dgvTables
            // 
            this.dgvTables.AllowUserToAddRows = false;
            this.dgvTables.AllowUserToDeleteRows = false;
            this.dgvTables.AllowUserToResizeColumns = false;
            this.dgvTables.AllowUserToResizeRows = false;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTables.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvTables.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTables.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTables.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvTables.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTables.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvTables.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTables.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgvTables.Location = new System.Drawing.Point(12, 115);
            this.dgvTables.MultiSelect = false;
            this.dgvTables.Name = "dgvTables";
            this.dgvTables.ReadOnly = true;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTables.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvTables.RowsDefaultCellStyle = dataGridViewCellStyle10;
            this.dgvTables.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTables.ShowEditingIcon = false;
            this.dgvTables.Size = new System.Drawing.Size(1154, 453);
            this.dgvTables.TabIndex = 1;
            this.dgvTables.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTables_CellClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(57, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "List of Tables:";
            // 
            // txbFilter
            // 
            this.txbFilter.Location = new System.Drawing.Point(6, 37);
            this.txbFilter.Name = "txbFilter";
            this.txbFilter.Size = new System.Drawing.Size(134, 20);
            this.txbFilter.TabIndex = 3;
            this.txbFilter.TextChanged += new System.EventHandler(this.txbFilter_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Filter by all columns:";
            // 
            // cmbColumns
            // 
            this.cmbColumns.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbColumns.FormattingEnabled = true;
            this.cmbColumns.Location = new System.Drawing.Point(6, 81);
            this.cmbColumns.Name = "cmbColumns";
            this.cmbColumns.Size = new System.Drawing.Size(134, 21);
            this.cmbColumns.TabIndex = 6;
            this.cmbColumns.SelectedIndexChanged += new System.EventHandler(this.cmbColumns_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Or filter by one column:";
            // 
            // btnRemoveFilter
            // 
            this.btnRemoveFilter.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnRemoveFilter.BackgroundImage")));
            this.btnRemoveFilter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRemoveFilter.ImageAlign = System.Drawing.ContentAlignment.TopRight;
            this.btnRemoveFilter.Location = new System.Drawing.Point(146, 36);
            this.btnRemoveFilter.Name = "btnRemoveFilter";
            this.btnRemoveFilter.Size = new System.Drawing.Size(22, 22);
            this.btnRemoveFilter.TabIndex = 8;
            this.btnRemoveFilter.UseVisualStyleBackColor = true;
            this.btnRemoveFilter.Click += new System.EventHandler(this.btnRemoveFilter_Click);
            // 
            // btnAscendingSort
            // 
            this.btnAscendingSort.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAscendingSort.BackgroundImage")));
            this.btnAscendingSort.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAscendingSort.Location = new System.Drawing.Point(9, 35);
            this.btnAscendingSort.Name = "btnAscendingSort";
            this.btnAscendingSort.Size = new System.Drawing.Size(55, 59);
            this.btnAscendingSort.TabIndex = 10;
            this.btnAscendingSort.UseVisualStyleBackColor = true;
            this.btnAscendingSort.Click += new System.EventHandler(this.btnAscendingSort_Click);
            // 
            // btnDescendingSort
            // 
            this.btnDescendingSort.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnDescendingSort.BackgroundImage")));
            this.btnDescendingSort.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDescendingSort.Location = new System.Drawing.Point(86, 35);
            this.btnDescendingSort.Name = "btnDescendingSort";
            this.btnDescendingSort.Size = new System.Drawing.Size(55, 59);
            this.btnDescendingSort.TabIndex = 11;
            this.btnDescendingSort.UseVisualStyleBackColor = true;
            this.btnDescendingSort.Click += new System.EventHandler(this.btnDescendingSort_Click);
            // 
            // btnWordExport
            // 
            this.btnWordExport.BackgroundImage = global::Toyshop.Properties.Resources.word_icon;
            this.btnWordExport.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnWordExport.Location = new System.Drawing.Point(6, 19);
            this.btnWordExport.Name = "btnWordExport";
            this.btnWordExport.Size = new System.Drawing.Size(46, 51);
            this.btnWordExport.TabIndex = 12;
            this.btnWordExport.UseVisualStyleBackColor = true;
            this.btnWordExport.Click += new System.EventHandler(this.derp_Click);
            // 
            // btnExcelExport
            // 
            this.btnExcelExport.BackgroundImage = global::Toyshop.Properties.Resources.excel_icon;
            this.btnExcelExport.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnExcelExport.Location = new System.Drawing.Point(58, 19);
            this.btnExcelExport.Name = "btnExcelExport";
            this.btnExcelExport.Size = new System.Drawing.Size(46, 51);
            this.btnExcelExport.TabIndex = 12;
            this.btnExcelExport.UseVisualStyleBackColor = true;
            this.btnExcelExport.Click += new System.EventHandler(this.durp_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btnWordExport);
            this.groupBox1.Controls.Add(this.btnExcelExport);
            this.groupBox1.Location = new System.Drawing.Point(1056, 33);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(110, 76);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Export table";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtFilterValue);
            this.groupBox2.Controls.Add(this.cmbOperator);
            this.groupBox2.Controls.Add(this.txbFilter);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.btnRemoveFilter);
            this.groupBox2.Controls.Add(this.cmbColumns);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(412, 1);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(392, 108);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Filters";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnAscendingSort);
            this.groupBox3.Controls.Add(this.btnDescendingSort);
            this.groupBox3.Location = new System.Drawing.Point(246, 9);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(147, 100);
            this.groupBox3.TabIndex = 15;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Sorting by chosen column";
            // 
            // cmbOperator
            // 
            this.cmbOperator.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOperator.FormattingEnabled = true;
            this.cmbOperator.Items.AddRange(new object[] {
            "LIKE",
            "NOT LIKE",
            "=",
            ">",
            ">=",
            "<",
            "<="});
            this.cmbOperator.Location = new System.Drawing.Point(146, 81);
            this.cmbOperator.Name = "cmbOperator";
            this.cmbOperator.Size = new System.Drawing.Size(84, 21);
            this.cmbOperator.TabIndex = 16;
            this.cmbOperator.SelectedIndexChanged += new System.EventHandler(this.cmbOperator_SelectedIndexChanged);
            // 
            // txtFilterValue
            // 
            this.txtFilterValue.Location = new System.Drawing.Point(236, 82);
            this.txtFilterValue.Name = "txtFilterValue";
            this.txtFilterValue.Size = new System.Drawing.Size(150, 20);
            this.txtFilterValue.TabIndex = 17;
            this.txtFilterValue.TextChanged += new System.EventHandler(this.txtFilterValue_TextChanged);
            // 
            // ViewTablesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1178, 580);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvTables);
            this.Controls.Add(this.cmbListOfTables);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ViewTablesForm";
            this.Text = "View Tables";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ViewTablesForm_FormClosing);
            this.Load += new System.EventHandler(this.ViewTablesForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTables)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox cmbListOfTables;
        private System.Windows.Forms.DataGridView dgvTables;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txbFilter;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbColumns;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnRemoveFilter;
        private System.Windows.Forms.Button btnAscendingSort;
        private System.Windows.Forms.Button btnDescendingSort;
        private System.Windows.Forms.Button btnWordExport;
        private System.Windows.Forms.Button btnExcelExport;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtFilterValue;
        private System.Windows.Forms.ComboBox cmbOperator;
        private System.Windows.Forms.GroupBox groupBox3;
    }
}