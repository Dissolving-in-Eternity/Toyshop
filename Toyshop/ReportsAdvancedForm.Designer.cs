namespace Toyshop
{
    partial class ReportsAdvancedForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportsAdvancedForm));
            this.BottomToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.TopToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.RightToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.LeftToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.ContentPanel = new System.Windows.Forms.ToolStripContentPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnToExcel = new System.Windows.Forms.Button();
            this.btnToWord = new System.Windows.Forms.Button();
            this.grpbxProducts = new System.Windows.Forms.GroupBox();
            this.radioByPriceRange = new System.Windows.Forms.RadioButton();
            this.radioByManufacturer = new System.Windows.Forms.RadioButton();
            this.radioByName = new System.Windows.Forms.RadioButton();
            this.radioByCategory = new System.Windows.Forms.RadioButton();
            this.radioInStock = new System.Windows.Forms.RadioButton();
            this.btnQueryProducts = new System.Windows.Forms.Button();
            this.dgvResult = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnMultiTable = new System.Windows.Forms.Button();
            this.txtMultitable = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnProcedures = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.grpbxProducts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResult)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // BottomToolStripPanel
            // 
            this.BottomToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.BottomToolStripPanel.Name = "BottomToolStripPanel";
            this.BottomToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.BottomToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.BottomToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // TopToolStripPanel
            // 
            this.TopToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.TopToolStripPanel.Name = "TopToolStripPanel";
            this.TopToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.TopToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.TopToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // RightToolStripPanel
            // 
            this.RightToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.RightToolStripPanel.Name = "RightToolStripPanel";
            this.RightToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.RightToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.RightToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // LeftToolStripPanel
            // 
            this.LeftToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.LeftToolStripPanel.Name = "LeftToolStripPanel";
            this.LeftToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.LeftToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.LeftToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // ContentPanel
            // 
            this.ContentPanel.Size = new System.Drawing.Size(150, 175);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.Font = new System.Drawing.Font("Footlight MT Light", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(26, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Products";
            // 
            // btnToExcel
            // 
            this.btnToExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnToExcel.BackgroundImage = global::Toyshop.Properties.Resources.excel_icon;
            this.btnToExcel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnToExcel.Location = new System.Drawing.Point(97, 24);
            this.btnToExcel.Name = "btnToExcel";
            this.btnToExcel.Size = new System.Drawing.Size(80, 80);
            this.btnToExcel.TabIndex = 11;
            this.btnToExcel.UseVisualStyleBackColor = true;
            this.btnToExcel.Click += new System.EventHandler(this.btnToExcel_Click);
            // 
            // btnToWord
            // 
            this.btnToWord.BackgroundImage = global::Toyshop.Properties.Resources.word_icon;
            this.btnToWord.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnToWord.Location = new System.Drawing.Point(6, 24);
            this.btnToWord.Name = "btnToWord";
            this.btnToWord.Size = new System.Drawing.Size(80, 80);
            this.btnToWord.TabIndex = 10;
            this.btnToWord.UseVisualStyleBackColor = true;
            this.btnToWord.Click += new System.EventHandler(this.btnToWord_Click);
            // 
            // grpbxProducts
            // 
            this.grpbxProducts.Controls.Add(this.radioByPriceRange);
            this.grpbxProducts.Controls.Add(this.radioByManufacturer);
            this.grpbxProducts.Controls.Add(this.radioByName);
            this.grpbxProducts.Controls.Add(this.radioByCategory);
            this.grpbxProducts.Controls.Add(this.btnQueryProducts);
            this.grpbxProducts.Controls.Add(this.radioInStock);
            this.grpbxProducts.Location = new System.Drawing.Point(12, 50);
            this.grpbxProducts.Name = "grpbxProducts";
            this.grpbxProducts.Size = new System.Drawing.Size(264, 110);
            this.grpbxProducts.TabIndex = 12;
            this.grpbxProducts.TabStop = false;
            // 
            // radioByPriceRange
            // 
            this.radioByPriceRange.AutoSize = true;
            this.radioByPriceRange.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radioByPriceRange.Location = new System.Drawing.Point(137, 32);
            this.radioByPriceRange.Name = "radioByPriceRange";
            this.radioByPriceRange.Size = new System.Drawing.Size(112, 17);
            this.radioByPriceRange.TabIndex = 6;
            this.radioByPriceRange.TabStop = true;
            this.radioByPriceRange.Text = "By Price Range";
            this.radioByPriceRange.UseVisualStyleBackColor = true;
            // 
            // radioByManufacturer
            // 
            this.radioByManufacturer.AutoSize = true;
            this.radioByManufacturer.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radioByManufacturer.Location = new System.Drawing.Point(137, 10);
            this.radioByManufacturer.Name = "radioByManufacturer";
            this.radioByManufacturer.Size = new System.Drawing.Size(119, 17);
            this.radioByManufacturer.TabIndex = 5;
            this.radioByManufacturer.TabStop = true;
            this.radioByManufacturer.Text = "By Manufactorer";
            this.radioByManufacturer.UseVisualStyleBackColor = true;
            // 
            // radioByName
            // 
            this.radioByName.AutoSize = true;
            this.radioByName.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radioByName.Location = new System.Drawing.Point(18, 56);
            this.radioByName.Name = "radioByName";
            this.radioByName.Size = new System.Drawing.Size(77, 17);
            this.radioByName.TabIndex = 4;
            this.radioByName.TabStop = true;
            this.radioByName.Text = "By Name";
            this.radioByName.UseVisualStyleBackColor = true;
            // 
            // radioByCategory
            // 
            this.radioByCategory.AutoSize = true;
            this.radioByCategory.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radioByCategory.Location = new System.Drawing.Point(18, 33);
            this.radioByCategory.Name = "radioByCategory";
            this.radioByCategory.Size = new System.Drawing.Size(97, 17);
            this.radioByCategory.TabIndex = 3;
            this.radioByCategory.TabStop = true;
            this.radioByCategory.Text = "By Category";
            this.radioByCategory.UseVisualStyleBackColor = true;
            // 
            // radioInStock
            // 
            this.radioInStock.AutoSize = true;
            this.radioInStock.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radioInStock.Location = new System.Drawing.Point(18, 10);
            this.radioInStock.Name = "radioInStock";
            this.radioInStock.Size = new System.Drawing.Size(73, 17);
            this.radioInStock.TabIndex = 0;
            this.radioInStock.TabStop = true;
            this.radioInStock.Text = "In Stock";
            this.radioInStock.UseVisualStyleBackColor = true;
            // 
            // btnQueryProducts
            // 
            this.btnQueryProducts.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQueryProducts.Location = new System.Drawing.Point(18, 79);
            this.btnQueryProducts.Name = "btnQueryProducts";
            this.btnQueryProducts.Size = new System.Drawing.Size(75, 23);
            this.btnQueryProducts.TabIndex = 14;
            this.btnQueryProducts.Text = "Query";
            this.btnQueryProducts.UseVisualStyleBackColor = true;
            this.btnQueryProducts.Click += new System.EventHandler(this.btnQueryProducts_Click);
            // 
            // dgvResult
            // 
            this.dgvResult.AllowUserToAddRows = false;
            this.dgvResult.AllowUserToDeleteRows = false;
            this.dgvResult.AllowUserToResizeColumns = false;
            this.dgvResult.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvResult.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvResult.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvResult.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvResult.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvResult.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvResult.Location = new System.Drawing.Point(12, 166);
            this.dgvResult.Name = "dgvResult";
            this.dgvResult.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvResult.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvResult.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvResult.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvResult.ShowEditingIcon = false;
            this.dgvResult.Size = new System.Drawing.Size(1338, 431);
            this.dgvResult.TabIndex = 17;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btnToExcel);
            this.groupBox1.Controls.Add(this.btnToWord);
            this.groupBox1.Location = new System.Drawing.Point(1167, 50);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(183, 110);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Export table";
            // 
            // btnMultiTable
            // 
            this.btnMultiTable.Location = new System.Drawing.Point(6, 45);
            this.btnMultiTable.Name = "btnMultiTable";
            this.btnMultiTable.Size = new System.Drawing.Size(163, 57);
            this.btnMultiTable.TabIndex = 19;
            this.btnMultiTable.Text = "Select all products from specified warehouse";
            this.btnMultiTable.UseVisualStyleBackColor = true;
            this.btnMultiTable.Click += new System.EventHandler(this.btnMultiTable_Click);
            // 
            // txtMultitable
            // 
            this.txtMultitable.Location = new System.Drawing.Point(91, 19);
            this.txtMultitable.Name = "txtMultitable";
            this.txtMultitable.Size = new System.Drawing.Size(78, 20);
            this.txtMultitable.TabIndex = 21;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 22;
            this.label3.Text = "Warehouse No";
            // 
            // btnProcedures
            // 
            this.btnProcedures.Font = new System.Drawing.Font("Footlight MT Light", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProcedures.Location = new System.Drawing.Point(524, 50);
            this.btnProcedures.Name = "btnProcedures";
            this.btnProcedures.Size = new System.Drawing.Size(202, 110);
            this.btnProcedures.TabIndex = 23;
            this.btnProcedures.Text = "-------------- Advanced query constructor --------------";
            this.btnProcedures.UseVisualStyleBackColor = true;
            this.btnProcedures.Click += new System.EventHandler(this.btnProcedures_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.btnMultiTable);
            this.groupBox2.Controls.Add(this.txtMultitable);
            this.groupBox2.Location = new System.Drawing.Point(317, 50);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(177, 110);
            this.groupBox2.TabIndex = 24;
            this.groupBox2.TabStop = false;
            // 
            // ReportsAdvancedForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1362, 609);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnProcedures);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvResult);
            this.Controls.Add(this.grpbxProducts);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ReportsAdvancedForm";
            this.Text = "Reports";
            this.TransparencyKey = System.Drawing.Color.White;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ReportsForm_FormClosing);
            this.Load += new System.EventHandler(this.ReportsForm_Load);
            this.grpbxProducts.ResumeLayout(false);
            this.grpbxProducts.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResult)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStripPanel BottomToolStripPanel;
        private System.Windows.Forms.ToolStripPanel TopToolStripPanel;
        private System.Windows.Forms.ToolStripPanel RightToolStripPanel;
        private System.Windows.Forms.ToolStripPanel LeftToolStripPanel;
        private System.Windows.Forms.ToolStripContentPanel ContentPanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnToWord;
        private System.Windows.Forms.Button btnToExcel;
        private System.Windows.Forms.GroupBox grpbxProducts;
        private System.Windows.Forms.RadioButton radioByPriceRange;
        private System.Windows.Forms.RadioButton radioByManufacturer;
        private System.Windows.Forms.RadioButton radioByName;
        private System.Windows.Forms.RadioButton radioByCategory;
        private System.Windows.Forms.RadioButton radioInStock;
        private System.Windows.Forms.Button btnQueryProducts;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnMultiTable;
        private System.Windows.Forms.TextBox txtMultitable;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnProcedures;
        internal System.Windows.Forms.DataGridView dgvResult;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}