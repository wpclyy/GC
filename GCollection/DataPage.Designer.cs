namespace GCollection
{
    partial class DataPage
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.lblpagecount = new System.Windows.Forms.Label();
            this.lbltotalcount = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbpagesize = new System.Windows.Forms.ComboBox();
            this.btnfirstpage = new System.Windows.Forms.Button();
            this.btnprevpage = new System.Windows.Forms.Button();
            this.btnnextpage = new System.Windows.Forms.Button();
            this.btnlastpage = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtcurrentpage = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblpagecount
            // 
            this.lblpagecount.AutoSize = true;
            this.lblpagecount.Location = new System.Drawing.Point(474, 11);
            this.lblpagecount.Name = "lblpagecount";
            this.lblpagecount.Size = new System.Drawing.Size(35, 12);
            this.lblpagecount.TabIndex = 0;
            this.lblpagecount.Text = "共2页";
            // 
            // lbltotalcount
            // 
            this.lbltotalcount.AutoSize = true;
            this.lbltotalcount.Location = new System.Drawing.Point(533, 11);
            this.lbltotalcount.Name = "lbltotalcount";
            this.lbltotalcount.Size = new System.Drawing.Size(47, 12);
            this.lbltotalcount.TabIndex = 1;
            this.lbltotalcount.Text = "总计5条";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "每页条数：";
            // 
            // cmbpagesize
            // 
            this.cmbpagesize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbpagesize.FormattingEnabled = true;
            this.cmbpagesize.Items.AddRange(new object[] {
            "10",
            "20",
            "30",
            "50",
            "100"});
            this.cmbpagesize.Location = new System.Drawing.Point(91, 7);
            this.cmbpagesize.Name = "cmbpagesize";
            this.cmbpagesize.Size = new System.Drawing.Size(44, 20);
            this.cmbpagesize.TabIndex = 3;
            this.cmbpagesize.SelectedIndexChanged += new System.EventHandler(this.cmbpagesize_SelectedIndexChanged);
            // 
            // btnfirstpage
            // 
            this.btnfirstpage.Location = new System.Drawing.Point(153, 6);
            this.btnfirstpage.Name = "btnfirstpage";
            this.btnfirstpage.Size = new System.Drawing.Size(37, 23);
            this.btnfirstpage.TabIndex = 4;
            this.btnfirstpage.Text = "首页";
            this.btnfirstpage.UseVisualStyleBackColor = true;
            this.btnfirstpage.Click += new System.EventHandler(this.btnfirstpage_Click);
            // 
            // btnprevpage
            // 
            this.btnprevpage.Location = new System.Drawing.Point(196, 6);
            this.btnprevpage.Name = "btnprevpage";
            this.btnprevpage.Size = new System.Drawing.Size(51, 23);
            this.btnprevpage.TabIndex = 5;
            this.btnprevpage.Text = "上一页";
            this.btnprevpage.UseVisualStyleBackColor = true;
            this.btnprevpage.Click += new System.EventHandler(this.btnprevpage_Click);
            // 
            // btnnextpage
            // 
            this.btnnextpage.Location = new System.Drawing.Point(342, 6);
            this.btnnextpage.Name = "btnnextpage";
            this.btnnextpage.Size = new System.Drawing.Size(54, 23);
            this.btnnextpage.TabIndex = 6;
            this.btnnextpage.Text = "下一页";
            this.btnnextpage.UseVisualStyleBackColor = true;
            this.btnnextpage.Click += new System.EventHandler(this.btnnextpage_Click);
            // 
            // btnlastpage
            // 
            this.btnlastpage.Location = new System.Drawing.Point(402, 6);
            this.btnlastpage.Name = "btnlastpage";
            this.btnlastpage.Size = new System.Drawing.Size(37, 23);
            this.btnlastpage.TabIndex = 7;
            this.btnlastpage.Text = "末页";
            this.btnlastpage.UseVisualStyleBackColor = true;
            this.btnlastpage.Click += new System.EventHandler(this.btnlastpage_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(256, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 12);
            this.label4.TabIndex = 8;
            this.label4.Text = "第";
            // 
            // txtcurrentpage
            // 
            this.txtcurrentpage.Location = new System.Drawing.Point(276, 6);
            this.txtcurrentpage.Name = "txtcurrentpage";
            this.txtcurrentpage.ReadOnly = true;
            this.txtcurrentpage.Size = new System.Drawing.Size(38, 21);
            this.txtcurrentpage.TabIndex = 9;
            this.txtcurrentpage.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtcurrentpage_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(317, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 12);
            this.label5.TabIndex = 10;
            this.label5.Text = "页";
            // 
            // DataPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtcurrentpage);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnlastpage);
            this.Controls.Add(this.btnnextpage);
            this.Controls.Add(this.btnprevpage);
            this.Controls.Add(this.btnfirstpage);
            this.Controls.Add(this.cmbpagesize);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbltotalcount);
            this.Controls.Add(this.lblpagecount);
            this.Name = "DataPage";
            this.Size = new System.Drawing.Size(607, 32);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblpagecount;
        private System.Windows.Forms.Label lbltotalcount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbpagesize;
        private System.Windows.Forms.Button btnfirstpage;
        private System.Windows.Forms.Button btnprevpage;
        private System.Windows.Forms.Button btnnextpage;
        private System.Windows.Forms.Button btnlastpage;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtcurrentpage;
        private System.Windows.Forms.Label label5;
    }
}
