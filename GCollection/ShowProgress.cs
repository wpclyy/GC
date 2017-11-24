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
    public partial class ShowProgress : Form
    {
    
        public ShowProgress()
        {
            InitializeComponent();
        }

        BackgroundWorker bgw = null;
        public ShowProgress(BackgroundWorker bg,string s)
        {
            InitializeComponent();
            bgw = bg;
            lbltitle.Text  = s;
        }

        private void ShowProgress_Load(object sender, EventArgs e)
        {
            this.progressBar1.Value = 0;
            this.label1.Text = "";
            this.label2.Text = "";
            this.lbltip1.Text = "";
            this.lbltip2.Text = "";
        }


        public void setsgoodsprogress(string c1, string c2, string t1, string t2,string t3)
        {
            lbltip1.Text = t1;
            label1.Text = "（" + c1 + "）   "+t3;

            lbltip2.Text = t2;
            label2.Text = "（" + c2 + "）";
        }

        public void setprogress(string c1,string c2,string t1,string t2)
        {
            if (c1 == "")
            {
                lbltip1.Text = "";
                lbltip1.Visible = false;
                label1.Text = "";
                label1.Visible = false;
            }
            else {
                lbltip1.Text = t1;
                label1.Text ="（"+ c1+"）";
            }
            if (c2 == "")
            {
                lbltip2.Text = "";
                lbltip2.Visible = false;
                label2.Text = "";
                label2.Visible = false;
            }
            else
            {
                lbltip2.Text = t2;
                label2.Text = "（" + c2 + "）";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (bgw != null)
            {
                bgw.CancelAsync();
            }
           // this.Close();
        }
    }
}
