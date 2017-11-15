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
    public partial class FormLoad : Form
    {
        public FormLoad()
        {
            InitializeComponent();
        }
        MForm mf = null;
        private void FormLoad_Load(object sender, EventArgs e)
        {
           
        }

        public void loading()
        {
            if (Program.mfloadflag == "OK")
            {
                timer1.Stop();
                this.Hide();
                mf.Show();
            } 
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            loading();
        }

        private void FormLoad_Shown(object sender, EventArgs e)
        {
            timer1.Start();
            Application.DoEvents();
            mf = new MForm();
            mf.Hide();
            mf.LoaderData();
        }
    }
}
