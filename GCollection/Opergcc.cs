using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCollection
{
   public class Opergcc
    {
        /// <summary>
        /// 本地数据库链接字符串
        /// </summary>
        string str = "server=192.168.2.88;user id=Fany;password=wang198912;database=gcollection";

         /// <summary>
        /// 购低网数据库链接字符串
        /// </summary>
        string strdsc = "server=192.168.2.88;user id=Fany;password=wang198912;database=dasc";

        /// <summary>
        /// 查询供应商
        /// </summary>
        /// <returns></returns>
        public DataSet querysuppliers()
        {
            DataSet retSet = new DataSet();
            retSet = MySqlHelper.GetDataSet(str, "select * from supplier ");
            return retSet;
        }

        /// <summary>
        /// 查询商品分类
        /// </summary>
        /// <returns></returns>
        public DataSet querycate()
        {
            DataSet retSet = new DataSet();
            retSet = MySqlHelper.GetDataSet(str, "select * from category ");
            return retSet;
        }

        /// <summary>
        /// 根据商品分类ID查询商品
        /// </summary>
        /// <param name="catid"></param>
        /// <returns></returns>
        public DataSet queryproductsbycatid(string catid)
        {
            DataSet retSet = new DataSet();
            retSet = MySqlHelper.GetDataSet(str, "select * from productinfo where catId='" + catid + "'");
            return retSet;
        }

        /// <summary>
        /// 分页搜索根据分类ID搜索商品
        /// </summary>
        /// <param name="catid"></param>
        /// <param name="currentpage"></param>
        /// <param name="pagesize"></param>
        /// <param name="totalcount"></param>
        /// <returns></returns>
        public DataSet queryproductbycatid_page(string catid, int currentpage, int pagesize, out int totalcount)
        {
            totalcount = 0;
            DataSet dss = MySqlHelper.GetDataSet(str, "select  count(*) as totalcount from goods b  where b.cat_id='" + catid + "'");
            totalcount = int.Parse(dss.Tables[0].Rows[0]["totalcount"].ToString());
            string sql = "select CASE c.status WHEN 1 THEN '已上传' ELSE '未上传' END as status,c.goods_sn,c.goods_name,c.cat_id,c.brand_id,c.goods_number,c.goods_weight,c.market_price,c.shop_price,c.is_best,c.is_new,c.is_hot,c.is_shipping,c.is_on_sale,c.goods_thumb,c.goods_desc,c.integral,b.catname,a.catId as catid from productinfo  a left join category b on a.catId=b.catid left join goods c on a.productID=c.goods_sn  where c.cat_id='" + catid + "' limit " + ((currentpage - 1) * pagesize) + "," + pagesize;
            DataSet retSet = new DataSet();
            retSet = MySqlHelper.GetDataSet(str, sql);
            return retSet;
        }

        /// <summary>
        /// 分页搜索根据供应商搜索商品
        /// </summary>
        /// <param name="memberid"></param>
        /// <param name="currentpage"></param>
        /// <param name="pagesize"></param>
        /// <param name="totalcount"></param>
        /// <returns></returns>
        public DataSet queryproductbysupp_page(string memberid, int currentpage, int pagesize, out int totalcount)
        {
            totalcount = 0;
            DataSet dss = MySqlHelper.GetDataSet(str, "select  count(*) as totalcount from productinfo a  left join goods b on a.productID=b.goods_sn where a.memberid='" + memberid + "'");
            totalcount = int.Parse(dss.Tables[0].Rows[0]["totalcount"].ToString());
            string sql = "select CASE c.status WHEN 1 THEN '已上传' ELSE '未上传' END as status,c.goods_sn,c.goods_name,c.cat_id,c.brand_id,c.goods_number,c.goods_weight,c.market_price,c.shop_price,c.is_best,c.is_new,c.is_hot,c.is_shipping,c.is_on_sale,c.goods_thumb,c.goods_desc,c.integral,b.catname ,a.catId as catid from productinfo  a left join category b on a.catId=b.catid left join goods c on a.productID=c.goods_sn  where a.memberid='" + memberid + "' limit " + ((currentpage - 1) * pagesize) + "," + pagesize;
            DataSet retSet = new DataSet();
            retSet = MySqlHelper.GetDataSet(str, sql);
            return retSet;
        }

        /// <summary>
        /// 批量删除根据商品ID删除商品
        /// </summary>
        /// <param name="pids"></param>
        /// <returns></returns>
        public bool deleteproductbyid(string pids)
        {
            string sql1 = "delete from productinfo where productID in(" + pids + ")";
            string sql2 = "delete from goods where goods_sn in(" + pids + ")";
            string[] sql = new string[2];
            sql[0] = sql1;
            sql[1] = sql2;
            MySqlParameter[][] parms = new MySqlParameter[2][];
            parms[0] = null;
            parms[1] = null;
            bool b = MySqlHelper.ExecuteTransaction(str, CommandType.Text, sql, parms);
            return b;
        }

        /// <summary>
        /// 根据条件查询商品
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public DataTable QueryConditionGoods(string condition)
        {
            DataSet retSet = new DataSet();
            retSet = MySqlHelper.GetDataSet(str, "select  goods_id,goods_sn,goods_name,goods_weight,goods_number,brand_id,cat_id,is_best,is_new,is_hot,is_on_sale,is_shipping,shop_price,market_price from goods  where " + condition);
            return retSet.Tables[0];
        }

        /// <summary>
        /// 批量修改商品
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public bool UpdateProducts(string conditions, string goods_sn)
        {
            string sql = "update goods set ";
            string where = "  where goods_sn in(" + goods_sn + ")";
            sql += conditions + where;
            int c = MySqlHelper.ExecuteNonQuery(str, CommandType.Text, sql);
            if (c >= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 单个修改商品
        /// </summary>
        /// <returns></returns>
        public bool UpdateProduct(Product p)
        {
            string sql = "update  goods set  goods_name='" + p.Goods_name + "', market_price=" + p.Market_price + ",shop_price=" + p.Shop_price
                + ",integral=" + p.Integral + ",cat_id=" + p.Cat_id + ",brand_id=" + p.Brand_id + ",goods_number=" + p.Goods_number + ",goods_weight=" + p.Goods_weight
                + ",is_best=" + p.Is_best + ",is_new=" + p.Is_new + ",is_hot=" + p.Is_hot + ",is_shipping=" + p.Is_shipping + ",is_on_sale=" + p.Is_on_sale
                + ",goods_desc='" + p.Goods_desc + "'";
            string where = "  where goods_sn='" + p.Goods_sn + "'";
            sql += where;
            int c = MySqlHelper.ExecuteNonQuery(str, CommandType.Text, sql);
            if (c >= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 查询大商创的商品分类
        /// </summary>
        /// <returns></returns>
        public DataSet Querydsccate()
        {
            DataSet retSet = new DataSet();
            retSet = MySqlHelper.GetDataSet(strdsc, "select * from dsc_category ");
            return retSet;
        }

        /// <summary>
        ///     查询大商创的品牌
        /// </summary>
        /// <returns></returns>
        public DataSet Querydscbrand()
        {
            DataSet retSet = new DataSet();
            retSet = MySqlHelper.GetDataSet(strdsc, "select * from dsc_brand ");
            return retSet;
        }

        /// <summary>
        /// 关联商品分类
        /// </summary>
        /// <param name="catid"></param>
        /// <param name="gcatid"></param>
        /// <param name="gcatname"></param>
        /// <returns></returns>
        public int Relcate(string catid, string gcatid, string gcatname)
        {
            string sqlrelcate = "update category set gcatid='" + gcatid + "',gcatname='" + gcatname + "'  where catid='" + catid + "'";
            string sqlcatgoods = "select productID from productinfo where catId='" + catid + "'";
            string sqlr = "update goods set cat_id=" + gcatid + " where goods_sn in (" + sqlcatgoods + ")";

            string[] sql = new string[2];
            sql[0] = sqlrelcate;
            sql[1] = sqlr;
            MySqlParameter[][] parms = new MySqlParameter[2][];
            parms[0] = null;
            parms[1] = null;
            bool b = MySqlHelper.ExecuteTransaction(str, CommandType.Text, sql, parms);
            if (b)
            {
                return 1;
            }
            else
            {
                return 0;
            }

        }

        /// <summary>
        /// 获取绑定商品分类的商品个数
        /// </summary>
        /// <returns></returns>
        public int Hasgoods(int catid)
        {
            int c = 0;
            object obj = MySqlHelper.ExecuteScalar(str, CommandType.Text, "select count(*) from goods where cat_id=" + catid);
            c = Convert.ToInt32(obj);
            return c;
        }

        /// <summary>
        /// 查询分类商品数量
        /// </summary>
        /// <returns></returns>
        public DataTable Hasgoods()
        {
            string sql = "select cat_id, count(*) as count from goods group by cat_id";
            DataSet ds = MySqlHelper.GetDataSet(str, sql);
            return ds.Tables[0];
        }

        /// <summary>
        /// 获取全部商品个数
        /// </summary>
        /// <returns></returns>
        public int Hasallgoods()
        {
            int c = 0;
            object obj = MySqlHelper.ExecuteScalar(str, CommandType.Text, "select count(*) from goods");
            c = Convert.ToInt32(obj);
            return c;
        }

        /// <summary>
        /// 更新商品状态
        /// </summary>
        /// <param name="goods_sn"></param>
        /// <returns></returns>
        public int setgoodsstatus(string goods_sn)
        {
            string sql = "update goods set status=1 where goods_sn in(" + goods_sn + ")";
            int c = MySqlHelper.ExecuteNonQuery(str, CommandType.Text, sql);
            return c;
        }

        /// <summary>
        /// 根据商品编码获取商品信息
        /// </summary>
        /// <param name="productid"></param>
        /// <returns></returns>
        public DataTable QueryGoodsbyProductid(string productid)
        {
            string sql = "select * from productinfo where productID='" + productid + "'";
            DataSet ds = MySqlHelper.GetDataSet(str, sql);
            return ds.Tables[0];
        }

        /// <summary>
        /// 修改商品货品价格和库存
        /// </summary>
        /// <param name="productid"></param>
        /// <param name="skustr"></param>
        /// <param name="skuinfos"></param>
        /// <returns></returns>
        public int SaveSkumodelstrAndsaleinfos(string  productid,string skustr,string skuinfos)
        {
            string sql = "update productinfo set skumodelstr='"+ skustr + "',skuInfos='"+ skuinfos + "' where productID ='" + productid + "'";
            int c = MySqlHelper.ExecuteNonQuery(str, CommandType.Text, sql);
            return c;
        }
    }
}
