namespace Toyshop
{
    partial class CustomQueryForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomQueryForm));
            this.btnAddProcedure = new System.Windows.Forms.Button();
            this.cmbProcedures = new System.Windows.Forms.ComboBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnAddCustomParam = new System.Windows.Forms.Button();
            this.cmbCustomParamType = new System.Windows.Forms.ComboBox();
            this.txtCustomParamName = new System.Windows.Forms.TextBox();
            this.txtCustomParamValue = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnExecute = new System.Windows.Forms.Button();
            this.detailsPanel = new System.Windows.Forms.RichTextBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.tableParams = new System.Windows.Forms.TableLayoutPanel();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.checkValidation = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtProcName = new System.Windows.Forms.TextBox();
            this.richText = new System.Windows.Forms.RichTextBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tableParams.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAddProcedure
            // 
            this.btnAddProcedure.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddProcedure.Location = new System.Drawing.Point(557, 147);
            this.btnAddProcedure.Name = "btnAddProcedure";
            this.btnAddProcedure.Size = new System.Drawing.Size(80, 25);
            this.btnAddProcedure.TabIndex = 2;
            this.btnAddProcedure.Text = "Create";
            this.btnAddProcedure.UseVisualStyleBackColor = true;
            this.btnAddProcedure.Click += new System.EventHandler(this.btnAddProcedure_Click);
            // 
            // cmbProcedures
            // 
            this.cmbProcedures.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProcedures.FormattingEnabled = true;
            this.cmbProcedures.Location = new System.Drawing.Point(9, 28);
            this.cmbProcedures.Name = "cmbProcedures";
            this.cmbProcedures.Size = new System.Drawing.Size(188, 21);
            this.cmbProcedures.TabIndex = 3;
            this.cmbProcedures.SelectedIndexChanged += new System.EventHandler(this.cmbProcedures_SelectedIndexChanged);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(653, 206);
            this.tabControl1.TabIndex = 4;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnAddCustomParam);
            this.tabPage1.Controls.Add(this.cmbCustomParamType);
            this.tabPage1.Controls.Add(this.txtCustomParamName);
            this.tabPage1.Controls.Add(this.txtCustomParamValue);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.btnExecute);
            this.tabPage1.Controls.Add(this.detailsPanel);
            this.tabPage1.Controls.Add(this.btnDelete);
            this.tabPage1.Controls.Add(this.tableParams);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.cmbProcedures);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(645, 180);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Execute procedure";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnAddCustomParam
            // 
            this.btnAddCustomParam.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddCustomParam.Location = new System.Drawing.Point(366, 154);
            this.btnAddCustomParam.Name = "btnAddCustomParam";
            this.btnAddCustomParam.Size = new System.Drawing.Size(21, 21);
            this.btnAddCustomParam.TabIndex = 12;
            this.btnAddCustomParam.Text = "+";
            this.btnAddCustomParam.UseVisualStyleBackColor = true;
            this.btnAddCustomParam.Click += new System.EventHandler(this.btnAddCustomParam_Click);
            // 
            // cmbCustomParamType
            // 
            this.cmbCustomParamType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbCustomParamType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCustomParamType.FormattingEnabled = true;
            this.cmbCustomParamType.Location = new System.Drawing.Point(459, 154);
            this.cmbCustomParamType.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.cmbCustomParamType.Name = "cmbCustomParamType";
            this.cmbCustomParamType.Size = new System.Drawing.Size(84, 21);
            this.cmbCustomParamType.TabIndex = 0;
            // 
            // txtCustomParamName
            // 
            this.txtCustomParamName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCustomParamName.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.txtCustomParamName.Location = new System.Drawing.Point(393, 155);
            this.txtCustomParamName.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.txtCustomParamName.Name = "txtCustomParamName";
            this.txtCustomParamName.Size = new System.Drawing.Size(60, 20);
            this.txtCustomParamName.TabIndex = 1;
            this.txtCustomParamName.Text = "Name";
            this.txtCustomParamName.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtCustomParamName_MouseClick);
            // 
            // txtCustomParamValue
            // 
            this.txtCustomParamValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCustomParamValue.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.txtCustomParamValue.Location = new System.Drawing.Point(549, 154);
            this.txtCustomParamValue.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.txtCustomParamValue.Name = "txtCustomParamValue";
            this.txtCustomParamValue.Size = new System.Drawing.Size(85, 20);
            this.txtCustomParamValue.TabIndex = 1;
            this.txtCustomParamValue.Text = "Value";
            this.txtCustomParamValue.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtCustomParamValue_MouseClick);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(363, 141);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Add custom param";
            // 
            // btnExecute
            // 
            this.btnExecute.Location = new System.Drawing.Point(203, 27);
            this.btnExecute.Name = "btnExecute";
            this.btnExecute.Size = new System.Drawing.Size(100, 23);
            this.btnExecute.TabIndex = 10;
            this.btnExecute.Text = "Execute";
            this.btnExecute.UseVisualStyleBackColor = true;
            this.btnExecute.Click += new System.EventHandler(this.btnExecute_Click);
            // 
            // detailsPanel
            // 
            this.detailsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.detailsPanel.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.detailsPanel.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.detailsPanel.Location = new System.Drawing.Point(6, 55);
            this.detailsPanel.Name = "detailsPanel";
            this.detailsPanel.ReadOnly = true;
            this.detailsPanel.Size = new System.Drawing.Size(354, 117);
            this.detailsPanel.TabIndex = 9;
            this.detailsPanel.TabStop = false;
            this.detailsPanel.Text = "SELECT Moon, Sun FROM Sky \nWHERE Type = \'StellarObject\'";
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(309, 27);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(50, 23);
            this.btnDelete.TabIndex = 8;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // tableParams
            // 
            this.tableParams.ColumnCount = 3;
            this.tableParams.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableParams.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableParams.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableParams.Controls.Add(this.comboBox2, 1, 0);
            this.tableParams.Controls.Add(this.textBox3, 2, 0);
            this.tableParams.Controls.Add(this.label4, 0, 0);
            this.tableParams.Location = new System.Drawing.Point(366, 28);
            this.tableParams.Name = "tableParams";
            this.tableParams.RowCount = 5;
            this.tableParams.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableParams.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableParams.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableParams.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableParams.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableParams.Size = new System.Drawing.Size(271, 110);
            this.tableParams.TabIndex = 7;
            // 
            // comboBox2
            // 
            this.comboBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(93, 0);
            this.comboBox2.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(84, 21);
            this.comboBox2.TabIndex = 0;
            // 
            // textBox3
            // 
            this.textBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox3.Location = new System.Drawing.Point(183, 0);
            this.textBox3.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(85, 20);
            this.textBox3.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "param";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(363, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Specify parameters";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Select procedure";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.checkValidation);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.txtProcName);
            this.tabPage2.Controls.Add(this.richText);
            this.tabPage2.Controls.Add(this.btnAddProcedure);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(645, 180);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Create new procedure";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // checkValidation
            // 
            this.checkValidation.AutoSize = true;
            this.checkValidation.Checked = true;
            this.checkValidation.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkValidation.Location = new System.Drawing.Point(8, 152);
            this.checkValidation.Name = "checkValidation";
            this.checkValidation.Size = new System.Drawing.Size(139, 17);
            this.checkValidation.TabIndex = 6;
            this.checkValidation.Text = "Perform query validation";
            this.checkValidation.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(270, 153);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Procedure name:";
            // 
            // txtProcName
            // 
            this.txtProcName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtProcName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtProcName.Location = new System.Drawing.Point(364, 148);
            this.txtProcName.Name = "txtProcName";
            this.txtProcName.Size = new System.Drawing.Size(187, 23);
            this.txtProcName.TabIndex = 4;
            // 
            // richText
            // 
            this.richText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.richText.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.richText.Location = new System.Drawing.Point(8, 6);
            this.richText.Name = "richText";
            this.richText.Size = new System.Drawing.Size(629, 134);
            this.richText.TabIndex = 3;
            this.richText.Text = "SELECT p.ProductTitle, m.ManufacturerTitle, p.Price, p.InStock \nFROM Products AS " +
    "p, Manufacturers AS m \nWHERE p.ManufacturerCode = m.ManufacturerCode AND p.Price" +
    " > [@param]";
            this.richText.TextChanged += new System.EventHandler(this.richText_TextChanged);
            // 
            // CustomQueryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(653, 206);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CustomQueryForm";
            this.Text = "Custom Query";
            this.Load += new System.EventHandler(this.CustomQueryForm_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tableParams.ResumeLayout(false);
            this.tableParams.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnAddProcedure;
        private System.Windows.Forms.ComboBox cmbProcedures;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TableLayoutPanel tableParams;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.RichTextBox richText;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtProcName;
        private System.Windows.Forms.RichTextBox detailsPanel;
        private System.Windows.Forms.Button btnExecute;
        private System.Windows.Forms.CheckBox checkValidation;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnAddCustomParam;
        private System.Windows.Forms.ComboBox cmbCustomParamType;
        private System.Windows.Forms.TextBox txtCustomParamName;
        private System.Windows.Forms.TextBox txtCustomParamValue;
        private System.Windows.Forms.Label label5;
    }
}