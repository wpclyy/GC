using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
    public partial class FormProductPrice : Form
    {
        string skuinfo = "";
        string shop_price = "";
        string proxyprice = "";
        public FormProductPrice()
        {
            InitializeComponent();
        }

        public FormProductPrice(string s, string p,string proxy)
        {
            InitializeComponent();
            skuinfo = s;
            shop_price = p;
            proxyprice = proxy;
        }
        JArray sm = null;
        JArray skuprice = null;
        Dictionary<string, List<string>> dicgoodsattr = new Dictionary<string, List<string>>();
        Dictionary<string, string> dicskuprice = new Dictionary<string, string>();

        private void FormProductPrice_Load(object sender, EventArgs e)
        {
            if (skuinfo == null || skuinfo == ""||skuinfo=="null")
            {
                return;
            }
            sm = (JArray)JsonConvert.DeserializeObject(skuinfo);

            if (shop_price != null && shop_price != ""&&shop_price != "null")
            {
                skuprice = (JArray)JsonConvert.DeserializeObject(shop_price);
                foreach (JToken p in skuprice.Children())
                {
                    if (p["key"].ToString().ToLower() == "consign_price")
                    {
                        string ss = p["value"].ToString();
                        string[] arr = ss.Split(';');
                        if (arr.Length > 0)
                        {
                            for(int i=0;i<arr.Length;i++)
                            {
                               string[] arrs= arr[i].Split(':');
                                if (arrs.Length == 2)
                                {
                                    dicskuprice.Add(arrs[0],arrs[1]);
                                }
                            }
                        }
                        break;
                    }
                }
            }
            foreach (JToken j in sm.Children())
            {
                List<string> lst = new List<string>();
                string skuId = "";
                string amountOnSale = "";
                string attrvalue = "";
                foreach (JToken c in j["attributes"].Children())
                {
                    attrvalue += "【"+c["attributeValue"].ToString() + "】";
                }
                attrvalue = attrvalue.TrimEnd(',');
                lst.Add(attrvalue);
                skuId = j["skuId"].ToString();
                amountOnSale = j["amountOnSale"].ToString();
                lst.Add(amountOnSale);
                string sprice = "";
                if (dicskuprice.ContainsKey(skuId))
                {
                    sprice = dicskuprice[skuId];
                }
                else {
                    sprice = proxyprice;
                }
                lst.Add(sprice);
                if (!dicgoodsattr.ContainsKey(skuId))
                {
                    dicgoodsattr.Add(skuId, lst);
                }
            }
            int index = 1;
            foreach (string k in dicgoodsattr.Keys)
            {
                string sku = "";
                string price = "";
                string kc = "";
                sku = dicgoodsattr[k][0];
                kc = dicgoodsattr[k][1];
                price = dicgoodsattr[k][2];

                top = 40+35*(index-1);
                loadproducts(k,sku, price, kc);
                index++;
            }
        }

        int top =0;
        private void loadproducts(string skuid,string sku, string price, string kc)
        {
            Panel pl = new Panel();
            pl.BorderStyle = BorderStyle.FixedSingle;
            pl.Width = panel1.Width-30;
            pl.Height = 30;
            pl.Left = 1;
            pl.Top = top;

            Label lblsku = new Label();
            lblsku.Width = 200;
            lblsku.Text = sku;
            lblsku.Left = 50;
            lblsku.Top = 5;

            TextBox txtprice = new TextBox();
            txtprice.Tag = skuid;
            txtprice.Width = 80;
            txtprice.Text = price;
            txtprice.Left =300;
            txtprice.Top = 5;

            TextBox txtkc = new TextBox();
            txtkc.Width = 80;
            txtkc.Text = kc;
            txtkc.Left = 450;
            txtkc.Top = 5;

            pl.Controls.Add(lblsku);
            pl.Controls.Add(txtprice);
            pl.Controls.Add(txtkc);
            panel1.Controls.Add(pl);
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            foreach (Control c in panel1.Controls)
            {
                if (c is Panel)
                {
                    foreach(Control cc in c.Controls)
                    {
                        if (cc is TextBox)
                        {
                            if (cc.Tag != null && cc.Tag.ToString() != "")
                            {
                                string skuid = cc.Tag.ToString();
                                dicgoodsattr[skuid][2] = cc.Text.Trim();
                            }
                        }
                    }
                }
            }
            if (sm == null)
            {
                return;
            }
            foreach (JToken j in sm.Children())
            {
                string skuId = "";
                skuId = j["skuId"].ToString();
                j["amountOnSale"] = dicgoodsattr[skuId][1];
                j["price"] = dicgoodsattr[skuId][2];
            }

           string skuinfos=   JsonConvert.SerializeObject(sm);
            MessageBox.Show("OK");
        }
    }
}
