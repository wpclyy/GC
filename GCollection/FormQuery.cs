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
    public partial class FormQuery : Form
    {

        Dictionary<string, string> diccate = new Dictionary<string, string>();

        Dictionary<string, string> dicbrand = new Dictionary<string, string>();

        public FormQuery(DataTable dt1, DataTable dt2)
        {
            InitializeComponent();
            Loadcate_brand(dt1,dt2);
        }

        public void  Loadcate_brand(DataTable dtbrand,DataTable dtcate)
        {
            for (int i = 0; i < dtbrand.Rows.Count; i++)
            {
                dicbrand.Add(dtbrand.Rows[i]["brand_id"].ToString(), dtbrand.Rows[i]["brand_name"].ToString());
            }
            for (int i = 0; i < dtcate.Rows.Count; i++)
            {
                diccate.Add(dtcate.Rows[i]["cat_id"].ToString(), dtcate.Rows[i]["cat_name"].ToString());
            }
        }

        public void SetDataSource(DataTable dt)
        {
            if (dt != null)
            {
                dt.Columns.Add("cat_name", typeof(string)); //数据类型为 文本
                dt.Columns.Add("brand_name", typeof(string)); //数据类型为 文本
                dt.Columns.Add("best", typeof(string)); //数据类型为 文本
                dt.Columns.Add("new", typeof(string)); //数据类型为 文本
                dt.Columns.Add("hot", typeof(string)); //数据类型为 文本
                dt.Columns.Add("onsale", typeof(string)); //数据类型为 文本
                dt.Columns.Add("shipping", typeof(string)); //数据类型为 文本
                lblcount.Text = "共有(" + dt.Rows.Count + ")条商品";
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string brand_id = dt.Rows[i]["brand_id"].ToString();
                    string cat_id = dt.Rows[i]["cat_id"].ToString();
                    string brand_name = "";
                    string cat_name = "";
                    brand_name = dicbrand.ContainsKey(brand_id) ? dicbrand[brand_id] : "";
                    cat_name = diccate.ContainsKey(cat_id) ? diccate[cat_id] : "";

                    dt.Rows[i]["cat_name"] = cat_name;
                    dt.Rows[i]["brand_name"] = brand_name;
                    dt.Rows[i]["best"] = dt.Rows[i]["is_best"].ToString()=="1"?"是":"否";
                    dt.Rows[i]["new"] = dt.Rows[i]["is_new"].ToString() == "1" ? "是" : "否"; 
                    dt.Rows[i]["hot"] = dt.Rows[i]["is_hot"].ToString() == "1" ? "是" : "否"; 
                    dt.Rows[i]["onsale"] = dt.Rows[i]["is_on_sale"].ToString() == "1" ? "是" : "否";;
                    dt.Rows[i]["shipping"] = dt.Rows[i]["is_shipping"].ToString() == "1" ? "是" : "否";;
                }
                DataGridViewTextBoxColumn cbest = new DataGridViewTextBoxColumn();
                cbest.Name = "best";
                cbest.DataPropertyName = "best";
                cbest.HeaderText = "精品";

                DataGridViewTextBoxColumn cnew = new DataGridViewTextBoxColumn();
                cnew.Name = "new";
                cnew.DataPropertyName = "new";
                cnew.HeaderText = "新品";

                DataGridViewTextBoxColumn chot = new DataGridViewTextBoxColumn();
                chot.Name = "hot";
                chot.DataPropertyName = "hot";
                chot.HeaderText = "热销";

                DataGridViewTextBoxColumn consale = new DataGridViewTextBoxColumn();
                consale.Name = "onsale";
                consale.DataPropertyName = "onsale";
                consale.HeaderText = "上架";

                DataGridViewTextBoxColumn cshipping = new DataGridViewTextBoxColumn();
                cshipping.Name = "shipping";
                cshipping.DataPropertyName = "shipping";
                cshipping.HeaderText = "免邮费";

                dataGridView1.Columns.Add(cbest);
                dataGridView1.Columns.Add(cnew);
                dataGridView1.Columns.Add(chot);
                dataGridView1.Columns.Add(consale);
                dataGridView1.Columns.Add(cshipping);
                dataGridView1.DataSource = dt;
            }
        }
    }
}
