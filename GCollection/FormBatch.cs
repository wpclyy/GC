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
    public partial class FormBatch : Form
    {
        /// <summary>
        /// 购低网品牌表
        /// </summary>
        DataTable dtbrand = new DataTable();

        /// <summary>
        /// 购低网分类表
        /// </summary>
        DataTable dtcate = new DataTable();

        SpockLogic_r spr = null;

        Dictionary<string, Control> diccontrl = new Dictionary<string, Control>();
        Dictionary<string, Control> diccontrlq = new Dictionary<string, Control>();

        public FormBatch()
        {
            InitializeComponent();
        }

        public FormBatch (DataTable dt1,DataTable dt2,SpockLogic_r sp)
        {
            InitializeComponent();
            spr = sp;
            dtbrand = dt1;
            dtcate = dt2;
            showbrand();
            showcatedsc();
        }

        /// <summary>
        /// 加载品牌
        /// </summary>
        public void showbrand()
        {
            cmbbrand.DataSource = dtbrand;
            cmbbrand.ValueMember = "brand_id";
            cmbbrand.DisplayMember = "brand_name";

            qcmbbrand.DataSource = dtbrand;
            qcmbbrand.ValueMember = "brand_id";
            qcmbbrand.DisplayMember = "brand_name";
        }

        /// <summary>
        /// 显示购低网商品分类树
        /// </summary>
        public void showcatedsc()
        {
            foreach (DataRow row in dtcate.Rows)
            {
                if (row["parent_id"].ToString() == "0")
                {
                    Application.DoEvents();
                    TreeNode pnode = new TreeNode();
                    pnode.Text = row["cat_name"].ToString();
                    pnode.Tag = row["cat_id"].ToString();
                    tvcat.Nodes.Add(pnode);
                    string catid = pnode.Tag.ToString();
                    AddChildnode_dsc(catid, pnode, dtcate);
                    TreeNode tt=(TreeNode) pnode.Clone();
                    treeView1.Nodes.Add(tt);
                }
            }
        }

        public void AddChildnode_dsc(string pid, TreeNode pnode, DataTable dt)
        {
            foreach (DataRow row in dt.Rows)
            {
                if (row["parent_id"].ToString() == pid)
                {
                    TreeNode cnode = new TreeNode();
                    cnode.Text = row["cat_name"].ToString();
                    cnode.Tag = row["cat_id"].ToString();
                    pnode.Nodes.Add(cnode);
                    string catid = cnode.Tag.ToString();
                    AddChildnode_dsc(catid, cnode, dt);
                }
            }
        }

        private void tvcat_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.GetNodeCount(true) < 1)
            {
                txtcate.Text = e.Node.Text;
                lblcatid.Text = e.Node.Tag.ToString();
                tvcat.CollapseAll();
                tvcat.Hide();
            }
        }

        private void tvcat_Leave(object sender, EventArgs e)
        {
            tvcat.CollapseAll();
            tvcat.Hide();
        }

        private void txtcate_Enter(object sender, EventArgs e)
        {
            tvcat.BringToFront();
            tvcat.Show();
        }

        private void txtcate_Leave(object sender, EventArgs e)
        {
            if (!tvcat.Focused)
            {
                tvcat.Hide();
            }
        }


        private void FormBatchGoodsUpdate_Load(object sender, EventArgs e)
        {
            LoadQuery();
            LoadSet();
        }

        private void LoadQuery()
        {
            treeView1.Height = 200;
            treeView1.Width = 200;
            treeView1.Top = 50;
            foreach (Control ctrl in tabPage1.Controls)
            {
                diccontrlq.Add(ctrl.Name, ctrl);
                if (ctrl is ComboBox)
                {
                    if ((ctrl as ComboBox).Items.Count > 0)
                    {
                        (ctrl as ComboBox).SelectedIndex = 0;
                    }
                    ctrl.Enabled = false;
                }
                else if (ctrl is CheckBox)
                {
                    ctrl.Enabled = true;
                }
                else if (!(ctrl is TreeView) && !(ctrl is Label) && !(ctrl is Button))
                {
                    ctrl.Enabled = false;
                }
            }
        }

        private void LoadSet()
        {
            tvcat.Height = 200;
            tvcat.Width = 200;
            tvcat.Top = 50;
            foreach (Control ctrl in panel1.Controls)
            {
                diccontrl.Add(ctrl.Name, ctrl);
                if (ctrl is ComboBox)
                {
                    if ((ctrl as ComboBox).Items.Count > 0)
                    {
                        (ctrl as ComboBox).SelectedIndex = 0;
                    }
                    ctrl.Enabled = false;
                }
                else if (ctrl is CheckBox)
                {
                    ctrl.Enabled = true;
                }
                else if (!(ctrl is TreeView) && !(ctrl is Label))
                {
                    ctrl.Enabled = false;
                }
            }
        }

        private void QCheckChanged(object sender, EventArgs e)
        {
            CheckBox ckb = (sender as CheckBox);
            string tag = ckb.Tag.ToString();
            if (tag == "goodsprice")
            {
                qckbgoodsprice2.Checked = false;
            }
            else if (tag == "goodsprice2")
            {
                qckbgoodsprice.Checked = false;
            }
            if (ckb.Checked)
            {
                QQueryControlandEnabled(tag, true);
            }
            else
            {
                QQueryControlandEnabled(tag, false);
            }
            ckb.Enabled = true;

        }

        private void  QQueryControlandEnabled(string tag, bool b)
        {
            foreach (string cname in diccontrlq.Keys)
            {
                string str = diccontrlq[cname].Tag == null ? "" : diccontrlq[cname].Tag.ToString();
                if (str == tag)
                {
                    diccontrlq[cname].Enabled = b;
                }
            }
        }

        private void CheckChanged(object sender ,EventArgs e)
        {
            CheckBox ckb = (sender as CheckBox);
            string tag = ckb.Tag.ToString ();
            if (tag == "goodsprice")
            {
                ckbgoodsprice2.Checked = false;
            }
            else if(tag=="goodsprice2") {
                ckbgoodsprice.Checked = false;
            }
            if (ckb.Checked)
            {
                QueryControlandEnabled(tag, true);
            }
            else
            {
                QueryControlandEnabled(tag, false);
            }
            ckb.Enabled = true;

        }

        private void QueryControlandEnabled(string tag, bool b)
        {
            foreach (string  cname in diccontrl.Keys)
            {
                string str = diccontrl[cname].Tag == null ? "" : diccontrl[cname].Tag.ToString ();
                if (str==tag)
                {
                    diccontrl[cname].Enabled = b;
                }
            }
        }

        private void cmbgoodsname_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbgoodsname2.SelectedIndex = cmbgoodsname.SelectedIndex;
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> dicwhere = new Dictionary<string, string>();
            GetSetParams(dicwhere);
            string conditions = "";
            foreach (string key in dicwhere.Keys)
            {
                conditions +=key + "=" + dicwhere[key]+",";
            }
            conditions = conditions.TrimEnd(',');
            if (string.Empty != conditions)
            {
                DataTable dt = QueryDatatable();
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        DialogResult dr = MessageBox.Show("您确定批量修改商品吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                        if (dr != DialogResult.OK)
                        {
                            return;
                        }
                        string goods_sn = "";
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            goods_sn += "'" + dt.Rows[i]["goods_sn"] + "',";
                        }
                        if (string.Empty != goods_sn)
                        {
                            goods_sn = goods_sn.TrimEnd(',');
                            bool b = spr.opgcc.UpdateProducts(conditions, goods_sn);
                            if (b)
                            {
                                MessageBox.Show("批量修改成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("查询不到符合条件的商品！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else {
                    MessageBox.Show("请先设置查询条件！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("请勾选设置需要修改的属性值！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void GetSetParams(Dictionary<string ,string> dicwhere)
        {
            foreach (Control ctrl in panel1.Controls)
            {
                if (ctrl is CheckBox)
                {
                    if ((ctrl as CheckBox).Checked)
                    {
                        if (ctrl.Tag.ToString() == "kucun")
                        {
                            string s = txtkucun.Text.Trim();
                            if (string.Empty!= s)
                            {
                                dicwhere.Add("goods_number", s);
                            }
                        }
                        else if (ctrl.Tag.ToString() == "weight")
                        {
                            string s = txtweight.Text.Trim();
                            if (string.Empty != s)
                            {
                                dicwhere.Add("goods_weight", s);
                            }
                        }
                        else if (ctrl.Tag.ToString() == "goodsname")
                        {
                            if (cmbgoodsname.Text == "直接修改")
                            {
                                string s = txtgoodsname.Text.Trim();
                                if (string.Empty != s)
                                {
                                    string t = "'" + s + "'";
                                    dicwhere.Add("goods_name", t);
                                }
                            }
                            else if (cmbgoodsname.Text == "增加前缀")
                            {
                                string s = txtgoodsname.Text.Trim();
                                string s1 = txtgoodsname2.Text.Trim();
                                string t = "";
                                if (string.Empty != s)
                                {
                                    t += "'" + s + "' +goods_name";
                                    if (string.Empty != s1)
                                    {
                                        t += "+'" + s1 + "'";
                                    }
                                }
                                else {
                                    if (string.Empty != s1)
                                    {
                                       t += "goods_name+'"+s1+"'";
                                    }
                                }
                                if (string.Empty != t)
                                {
                                    dicwhere.Add("goods_name", t);
                                }
                            }
                            else if (cmbgoodsname.Text == "查找包含")
                            {
                                string s = txtgoodsname.Text.Trim();
                                string s1 = txtgoodsname2.Text.Trim();
                                if (string.Empty != s)
                                {
                                    string t = "REPLACE(goods_name, '" + s + "', '" + s1 + "' )";
                                    dicwhere.Add("goods_name", t);
                                }
                            }
                        }
                        else if (ctrl.Tag.ToString() == "goodsprice")
                        {
                            string s = txtgoodprice.Text.Trim();
                            string p = cmbgoodspricetype.Text.Trim();
                            string t = "";
                            if (p == "本店价")
                            {
                                t = "shop_price";
                            }
                            else if (p == "市场价")
                            {
                                t = "market_price";
                            }
                            if(string.Empty!=s)
                            {
                                dicwhere.Add(t, s);
                            }
                        }
                        else if (ctrl.Tag.ToString() == "goodsprice2")
                        {
                            string s = txtgoodsprice2.Text.Trim();
                            if (string.Empty != s)
                            {
                                string p1 = cmbgoodspricetype1.Text.Trim();
                                string p2 = cmbgoodspricetype2.Text.Trim();
                                string oper = cmboper.Text.Trim();
                                if (p1 == "本店价")
                                {
                                    if (p2 == "本店价")
                                    {
                                        string t = " shop_price" + oper + s;
                                        dicwhere.Add("shop_price", t);
                                    }
                                    else if (p2 == "市场价")
                                    {
                                        string t = " market_price" + oper + s;
                                        dicwhere.Add("shop_price", t);
                                    }
                                }
                                else if (p1 == "市场价")
                                {
                                    if (p2 == "本店价")
                                    {
                                        string t = " shop_price" + oper + s;
                                        dicwhere.Add("market_price", t);
                                    }
                                    else if (p2 == "市场价")
                                    {
                                        string t = " market_price" + oper + s;
                                        dicwhere.Add("market_price", t);
                                    }
                                }
                            }
                        }
                        else if (ctrl.Tag.ToString() == "brand")
                        {
                            string s = cmbbrand.SelectedValue.ToString ();
                            if(string.Empty!=s)
                            {
                                dicwhere.Add("brand_id", s);
                            }
                        }
                        else if (ctrl.Tag.ToString() == "cate")
                        {
                            string catid = lblcatid.Text.Trim();
                            if (string.Empty != catid&& catid != "0")
                            {
                                dicwhere.Add("cat_id", catid);
                            }
                        }
                        else if (ctrl.Tag.ToString() == "best")
                        {
                            string s = cmbbest.Text.Trim();
                            string t = (s == "是") ? "1" : "0";
                            dicwhere.Add("is_best", t);
                        }
                        else if (ctrl.Tag.ToString() == "new")
                        {
                            string s = cmbnew.Text.Trim();
                            string t = (s == "是") ? "1" : "0";
                            dicwhere.Add("is_new", t);
                        }
                        else if (ctrl.Tag.ToString() == "hot")
                        {
                            string s = cmbhot.Text.Trim();
                            string t = (s == "是") ? "1" : "0";
                            dicwhere.Add("is_hot", t);
                        }
                        else if (ctrl.Tag.ToString() == "onsale")
                        {
                            string s = cmbonsale.Text.Trim();
                            string t = (s == "是") ? "1" : "0";
                            dicwhere.Add("is_on_sale", t);
                        }
                        else if (ctrl.Tag.ToString() == "shipping")
                        {
                            string s = cmbshipping.Text.Trim();
                            string t = (s == "是") ? "1" : "0";
                            dicwhere.Add("is_shipping", t);
                        }
                    }
                }
            }
        }

        private void TxtDigit_KeyPress(object sender, KeyPressEventArgs e)
        {
             if (e.KeyChar != 8 && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void TxtFloat_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 8 && !Char.IsDigit(e.KeyChar) && e.KeyChar != 0x2E)
            {
                e.Handled = true;
            }

            if (e.KeyChar == '.')   //允许输入回退键
            {
                TextBox tb = sender as TextBox;

                if (tb.Text == "")
                {
                    tb.Text = "0.";
                    tb.Select(tb.Text.Length, 0);
                    e.Handled = true;
                }
                else if (tb.Text.Contains("."))
                {
                    e.Handled = true;
                }
                else
                {
                    e.Handled = false;
                }
            }
        }

        private void qtxtcate_Enter(object sender, EventArgs e)
        {
            treeView1.BringToFront();
            treeView1.Show();
        }

        private void qtxtcate_Leave(object sender, EventArgs e)
        {
            if (!treeView1.Focused)
            {
                treeView1.Hide();
            }
        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.GetNodeCount(true) < 1)
            {
                qtxtcate.Text = e.Node.Text;
                qlblcatid.Text = e.Node.Tag.ToString();
                treeView1.CollapseAll();
                treeView1.Hide();
            }
        }


        private void treeView1_Leave(object sender, EventArgs e)
        {
            treeView1.CollapseAll();
            treeView1.Hide();
        }

        private void GetQueryCondition(Dictionary<string, string> dicwhere)
        {
            foreach (Control ctrl in tabPage1.Controls)
            {
                if (ctrl is CheckBox)
                {
                    if ((ctrl as CheckBox).Checked)
                    {
                        if (ctrl.Tag.ToString() == "goodssn")
                        {
                            string s = qtxtgoodssn.Text.Trim();
                            string p = qcmbgoodssn.Text.Trim();
                            if (string.Empty != s)
                            {
                                string t = "";
                                if (p == "包含")
                                {
                                    t = "locate('" + s + "',goods_sn)>0";
                                }
                                else if(p=="不包含")
                                {
                                    t = "locate('" + s + "',goods_sn)=0";
                                }
                                if (string.Empty != t)
                                {
                                    dicwhere.Add("goods_sn", t);
                                }
                            }
                        }
                        else if (ctrl.Tag.ToString() == "goodsname")
                        {
                            string s = qtxtgoodsname.Text.Trim();
                            string p = qcmbgoodsname.Text.Trim();
                            if (string.Empty != s)
                            {
                                string t = "";
                                if (p == "包含")
                                {
                                    t = "locate('" + s + "',goods_name)>0";
                                }
                                else if (p == "不包含")
                                {
                                    t = "locate('" + s + "',goods_name)=0";
                                }
                                if (string.Empty != t)
                                {
                                    dicwhere.Add("goods_name", t);
                                }
                            }
                        }
                        else if (ctrl.Tag.ToString() == "goodsprice")
                        {
                            string s = qtxtgoodsprice.Text.Trim();
                            string p = qcmbgoodsprice.Text.Trim();
                            string op = qcmboper.Text.Trim();

                            string t = "";
                            if (p == "本店价")
                            {
                                t = "shop_price";
                            }
                            else if (p == "市场价")
                            {
                                t = "market_price";
                            }
                            if (string.Empty != s)
                            {
                                string ss = t + op + s;
                                dicwhere.Add(t, ss);
                            }
                        }
                        else if (ctrl.Tag.ToString() == "goodsprice2")
                        {
                            string s1 = qtxtgoodsprice1.Text.Trim();
                            string s2 = qtxtgoodsprice2.Text.Trim();
                            if (string.Empty != s1 &&string.Empty!=s2)
                            {
                                string p = qcmbgoodsprice2.Text.Trim();
                                string t = "";
                                if (p == "本店价")
                                {
                                    t = "shop_price  BETWEEN " + s1 + " AND " + s2;
                                    dicwhere.Add("shop_price", t);
                                }
                                else if (p== "市场价")
                                {
                                    t = "market_price  BETWEEN " + s1 + " AND " + s2;
                                    dicwhere.Add("market_price", t);
                                }
                            }
                        }
                        else if (ctrl.Tag.ToString() == "brand")
                        {
                            string s = qcmbbrand.SelectedValue.ToString();
                            if (string.Empty != s)
                            {
                                string t = "brand_id=" + s;
                                dicwhere.Add("brand_id", t);
                            }
                        }
                        else if (ctrl.Tag.ToString() == "cate")
                        {
                            string catid = qlblcatid.Text.Trim();
                            if (string.Empty != catid && catid != "0")
                            {
                                string t = "cat_id=" + catid;
                                dicwhere.Add("cat_id", t);
                            }
                        }
                        else if (ctrl.Tag.ToString() == "best")
                        {
                            string s = qcmbbest.Text.Trim();
                            string t = (s == "是") ? "1" : "0";
                            t = "is_best=" + t;
                            dicwhere.Add("is_best", t);
                        }
                        else if (ctrl.Tag.ToString() == "new")
                        {
                            string s = qcmbnew.Text.Trim();
                            string t = (s == "是") ? "1" : "0";
                            t = "is_new=" + t;
                            dicwhere.Add("is_new", t);
                        }
                        else if (ctrl.Tag.ToString() == "hot")
                        {
                            string s = qcmbhot.Text.Trim();
                            string t = (s == "是") ? "1" : "0";
                            t = "is_hot=" + t;
                            dicwhere.Add("is_hot", t);
                        }
                        else if (ctrl.Tag.ToString() == "onsale")
                        {
                            string s = qcmbonsale.Text.Trim();
                            string t = (s == "是") ? "1" : "0";
                            t = "is_on_sale=" + t;
                            dicwhere.Add("is_on_sale", t);
                        }
                        else if (ctrl.Tag.ToString() == "shipping")
                        {
                            string s = qcmbshipping.Text.Trim();
                            string t = (s == "是") ? "1" : "0";
                            t = "is_shipping=" + t;
                            dicwhere.Add("is_shipping", t);
                        }
                    }
                }
            }
        }

        private void btnquery1_Click(object sender, EventArgs e)
        {
            Querygoods();
        }

        private void Querygoods()
        {
            DataTable dt =  QueryDatatable();
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    FormQuery frm = new FormQuery(dtbrand, dtcate);
                    frm.SetDataSource(dt);
                    frm.ShowDialog(this);
                }
                else
                {
                    MessageBox.Show("查询不到符合条件的商品！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("请先设置查询条件！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private DataTable QueryDatatable()
        {
            Dictionary<string, string> dicwhere = new Dictionary<string, string>();
            GetQueryCondition(dicwhere);
            string conditions = "";
            foreach (string key in dicwhere.Keys)
            {
                conditions += dicwhere[key] + " and ";
            }
            if (string.Empty != conditions)
            {
                conditions = conditions.TrimEnd(new char[] { 'a', 'n', 'd', ' ' });
                DataTable dt = spr.opgcc.QueryConditionGoods(conditions);
                return dt;
            }
            return null;
        }

        private void btnquery2_Click(object sender, EventArgs e)
        {
            Querygoods();
        }

    }
}
