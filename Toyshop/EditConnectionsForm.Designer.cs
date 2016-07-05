namespace Toyshop
{
    partial class EditConnectionsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditConnectionsForm));
            this.lstbConnections = new System.Windows.Forms.ListBox();
            this.cmbParentTable = new System.Windows.Forms.ComboBox();
            this.cmbChildTable = new System.Windows.Forms.ComboBox();
            this.cmbParentColumns = new System.Windows.Forms.ComboBox();
            this.cmbChildColumns = new System.Windows.Forms.ComboBox();
            this.btnCreateConnection = new System.Windows.Forms.Button();
            this.btnDeleteConnection = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lstbConnections
            // 
            this.lstbConnections.FormattingEnabled = true;
            this.lstbConnections.Location = new System.Drawing.Point(46, 39);
            this.lstbConnections.Name = "lstbConnections";
            this.lstbConnections.Size = new System.Drawing.Size(457, 303);
            this.lstbConnections.TabIndex = 0;
            // 
            // cmbParentTable
            // 
            this.cmbParentTable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbParentTable.FormattingEnabled = true;
            this.cmbParentTable.Location = new System.Drawing.Point(46, 388);
            this.cmbParentTable.Name = "cmbParentTable";
            this.cmbParentTable.Size = new System.Drawing.Size(121, 21);
            this.cmbParentTable.TabIndex = 1;
            this.cmbParentTable.SelectedIndexChanged += new System.EventHandler(this.cmbTable1_SelectedIndexChanged);
            // 
            // cmbChildTable
            // 
            this.cmbChildTable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbChildTable.FormattingEnabled = true;
            this.cmbChildTable.Location = new System.Drawing.Point(46, 441);
            this.cmbChildTable.Name = "cmbChildTable";
            this.cmbChildTable.Size = new System.Drawing.Size(121, 21);
            this.cmbChildTable.TabIndex = 2;
            this.cmbChildTable.SelectedIndexChanged += new System.EventHandler(this.cmbTable2_SelectedIndexChanged);
            // 
            // cmbParentColumns
            // 
            this.cmbParentColumns.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbParentColumns.FormattingEnabled = true;
            this.cmbParentColumns.Location = new System.Drawing.Point(191, 388);
            this.cmbParentColumns.Name = "cmbParentColumns";
            this.cmbParentColumns.Size = new System.Drawing.Size(121, 21);
            this.cmbParentColumns.TabIndex = 3;
            // 
            // cmbChildColumns
            // 
            this.cmbChildColumns.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbChildColumns.FormattingEnabled = true;
            this.cmbChildColumns.Location = new System.Drawing.Point(191, 441);
            this.cmbChildColumns.Name = "cmbChildColumns";
            this.cmbChildColumns.Size = new System.Drawing.Size(121, 21);
            this.cmbChildColumns.TabIndex = 4;
            // 
            // btnCreateConnection
            // 
            this.btnCreateConnection.Location = new System.Drawing.Point(349, 388);
            this.btnCreateConnection.Name = "btnCreateConnection";
            this.btnCreateConnection.Size = new System.Drawing.Size(154, 30);
            this.btnCreateConnection.TabIndex = 5;
            this.btnCreateConnection.Text = "Create Connection";
            this.btnCreateConnection.UseVisualStyleBackColor = true;
            this.btnCreateConnection.Click += new System.EventHandler(this.btnCreateConnection_Click);
            // 
            // btnDeleteConnection
            // 
            this.btnDeleteConnection.Location = new System.Drawing.Point(349, 431);
            this.btnDeleteConnection.Name = "btnDeleteConnection";
            this.btnDeleteConnection.Size = new System.Drawing.Size(154, 31);
            this.btnDeleteConnection.TabIndex = 6;
            this.btnDeleteConnection.Text = "Delete Selected Connection";
            this.btnDeleteConnection.UseVisualStyleBackColor = true;
            this.btnDeleteConnection.Click += new System.EventHandler(this.btnDeleteConnection_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(43, 372);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Choose Parent table:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(188, 372);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Choose Parent column:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(43, 425);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Choose Child table:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(188, 425);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(109, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Choose Child column:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(43, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(105, 13);
            this.label5.TabIndex = 21;
            this.label5.Text = "Current connections:";
            // 
            // EditConnectionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(551, 493);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnDeleteConnection);
            this.Controls.Add(this.btnCreateConnection);
            this.Controls.Add(this.cmbChildColumns);
            this.Controls.Add(this.cmbParentColumns);
            this.Controls.Add(this.cmbChildTable);
            this.Controls.Add(this.cmbParentTable);
            this.Controls.Add(this.lstbConnections);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "EditConnectionsForm";
            this.Text = "Edit Connections";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EditConnectionsForm_FormClosing);
            this.Load += new System.EventHandler(this.EditConnectionsForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstbConnections;
        private System.Windows.Forms.ComboBox cmbParentTable;
        private System.Windows.Forms.ComboBox cmbChildTable;
        private System.Windows.Forms.ComboBox cmbParentColumns;
        private System.Windows.Forms.ComboBox cmbChildColumns;
        private System.Windows.Forms.Button btnCreateConnection;
        private System.Windows.Forms.Button btnDeleteConnection;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}