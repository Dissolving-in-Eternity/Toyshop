namespace Toyshop
{
    partial class ViewCatalogForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewCatalogForm));
            this.tree = new System.Windows.Forms.TreeView();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.lblPrice = new System.Windows.Forms.Label();
            this.lblCurrentNumber = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbAgeGroup = new System.Windows.Forms.ComboBox();
            this.cmbManufacturer = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txbFilter = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txbPriceFrom = new System.Windows.Forms.TextBox();
            this.txbPriceTo = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txbDescription = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.listView = new System.Windows.Forms.ListView();
            this.lblCount = new System.Windows.Forms.Label();
            this.btnPlaceOrder = new System.Windows.Forms.Button();
            this.btnQuery = new System.Windows.Forms.Button();
            this.btnOrder = new System.Windows.Forms.Button();
            this.pctbxInStock = new System.Windows.Forms.PictureBox();
            this.btnPriceFilter = new System.Windows.Forms.Button();
            this.btnRemoveFilter = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnPrev = new System.Windows.Forms.Button();
            this.pctbxCatalogImage = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pctbxInStock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctbxCatalogImage)).BeginInit();
            this.SuspendLayout();
            // 
            // tree
            // 
            this.tree.ImageIndex = 0;
            this.tree.ImageList = this.imageList;
            this.tree.Location = new System.Drawing.Point(16, 339);
            this.tree.Name = "tree";
            this.tree.SelectedImageIndex = 0;
            this.tree.Size = new System.Drawing.Size(208, 276);
            this.tree.TabIndex = 4;
            this.tree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.categoryTreeView_AfterSelect);
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "BigEyes-Creature.ico");
            this.imageList.Images.SetKeyName(1, "Black-Creature (1).ico");
            this.imageList.Images.SetKeyName(2, "black-creature.ico");
            this.imageList.Images.SetKeyName(3, "BlackPower-creature.ico");
            this.imageList.Images.SetKeyName(4, "blue-creature.ico");
            this.imageList.Images.SetKeyName(5, "brown-creature.ico");
            this.imageList.Images.SetKeyName(6, "Cheeks-Creature.ico");
            this.imageList.Images.SetKeyName(7, "China-Creature.ico");
            this.imageList.Images.SetKeyName(8, "Domokun-Creature.ico");
            this.imageList.Images.SetKeyName(9, "Ears-Creature.ico");
            this.imageList.Images.SetKeyName(10, "Glasses-Creature.ico");
            this.imageList.Images.SetKeyName(11, "green-creature.ico");
            this.imageList.Images.SetKeyName(12, "Nose-Creature.ico");
            this.imageList.Images.SetKeyName(13, "orange-creature.ico");
            this.imageList.Images.SetKeyName(14, "pink-creature.ico");
            this.imageList.Images.SetKeyName(15, "Pirate-Creature.ico");
            this.imageList.Images.SetKeyName(16, "red-creature.ico");
            this.imageList.Images.SetKeyName(17, "Scar-Creature.ico");
            this.imageList.Images.SetKeyName(18, "Smile-Creature.ico");
            this.imageList.Images.SetKeyName(19, "Tentacles-creature.ico");
            this.imageList.Images.SetKeyName(20, "tie-creature.ico");
            this.imageList.Images.SetKeyName(21, "white-creature.ico");
            // 
            // cmbCategory
            // 
            this.cmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategory.FormattingEnabled = true;
            this.cmbCategory.Location = new System.Drawing.Point(16, 40);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(208, 21);
            this.cmbCategory.TabIndex = 5;
            // 
            // lblPrice
            // 
            this.lblPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblPrice.Location = new System.Drawing.Point(372, 578);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(353, 37);
            this.lblPrice.TabIndex = 6;
            this.lblPrice.Text = "0.00";
            this.lblPrice.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCurrentNumber
            // 
            this.lblCurrentNumber.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblCurrentNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblCurrentNumber.Location = new System.Drawing.Point(608, 10);
            this.lblCurrentNumber.Name = "lblCurrentNumber";
            this.lblCurrentNumber.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblCurrentNumber.Size = new System.Drawing.Size(117, 31);
            this.lblCurrentNumber.TabIndex = 7;
            this.lblCurrentNumber.Text = "N";
            this.lblCurrentNumber.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Choose by Category:";
            // 
            // cmbAgeGroup
            // 
            this.cmbAgeGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAgeGroup.FormattingEnabled = true;
            this.cmbAgeGroup.Location = new System.Drawing.Point(16, 85);
            this.cmbAgeGroup.Name = "cmbAgeGroup";
            this.cmbAgeGroup.Size = new System.Drawing.Size(208, 21);
            this.cmbAgeGroup.TabIndex = 10;
            // 
            // cmbManufacturer
            // 
            this.cmbManufacturer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbManufacturer.FormattingEnabled = true;
            this.cmbManufacturer.Location = new System.Drawing.Point(16, 131);
            this.cmbManufacturer.Name = "cmbManufacturer";
            this.cmbManufacturer.Size = new System.Drawing.Size(208, 21);
            this.cmbManufacturer.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Choose by Age Group:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 115);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(126, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Choose by Manufactorer:";
            // 
            // txbFilter
            // 
            this.txbFilter.Location = new System.Drawing.Point(16, 300);
            this.txbFilter.Name = "txbFilter";
            this.txbFilter.Size = new System.Drawing.Size(174, 20);
            this.txbFilter.TabIndex = 14;
            this.txbFilter.TextChanged += new System.EventHandler(this.txbFilter_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 284);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(145, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Filter by Name or Description:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 228);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "Choose by Price:";
            // 
            // txbPriceFrom
            // 
            this.txbPriceFrom.Location = new System.Drawing.Point(43, 244);
            this.txbPriceFrom.Name = "txbPriceFrom";
            this.txbPriceFrom.Size = new System.Drawing.Size(51, 20);
            this.txbPriceFrom.TabIndex = 18;
            // 
            // txbPriceTo
            // 
            this.txbPriceTo.Location = new System.Drawing.Point(116, 244);
            this.txbPriceTo.Name = "txbPriceTo";
            this.txbPriceTo.Size = new System.Drawing.Size(51, 20);
            this.txbPriceTo.TabIndex = 19;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 247);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(27, 13);
            this.label6.TabIndex = 20;
            this.label6.Text = "from";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(99, 247);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(16, 13);
            this.label7.TabIndex = 21;
            this.label7.Text = "to";
            // 
            // txbDescription
            // 
            this.txbDescription.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txbDescription.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.txbDescription.Cursor = System.Windows.Forms.Cursors.Default;
            this.txbDescription.Font = new System.Drawing.Font("Corbel", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbDescription.Location = new System.Drawing.Point(377, 413);
            this.txbDescription.Multiline = true;
            this.txbDescription.Name = "txbDescription";
            this.txbDescription.ReadOnly = true;
            this.txbDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txbDescription.Size = new System.Drawing.Size(348, 89);
            this.txbDescription.TabIndex = 28;
            // 
            // lblName
            // 
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblName.Location = new System.Drawing.Point(373, 375);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(352, 29);
            this.lblName.TabIndex = 29;
            this.lblName.Text = "Product Name";
            // 
            // listView
            // 
            this.listView.Alignment = System.Windows.Forms.ListViewAlignment.Default;
            this.listView.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.listView.AutoArrange = false;
            this.listView.BackColor = System.Drawing.SystemColors.Control;
            this.listView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listView.Location = new System.Drawing.Point(371, 504);
            this.listView.Name = "listView";
            this.listView.Scrollable = false;
            this.listView.Size = new System.Drawing.Size(354, 63);
            this.listView.TabIndex = 30;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.View = System.Windows.Forms.View.Tile;
            this.listView.SelectedIndexChanged += new System.EventHandler(this.listView_SelectedIndexChanged);
            // 
            // lblCount
            // 
            this.lblCount.Font = new System.Drawing.Font("Comic Sans MS", 17.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblCount.Location = new System.Drawing.Point(372, 9);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(353, 31);
            this.lblCount.TabIndex = 31;
            this.lblCount.Text = "N";
            this.lblCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnPlaceOrder
            // 
            this.btnPlaceOrder.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnPlaceOrder.BackgroundImage")));
            this.btnPlaceOrder.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPlaceOrder.Location = new System.Drawing.Point(731, 466);
            this.btnPlaceOrder.Name = "btnPlaceOrder";
            this.btnPlaceOrder.Size = new System.Drawing.Size(101, 36);
            this.btnPlaceOrder.TabIndex = 32;
            this.btnPlaceOrder.UseVisualStyleBackColor = true;
            this.btnPlaceOrder.Click += new System.EventHandler(this.btnPlaceOrder_Click);
            // 
            // btnQuery
            // 
            this.btnQuery.BackgroundImage = global::Toyshop.Properties.Resources._1461115779_done_01;
            this.btnQuery.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnQuery.ImageAlign = System.Drawing.ContentAlignment.TopRight;
            this.btnQuery.Location = new System.Drawing.Point(99, 160);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(40, 40);
            this.btnQuery.TabIndex = 26;
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // btnOrder
            // 
            this.btnOrder.BackgroundImage = global::Toyshop.Properties.Resources.empty_cart;
            this.btnOrder.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnOrder.Location = new System.Drawing.Point(752, 413);
            this.btnOrder.Name = "btnOrder";
            this.btnOrder.Size = new System.Drawing.Size(56, 53);
            this.btnOrder.TabIndex = 25;
            this.btnOrder.UseVisualStyleBackColor = true;
            this.btnOrder.Click += new System.EventHandler(this.btnOrder_Click);
            // 
            // pctbxInStock
            // 
            this.pctbxInStock.Location = new System.Drawing.Point(762, 369);
            this.pctbxInStock.Name = "pctbxInStock";
            this.pctbxInStock.Size = new System.Drawing.Size(35, 35);
            this.pctbxInStock.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pctbxInStock.TabIndex = 23;
            this.pctbxInStock.TabStop = false;
            // 
            // btnPriceFilter
            // 
            this.btnPriceFilter.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnPriceFilter.BackgroundImage")));
            this.btnPriceFilter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPriceFilter.Location = new System.Drawing.Point(184, 233);
            this.btnPriceFilter.Name = "btnPriceFilter";
            this.btnPriceFilter.Size = new System.Drawing.Size(40, 40);
            this.btnPriceFilter.TabIndex = 22;
            this.btnPriceFilter.UseVisualStyleBackColor = true;
            this.btnPriceFilter.Click += new System.EventHandler(this.btnPriceFilter_Click);
            // 
            // btnRemoveFilter
            // 
            this.btnRemoveFilter.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnRemoveFilter.BackgroundImage")));
            this.btnRemoveFilter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRemoveFilter.ImageAlign = System.Drawing.ContentAlignment.TopRight;
            this.btnRemoveFilter.Location = new System.Drawing.Point(202, 298);
            this.btnRemoveFilter.Name = "btnRemoveFilter";
            this.btnRemoveFilter.Size = new System.Drawing.Size(22, 22);
            this.btnRemoveFilter.TabIndex = 16;
            this.btnRemoveFilter.UseVisualStyleBackColor = true;
            this.btnRemoveFilter.Click += new System.EventHandler(this.btnRemoveFilter_Click);
            // 
            // btnNext
            // 
            this.btnNext.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNext.BackgroundImage")));
            this.btnNext.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnNext.Location = new System.Drawing.Point(733, 160);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(75, 75);
            this.btnNext.TabIndex = 3;
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnPrev
            // 
            this.btnPrev.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnPrev.BackgroundImage")));
            this.btnPrev.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPrev.Location = new System.Drawing.Point(288, 160);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(75, 75);
            this.btnPrev.TabIndex = 2;
            this.btnPrev.UseVisualStyleBackColor = true;
            this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click);
            // 
            // pctbxCatalogImage
            // 
            this.pctbxCatalogImage.BackColor = System.Drawing.SystemColors.Control;
            this.pctbxCatalogImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pctbxCatalogImage.Location = new System.Drawing.Point(371, 44);
            this.pctbxCatalogImage.Name = "pctbxCatalogImage";
            this.pctbxCatalogImage.Size = new System.Drawing.Size(354, 319);
            this.pctbxCatalogImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pctbxCatalogImage.TabIndex = 0;
            this.pctbxCatalogImage.TabStop = false;
            // 
            // ViewCatalogForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(833, 627);
            this.Controls.Add(this.btnPlaceOrder);
            this.Controls.Add(this.lblCount);
            this.Controls.Add(this.listView);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txbDescription);
            this.Controls.Add(this.btnQuery);
            this.Controls.Add(this.btnOrder);
            this.Controls.Add(this.pctbxInStock);
            this.Controls.Add(this.btnPriceFilter);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txbPriceTo);
            this.Controls.Add(this.txbPriceFrom);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txbFilter);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnRemoveFilter);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbManufacturer);
            this.Controls.Add(this.cmbAgeGroup);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblCurrentNumber);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.cmbCategory);
            this.Controls.Add(this.tree);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnPrev);
            this.Controls.Add(this.pctbxCatalogImage);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.Name = "ViewCatalogForm";
            this.Text = "Catalog";
            this.Load += new System.EventHandler(this.ViewCatalogForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pctbxInStock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctbxCatalogImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pctbxCatalogImage;
        private System.Windows.Forms.Button btnPrev;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.TreeView tree;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.Label lblCurrentNumber;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbAgeGroup;
        private System.Windows.Forms.ComboBox cmbManufacturer;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txbFilter;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnRemoveFilter;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txbPriceFrom;
        private System.Windows.Forms.TextBox txbPriceTo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnPriceFilter;
        private System.Windows.Forms.PictureBox pctbxInStock;
        private System.Windows.Forms.Button btnOrder;
        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.TextBox txbDescription;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.ListView listView;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.Button btnPlaceOrder;
    }
}