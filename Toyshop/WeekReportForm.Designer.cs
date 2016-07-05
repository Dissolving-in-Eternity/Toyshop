namespace Toyshop
{
    partial class WeekReportForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WeekReportForm));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabReport = new System.Windows.Forms.TabPage();
            this.btnExportWordReport = new System.Windows.Forms.Button();
            this.labDateReport = new System.Windows.Forms.Label();
            this.labLoginReport = new System.Windows.Forms.Label();
            this.labItemsSoldReport = new System.Windows.Forms.Label();
            this.labTotal = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvReport = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabResidue = new System.Windows.Forms.TabPage();
            this.btnExportWordResidue = new System.Windows.Forms.Button();
            this.labDateResidue = new System.Windows.Forms.Label();
            this.labLoginResidue = new System.Windows.Forms.Label();
            this.labItemsSoldResidue = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.dgvResidue = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl1.SuspendLayout();
            this.tabReport.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReport)).BeginInit();
            this.tabResidue.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResidue)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabReport);
            this.tabControl1.Controls.Add(this.tabResidue);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(668, 306);
            this.tabControl1.TabIndex = 0;
            // 
            // tabReport
            // 
            this.tabReport.Controls.Add(this.btnExportWordReport);
            this.tabReport.Controls.Add(this.labDateReport);
            this.tabReport.Controls.Add(this.labLoginReport);
            this.tabReport.Controls.Add(this.labItemsSoldReport);
            this.tabReport.Controls.Add(this.labTotal);
            this.tabReport.Controls.Add(this.label3);
            this.tabReport.Controls.Add(this.label1);
            this.tabReport.Controls.Add(this.dgvReport);
            this.tabReport.Location = new System.Drawing.Point(4, 22);
            this.tabReport.Name = "tabReport";
            this.tabReport.Padding = new System.Windows.Forms.Padding(3);
            this.tabReport.Size = new System.Drawing.Size(660, 280);
            this.tabReport.TabIndex = 0;
            this.tabReport.Text = "Report";
            this.tabReport.UseVisualStyleBackColor = true;
            // 
            // btnExportWordReport
            // 
            this.btnExportWordReport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportWordReport.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnExportWordReport.Location = new System.Drawing.Point(556, 2);
            this.btnExportWordReport.Name = "btnExportWordReport";
            this.btnExportWordReport.Size = new System.Drawing.Size(96, 21);
            this.btnExportWordReport.TabIndex = 2;
            this.btnExportWordReport.Text = "Export to Word";
            this.btnExportWordReport.UseVisualStyleBackColor = true;
            this.btnExportWordReport.Click += new System.EventHandler(this.btnExportWordReport_Click);
            // 
            // labDateReport
            // 
            this.labDateReport.AutoSize = true;
            this.labDateReport.Font = new System.Drawing.Font("Tempus Sans ITC", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labDateReport.Location = new System.Drawing.Point(182, 3);
            this.labDateReport.Name = "labDateReport";
            this.labDateReport.Size = new System.Drawing.Size(181, 20);
            this.labDateReport.TabIndex = 1;
            this.labDateReport.Text = "13.05.2016 - 20.05.2016";
            // 
            // labLoginReport
            // 
            this.labLoginReport.AutoSize = true;
            this.labLoginReport.Font = new System.Drawing.Font("Tempus Sans ITC", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labLoginReport.Location = new System.Drawing.Point(55, 3);
            this.labLoginReport.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.labLoginReport.Name = "labLoginReport";
            this.labLoginReport.Size = new System.Drawing.Size(73, 20);
            this.labLoginReport.TabIndex = 1;
            this.labLoginReport.Text = "John Doe";
            // 
            // labItemsSoldReport
            // 
            this.labItemsSoldReport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labItemsSoldReport.AutoSize = true;
            this.labItemsSoldReport.Font = new System.Drawing.Font("Tempus Sans ITC", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labItemsSoldReport.Location = new System.Drawing.Point(559, 255);
            this.labItemsSoldReport.Name = "labItemsSoldReport";
            this.labItemsSoldReport.Size = new System.Drawing.Size(93, 20);
            this.labItemsSoldReport.TabIndex = 1;
            this.labItemsSoldReport.Text = "13 items sold";
            this.labItemsSoldReport.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // labTotal
            // 
            this.labTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labTotal.AutoSize = true;
            this.labTotal.Font = new System.Drawing.Font("Tempus Sans ITC", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labTotal.Location = new System.Drawing.Point(59, 255);
            this.labTotal.Name = "labTotal";
            this.labTotal.Size = new System.Drawing.Size(39, 20);
            this.labTotal.TabIndex = 1;
            this.labTotal.Text = "1337";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tempus Sans ITC", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(8, 3);
            this.label3.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 20);
            this.label3.TabIndex = 1;
            this.label3.Text = "Seller:";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tempus Sans ITC", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 255);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Total:";
            // 
            // dgvReport
            // 
            this.dgvReport.AllowUserToAddRows = false;
            this.dgvReport.AllowUserToDeleteRows = false;
            this.dgvReport.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvReport.BackgroundColor = System.Drawing.Color.White;
            this.dgvReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReport.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column6,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5});
            this.dgvReport.Location = new System.Drawing.Point(8, 26);
            this.dgvReport.Name = "dgvReport";
            this.dgvReport.ReadOnly = true;
            this.dgvReport.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvReport.Size = new System.Drawing.Size(644, 226);
            this.dgvReport.TabIndex = 0;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "№";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Date";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "ProductTitle";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Price";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Quantity";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Subtotal";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // tabResidue
            // 
            this.tabResidue.Controls.Add(this.btnExportWordResidue);
            this.tabResidue.Controls.Add(this.labDateResidue);
            this.tabResidue.Controls.Add(this.labLoginResidue);
            this.tabResidue.Controls.Add(this.labItemsSoldResidue);
            this.tabResidue.Controls.Add(this.label7);
            this.tabResidue.Controls.Add(this.dgvResidue);
            this.tabResidue.Location = new System.Drawing.Point(4, 22);
            this.tabResidue.Name = "tabResidue";
            this.tabResidue.Padding = new System.Windows.Forms.Padding(3);
            this.tabResidue.Size = new System.Drawing.Size(660, 280);
            this.tabResidue.TabIndex = 1;
            this.tabResidue.Text = "Residue";
            this.tabResidue.UseVisualStyleBackColor = true;
            // 
            // btnExportWordResidue
            // 
            this.btnExportWordResidue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportWordResidue.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnExportWordResidue.Location = new System.Drawing.Point(556, 2);
            this.btnExportWordResidue.Name = "btnExportWordResidue";
            this.btnExportWordResidue.Size = new System.Drawing.Size(96, 21);
            this.btnExportWordResidue.TabIndex = 10;
            this.btnExportWordResidue.Text = "Export to Word";
            this.btnExportWordResidue.UseVisualStyleBackColor = true;
            this.btnExportWordResidue.Click += new System.EventHandler(this.btnExportWordReport_Click);
            // 
            // labDateResidue
            // 
            this.labDateResidue.AutoSize = true;
            this.labDateResidue.Font = new System.Drawing.Font("Tempus Sans ITC", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labDateResidue.Location = new System.Drawing.Point(182, 3);
            this.labDateResidue.Name = "labDateResidue";
            this.labDateResidue.Size = new System.Drawing.Size(181, 20);
            this.labDateResidue.TabIndex = 4;
            this.labDateResidue.Text = "13.05.2016 - 20.05.2016";
            // 
            // labLoginResidue
            // 
            this.labLoginResidue.AutoSize = true;
            this.labLoginResidue.Font = new System.Drawing.Font("Tempus Sans ITC", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labLoginResidue.Location = new System.Drawing.Point(55, 3);
            this.labLoginResidue.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.labLoginResidue.Name = "labLoginResidue";
            this.labLoginResidue.Size = new System.Drawing.Size(73, 20);
            this.labLoginResidue.TabIndex = 5;
            this.labLoginResidue.Text = "John Doe";
            // 
            // labItemsSoldResidue
            // 
            this.labItemsSoldResidue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labItemsSoldResidue.AutoSize = true;
            this.labItemsSoldResidue.Font = new System.Drawing.Font("Tempus Sans ITC", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labItemsSoldResidue.Location = new System.Drawing.Point(559, 255);
            this.labItemsSoldResidue.Name = "labItemsSoldResidue";
            this.labItemsSoldResidue.Size = new System.Drawing.Size(93, 20);
            this.labItemsSoldResidue.TabIndex = 6;
            this.labItemsSoldResidue.Text = "13 items sold";
            this.labItemsSoldResidue.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tempus Sans ITC", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(8, 3);
            this.label7.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 20);
            this.label7.TabIndex = 8;
            this.label7.Text = "Seller:";
            // 
            // dgvResidue
            // 
            this.dgvResidue.AllowUserToAddRows = false;
            this.dgvResidue.AllowUserToDeleteRows = false;
            this.dgvResidue.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvResidue.BackgroundColor = System.Drawing.Color.White;
            this.dgvResidue.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResidue.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4});
            this.dgvResidue.Location = new System.Drawing.Point(8, 26);
            this.dgvResidue.Name = "dgvResidue";
            this.dgvResidue.ReadOnly = true;
            this.dgvResidue.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvResidue.Size = new System.Drawing.Size(644, 226);
            this.dgvResidue.TabIndex = 3;
            this.dgvResidue.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvResidue_CellFormatting);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "№";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.FillWeight = 200F;
            this.dataGridViewTextBoxColumn2.HeaderText = "ProductTitle";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 200;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Sold";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "Residue";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // WeekReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(668, 306);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WeekReportForm";
            this.Text = "Week Report";
            this.Load += new System.EventHandler(this.WeekReportForm_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabReport.ResumeLayout(false);
            this.tabReport.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReport)).EndInit();
            this.tabResidue.ResumeLayout(false);
            this.tabResidue.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResidue)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabReport;
        private System.Windows.Forms.Button btnExportWordReport;
        private System.Windows.Forms.Label labDateReport;
        private System.Windows.Forms.Label labLoginReport;
        private System.Windows.Forms.Label labItemsSoldReport;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvReport;
        private System.Windows.Forms.TabPage tabResidue;
        private System.Windows.Forms.Button btnExportWordResidue;
        private System.Windows.Forms.Label labDateResidue;
        private System.Windows.Forms.Label labLoginResidue;
        private System.Windows.Forms.Label labItemsSoldResidue;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView dgvResidue;
        private System.Windows.Forms.Label labTotal;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
    }
}