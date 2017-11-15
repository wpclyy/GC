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
    public partial class ShowProduct : Form
    {
        public ShowProduct()
        {
            InitializeComponent();
        }

        public void seturl(string url,string producttitlel)
        {
            webBrowser1.Navigate(url);
            this.Text = producttitlel;
        }
    }
}
