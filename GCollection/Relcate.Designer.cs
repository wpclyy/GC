namespace GCollection
{
    partial class Relcate
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
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.treeView2 = new System.Windows.Forms.TreeView();
            this.button1 = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblp2 = new System.Windows.Forms.Label();
            this.lblp1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnclose = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.HideSelection = false;
            this.treeView1.Location = new System.Drawing.Point(12, 96);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(231, 566);
            this.treeView1.TabIndex = 0;
            this.treeView1.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "1688分类";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(524, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "购低网分类";
            // 
            // treeView2
            // 
            this.treeView2.Location = new System.Drawing.Point(526, 96);
            this.treeView2.Name = "treeView2";
            this.treeView2.Size = new System.Drawing.Size(242, 566);
            this.treeView2.TabIndex = 3;
            this.treeView2.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView2_NodeMouseClick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(100, 132);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 32);
            this.button1.TabIndex = 4;
            this.button1.Text = "关联分类";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(5, 55);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(100, 34);
            this.textBox1.TabIndex = 5;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(165, 55);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(100, 34);
            this.textBox2.TabIndex = 6;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lblp2);
            this.panel1.Controls.Add(this.textBox2);
            this.panel1.Controls.Add(this.lblp1);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Location = new System.Drawing.Point(248, 100);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(271, 175);
            this.panel1.TabIndex = 7;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // lblp2
            // 
            this.lblp2.AutoSize = true;
            this.lblp2.Location = new System.Drawing.Point(163, 7);
            this.lblp2.MaximumSize = new System.Drawing.Size(100, 50);
            this.lblp2.Name = "lblp2";
            this.lblp2.Size = new System.Drawing.Size(89, 12);
            this.lblp2.TabIndex = 11;
            this.lblp2.Text = "购低网父级分类";
            // 
            // lblp1
            // 
            this.lblp1.AutoSize = true;
            this.lblp1.Location = new System.Drawing.Point(3, 7);
            this.lblp1.MaximumSize = new System.Drawing.Size(100, 50);
            this.lblp1.Name = "lblp1";
            this.lblp1.Size = new System.Drawing.Size(77, 12);
            this.lblp1.TabIndex = 10;
            this.lblp1.Text = "1688父级分类";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(51, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(401, 12);
            this.label3.TabIndex = 8;
            this.label3.Text = "1.分类名称显示红色表示该分类已经绑定，点击可以看到绑定的具体分类。";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 9;
            this.label4.Text = "提示：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(51, 36);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(305, 12);
            this.label5.TabIndex = 10;
            this.label5.Text = "2.分类关联成功会对已经绑定了该分类的商品进行更新。";
            // 
            // label6
            // 
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label6.Location = new System.Drawing.Point(-2, 665);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(803, 2);
            this.label6.TabIndex = 11;
            this.label6.Text = "label6";
            // 
            // btnclose
            // 
            this.btnclose.Location = new System.Drawing.Point(693, 670);
            this.btnclose.Name = "btnclose";
            this.btnclose.Size = new System.Drawing.Size(74, 27);
            this.btnclose.TabIndex = 12;
            this.btnclose.Text = "关闭";
            this.btnclose.UseVisualStyleBackColor = true;
            this.btnclose.Click += new System.EventHandler(this.btnclose_Click);
            // 
            // Relcate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(787, 700);
            this.Controls.Add(this.btnclose);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.treeView2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.treeView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Relcate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "关联分类";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Relcate_FormClosing);
            this.Load += new System.EventHandler(this.Relcate_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TreeView treeView2;
        private System.Windows.Forms.Button button1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblp2;
        private System.Windows.Forms.Label lblp1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnclose;
    }
}