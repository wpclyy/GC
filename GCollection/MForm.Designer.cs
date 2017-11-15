namespace GCollection
{
    partial class MForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MForm));
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("未分类商品");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("全部数据", new System.Windows.Forms.TreeNode[] {
            treeNode1});
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton7 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton6 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton5 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label4 = new System.Windows.Forms.Label();
            this.btnrefreshcount = new System.Windows.Forms.Button();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnsuppsousou = new System.Windows.Forms.Button();
            this.txtsuppsousou = new System.Windows.Forms.TextBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.btnsave = new System.Windows.Forms.Button();
            this.btnview = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.btnproductprice = new System.Windows.Forms.Button();
            this.cmbbrand = new System.Windows.Forms.ComboBox();
            this.tvcat = new System.Windows.Forms.TreeView();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtsellprice = new System.Windows.Forms.TextBox();
            this.txtgoodscate = new System.Windows.Forms.TextBox();
            this.txtjifenjiner = new System.Windows.Forms.TextBox();
            this.txtprice = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtgoodstitle = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ckbshipping = new System.Windows.Forms.CheckBox();
            this.ckbonsale = new System.Windows.Forms.CheckBox();
            this.ckbhot = new System.Windows.Forms.CheckBox();
            this.ckbnew = new System.Windows.Forms.CheckBox();
            this.ckbbest = new System.Windows.Forms.CheckBox();
            this.ckball = new System.Windows.Forms.CheckBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.colcheck = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.xuhao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.goods_sn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.goods_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.brand_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.catname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.goods_number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.goods_weight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shop_price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.market_price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.is_best = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.is_new = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.is_hot = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.is_shipping = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.is_on_sale = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.cat_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.catid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.goods_thumb = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.goods_desc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.integral = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bgloadcate = new System.ComponentModel.BackgroundWorker();
            this.bgwcaiji = new System.ComponentModel.BackgroundWorker();
            this.bgwcate = new System.ComponentModel.BackgroundWorker();
            this.bgwloadsupplier = new System.ComponentModel.BackgroundWorker();
            this.bgwsign = new System.ComponentModel.BackgroundWorker();
            this.bgwsupplier = new System.ComponentModel.BackgroundWorker();
            this.bgwrefreshgoods = new System.ComponentModel.BackgroundWorker();
            this.dataPage1 = new GCollection.DataPage();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabPage4.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton2,
            this.toolStripButton3,
            this.toolStripSeparator1,
            this.toolStripButton7,
            this.toolStripButton6,
            this.toolStripButton5,
            this.toolStripSeparator2,
            this.toolStripButton4});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1170, 27);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(104, 24);
            this.toolStripButton1.Text = "采集商品分类";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(92, 24);
            this.toolStripButton2.Text = "采集供应商";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(80, 24);
            this.toolStripButton3.Text = "采集商品";
            this.toolStripButton3.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // toolStripButton7
            // 
            this.toolStripButton7.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton7.Image")));
            this.toolStripButton7.ImageTransparentColor = System.Drawing.Color.MediumBlue;
            this.toolStripButton7.Name = "toolStripButton7";
            this.toolStripButton7.Size = new System.Drawing.Size(80, 24);
            this.toolStripButton7.Text = "关联分类";
            this.toolStripButton7.Click += new System.EventHandler(this.toolStripButton7_Click);
            // 
            // toolStripButton6
            // 
            this.toolStripButton6.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton6.Image")));
            this.toolStripButton6.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton6.Name = "toolStripButton6";
            this.toolStripButton6.Size = new System.Drawing.Size(80, 24);
            this.toolStripButton6.Text = "批量修改";
            this.toolStripButton6.Click += new System.EventHandler(this.toolStripButton6_Click);
            // 
            // toolStripButton5
            // 
            this.toolStripButton5.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton5.Image")));
            this.toolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton5.Name = "toolStripButton5";
            this.toolStripButton5.Size = new System.Drawing.Size(80, 24);
            this.toolStripButton5.Text = "删除商品";
            this.toolStripButton5.Click += new System.EventHandler(this.toolStripButton5_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 27);
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton4.Image")));
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(80, 24);
            this.toolStripButton4.Text = "上传商品";
            this.toolStripButton4.Click += new System.EventHandler(this.toolStripButton4_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 675);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1170, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 27);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tabControl1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btnsave);
            this.splitContainer1.Panel2.Controls.Add(this.btnview);
            this.splitContainer1.Panel2.Controls.Add(this.panel2);
            this.splitContainer1.Panel2.Controls.Add(this.panel1);
            this.splitContainer1.Size = new System.Drawing.Size(1170, 648);
            this.splitContainer1.SplitterDistance = 237;
            this.splitContainer1.TabIndex = 2;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(237, 648);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.btnrefreshcount);
            this.tabPage1.Controls.Add(this.treeView1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(229, 622);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "商品分类";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(37, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 12);
            this.label4.TabIndex = 2;
            this.label4.Text = "(刷新分类商品数量)";
            // 
            // btnrefreshcount
            // 
            this.btnrefreshcount.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnrefreshcount.BackgroundImage")));
            this.btnrefreshcount.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnrefreshcount.Location = new System.Drawing.Point(3, 3);
            this.btnrefreshcount.Name = "btnrefreshcount";
            this.btnrefreshcount.Size = new System.Drawing.Size(28, 24);
            this.btnrefreshcount.TabIndex = 1;
            this.btnrefreshcount.UseVisualStyleBackColor = true;
            this.btnrefreshcount.Click += new System.EventHandler(this.btnrefreshcount_Click);
            // 
            // treeView1
            // 
            this.treeView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeView1.HideSelection = false;
            this.treeView1.Location = new System.Drawing.Point(3, 30);
            this.treeView1.Name = "treeView1";
            treeNode1.Name = "节点1";
            treeNode1.Tag = "0";
            treeNode1.Text = "未分类商品";
            treeNode2.Name = "节点0";
            treeNode2.Tag = "0";
            treeNode2.Text = "全部数据";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode2});
            this.treeView1.Size = new System.Drawing.Size(223, 589);
            this.treeView1.TabIndex = 0;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnsuppsousou);
            this.tabPage2.Controls.Add(this.txtsuppsousou);
            this.tabPage2.Controls.Add(this.listBox1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(229, 622);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "供应商";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnsuppsousou
            // 
            this.btnsuppsousou.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnsuppsousou.Location = new System.Drawing.Point(182, 7);
            this.btnsuppsousou.Name = "btnsuppsousou";
            this.btnsuppsousou.Size = new System.Drawing.Size(44, 23);
            this.btnsuppsousou.TabIndex = 2;
            this.btnsuppsousou.Text = "搜索";
            this.btnsuppsousou.UseVisualStyleBackColor = true;
            this.btnsuppsousou.Click += new System.EventHandler(this.btnsuppsousou_Click);
            // 
            // txtsuppsousou
            // 
            this.txtsuppsousou.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtsuppsousou.ForeColor = System.Drawing.Color.Gainsboro;
            this.txtsuppsousou.Location = new System.Drawing.Point(3, 8);
            this.txtsuppsousou.Name = "txtsuppsousou";
            this.txtsuppsousou.Size = new System.Drawing.Size(173, 21);
            this.txtsuppsousou.TabIndex = 1;
            this.txtsuppsousou.Text = "请输入供应商名称";
            this.txtsuppsousou.Enter += new System.EventHandler(this.txtsuppsousou_Enter);
            this.txtsuppsousou.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtsuppsousou_KeyDown);
            this.txtsuppsousou.Leave += new System.EventHandler(this.txtsuppsousou_Leave);
            // 
            // listBox1
            // 
            this.listBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBox1.DisplayMember = "company";
            this.listBox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.listBox1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 20;
            this.listBox1.Location = new System.Drawing.Point(3, 35);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(223, 544);
            this.listBox1.TabIndex = 0;
            this.listBox1.ValueMember = "memberId";
            this.listBox1.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.listBox1_DrawItem);
            this.listBox1.SelectedValueChanged += new System.EventHandler(this.listBox1_SelectedValueChanged);
            this.listBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.listBox1_KeyPress);
            this.listBox1.Leave += new System.EventHandler(this.listBox1_Leave);
            // 
            // btnsave
            // 
            this.btnsave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnsave.Location = new System.Drawing.Point(805, 619);
            this.btnsave.Name = "btnsave";
            this.btnsave.Size = new System.Drawing.Size(50, 23);
            this.btnsave.TabIndex = 3;
            this.btnsave.Text = "保存";
            this.btnsave.UseVisualStyleBackColor = true;
            this.btnsave.Click += new System.EventHandler(this.btnsave_Click);
            // 
            // btnview
            // 
            this.btnview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnview.Location = new System.Drawing.Point(721, 619);
            this.btnview.Name = "btnview";
            this.btnview.Size = new System.Drawing.Size(50, 23);
            this.btnview.TabIndex = 2;
            this.btnview.Text = "预览";
            this.btnview.UseVisualStyleBackColor = true;
            this.btnview.Click += new System.EventHandler(this.btnview_Click);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.tabControl2);
            this.panel2.Location = new System.Drawing.Point(4, 289);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(922, 326);
            this.panel2.TabIndex = 1;
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabPage3);
            this.tabControl2.Controls.Add(this.tabPage4);
            this.tabControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl2.Location = new System.Drawing.Point(0, 0);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(920, 324);
            this.tabControl2.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.btnproductprice);
            this.tabPage3.Controls.Add(this.cmbbrand);
            this.tabPage3.Controls.Add(this.tvcat);
            this.tabPage3.Controls.Add(this.pictureBox1);
            this.tabPage3.Controls.Add(this.txtsellprice);
            this.tabPage3.Controls.Add(this.txtgoodscate);
            this.tabPage3.Controls.Add(this.txtjifenjiner);
            this.tabPage3.Controls.Add(this.txtprice);
            this.tabPage3.Controls.Add(this.label8);
            this.tabPage3.Controls.Add(this.label7);
            this.tabPage3.Controls.Add(this.label6);
            this.tabPage3.Controls.Add(this.label3);
            this.tabPage3.Controls.Add(this.label2);
            this.tabPage3.Controls.Add(this.txtgoodstitle);
            this.tabPage3.Controls.Add(this.label1);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(912, 298);
            this.tabPage3.TabIndex = 0;
            this.tabPage3.Text = "通用信息";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // btnproductprice
            // 
            this.btnproductprice.Location = new System.Drawing.Point(89, 241);
            this.btnproductprice.Name = "btnproductprice";
            this.btnproductprice.Size = new System.Drawing.Size(109, 23);
            this.btnproductprice.TabIndex = 22;
            this.btnproductprice.Text = "设置货品价格";
            this.btnproductprice.UseVisualStyleBackColor = true;
            this.btnproductprice.Click += new System.EventHandler(this.btnproductprice_Click);
            // 
            // cmbbrand
            // 
            this.cmbbrand.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbbrand.FormattingEnabled = true;
            this.cmbbrand.Location = new System.Drawing.Point(89, 198);
            this.cmbbrand.Name = "cmbbrand";
            this.cmbbrand.Size = new System.Drawing.Size(145, 20);
            this.cmbbrand.TabIndex = 21;
            // 
            // tvcat
            // 
            this.tvcat.Location = new System.Drawing.Point(239, 157);
            this.tvcat.Name = "tvcat";
            this.tvcat.Size = new System.Drawing.Size(266, 137);
            this.tvcat.TabIndex = 20;
            this.tvcat.Visible = false;
            this.tvcat.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvcat_AfterSelect);
            this.tvcat.Leave += new System.EventHandler(this.tvcat_Leave);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(573, 6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(286, 286);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 18;
            this.pictureBox1.TabStop = false;
            // 
            // txtsellprice
            // 
            this.txtsellprice.Location = new System.Drawing.Point(89, 79);
            this.txtsellprice.Name = "txtsellprice";
            this.txtsellprice.Size = new System.Drawing.Size(145, 21);
            this.txtsellprice.TabIndex = 13;
            this.txtsellprice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtFloat_KeyPress);
            // 
            // txtgoodscate
            // 
            this.txtgoodscate.Location = new System.Drawing.Point(89, 157);
            this.txtgoodscate.Name = "txtgoodscate";
            this.txtgoodscate.ReadOnly = true;
            this.txtgoodscate.Size = new System.Drawing.Size(145, 21);
            this.txtgoodscate.TabIndex = 12;
            this.txtgoodscate.Enter += new System.EventHandler(this.txtgoodscate_Enter);
            this.txtgoodscate.Leave += new System.EventHandler(this.txtgoodscate_Leave);
            // 
            // txtjifenjiner
            // 
            this.txtjifenjiner.Location = new System.Drawing.Point(89, 118);
            this.txtjifenjiner.Name = "txtjifenjiner";
            this.txtjifenjiner.Size = new System.Drawing.Size(145, 21);
            this.txtjifenjiner.TabIndex = 11;
            this.txtjifenjiner.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtDigit_KeyPress);
            // 
            // txtprice
            // 
            this.txtprice.Location = new System.Drawing.Point(89, 42);
            this.txtprice.Name = "txtprice";
            this.txtprice.Size = new System.Drawing.Size(145, 21);
            this.txtprice.TabIndex = 10;
            this.txtprice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtFloat_KeyPress);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(30, 201);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 8;
            this.label8.Text = "商品品牌";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(30, 160);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 7;
            this.label7.Text = "商品分类";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 121);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 12);
            this.label6.TabIndex = 6;
            this.label6.Text = "积分购买金额";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "市场售价";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "本店售价";
            // 
            // txtgoodstitle
            // 
            this.txtgoodstitle.Location = new System.Drawing.Point(89, 6);
            this.txtgoodstitle.Name = "txtgoodstitle";
            this.txtgoodstitle.Size = new System.Drawing.Size(416, 21);
            this.txtgoodstitle.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "商品名称";
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.webBrowser1);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(912, 298);
            this.tabPage4.TabIndex = 1;
            this.tabPage4.Text = "商品描述";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // webBrowser1
            // 
            this.webBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser1.Location = new System.Drawing.Point(3, 3);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(906, 292);
            this.webBrowser1.TabIndex = 1;
            this.webBrowser1.Resize += new System.EventHandler(this.webBrowser1_Resize);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.ckbshipping);
            this.panel1.Controls.Add(this.ckbonsale);
            this.panel1.Controls.Add(this.ckbhot);
            this.panel1.Controls.Add(this.ckbnew);
            this.panel1.Controls.Add(this.ckbbest);
            this.panel1.Controls.Add(this.ckball);
            this.panel1.Controls.Add(this.dataPage1);
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(923, 285);
            this.panel1.TabIndex = 0;
            // 
            // ckbshipping
            // 
            this.ckbshipping.AutoSize = true;
            this.ckbshipping.BackColor = System.Drawing.Color.White;
            this.ckbshipping.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ckbshipping.Location = new System.Drawing.Point(1267, 4);
            this.ckbshipping.Name = "ckbshipping";
            this.ckbshipping.Size = new System.Drawing.Size(15, 14);
            this.ckbshipping.TabIndex = 7;
            this.ckbshipping.UseVisualStyleBackColor = false;
            this.ckbshipping.CheckedChanged += new System.EventHandler(this.ckbshipping_CheckedChanged);
            // 
            // ckbonsale
            // 
            this.ckbonsale.AutoSize = true;
            this.ckbonsale.BackColor = System.Drawing.Color.White;
            this.ckbonsale.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ckbonsale.Location = new System.Drawing.Point(1356, 4);
            this.ckbonsale.Name = "ckbonsale";
            this.ckbonsale.Size = new System.Drawing.Size(15, 14);
            this.ckbonsale.TabIndex = 6;
            this.ckbonsale.UseVisualStyleBackColor = false;
            this.ckbonsale.CheckedChanged += new System.EventHandler(this.ckbonsale_CheckedChanged);
            // 
            // ckbhot
            // 
            this.ckbhot.AutoSize = true;
            this.ckbhot.BackColor = System.Drawing.Color.White;
            this.ckbhot.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ckbhot.Location = new System.Drawing.Point(1156, 4);
            this.ckbhot.Name = "ckbhot";
            this.ckbhot.Size = new System.Drawing.Size(15, 14);
            this.ckbhot.TabIndex = 5;
            this.ckbhot.UseVisualStyleBackColor = false;
            this.ckbhot.CheckedChanged += new System.EventHandler(this.ckbhot_CheckedChanged);
            // 
            // ckbnew
            // 
            this.ckbnew.AutoSize = true;
            this.ckbnew.BackColor = System.Drawing.Color.White;
            this.ckbnew.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ckbnew.Location = new System.Drawing.Point(1055, 4);
            this.ckbnew.Name = "ckbnew";
            this.ckbnew.Size = new System.Drawing.Size(15, 14);
            this.ckbnew.TabIndex = 4;
            this.ckbnew.UseVisualStyleBackColor = false;
            this.ckbnew.CheckedChanged += new System.EventHandler(this.ckbnew_CheckedChanged);
            // 
            // ckbbest
            // 
            this.ckbbest.AutoSize = true;
            this.ckbbest.BackColor = System.Drawing.SystemColors.Window;
            this.ckbbest.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ckbbest.Location = new System.Drawing.Point(955, 4);
            this.ckbbest.Name = "ckbbest";
            this.ckbbest.Size = new System.Drawing.Size(15, 14);
            this.ckbbest.TabIndex = 3;
            this.ckbbest.UseVisualStyleBackColor = false;
            this.ckbbest.CheckedChanged += new System.EventHandler(this.ckbbest_CheckedChanged);
            // 
            // ckball
            // 
            this.ckball.AutoSize = true;
            this.ckball.BackColor = System.Drawing.Color.White;
            this.ckball.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ckball.Location = new System.Drawing.Point(12, 4);
            this.ckball.Name = "ckball";
            this.ckball.Size = new System.Drawing.Size(48, 16);
            this.ckball.TabIndex = 2;
            this.ckball.Text = "全选";
            this.ckball.UseVisualStyleBackColor = false;
            this.ckball.CheckedChanged += new System.EventHandler(this.ckball_CheckedChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colcheck,
            this.xuhao,
            this.status,
            this.goods_sn,
            this.goods_name,
            this.brand_id,
            this.catname,
            this.goods_number,
            this.goods_weight,
            this.shop_price,
            this.market_price,
            this.is_best,
            this.is_new,
            this.is_hot,
            this.is_shipping,
            this.is_on_sale,
            this.cat_id,
            this.catid,
            this.goods_thumb,
            this.goods_desc,
            this.integral});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.Location = new System.Drawing.Point(2, 1);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(921, 243);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseClick);
            this.dataGridView1.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseDoubleClick);
            this.dataGridView1.CurrentCellDirtyStateChanged += new System.EventHandler(this.dataGridView1_CurrentCellDirtyStateChanged);
            this.dataGridView1.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dataGridView1_RowPostPaint);
            // 
            // colcheck
            // 
            this.colcheck.FalseValue = "0";
            this.colcheck.HeaderText = "";
            this.colcheck.Name = "colcheck";
            this.colcheck.TrueValue = "1";
            this.colcheck.Width = 60;
            // 
            // xuhao
            // 
            this.xuhao.HeaderText = "序号";
            this.xuhao.Name = "xuhao";
            this.xuhao.ReadOnly = true;
            this.xuhao.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.xuhao.Width = 60;
            // 
            // status
            // 
            this.status.DataPropertyName = "status";
            this.status.HeaderText = "商品状态";
            this.status.Name = "status";
            this.status.ReadOnly = true;
            this.status.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // goods_sn
            // 
            this.goods_sn.DataPropertyName = "goods_sn";
            this.goods_sn.HeaderText = "货号";
            this.goods_sn.Name = "goods_sn";
            this.goods_sn.ReadOnly = true;
            this.goods_sn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // goods_name
            // 
            this.goods_name.DataPropertyName = "goods_name";
            this.goods_name.HeaderText = "商品名称";
            this.goods_name.Name = "goods_name";
            this.goods_name.ReadOnly = true;
            this.goods_name.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // brand_id
            // 
            this.brand_id.DataPropertyName = "brand_id";
            this.brand_id.HeaderText = "品牌";
            this.brand_id.Name = "brand_id";
            this.brand_id.ReadOnly = true;
            this.brand_id.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // catname
            // 
            this.catname.DataPropertyName = "catname";
            this.catname.HeaderText = "1688分类";
            this.catname.Name = "catname";
            this.catname.ReadOnly = true;
            this.catname.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.catname.Width = 200;
            // 
            // goods_number
            // 
            this.goods_number.DataPropertyName = "goods_number";
            this.goods_number.HeaderText = "库存";
            this.goods_number.Name = "goods_number";
            this.goods_number.ReadOnly = true;
            this.goods_number.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // goods_weight
            // 
            this.goods_weight.DataPropertyName = "goods_weight";
            this.goods_weight.HeaderText = "重量(千克)";
            this.goods_weight.Name = "goods_weight";
            this.goods_weight.ReadOnly = true;
            this.goods_weight.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // shop_price
            // 
            this.shop_price.DataPropertyName = "shop_price";
            this.shop_price.HeaderText = "本店价";
            this.shop_price.Name = "shop_price";
            this.shop_price.ReadOnly = true;
            this.shop_price.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // market_price
            // 
            this.market_price.DataPropertyName = "market_price";
            this.market_price.HeaderText = "市场价";
            this.market_price.Name = "market_price";
            this.market_price.ReadOnly = true;
            this.market_price.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // is_best
            // 
            this.is_best.DataPropertyName = "is_best";
            this.is_best.FalseValue = "0";
            this.is_best.HeaderText = "精品";
            this.is_best.Name = "is_best";
            this.is_best.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.is_best.TrueValue = "1";
            // 
            // is_new
            // 
            this.is_new.DataPropertyName = "is_new";
            this.is_new.FalseValue = "0";
            this.is_new.HeaderText = "新品";
            this.is_new.Name = "is_new";
            this.is_new.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.is_new.TrueValue = "1";
            // 
            // is_hot
            // 
            this.is_hot.DataPropertyName = "is_hot";
            this.is_hot.FalseValue = "0";
            this.is_hot.HeaderText = "热销";
            this.is_hot.Name = "is_hot";
            this.is_hot.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.is_hot.TrueValue = "1";
            // 
            // is_shipping
            // 
            this.is_shipping.DataPropertyName = "is_shipping";
            this.is_shipping.FalseValue = "0";
            this.is_shipping.HeaderText = "免运费";
            this.is_shipping.Name = "is_shipping";
            this.is_shipping.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.is_shipping.TrueValue = "1";
            // 
            // is_on_sale
            // 
            this.is_on_sale.DataPropertyName = "is_on_sale";
            this.is_on_sale.FalseValue = "0";
            this.is_on_sale.HeaderText = "上架";
            this.is_on_sale.Name = "is_on_sale";
            this.is_on_sale.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.is_on_sale.TrueValue = "1";
            // 
            // cat_id
            // 
            this.cat_id.DataPropertyName = "cat_id";
            this.cat_id.HeaderText = "商品分类ID";
            this.cat_id.Name = "cat_id";
            this.cat_id.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.cat_id.Visible = false;
            // 
            // catid
            // 
            this.catid.DataPropertyName = "catid";
            this.catid.HeaderText = "1688分类ID";
            this.catid.Name = "catid";
            this.catid.Visible = false;
            // 
            // goods_thumb
            // 
            this.goods_thumb.DataPropertyName = "goods_thumb";
            this.goods_thumb.HeaderText = "商品略缩图";
            this.goods_thumb.Name = "goods_thumb";
            this.goods_thumb.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.goods_thumb.Visible = false;
            // 
            // goods_desc
            // 
            this.goods_desc.DataPropertyName = "goods_desc";
            this.goods_desc.HeaderText = "商品详情";
            this.goods_desc.Name = "goods_desc";
            this.goods_desc.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.goods_desc.Visible = false;
            // 
            // integral
            // 
            this.integral.DataPropertyName = "integral";
            this.integral.HeaderText = "积分金额";
            this.integral.Name = "integral";
            this.integral.Visible = false;
            // 
            // bgloadcate
            // 
            this.bgloadcate.WorkerReportsProgress = true;
            this.bgloadcate.WorkerSupportsCancellation = true;
            this.bgloadcate.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgloadcate_DoWork);
            this.bgloadcate.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgloadcate_RunWorkerCompleted);
            // 
            // bgwcaiji
            // 
            this.bgwcaiji.WorkerReportsProgress = true;
            this.bgwcaiji.WorkerSupportsCancellation = true;
            this.bgwcaiji.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwcaiji_DoWork);
            this.bgwcaiji.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwcaiji_RunWorkerCompleted);
            // 
            // bgwcate
            // 
            this.bgwcate.WorkerReportsProgress = true;
            this.bgwcate.WorkerSupportsCancellation = true;
            this.bgwcate.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwcate_DoWork);
            this.bgwcate.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwcate_RunWorkerCompleted);
            // 
            // bgwloadsupplier
            // 
            this.bgwloadsupplier.WorkerReportsProgress = true;
            this.bgwloadsupplier.WorkerSupportsCancellation = true;
            this.bgwloadsupplier.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwloadsupplier_DoWork);
            this.bgwloadsupplier.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwloadsupplier_RunWorkerCompleted);
            // 
            // bgwsign
            // 
            this.bgwsign.WorkerReportsProgress = true;
            this.bgwsign.WorkerSupportsCancellation = true;
            this.bgwsign.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwsign_DoWork);
            this.bgwsign.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwsign_RunWorkerCompleted);
            // 
            // bgwsupplier
            // 
            this.bgwsupplier.WorkerReportsProgress = true;
            this.bgwsupplier.WorkerSupportsCancellation = true;
            this.bgwsupplier.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwsupplier_DoWork);
            this.bgwsupplier.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwsupplier_RunWorkerCompleted);
            // 
            // bgwrefreshgoods
            // 
            this.bgwrefreshgoods.WorkerReportsProgress = true;
            this.bgwrefreshgoods.WorkerSupportsCancellation = true;
            this.bgwrefreshgoods.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwrefreshgoods_DoWork);
            this.bgwrefreshgoods.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwrefreshgoods_RunWorkerCompleted);
            // 
            // dataPage1
            // 
            this.dataPage1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataPage1.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.dataPage1.CurrentPage = 1;
            this.dataPage1.Location = new System.Drawing.Point(1, 248);
            this.dataPage1.Name = "dataPage1";
            this.dataPage1.PageCount = 0;
            this.dataPage1.PageSize = 10;
            this.dataPage1.Size = new System.Drawing.Size(919, 31);
            this.dataPage1.TabIndex = 1;
            this.dataPage1.TotalCount = 0;
            this.dataPage1.EventPaging += new GCollection.DataPage.EventPagingHandler(this.dataPage1_EventPaging);
            // 
            // MForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1170, 697);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "小助手V0.1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MForm_FormClosing);
            this.Load += new System.EventHandler(this.MForm_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.tabControl2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabPage4.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private DataPage dataPage1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.ComponentModel.BackgroundWorker bgloadcate;
        private System.ComponentModel.BackgroundWorker bgwcaiji;
        private System.ComponentModel.BackgroundWorker bgwcate;
        private System.ComponentModel.BackgroundWorker bgwloadsupplier;
        private System.ComponentModel.BackgroundWorker bgwsign;
        private System.ComponentModel.BackgroundWorker bgwsupplier;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TextBox txtsellprice;
        private System.Windows.Forms.TextBox txtgoodscate;
        private System.Windows.Forms.TextBox txtjifenjiner;
        private System.Windows.Forms.TextBox txtprice;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtgoodstitle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnsave;
        private System.Windows.Forms.Button btnview;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.ToolStripButton toolStripButton5;
        private System.Windows.Forms.ToolStripButton toolStripButton6;
        private System.Windows.Forms.CheckBox ckball;
        private System.Windows.Forms.CheckBox ckbshipping;
        private System.Windows.Forms.CheckBox ckbonsale;
        private System.Windows.Forms.CheckBox ckbhot;
        private System.Windows.Forms.CheckBox ckbnew;
        private System.Windows.Forms.CheckBox ckbbest;
        private System.Windows.Forms.TreeView tvcat;
        private System.Windows.Forms.ComboBox cmbbrand;
        private System.Windows.Forms.ToolStripButton toolStripButton7;
        private System.ComponentModel.BackgroundWorker bgwrefreshgoods;
        private System.Windows.Forms.Button btnsuppsousou;
        private System.Windows.Forms.TextBox txtsuppsousou;
        private System.Windows.Forms.Button btnrefreshcount;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.Button btnproductprice;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colcheck;
        private System.Windows.Forms.DataGridViewTextBoxColumn xuhao;
        private System.Windows.Forms.DataGridViewTextBoxColumn status;
        private System.Windows.Forms.DataGridViewTextBoxColumn goods_sn;
        private System.Windows.Forms.DataGridViewTextBoxColumn goods_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn brand_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn catname;
        private System.Windows.Forms.DataGridViewTextBoxColumn goods_number;
        private System.Windows.Forms.DataGridViewTextBoxColumn goods_weight;
        private System.Windows.Forms.DataGridViewTextBoxColumn shop_price;
        private System.Windows.Forms.DataGridViewTextBoxColumn market_price;
        private System.Windows.Forms.DataGridViewCheckBoxColumn is_best;
        private System.Windows.Forms.DataGridViewCheckBoxColumn is_new;
        private System.Windows.Forms.DataGridViewCheckBoxColumn is_hot;
        private System.Windows.Forms.DataGridViewCheckBoxColumn is_shipping;
        private System.Windows.Forms.DataGridViewCheckBoxColumn is_on_sale;
        private System.Windows.Forms.DataGridViewTextBoxColumn cat_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn catid;
        private System.Windows.Forms.DataGridViewTextBoxColumn goods_thumb;
        private System.Windows.Forms.DataGridViewTextBoxColumn goods_desc;
        private System.Windows.Forms.DataGridViewTextBoxColumn integral;
    }
}