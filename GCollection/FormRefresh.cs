using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GCollection
{
    public partial class FormRefresh : Form
    {
        public FormRefresh()
        {
            InitializeComponent();
            this.MaximumSize = new Size(Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            refreshing();
        }

        private void refreshing()
        {
            if (Program.mfloadflag == "OK")
            {
                timer1.Stop();
                this.Close();
            }
        }

        private void FormRefresh_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        public void setprogress(int current,int allcount)
        {
            string t = "（"+ current + "/"+allcount+"）正在上传商品...";
            label1.Text = t;
            Application.DoEvents();
        }
    }
}
