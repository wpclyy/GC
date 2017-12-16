namespace GCollection
{
    partial class ShowProgress
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
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lbltip1 = new System.Windows.Forms.Label();
            this.lbltip2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbltitle = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // progressBar1
            // 
            this.progressBar1.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.progressBar1.Location = new System.Drawing.Point(3, 29);
            this.progressBar1.MarqueeAnimationSpeed = 25;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(404, 21);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Bisque;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(84, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "()";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(347, 108);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(57, 26);
            this.button1.TabIndex = 2;
            this.button1.Text = "取消";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Bisque;
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(84, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "()";
            // 
            // lbltip1
            // 
            this.lbltip1.AutoSize = true;
            this.lbltip1.BackColor = System.Drawing.Color.Bisque;
            this.lbltip1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lbltip1.Location = new System.Drawing.Point(3, 57);
            this.lbltip1.Name = "lbltip1";
            this.lbltip1.Size = new System.Drawing.Size(53, 12);
            this.lbltip1.TabIndex = 4;
            this.lbltip1.Text = "当前进度";
            // 
            // lbltip2
            // 
            this.lbltip2.AutoSize = true;
            this.lbltip2.BackColor = System.Drawing.Color.Bisque;
            this.lbltip2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lbltip2.Location = new System.Drawing.Point(3, 82);
            this.lbltip2.Name = "lbltip2";
            this.lbltip2.Size = new System.Drawing.Size(53, 12);
            this.lbltip2.TabIndex = 5;
            this.lbltip2.Text = "当前进度";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Bisque;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.lbltitle);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.lbltip2);
            this.panel1.Controls.Add(this.progressBar1);
            this.panel1.Controls.Add(this.lbltip1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(1, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(413, 140);
            this.panel1.TabIndex = 6;
            // 
            // lbltitle
            // 
            this.lbltitle.AutoSize = true;
            this.lbltitle.Location = new System.Drawing.Point(3, 8);
            this.lbltitle.Name = "lbltitle";
            this.lbltitle.Size = new System.Drawing.Size(35, 12);
            this.lbltitle.TabIndex = 6;
            this.lbltitle.Text = "title";
            // 
            // label3
            // 
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label3.Location = new System.Drawing.Point(-1, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(413, 1);
            this.label3.TabIndex = 7;
            // 
            // ShowProgress
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(415, 142);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ShowProgress";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.ShowProgress_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbltip1;
        private System.Windows.Forms.Label lbltip2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbltitle;
        private System.Windows.Forms.Label label3;
    }
}