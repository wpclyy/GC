namespace GCollection
{
    partial class FormQuery
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
            this.label1 = new System.Windows.Forms.Label();
            this.lblcount = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.goods_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cat_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.goods_sn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.goods_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.brand_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.goods_number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.goods_weight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shop_price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.market_price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.is_best = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.is_new = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.is_hot = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.is_shipping = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.is_on_sale = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cat_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.brand_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "提示信息：";
            // 
            // lblcount
            // 
            this.lblcount.AutoSize = true;
            this.lblcount.Location = new System.Drawing.Point(74, 13);
            this.lblcount.Name = "lblcount";
            this.lblcount.Size = new System.Drawing.Size(83, 12);
            this.lblcount.TabIndex = 4;
            this.lblcount.Text = "共有(0)条商品";
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
            this.goods_id,
            this.cat_name,
            this.goods_sn,
            this.goods_name,
            this.brand_name,
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
            this.brand_id});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.Location = new System.Drawing.Point(0, 45);
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
            this.dataGridView1.Size = new System.Drawing.Size(822, 436);
            this.dataGridView1.TabIndex = 5;
            // 
            // goods_id
            // 
            this.goods_id.DataPropertyName = "goods_id";
            this.goods_id.HeaderText = "编号";
            this.goods_id.Name = "goods_id";
            this.goods_id.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.goods_id.Width = 60;
            // 
            // cat_name
            // 
            this.cat_name.DataPropertyName = "cat_name";
            this.cat_name.HeaderText = "商品分类";
            this.cat_name.Name = "cat_name";
            // 
            // goods_sn
            // 
            this.goods_sn.DataPropertyName = "goods_sn";
            this.goods_sn.HeaderText = "货号";
            this.goods_sn.Name = "goods_sn";
            this.goods_sn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // goods_name
            // 
            this.goods_name.DataPropertyName = "goods_name";
            this.goods_name.HeaderText = "商品名称";
            this.goods_name.Name = "goods_name";
            this.goods_name.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.goods_name.Width = 200;
            // 
            // brand_name
            // 
            this.brand_name.DataPropertyName = "brand_name";
            this.brand_name.HeaderText = "品牌";
            this.brand_name.Name = "brand_name";
            // 
            // goods_number
            // 
            this.goods_number.DataPropertyName = "goods_number";
            this.goods_number.HeaderText = "库存";
            this.goods_number.Name = "goods_number";
            this.goods_number.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // goods_weight
            // 
            this.goods_weight.DataPropertyName = "goods_weight";
            this.goods_weight.HeaderText = "重量(千克)";
            this.goods_weight.Name = "goods_weight";
            this.goods_weight.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // shop_price
            // 
            this.shop_price.DataPropertyName = "shop_price";
            this.shop_price.HeaderText = "本店价";
            this.shop_price.Name = "shop_price";
            this.shop_price.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // market_price
            // 
            this.market_price.DataPropertyName = "market_price";
            this.market_price.HeaderText = "市场价";
            this.market_price.Name = "market_price";
            this.market_price.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // is_best
            // 
            this.is_best.DataPropertyName = "is_best";
            this.is_best.HeaderText = "精品";
            this.is_best.Name = "is_best";
            this.is_best.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.is_best.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.is_best.Visible = false;
            // 
            // is_new
            // 
            this.is_new.DataPropertyName = "is_new";
            this.is_new.HeaderText = "新品";
            this.is_new.Name = "is_new";
            this.is_new.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.is_new.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.is_new.Visible = false;
            // 
            // is_hot
            // 
            this.is_hot.DataPropertyName = "is_hot";
            this.is_hot.HeaderText = "热销";
            this.is_hot.Name = "is_hot";
            this.is_hot.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.is_hot.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.is_hot.Visible = false;
            // 
            // is_shipping
            // 
            this.is_shipping.DataPropertyName = "is_shipping";
            this.is_shipping.HeaderText = "免运费";
            this.is_shipping.Name = "is_shipping";
            this.is_shipping.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.is_shipping.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.is_shipping.Visible = false;
            // 
            // is_on_sale
            // 
            this.is_on_sale.DataPropertyName = "is_on_sale";
            this.is_on_sale.HeaderText = "上架";
            this.is_on_sale.Name = "is_on_sale";
            this.is_on_sale.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.is_on_sale.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.is_on_sale.Visible = false;
            // 
            // cat_id
            // 
            this.cat_id.DataPropertyName = "cat_id";
            this.cat_id.HeaderText = "商品分类ID";
            this.cat_id.Name = "cat_id";
            this.cat_id.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.cat_id.Visible = false;
            // 
            // brand_id
            // 
            this.brand_id.DataPropertyName = "brand_id";
            this.brand_id.HeaderText = "品牌ID";
            this.brand_id.Name = "brand_id";
            this.brand_id.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.brand_id.Visible = false;
            // 
            // FormQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(819, 483);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.lblcount);
            this.Controls.Add(this.label1);
            this.Name = "FormQuery";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "商品查询结果";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblcount;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn goods_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn cat_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn goods_sn;
        private System.Windows.Forms.DataGridViewTextBoxColumn goods_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn brand_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn goods_number;
        private System.Windows.Forms.DataGridViewTextBoxColumn goods_weight;
        private System.Windows.Forms.DataGridViewTextBoxColumn shop_price;
        private System.Windows.Forms.DataGridViewTextBoxColumn market_price;
        private System.Windows.Forms.DataGridViewTextBoxColumn is_best;
        private System.Windows.Forms.DataGridViewTextBoxColumn is_new;
        private System.Windows.Forms.DataGridViewTextBoxColumn is_hot;
        private System.Windows.Forms.DataGridViewTextBoxColumn is_shipping;
        private System.Windows.Forms.DataGridViewTextBoxColumn is_on_sale;
        private System.Windows.Forms.DataGridViewTextBoxColumn cat_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn brand_id;
    }
}