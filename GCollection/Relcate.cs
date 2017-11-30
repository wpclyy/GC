using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GCollection
{
    public partial class Relcate : Form
    {
        /// <summary>
        /// 购低网分类表
        /// </summary>
        DataTable dtdsc = null;

        /// <summary>
        /// 1688分类表
        /// </summary>
        DataTable dtali = null;

        /// <summary>
        /// 购低网分类(catid,catname)集合
        /// </summary>
        Dictionary<string, string> diccate = new Dictionary<string, string>();

        /// <summary>
        /// 购低网分类树节点(catid, treenode)集合
        /// </summary>
        Dictionary<int, TreeNode> catetreenodedata = new Dictionary<int, TreeNode>();

        /// <summary>
        /// 业务操作类
        /// </summary>
        SpockLogic_r spr = null;

        /// <summary>
        /// 窗体关闭标识
        /// </summary>
        string closing ="0";

        public Relcate(SpockLogic_r sr)
        {
            InitializeComponent();
            spr = sr;
            lblp1.Text = "";
            lblp2.Text = "";
        }

        private void Relcate_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 加载分类
        /// </summary>
        /// <param name="dt_ali"></param>
        /// <param name="dt_dsc"></param>
        /// <param name="diccateidname"></param>
        /// <param name="diccateidnode"></param>
        public void Loaderdata(DataTable dt_ali ,DataTable dt_dsc,Dictionary<string  ,string > diccateidname)
        {
            dtdsc = dt_dsc;
            dtali = dt_ali;
            diccate = diccateidname;
            backgroundWorker1.RunWorkerAsync();
        }

        #region 加载商品分类

        /// <summary>
        /// 显示购低网分类树
        /// </summary>
        public void showcatedsc()
        {
            foreach (DataRow row in dtdsc.Rows)
            {
                if (row["parent_id"].ToString() == "0")
                {
                    Application.DoEvents();
                    TreeNode pnode = new TreeNode();
                    pnode.Text = row["cat_name"].ToString();
                    pnode.Tag = row["cat_id"].ToString();
                    treeView2.Nodes.Add(pnode);
                    string catid = pnode.Tag.ToString();
                    AddChildnode_dsc(catid, pnode);
                }
            }
        }

        /// <summary>
        /// 嵌套加载购低网树节点
        /// </summary>
        /// <param name="pid"></param>
        /// <param name="pnode"></param>
        public void AddChildnode_dsc(string pid, TreeNode pnode)
        {
            catetreenodedata.Add(Convert.ToInt32(pnode.Tag), pnode);
            foreach (DataRow row in dtdsc.Rows)
            {
                if (row["parent_id"].ToString() == pid)
                {
                    TreeNode cnode = new TreeNode();
                    cnode.Text = row["cat_name"].ToString();
                    cnode.Tag = row["cat_id"].ToString();
                    pnode.Nodes.Add(cnode);
                    string catid = cnode.Tag.ToString();
                    AddChildnode_dsc(catid, cnode);
                }
            }
        }

        /// <summary>
        /// 显示1688分类树
        /// </summary>
        public void showcateali()
        {
            foreach (DataRow row in dtali.Rows)
            {
                if (closing == "1")
                {
                    return;
                }
                if (row["parentIDs"].ToString() == "0")
                {
                    Application.DoEvents();
                    TreeNode pnode = new TreeNode();
                    pnode.Text = row["catname"].ToString();
                    pnode.Tag = row["catid"].ToString();
                    treeView1.Nodes.Add(pnode);
                    string catid = pnode.Tag.ToString();
                    AddChildnode_ali(catid, pnode);
                }
            }
        }

        /// <summary>
        /// 嵌套加载1688分类树节点
        /// </summary>
        /// <param name="pid"></param>
        /// <param name="pnode"></param>
        public void AddChildnode_ali(string pid, TreeNode pnode)
        {
            foreach (DataRow row in dtali.Rows)
            {
                if (closing == "1")
                {
                    return;
                }
                if (row["parentIDs"].ToString() == pid)
                {
                    TreeNode cnode = new TreeNode();
                    cnode.Text = row["catname"].ToString();
                    cnode.Tag = row["catid"].ToString();
                    pnode.Nodes.Add(cnode);
                    if (spr.diccate.ContainsKey(cnode.Tag.ToString()) && spr.diccate[cnode.Tag.ToString()] != 0)
                    {
                        cnode.BackColor = Color.Red;
                    }
                    string catid = cnode.Tag.ToString();
                    AddChildnode_ali(catid, cnode);
                }
            }
        }

        /// <summary>
        /// 加载1688分类后台线程
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            showcateali();
            showcatedsc();
        }
        #endregion

        /// <summary>
        /// 分类关联操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            string s1 = textBox1.Text;
            string c1 = textBox1.Tag == null ? "" : textBox1.Tag.ToString();

            string s2 = textBox2.Text;
            string c2 = textBox2.Tag == null ? "" : textBox2.Tag.ToString();

            if (c1 != "" && c2 != "" && s2 != "")
            {
                int c = spr.opgcc.Relcate(c1, c2, s2);
                if (c > 0)
                {
                    spr.Loadrelcate();
                    huaxian(Color.Red);
                    if (treeView1.SelectedNode != null)
                    {
                        foreach (int key in catetreenodedata.Keys)
                        {
                            catetreenodedata[key].BackColor = Color.Transparent;
                        }
                        treeView1.SelectedNode.BackColor = Color.Red;
                        treeView2.SelectedNode.BackColor = Color.Red;
                    }
                    MessageBox.Show("OK","提示",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
            }
            else if(c1==string.Empty)
            {
                MessageBox.Show("请选择需要关联的1688分类!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (c2 == string.Empty)
            {
                MessageBox.Show("请选择需要关联的购低网分类!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        /// <summary>
        /// 分类关联线
        /// </summary>
        /// <param name="cr"></param>
        private void huaxian(Color cr)
        {
            Pen pen = new Pen(cr, 1);
            pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            pen.DashPattern = new float[] { 2f, 2f };
            Graphics gh = panel1.CreateGraphics();
            Point p1 = new Point(textBox1.Left + textBox1.Width, textBox1.Top + textBox1.Height / 2);
            Point p2 = new Point(textBox2.Left + textBox2.Width, textBox2.Top + textBox2.Height / 2);
            gh.DrawLine(pen, p1, p2);
        }

        /// <summary>
        /// 初始连线
        /// </summary>
        /// <param name="cr"></param>
        private void huaxian1(Color cr)
        {
            Pen pen = new Pen(cr, 1);
            pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            pen.DashPattern = new float[] { 2f, 2f };
            Graphics gh = panel1.CreateGraphics();
            Point p1 = new Point(textBox1.Left + textBox1.Width / 2, textBox1.Top + textBox1.Height);
            Point p2 = new Point(textBox2.Left + textBox2.Width / 2, textBox2.Top + textBox2.Height);
            Point p3 = new Point(button1.Left + button1.Width / 2, button1.Top);
            gh.DrawLine(pen, p1, p3);
            gh.DrawLine(pen, p2, p3);
        }


        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.GetNodeCount(true) < 1)
             {
                treeView1.SelectedNode = e.Node;
                  textBox1.Text = e.Node.Text;
                 textBox1.Tag = e.Node.Tag;
                string s1 = GetParentNodeInfo(e.Node);
                string[] sarr1 = s1.Split(new char[3] { '-', '-', '>' });
                string st1 = "";
                for (int j = sarr1.Length - 1; j >= 0; j--)
                {
                    if (sarr1[j] != "")
                    {
                        st1 += sarr1[j] + "/";
                    }
                }
                lblp1.Text = st1.TrimEnd('/');
                if (spr.diccate.ContainsKey(textBox1.Tag.ToString()))
                {
                    int s = spr.diccate[textBox1.Tag.ToString()];
                    if (s == 0)
                    {
                        //没有关联分类
                        textBox2.Text = "";
                        textBox2.Tag = null;
                        lblp2.Text = "";
                        using (Graphics gh = panel1.CreateGraphics())
                        {
                            huaxian(panel1.BackColor);
                        }
                        foreach (int key in catetreenodedata.Keys)
                        {
                            catetreenodedata[key].BackColor = Color.Transparent;
                        }
                    }
                    else
                    {
                        //关联分类
                        textBox2.Text = diccate[s.ToString()];
                        textBox2.Tag = s;
                        huaxian(Color.Red);
                        if (catetreenodedata.ContainsKey(s))
                        {
                            string s2 = GetParentNodeInfo(catetreenodedata[s]);
                            string[] sarr2 = s2.Split(new char[3] { '-', '-', '>' });
                            string st2 = "";
                            for (int j = sarr2.Length - 1; j >= 0; j--)
                            {
                                if (sarr2[j] != "")
                                {
                                    st2 += sarr2[j] + "/";
                                }
                            }
                            lblp2.Text = st2.TrimEnd('/');
                            foreach (int key in catetreenodedata.Keys)
                            {
                                catetreenodedata[key].BackColor = Color.Transparent;
                            }
                            catetreenodedata[s].BackColor = Color.Red;
                            treeView2.SelectedNode = catetreenodedata[s];
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 获取所有父节点text
        /// </summary>
        /// <param name="currTreeNode"></param>
        /// <returns></returns>
        private string GetParentNodeInfo( TreeNode currTreeNode)
        {
            string rv = "";
            if (currTreeNode.Parent != null)
            {
                rv = "-->"+currTreeNode.Parent.Text;
                rv += GetParentNodeInfo(currTreeNode.Parent);
            }
            return rv;
        }

        private void treeView2_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.GetNodeCount(true) < 1)
            {
                treeView2.SelectedNode = e.Node;
                textBox2.Text = e.Node.Text;
                textBox2.Tag = e.Node.Tag;
                string s2 = GetParentNodeInfo(e.Node);
                string[] sarr2 = s2.Split(new char[3] { '-', '-', '>' });
                string st2 = "";
                for (int j = sarr2.Length - 1; j >= 0; j--)
                {
                    if (sarr2[j] != "")
                    {
                        st2 += sarr2[j] + "/";
                    }
                }
                lblp2.Text = st2.TrimEnd('/');
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            huaxian1(Color.Red);
        }

        private void Relcate_FormClosing(object sender, FormClosingEventArgs e)
        {
            closing = "1";
        }
    }
}
