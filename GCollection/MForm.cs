using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GCollection
{
    [ComVisible(true)]
    public partial class MForm : Form
    {
        /// <summary>
        /// 业务操作类
        /// </summary>
        SpockLogic_r spr = null;

        public MForm()
        {
            InitializeComponent();
            spr = new SpockLogic_r(this);
            this.webBrowser1.Url = new Uri(Application.StartupPath + "\\kindeditor\\e.html", UriKind.Absolute);
            this.webBrowser1.ObjectForScripting = this;
            dataGridView1.CellPainting += new DataGridViewCellPaintingEventHandler(dataGridView1_CellPainting);
            System.Net.ServicePointManager.DefaultConnectionLimit = 512;   //HTTP请求并发数量最大不超过1024
        }
        /// <summary>
        /// 商品详情编辑器的内容
        /// </summary>
        string content = "";

        //设置webBrowser1.ObjectForScripting属性才会调用此方法
        public void RequestContent(string str)
        {
            content = str;
        }

        delegate void Delegateshowcate(DataSet ds);
        delegate void Delegateshowtoolstripstatus();
        /*每页数量*/
        int pagesize = 5;
        /*已获取数量*/
        int ccurrcount = 0;
        /*总数量*/
        int allcount = 0;
        /*供应商总数*/
        int sallcount = 0;
        /*当前供应商数量*/
        int scurrcount = 0;
        /*当前供应商名称*/
        string suppliername = "";
        /*当前供应商ID*/
        string member = "";
        private static object ojb = new object();

        /// <summary>
        /// 进度条
        /// </summary>
        ShowProgress spro = null;

        /// <summary>
        /// 购低网分类树集合(分类ID，树节点)
        /// </summary>
        Dictionary<int, TreeNode> catetreenodedata = new Dictionary<int, TreeNode>();

        /// <summary>
        /// 购低网分类集合(分类ID，分类名称)
        /// </summary>
        Dictionary<string, string> diccatedata = new Dictionary<string, string>();

        /// <summary>
        /// 1688分类ID,父类ID集合(catid,parentid)
        /// </summary>
        Dictionary<string, string> diccateidali = new Dictionary<string, string>();

        /// <summary>
        /// 1688分类ID、名称集合
        /// </summary>
        Dictionary<string, string> diccatenameali = new Dictionary<string, string>();

        /// <summary>
        /// 商品查询类型 0:按分类，1：按供应商
        /// </summary>
        int querytype = 0;

        private void MForm_Load(object sender, EventArgs e)
        {
        }

        public void LoaderData()
        {
            bgwloadsupplier.RunWorkerAsync();
            bgloadcate.RunWorkerAsync();
        }

        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            string colname = dataGridView1.Columns[e.ColumnIndex].Name;
            if (e.RowIndex == -1 && (colname == "colcheck" || colname == "is_best" || colname == "is_new" || colname == "is_hot" || colname == "is_shipping" || colname == "is_on_sale"))
            {
                ResetHeaderCheckBoxLocation(e.ColumnIndex, e.RowIndex);
            }
        }

        /// <summary>
        /// 固定datagridview,CHECKBOX位置
        /// </summary>
        /// <param name="ColumnIndex"></param>
        /// <param name="RowIndex"></param>
        private void ResetHeaderCheckBoxLocation(int ColumnIndex, int RowIndex)
        {
             int index2= dataGridView1.Columns["is_best"].Index;
            int index3= dataGridView1.Columns["is_new"].Index;
            int index4 = dataGridView1.Columns["is_hot"].Index;
            int index5= dataGridView1.Columns["is_shipping"].Index;
            int index6 = dataGridView1.Columns["is_on_sale"].Index;
            int index1 = dataGridView1.Columns["colcheck"].Index;

            Rectangle r1 = dataGridView1.GetColumnDisplayRectangle(index1, false);
            Rectangle r2 = dataGridView1.GetColumnDisplayRectangle(index2, false);
            Rectangle r3 = dataGridView1.GetColumnDisplayRectangle(index3, false);
            Rectangle r4 = dataGridView1.GetColumnDisplayRectangle(index4, false);
            Rectangle r5 = dataGridView1.GetColumnDisplayRectangle(index5, false);
            Rectangle r6 = dataGridView1.GetColumnDisplayRectangle(index6, false);

            if (r1.X > 0)
            {
                ckball.Left = r1.X + 7 - dataGridView1.HorizontalScrollingOffset;
                ckball.Top = r1.Y + 4;
                ckball.Show();
            }
            else
            {
                ckball.Left = -dataGridView1.HorizontalScrollingOffset;
                ckball.Top = r1.Y + 4;
                ckball.Hide();
            }

            if (r2.X > 0)
            {
                ckbbest.Left = r2.X + 50;
                ckbbest.Top = r2.Y + 4;
                ckbbest.Show();
            }
            else {
                ckbbest.Hide();
            }

            if (r3.X > 0)
            {
                ckbnew.Left = r3.X + 50;
                ckbnew.Top = r3.Y + 4;
                ckbnew.Show();
            }
            else {
                ckbnew.Hide();
            }

            if (r4.X > 0)
            {
                ckbhot.Left = r4.X + 50;
                ckbhot.Top = r4.Y + 4;
                ckbhot.Show();
            }
            else
            {
                ckbhot.Hide();
            }

            if (r5.X > 0)
            {
                ckbshipping.Left = r5.X + 50;
                ckbshipping.Top = r5.Y + 4;
                ckbshipping.Show();
            }
            else {
                ckbshipping.Hide();
            }

            if (r6.X > 0)
            {
                ckbonsale.Left = r6.X + 50;
                ckbonsale.Top = r6.Y + 4;
                ckbonsale.Show();
            }
            else
            {
                ckbonsale.Hide();
            }
        }

        /// <summary>
        /// 1688供应商表
        /// </summary>
        DataSet dssupp = new DataSet();

        /// <summary>
        /// 1688分类表
        /// </summary>
        DataTable dtcateali = new DataTable();

        /// <summary>
        /// 购低网品牌表
        /// </summary>
        DataTable dtbrand = new DataTable();

        /// <summary>
        /// 购低网分类表
        /// </summary>
        DataTable dtcate = new DataTable();

        /// <summary>
        /// 商品数量集合(购低网分类ID，数量)
        /// </summary>
        Dictionary<string, string> dicgoodscount = new Dictionary<string, string>();

        /// <summary>
        /// 查询商品分类
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bgloadcate_DoWork(object sender, DoWorkEventArgs e)
        {
            DataSet ds = spr.Querydscbrand();
            dtbrand = ds.Tables[0];

            DataSet ds1 = spr.Querydsccate();
            dtcate = ds1.Tables[0];

            LoadAliCate();
        }

        private void bgloadcate_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            showbrand();
            showcatedsc();
            Getgoodscount();
            loadcategoodscount();
        }

        /// <summary>
        /// 加载分类商品数量
        /// </summary>
        private void Getgoodscount()
        {
            DataTable dt = spr.Hasgoods();
            dicgoodscount.Clear();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dicgoodscount.Add(dt.Rows[i]["cat_id"].ToString(), dt.Rows[i]["count"].ToString());
            }

            foreach (int catid in catetreenodedata.Keys)
            {
                if (!dicgoodscount.Keys.Contains(catid.ToString()))
                {
                    GetallChildrenCounts(catetreenodedata[catid]);
                }
            }
        }

        /// <summary>
        /// 嵌套获取下级分类商品数量方法
        /// </summary>
        /// <param name="tn"></param>
        /// <returns></returns>
        public int GetallChildrenCounts(TreeNode tn)
        {
            if (tn.Nodes.Count > 0)
            {
                int c = 0;
                foreach (TreeNode t in tn.Nodes)
                {
                    c += GetallChildrenCounts(t);
                }
                if (!dicgoodscount.ContainsKey(tn.Tag.ToString()))
                {
                    dicgoodscount.Add(tn.Tag.ToString(), c.ToString());
                }
                return c;
            }
            else
            {
                string catid = tn.Tag == null ? "" : tn.Tag.ToString();
                int cc = 0;
                if (dicgoodscount.ContainsKey(catid))
                {
                    string c = dicgoodscount[catid];
                    cc = Convert.ToInt32(c);
                    return cc;
                }
                else
                {
                    dicgoodscount.Add(catid, "0");
                    return cc;
                }
            }
        }

        /// <summary>
        /// 设置分类树商品数量
        /// </summary>
        public void loadcategoodscount()
        {
            int allcount = 0;
            allcount = spr.Hasallgoods();
            string[] strArray = treeView1.Nodes[0].Text.Split('('); //字符串转数组
            treeView1.Nodes[0].Text = strArray[0] + "(" + allcount + ")";

            string[] strArray1 = treeView1.Nodes[0].Nodes[0].Text.Split('('); //字符串转数组
            if (dicgoodscount.Keys.Contains("0"))
            {
                treeView1.Nodes[0].Nodes[0].Text = strArray1[0] + "(" + dicgoodscount["0"] + ")";
            }
            else
            {
                treeView1.Nodes[0].Nodes[0].Text = strArray1[0] + "(0)";
            }

            foreach (int catid in catetreenodedata.Keys)
            {
                if (dicgoodscount.Keys.Contains(catid.ToString()))
                {
                    Application.DoEvents();
                    catetreenodedata[catid].Text = diccatedata[catid.ToString()] + "(" + dicgoodscount[catid.ToString()] + ")";
                }
            }
            Program.mfloadflag = "OK";
        }

        /// <summary>
        /// 加载品牌
        /// </summary>
        public void showbrand()
        {
            cmbbrand.DataSource = dtbrand;
            cmbbrand.ValueMember = "brand_id";
            cmbbrand.DisplayMember = "brand_name";
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
                    treeView1.Nodes[0].Nodes.Add(pnode);
                    string catid = pnode.Tag.ToString();
                    AddChildnode_dsc(catid, pnode, dtcate);
                    TreeNode tt = (TreeNode)pnode.Clone();
                    tvcat.Nodes.Add(tt);
                }
            }
            treeView1.Nodes[0].Expand();
        }

        public void AddChildnode_dsc(string pid, TreeNode pnode, DataTable dt)
        {
            catetreenodedata.Add(Convert.ToInt32(pnode.Tag), pnode);
            diccatedata.Add(pnode.Tag.ToString(), pnode.Text);
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

        public void showsuppliers(DataSet ds)
        {
            if (this.listBox1.InvokeRequired)//等待异步
            {
                Delegateshowtoolstripstatus clsobj = new Delegateshowtoolstripstatus(
           delegate
           {
               this.listBox1.DataSource = null;
               this.listBox1.DisplayMember = "company";
               this.listBox1.ValueMember = "MemberId";
               this.listBox1.DataSource = ds.Tables[0];
               this.listBox1.Update();
               this.listBox1.SelectedItem = null;
           });
                this.BeginInvoke(clsobj);
            }
            else
            {
                this.listBox1.DataSource = null;
                this.listBox1.DisplayMember = "company";
                this.listBox1.ValueMember = "MemberId";
                this.listBox1.DataSource = ds.Tables[0];
                this.listBox1.Update();
                this.listBox1.SelectedItem = null;
            }
        }

        /// <summary>
        /// 获取商品分类
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (bgwcate.IsBusy)
            {
                bgwcate.CancelAsync();
            }
            else
            {
                DialogResult dr = MessageBox.Show("开始采集商品分类信息？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dr != DialogResult.OK)
                {
                    return;
                }
                bgwcate.RunWorkerAsync(this);
                spro = new ShowProgress(bgwcate, "正在采集商品分类信息");
                spro.ShowDialog(this);
            }
        }

        /// <summary>
        /// 获取分类线程状态
        /// </summary>
        /// <returns></returns>
        public bool querybkstatus()
        {
            bool b = bgwcate.CancellationPending;
            return b;
        }

        /// <summary>
        /// 设置商品分类进度条
        /// </summary>
        public void setcprogress()
        {
            ccurrcount++;
            string s = ccurrcount.ToString();
            if (this.InvokeRequired)//等待异步
            {
                Delegateshowtoolstripstatus clsobj = new Delegateshowtoolstripstatus(
            delegate
            {
                this.spro.setprogress(s, "", "当前进度", "");

            });
                this.BeginInvoke(clsobj);
            }
            else
            {
                this.spro.setprogress(s, "", "当前进度", "");
            }
        }

        private void bgwcate_DoWork(object sender, DoWorkEventArgs e)
        {
            ccurrcount = 0;
            allcount = 0;
            spr.getcategory(e);
        }

        private void bgwcate_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show("出错啦");
            }
            else if (e.Cancelled)
            {
                MessageBox.Show("已取消");
            }
            else
            {
                MessageBox.Show("完成");
                if (spro != null)
                {
                    spro.Close();
                }
                LoadAliCate();
            }
        }

        /// <summary>
        /// 加载1688分类
        /// </summary>
        private void LoadAliCate()
        {
            DataSet ds2 = spr.querycate();
            if (ds2.Tables[0] != null && ds2.Tables[0].Rows.Count > 0)
            {
                dtcateali = ds2.Tables[0];
                diccateidali.Clear();
                diccatenameali.Clear();
                for (int i = 0; i < dtcateali.Rows.Count; i++)
                {
                    diccateidali.Add(dtcateali.Rows[i]["catid"].ToString(), dtcateali.Rows[i]["parentIDs"].ToString());
                    diccatenameali.Add(dtcateali.Rows[i]["catid"].ToString(), dtcateali.Rows[i]["catname"].ToString());
                }
            }
            spr.Loadrelcate();
        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                row.Cells["xuhao"].Value = row.Index + 1;
            }
        }

        /// <summary>
        /// 采集供应商商品
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (this.member != "" && listBox1.SelectedItem != null)
            {
                if (bgwsign.IsBusy)
                {
                    bgwsign.CancelAsync();
                }
                else
                {
                    DialogResult dr = MessageBox.Show("开始采集商品信息？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (dr != DialogResult.OK)
                    {
                        return;
                    }
                    bgwsign.RunWorkerAsync(this);
                    spro = new ShowProgress(bgwsign, "正在采集商品信息");
                    spro.ShowDialog(this);
                }
            }
            else if (this.member == "" && listBox1.SelectedItem == null)
            {
                if (bgwcaiji.IsBusy)
                {
                    bgwcaiji.CancelAsync();
                }
                else
                {
                    DialogResult dr = MessageBox.Show("开始采集所有供应商的商品信息？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (dr != DialogResult.OK)
                    {
                        return;
                    }
                    bgwcaiji.RunWorkerAsync(this);
                    spro = new ShowProgress(bgwcaiji, "正在采集商品信息");
                    spro.ShowDialog(this);
                }
            }
        }

        /// <summary>
        /// 设置商品进度
        /// </summary>
        public void setprogress()
        {
            lock (ojb)
            {
                ccurrcount++;
                string s = ccurrcount.ToString();
                if (this.InvokeRequired)//等待异步
                {
                    Delegateshowtoolstripstatus clsobj = new Delegateshowtoolstripstatus(
               delegate
               {
                   string c1 = "", c2 = "";
                   c1 = scurrcount.ToString() + "/" + sallcount.ToString();
                   c2 = s + "/" + allcount.ToString();
                   this.spro.setsgoodsprogress(c1, c2, "当前供应商进度", "当前商品进度", suppliername);
               });
                    this.BeginInvoke(clsobj);
                }
                else
                {
                    string c1 = "", c2 = "";
                    c1 = scurrcount.ToString() + "/" + sallcount.ToString();
                    c2 = s + "/" + allcount.ToString();
                    this.spro.setsgoodsprogress(c1, c2, "当前供应商进度", "当前商品进度", suppliername);
                }
            }
        }

        private void bgwcaiji_DoWork(object sender, DoWorkEventArgs e)
        {
            ccurrcount = 0;
            allcount = 0;
            scurrcount = 0;
            sallcount = 0;
            suppliername = "";
            DataSet ds = spr.querysuppliers();
            if (ds != null)
            {
                sallcount = ds.Tables[0].Rows.Count;
            }
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                scurrcount += 1;
                suppliername = row["company"].ToString();
                string mid = row["MemberId"].ToString();
                allcount = spr.getproduct(mid);
                ccurrcount = 0;
                int allpage = 1;
                if (allcount > 0)
                {
                    float dc = (float)allcount / pagesize;
                    allpage = (int)Math.Ceiling(dc);
                    for (int i = 1; i <= allpage; i++)
                    {
                        if (((BackgroundWorker)sender).CancellationPending)
                        {
                            e.Cancel = true;
                            return;
                        }
                        else
                        {
                            spr.getproductbypage(i, pagesize, mid);
                        }
                    }
                }
            }
        }

        private void bgwcaiji_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show("出错啦");
            }
            else if (e.Cancelled)
            {
                MessageBox.Show("已取消");
            }
            else
            {
                MessageBox.Show("完成");
                if (spro != null)
                {
                    spro.Close();
                }
            }
            Refreshgoodscount();
        }

        /// <summary>
        /// 获取供应商
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (bgwsupplier.IsBusy)
            {
                bgwsupplier.CancelAsync();
            }
            else
            {
                DialogResult dr = MessageBox.Show("开始采集供应商信息？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dr != DialogResult.OK)
                {
                    return;
                }
                bgwsupplier.RunWorkerAsync(this);
                spro = new ShowProgress(bgwsupplier, "正在采集供应商信息");
                spro.ShowDialog(this);
            }
        }

        /// <summary>
        /// 设置供应商进度
        /// </summary>
        public void setsprogress()
        {
            lock (ojb)
            {
                ccurrcount++;
                string s = ccurrcount.ToString();
                if (this.InvokeRequired)//等待异步
                {
                    Delegateshowtoolstripstatus clsobj = new Delegateshowtoolstripstatus(
               delegate
               {
                   spro.setprogress(s + "/" + allcount, "", "当前进度", "");

               });
                    this.BeginInvoke(clsobj);
                }
                else
                {
                    spro.setprogress(s + "/" + allcount, "", "当前进度", "");
                }
            }
        }

        private void bgwsupplier_DoWork(object sender, DoWorkEventArgs e)
        {
            ccurrcount = 0;
            allcount = 0;
            allcount = spr.getsuppliers();
            int allpage = 1;
            if (allcount > 0)
            {
                float dc = (float)allcount / pagesize;
                allpage = (int)Math.Ceiling(dc);
                for (int i = 1; i <= allpage; i++)
                {
                    if (((BackgroundWorker)sender).CancellationPending)
                    {
                        e.Cancel = true;
                        return;
                    }
                    else
                    {
                        spr.start(i, pagesize);
                    }
                }
            }

        }

        private void bgwsupplier_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show("出错啦");
            }
            else if (e.Cancelled)
            {
                MessageBox.Show("已取消");
            }
            else
            {
                MessageBox.Show("完成");
                if (spro != null)
                {
                    spro.Close();
                }
            }
            bgwloadsupplier.RunWorkerAsync();
        }

        private void listBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedValue != null)
            {
                this.member = listBox1.SelectedValue.ToString();
                DataRowView my_row = (DataRowView)(listBox1.SelectedItem);
                this.suppliername = my_row["company"].ToString();
                querytype = 1;
                dataPage1.CurrentPage = 1;
                dataPage1.PageCount = 0;
                dataPage1.TotalCount = 0;
                dataPage1.PageSize = 20;
                Querygoodsbysupp(this.member);
            }
            else
            {
                this.member = "";
                this.suppliername = "";
                SetGoodsDetailinfoempty();
                dataPage1.CurrentPage = 1;
                dataPage1.PageCount = 0;
                dataPage1.TotalCount = 0;
                dataPage1.PageSize = 20;
                this.dataGridView1.AutoGenerateColumns = false;
                this.dataGridView1.DataSource = null;
            }
        }

        private void Querygoodsbysupp(string memeber)
        {
            int startindex = dataPage1.CurrentPage;
            int pagesize = dataPage1.PageSize;
            int totalcount = 0;
            DataSet ds = spr.queryproductbysupp_page(memeber, startindex, pagesize, out totalcount);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                string s = GetParentInfo(ds.Tables[0].Rows[i]["catid"].ToString());
                string[] sarr = s.Split('/');
                string st = "";
                for (int j = sarr.Length - 1; j >= 0; j--)
                {
                    if (sarr[j] != "")
                    {
                        st += sarr[j] + "/";
                    }
                }
                ds.Tables[0].Rows[i]["catname"] = st + ds.Tables[0].Rows[i]["catname"];
            }
            SetGoodsDetailinfoempty();
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.DataSource = null;
            this.dataGridView1.DataSource = ds.Tables[0];
            dataPage1.TotalCount = totalcount;
        }

        private void bgwsign_DoWork(object sender, DoWorkEventArgs e)
        {
            ccurrcount = 0;
            allcount = 0;
            scurrcount = 1;
            sallcount = 1;

            string mid = this.member;
            allcount = spr.getproduct(mid);
            int allpage = 1;
            if (allcount > 0)
            {
                float dc = (float)allcount / pagesize;
                allpage = (int)Math.Ceiling(dc);
                for (int i = 1; i <= allpage; i++)
                {
                    if (((BackgroundWorker)sender).CancellationPending)
                    {
                        e.Cancel = true;
                        return;
                    }
                    else
                    {
                        spr.getproductbypage(i, pagesize, mid);
                    }
                }
            }

        }

        private void bgwsign_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show("出错啦");
            }
            else if (e.Cancelled)
            {
                MessageBox.Show("已取消");
            }
            else
            {
                MessageBox.Show("完成");
                if (spro != null)
                {
                    spro.Close();
                }
            }
            listBox1_SelectedValueChanged(null, null);
            Refreshgoodscount();
        }

        private void bgwloadsupplier_DoWork(object sender, DoWorkEventArgs e)
        {
            DataSet dss = spr.querysuppliers();
            dssupp = dss;
        }

        private void bgwloadsupplier_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            showsuppliers(dssupp);
        }

        private void dataPage1_EventPaging(EventArgs e)
        {
            if (querytype == 0)
            {
                if (treeView1.SelectedNode != null)
                {
                    if (treeView1.SelectedNode.Nodes.Count < 1)
                    {
                        string catid = treeView1.SelectedNode.Tag.ToString();
                        string ss = treeView1.SelectedNode.Text;
                        GvDataBind(catid);
                    }
                }
            }
            else if (querytype == 1)
            {
                if (listBox1.SelectedItem != null)
                {
                    string memberid = listBox1.SelectedValue.ToString();
                    Querygoodsbysupp(memberid);
                }
            }
        }

        private void GvDataBind(string catid)
        {
            int startindex = dataPage1.CurrentPage;
            int pagesize = dataPage1.PageSize;
            int totalcount = 0;
            DataSet ds = spr.queryproductbycatid_page(catid, startindex, pagesize, out totalcount);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                string s = GetParentInfo(ds.Tables[0].Rows[i]["catid"].ToString());
                string[] sarr = s.Split('/');
                string st = "";
                for (int j = sarr.Length - 1; j >= 0; j--)
                {
                    if (sarr[j] != "")
                    {
                        st += sarr[j] + "/";
                    }
                }
                ds.Tables[0].Rows[i]["catname"] = st + ds.Tables[0].Rows[i]["catname"];
            }
            SetGoodsDetailinfoempty();
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.DataSource = null;
            this.dataGridView1.DataSource = ds.Tables[0];
            dataPage1.TotalCount = totalcount;
        }

        private string GetParentInfo(string catid)
        {
            string rv = "";
            if (diccateidali.ContainsKey(catid))
            {
                if (diccateidali.ContainsKey(diccateidali[catid]))
                {
                    rv += "/" + diccatenameali[diccateidali[catid]];
                    rv += GetParentInfo(diccateidali[catid]);
                }
            }
            return rv;
        }

        private void SetGoodsDetailinfoempty()
        {
            foreach (TabPage tp in tabControl2.TabPages)
            {
                foreach (Control ctr in tp.Controls)
                {
                    if (ctr is TextBox)//考虑是文本框的话
                    {
                        ((TextBox)ctr).Text = String.Empty;
                    }
                    else if (ctr is ComboBox)
                    {
                        ((ComboBox)ctr).Text = String.Empty;
                    }
                    else if (ctr is PictureBox)
                    {
                        ((PictureBox)ctr).ImageLocation = String.Empty;
                        ((PictureBox)ctr).Image = null;
                    }
                    else if (ctr is WebBrowser)
                    {
                        SetDetailContent("");
                    }
                }
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.GetNodeCount(true) < 1)
            {
                querytype = 0;
                dataPage1.CurrentPage = 1;
                dataPage1.PageCount = 0;
                dataPage1.TotalCount = 0;
                dataPage1.PageSize = 20;
                Application.DoEvents();
                dataPage1_EventPaging(e);
                int catid = Convert.ToInt32(e.Node.Tag);
                int c = spr.Hasgoods(catid);
                string[] strArray = e.Node.Text.Split('('); //字符串转数组
                e.Node.Text = strArray[0] + "(" + c.ToString() + ")";
            }
            else if (e.Node.Parent == null)
            {
                int c = spr.Hasallgoods();
                string[] strArray = e.Node.Text.Split('('); //字符串转数组
                e.Node.Text = strArray[0] + "(" + c.ToString() + ")";
            }
            else
            {
                string catid = e.Node.Tag.ToString();
                if (dicgoodscount.Keys.Contains(catid))
                {
                    e.Node.Text = diccatedata[catid] + "(" + dicgoodscount[catid] + ")";
                }
            }
        }

        public void SetDetailContent(string c)
        {
            webBrowser1.Document.InvokeScript("setContent", new object[] { c });
        }

        private void btnview_Click(object sender, EventArgs e)
        {
            string url = Application.StartupPath.ToString() + "/html/product.html";
            string content = this.content;
            this.Write(url, content);
            ShowProduct spr = new ShowProduct();
            spr.seturl(url, txtgoodstitle.Text);
            spr.ShowDialog(this);
        }


        public void Write(string url, string content)
        {
            FileStream fs = new FileStream(url, FileMode.Create);
            //获得字节数组
            byte[] data = Encoding.Default.GetBytes(content);
            //开始写入
            fs.Write(data, 0, data.Length);
            //清空缓冲区、关闭流
            fs.Flush();
            fs.Close();
        }

        private void MForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            bgloadcate.CancelAsync();
            System.Environment.Exit(0);
        }

        private void webBrowser1_Resize(object sender, EventArgs e)
        {
            this.webBrowser1.Refresh();
        }

        /// <summary>
        /// 单个修改商品
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnsave_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null || dataGridView1.CurrentRow.Index < 0)
            {
                return;
            }
            int rindex = dataGridView1.CurrentRow.Index;
            DataRow dr = (dataGridView1.Rows[rindex].DataBoundItem as DataRowView).Row;
            Product pt = new Product();

            if (string.Empty == txtgoodstitle.Text.Trim())
            {
                return;
            }

            if (string.Empty == txtsellprice.Text.Trim())
            {
                return;
            }

            if (string.Empty == txtprice.Text.Trim())
            {
                return;
            }

            if (string.Empty == txtjifenjiner.Text.Trim())
            {
                return;
            }

            pt.Goods_name = txtgoodstitle.Text.Trim();
            pt.Market_price = Convert.ToDecimal(txtsellprice.Text.Trim());
            pt.Shop_price = Convert.ToDecimal(txtprice.Text.Trim());
            pt.Integral = Convert.ToInt32(txtjifenjiner.Text.Trim());
            pt.Cat_id = Convert.ToInt32((txtgoodscate.Tag == null || txtgoodscate.Tag.ToString() == "") ? "0" : txtgoodscate.Tag.ToString());
            pt.Brand_id = Convert.ToInt32((cmbbrand.SelectedValue == null || cmbbrand.SelectedValue.ToString() == "") ? "0" : cmbbrand.SelectedValue.ToString());
            pt.Goods_number = Convert.ToUInt16(dr["goods_number"]);
            pt.Goods_weight = Convert.ToDecimal(dr["goods_weight"]);
            pt.Is_best = Convert.ToInt16(dr["is_best"]);
            pt.Is_new = Convert.ToInt16(dr["is_new"]);
            pt.Is_hot = Convert.ToInt16(dr["is_hot"]);
            pt.Is_shipping = Convert.ToInt16(dr["is_shipping"]);
            pt.Is_on_sale = Convert.ToInt16(dr["is_on_sale"]);
            pt.Goods_desc = this.content;
            pt.Goods_sn = dr["goods_sn"].ToString();
            bool b = spr.UpdateProduct(pt);
            if (b)
            {
                dataGridView1.CurrentRow.Cells["goods_name"].Value = pt.Goods_name;
                dataGridView1.CurrentRow.Cells["market_price"].Value = pt.Market_price;
                dataGridView1.CurrentRow.Cells["shop_price"].Value = pt.Shop_price;
                dataGridView1.CurrentRow.Cells["cat_id"].Value = pt.Cat_id;
                dataGridView1.CurrentRow.Cells["brand_id"].Value = pt.Brand_id;
                dataGridView1.CurrentRow.Cells["goods_desc"].Value = pt.Goods_desc;
                dataGridView1.CurrentRow.Cells["integral"].Value = pt.Integral;
                Refreshgoodscount();
                MessageBox.Show("保存成功！");
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

        /// <summary>
        /// 批量删除商品
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            DataTable TotalDT = (DataTable)dataGridView1.DataSource;
            if (TotalDT == null)
            {
                return;
            }
            string pids = "";
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                DataGridViewCheckBoxCell checkCell = (DataGridViewCheckBoxCell)this.dataGridView1.Rows[i].Cells["colcheck"];
                if (checkCell != null && ((bool)checkCell.EditingCellFormattedValue == true || (bool)checkCell.FormattedValue == true))
                {
                    pids += "'" + this.dataGridView1.Rows[i].Cells["goods_sn"].Value.ToString() + "',";
                }
            }
            if (pids != "")
            {
                DialogResult dr = MessageBox.Show("您确定删除吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dr != DialogResult.OK)
                {
                    return;
                }
                pids = pids.TrimEnd(',');
                bool b = spr.deleteproductbyid(pids);
                if (b)
                {
                    MessageBox.Show("删除完成！");
                    dataPage1_EventPaging(e);
                    Refreshgoodscount();
                }
            }
            else
            {
                MessageBox.Show("请勾选需要删除的商品？", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ckball_CheckedChanged(object sender, EventArgs e)
        {
            if (ckball.Checked == true)
            {
                for (int i = 0; i < this.dataGridView1.Rows.Count; i++)
                {
                    this.dataGridView1.Rows[i].Cells["colcheck"].Value = true;
                }
            }
            else
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    this.dataGridView1.Rows[i].Cells["colcheck"].Value = false;
                }
            }

        }

        private void ckbbest_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbbest.Checked == true)
            {
                for (int i = 0; i < this.dataGridView1.Rows.Count; i++)
                {
                    this.dataGridView1.Rows[i].Cells["is_best"].Value = true;
                }
            }
            else
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    this.dataGridView1.Rows[i].Cells["is_best"].Value = false;
                }
            }
        }

        private void ckbnew_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbnew.Checked == true)
            {
                for (int i = 0; i < this.dataGridView1.Rows.Count; i++)
                {
                    this.dataGridView1.Rows[i].Cells["is_new"].Value = true;
                }
            }
            else
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    this.dataGridView1.Rows[i].Cells["is_new"].Value = false;
                }
            }
        }

        private void ckbhot_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbhot.Checked == true)
            {
                for (int i = 0; i < this.dataGridView1.Rows.Count; i++)
                {
                    this.dataGridView1.Rows[i].Cells["is_hot"].Value = true;
                }
            }
            else
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    this.dataGridView1.Rows[i].Cells["is_hot"].Value = false;
                }
            }
        }

        private void ckbshipping_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbshipping.Checked == true)
            {
                for (int i = 0; i < this.dataGridView1.Rows.Count; i++)
                {
                    this.dataGridView1.Rows[i].Cells["is_shipping"].Value = true;
                }
            }
            else
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    this.dataGridView1.Rows[i].Cells["is_shipping"].Value = false;
                }
            }
        }

        private void ckbonsale_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbonsale.Checked == true)
            {
                for (int i = 0; i < this.dataGridView1.Rows.Count; i++)
                {
                    this.dataGridView1.Rows[i].Cells["is_on_sale"].Value = true;
                }
            }
            else
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    this.dataGridView1.Rows[i].Cells["is_on_sale"].Value = false;
                }
            }
        }

        /// <summary>
        /// 上传商品
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            //DataTable TotalDT = (DataTable)dataGridView1.DataSource;
            //if (TotalDT == null)
            //{
            //    return;
            //}

            ////克隆一个表结构  
            //DataTable gridSelectDT = TotalDT.Clone();
            //string goods_sn = "";
            //for (int i = 0; i < dataGridView1.Rows.Count; i++)
            //{
            //    DataGridViewCheckBoxCell checkCell = (DataGridViewCheckBoxCell)this.dataGridView1.Rows[i].Cells["colcheck"];
            //    if (checkCell != null && ((bool)checkCell.EditingCellFormattedValue == true || (bool)checkCell.FormattedValue == true))
            //    {
            //        DataRow dr = (dataGridView1.Rows[i].DataBoundItem as DataRowView).Row;
            //        object[] obj = dr.ItemArray;
            //        gridSelectDT.Rows.Add(obj);
            //        DataRow drnew = gridSelectDT.Rows[gridSelectDT.Rows.Count - 1];
            //        drnew["goods_thumb"] = GetGoodsImgUrl(drnew["goods_thumb"].ToString());
            //        goods_sn += "'" + dr["goods_sn"].ToString() + "',";
            //    }
            //}
            //if (gridSelectDT.Rows.Count > 0)
            //{
            //    DialogResult dr = MessageBox.Show("您确定上传商品吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            //    if (dr != DialogResult.OK)
            //    {
            //        return;
            //    }
            //    bool b = spr.Uploadgoods(gridSelectDT);
            //    if (b)
            //    {
            //        goods_sn = goods_sn.TrimEnd(',');
            //        spr.setgoodsstatus(goods_sn);
            //        dataPage1_EventPaging(e);
            //        MessageBox.Show("上传完成！");
            //    }
            //}
            //else {
            //    MessageBox.Show("请勾选需要上传的商品？", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
            ButtonUpload();
        }

        private void ButtonUpload()
        {
            DataTable TotalDT = (DataTable)dataGridView1.DataSource;
            if (TotalDT == null)
            {
                return;
            }

            DataTable gridSelectDT = TotalDT.Clone();
            string goods_sn = "";
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                DataGridViewCheckBoxCell checkCell = (DataGridViewCheckBoxCell)this.dataGridView1.Rows[i].Cells["colcheck"];
                if (checkCell != null && ((bool)checkCell.EditingCellFormattedValue == true || (bool)checkCell.FormattedValue == true))
                {
                    DataRow dr = (dataGridView1.Rows[i].DataBoundItem as DataRowView).Row;
                    object[] obj = dr.ItemArray;
                    gridSelectDT.Rows.Add(obj);
                    goods_sn += "'" + dr["goods_sn"].ToString() + "',";
                }
            }
            if (gridSelectDT.Rows.Count > 0)
            {
                DialogResult dr = MessageBox.Show("您确定上传商品吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dr != DialogResult.OK)
                {
                    return;
                }
                Program.mfloadflag = "";
                FormRefresh frm = new FormRefresh();
                frm.WindowState = FormWindowState.Normal;
                frm.setprogress(0, gridSelectDT.Rows.Count);
                frm.Show();
                Application.DoEvents();
                Dictionary<string, string> dic = new Dictionary<string, string>();
                for (int i=0;i<gridSelectDT.Rows.Count;i++)
                {
                    DataTable dt = spr.QueryGoodsbyProductid(gridSelectDT.Rows[i]["goods_sn"].ToString());
                    dic.Clear();
                    dic.Add("imagelist", dt.Rows[0]["imagelist"].ToString ());
                    dic.Add("saleinfo", dt.Rows[0]["saleinfo"].ToString());
                    dic.Add("productTitle", dt.Rows[0]["productTitle"].ToString());
                    dic.Add("productID", dt.Rows[0]["productID"].ToString());
                    dic.Add("desction", dt.Rows[0]["desction"].ToString());
                    dic.Add("skumodelstr", dt.Rows[0]["skumodelstr"].ToString());
                    dic.Add("skuInfos", dt.Rows[0]["skuInfos"].ToString());
                    dic.Add("detailpara", dt.Rows[0]["detailpara"].ToString());
                    dic.Add("shop_price", gridSelectDT.Rows[i]["shop_price"].ToString());
                    dic.Add("market_price", gridSelectDT.Rows[i]["market_price"].ToString());
                    dic.Add("category_id", gridSelectDT.Rows[i]["cat_id"].ToString());
                    uploaddsc(dic);
                    frm.setprogress(i+1, gridSelectDT.Rows.Count);
                    Application.DoEvents();
                }
                goods_sn = goods_sn.TrimEnd(',');
                spr.setgoodsstatus(goods_sn);
                dataPage1_EventPaging(null);
                MessageBox.Show("上传完成！");
                Program.mfloadflag = "OK";
            }
            else
            {
                MessageBox.Show("请勾选需要上传的商品？", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }



        private void tvcat_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.GetNodeCount(true) < 1)
            {
                txtgoodscate.Text = e.Node.Text;
                txtgoodscate.Tag = e.Node.Tag;
                tvcat.Hide();
            }
        }

        private void txtgoodscate_Enter(object sender, EventArgs e)
        {
            tvcat.Show();
        }

        private void tvcat_Leave(object sender, EventArgs e)
        {
            tvcat.Hide();
        }

        private void txtgoodscate_Leave(object sender, EventArgs e)
        {
            if (!tvcat.Focused)
            {
                tvcat.Hide();
            }
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            Relcate rc = new Relcate(spr);
            rc.Loaderdata(dtcateali, dtcate, diccatedata);
            rc.ShowDialog(this);
        }

        private void bgwrefreshgoods_DoWork(object sender, DoWorkEventArgs e)
        {
            Getgoodscount();
        }

        private void bgwrefreshgoods_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            int allcount = 0;
            allcount = spr.Hasallgoods();
            string[] strArray = treeView1.Nodes[0].Text.Split('('); //字符串转数组
            treeView1.Nodes[0].Text = strArray[0] + "(" + allcount + ")";

            string[] strArray1 = treeView1.Nodes[0].Nodes[0].Text.Split('('); //字符串转数组
            if (dicgoodscount.Keys.Contains("0"))
            {
                treeView1.Nodes[0].Nodes[0].Text = strArray1[0] + "(" + dicgoodscount["0"] + ")";
            }
            else
            {
                treeView1.Nodes[0].Nodes[0].Text = strArray1[0] + "(0)";
            }

            foreach (TreeNode tn in treeView1.Nodes[0].Nodes)
            {
                string catid = tn.Tag.ToString();
                if (catid != "0")
                {
                    if (dicgoodscount.Keys.Contains(catid))
                    {
                        Application.DoEvents();
                        tn.Text = diccatedata[catid] + "(" + dicgoodscount[catid] + ")";
                    }
                }
            }
            Program.mfloadflag = "OK";
        }
        public void Refreshgoodscount()
        {
            bgwrefreshgoods.RunWorkerAsync();
        }

        private void listBox1_Leave(object sender, EventArgs e)
        {
            //this.member = "";
            //this.suppliername = "";
        }

        private void btnsuppsousou_Click(object sender, EventArgs e)
        {
            if (txtsuppsousou.Text.Trim() != "")
            {
                string soutext = txtsuppsousou.Text.Trim();
                Setlistselected(soutext);
            }
        }

        private void Setlistselected(string text)
        {
            dicquerysupp.Clear();
            listBox1.SelectedItem = null;
            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                string company = ((DataRowView)listBox1.Items[i])["company"].ToString();
                if (company.Contains(text))
                {
                    dicquerysupp.Add(i, company);
                }
            }
            if (dicquerysupp.Keys.Count > 0)
            {
                if (listBox1.TopIndex == dicquerysupp.Keys.First())
                {
                    listBox1.Refresh();
                    //listBox1.TopIndex = dicquerysupp.Keys.First();
                }
                else
                {
                    // listBox1.Refresh();
                    listBox1.TopIndex = dicquerysupp.Keys.First();
                }
            }
            else
            {
                if (listBox1.TopIndex == 0)
                {
                    listBox1.Refresh();
                }
                else
                {
                    listBox1.TopIndex = 0;
                }
            }
        }
        Dictionary<int, string> dicquerysupp = new Dictionary<int, string>();

        private void listBox1_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0)
            {
                return;
            }
            Color vColor = e.ForeColor;
            string s = (((ListBox)sender).Items[e.Index] as DataRowView)["company"].ToString();
            if (dicquerysupp.Values.Contains(s))
            {
                vColor = Color.Red;
            }
            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            {
                e.Graphics.FillRectangle(new SolidBrush(Color.Blue), e.Bounds);
                //e.Graphics.DrawString(s, e.Font, new SolidBrush(Color.White), e.Bounds);
                TextRenderer.DrawText(e.Graphics, s, e.Font, e.Bounds, Color.White, TextFormatFlags.VerticalCenter | TextFormatFlags.Left);
            }
            else
            {
                e.Graphics.FillRectangle(new SolidBrush(e.BackColor), e.Bounds);
                //e.Graphics.DrawString(s, e.Font,new SolidBrush(vColor), e.Bounds);
                TextRenderer.DrawText(e.Graphics, s, e.Font, e.Bounds, vColor, TextFormatFlags.VerticalCenter | TextFormatFlags.Left);
                e.DrawFocusRectangle();
            }
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string goods_sn = this.dataGridView1.CurrentRow.Cells["goods_sn"].Value.ToString();
            txtgoodstitle.Text = this.dataGridView1.CurrentRow.Cells["goods_name"].Value.ToString();
            txtsellprice.Text = this.dataGridView1.CurrentRow.Cells["market_price"].Value.ToString();
            txtprice.Text = this.dataGridView1.CurrentRow.Cells["shop_price"].Value.ToString();
            cmbbrand.SelectedValue = this.dataGridView1.CurrentRow.Cells["brand_id"].Value.ToString();
            txtjifenjiner.Text = this.dataGridView1.CurrentRow.Cells["integral"].Value.ToString();
            string img = this.dataGridView1.CurrentRow.Cells["goods_thumb"].Value.ToString();
            if (img != string.Empty)
            {
                string picurl = GetGoodsImgUrl(img);
                pictureBox1.ImageLocation = picurl; ;
            }
            this.content = dataGridView1.CurrentRow.Cells["goods_desc"].Value.ToString();
            SetDetailContent(content);

            string dd = this.dataGridView1.CurrentRow.Cells["cat_id"].Value.ToString();
            txtgoodscate.Text = (diccatedata.Keys.Contains(dd) == true) ? diccatedata[dd] : "";
            txtgoodscate.Tag = dd;
        }

        /// <summary>
        /// 上传商品图片
        /// </summary>
        /// <param name="picurl"></param>
        private string[] UploadImg(string picurl)
        {
            HttpImg htimg = new HttpImg();
            Stream sm = htimg.htmlimg(picurl);
            Image img = Image.FromStream(sm);
            string[] imgs = new string[3] { "", "", "" };
            string goods_thumb = "";
            string goods_img = "";
            string original_img = "";
            imgs[0] = goods_thumb;
            imgs[1] = goods_img;
            imgs[2] = original_img;
            return imgs;
        }

        /// <summary>
        /// 获取商品原图地址URL
        /// </summary>
        /// <param name="spath"></param>
        /// <returns></returns>
        private string GetGoodsImgUrl(string spath)
        {
            int p2 = spath.LastIndexOf('.');
            int p1 = spath.IndexOf('.');
            string picurl = "";
            if (p1 != p2)
            {
                picurl = spath.Substring(0, p1) + "." + spath.Substring(p2 + 1);
            }
            else
            {
                picurl = spath;
            }

            string url = "https://cbu01.alicdn.com/";
            if (!picurl.Contains("https://"))
            {
                picurl = url + picurl;
            }
            return picurl;
        }

        /// <summary>
        /// 保存图片到本地
        /// </summary>
        /// <param name="img"></param>
        /// <param name="imgname"></param>
        private void SaveImg(Image img, string imgname)
        {
            if (!Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + @"image\"))
            {
                Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + @"image\");
            }
            string tempFileName = AppDomain.CurrentDomain.BaseDirectory + @"image\" + imgname + ".jpg";
            img.Save(tempFileName, img.RawFormat);
        }


        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            btnview.PerformClick();
        }

        private void txtsuppsousou_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                btnsuppsousou.PerformClick();
            }
        }

        private void txtsuppsousou_Enter(object sender, EventArgs e)
        {
            if (txtsuppsousou.Text.Trim() == "请输入供应商名称")
            {
                txtsuppsousou.Text = "";
                txtsuppsousou.ForeColor = SystemColors.WindowText;
            }
        }

        private void txtsuppsousou_Leave(object sender, EventArgs e)
        {
            if (txtsuppsousou.Text.Trim() == "")
            {
                txtsuppsousou.ForeColor = Color.Gainsboro;
                txtsuppsousou.Text = "请输入供应商名称";
            }

        }

        private void dataGridView1_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dataGridView1.IsCurrentCellDirty)
            {
                dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            FormBatch frm = new FormBatch(dtbrand, dtcate, spr);
            frm.ShowDialog(this);
        }

        private void btnrefreshcount_Click(object sender, EventArgs e)
        {
            Program.mfloadflag = "";
            Refreshgoodscount();
            FormRefresh frm = new FormRefresh();
            frm.Size = new Size(0, 0);
            frm.Show();
        }

        private void btnproductprice_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null || dataGridView1.CurrentRow.Index < 0)
            {
                return;
            }
            int rindex = dataGridView1.CurrentRow.Index;
            string productid = dataGridView1.CurrentRow.Cells["goods_sn"].Value.ToString ();
            DataTable dt=  spr.QueryGoodsbyProductid(productid);
            if (dt != null && dt.Rows.Count > 0)
            {
                string skuinfo = dt.Rows[0]["skuInfos"].ToString();
                string shopprice = dt.Rows[0]["extendinfos"].ToString();
                if (skuinfo == "" || skuinfo == null || skuinfo == "null")
                {

                }
                else
                {
                    string proxyprice = dataGridView1.CurrentRow.Cells["shop_price"].Value.ToString();
                    FormProductPrice frm = new FormProductPrice(skuinfo, shopprice,proxyprice);
                    frm.ShowDialog(this);
                }
            }
        }

        private void listBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (this.member != "" && listBox1.SelectedItem != null)
                {
                    toolStripButton3.PerformClick();
                }
            }
        }

        /// <summary>
        /// 上传商品到大商创
        /// </summary>
        private void uploaddsc(Dictionary<string,string>dic)
        {
            int is_on_sale = 1;//1上架，0下架
            int category_id = 0;//商品分类id
            int cat_id = 0;//商品类型，0普通商品
            string url = "https://cbu01.alicdn.com/";
            dscapi.gdsdk.GoodRequest gr = new dscapi.gdsdk.GoodRequest(url);
            string imagelist = dic["imagelist"];
            string producttitle = dic["productTitle"];
            string productid = dic["productID"];
            string saleinfo = dic["saleinfo"];
            string skuinfos = dic["skuInfos"];
            string skumodelstr = dic["skumodelstr"];
            string detailpara = dic["detailpara"];
            string desction = dic["desction"];
            string[]  imglst= imagelist.Split(',');
            category_id = int.Parse(dic["category_id"]);
            JObject saleobj = (JObject)JsonConvert.DeserializeObject(saleinfo);
            if (saleobj["quoteType"].ToString() == "0")
            {
                cat_id = 0;
                float shop_price = 0f;
                float market_price = 0f ;
                shop_price = float.Parse(dic["shop_price"]);
                market_price = float.Parse(dic["market_price"]);
                int goods_id = gr.setgoods(category_id, saleinfo, producttitle, productid, cat_id, skumodelstr, is_on_sale, shop_price, market_price);
                Dictionary<string, JObject> uploadimg = gr.updategoodsdesc(goods_id, imglst, desction);
                gr.dspec.GoodDetailPara(detailpara, goods_id, cat_id);
            }
            else
            {
                cat_id = gr.setgoodstypecat(productid + "_" + producttitle);
                float shop_price = 0f;
                float market_price = 0f;
                shop_price = float.Parse(dic["shop_price"]);
                market_price = float.Parse(dic["market_price"]);
                int goods_id = gr.setgoods(category_id, saleinfo, producttitle, productid, cat_id, skumodelstr, is_on_sale,shop_price,market_price);
                Dictionary<string, JObject> uploadimg = gr.updategoodsdesc(goods_id, imglst, desction);
                gr.setspec(skumodelstr, skuinfos, goods_id, cat_id, uploadimg);
                gr.dspec.GoodDetailPara(detailpara, goods_id, cat_id);
            }
        }
    }
}
