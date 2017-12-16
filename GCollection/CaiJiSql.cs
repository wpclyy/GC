using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCollection
{
    /*数据库业务操作类*/
    public class CaiJiSql
    {
        string Connection = "";
        public CaiJiSql()
        {
            Connection = Config.Connection;
        }

        /// <summary>
        /// 判断数据库链接是否成功
        /// </summary>
        /// <returns></returns>
        public bool ConnectTestW()
        {
            bool result = false;
            //创建连接对象
            MySqlConnection connection = new MySqlConnection(Connection);
            try
            {
                connection.Open();
                if (connection.State == ConnectionState.Open)
                {
                    //连接成功
                    result = true;
                }
                else
                {
                    //连接失败
                }
            }
            catch
            {
                //连接失败
            }
            finally
            {
                connection.Close();
            }
            return result;
        }

        /// <summary>
        /// 查询商品分类返回已存在分类
        /// </summary>
        /// <param name="catids"></param>
        /// <returns></returns>
        public string[] QueryCate(string catids)
        {
            if (catids == string.Empty)
            {
                return null;
            }
            DataSet  ds=MySqlHelper.GetDataSet(Connection, "select catid from category where catid  in(" + catids + ")");
            List<string> listS = new List<string>();
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                string s = row["catid"].ToString();
                listS.Add(s);
            }
            string[] marray = listS.ToArray();
            return marray;
        }

        /// <summary>
        /// 插入新的分类
        /// </summary>
        /// <param name="cateinfo"></param>
        /// <returns></returns>
        public int InsertCate(Category cateinfo)
        {
            MySqlParameter[] parm = {
                  MySqlHelper.CreateInParam("@catid", MySqlDbType.VarChar, 100, cateinfo.Catid),
                  MySqlHelper.CreateInParam("@catname",     MySqlDbType.VarChar,  100,    cateinfo.Catname),
                  MySqlHelper.CreateInParam("@parentIDs",     MySqlDbType.VarChar,  100,   cateinfo.Parentids),
                    };
          int c=   MySqlHelper.ExecuteNonQuery(Connection, CommandType.Text, "INSERT INTO `category`( `catid`, `catname`,`parentIDs`) VALUES (@catid,@catname,@parentIDs)", parm);
          return c;
        }

        /// <summary>
        /// 查询供应商返回已存在供应商
        /// </summary>
        /// <param name="memberIds"></param>
        /// <returns></returns>
        public string[] QuerySuppliers(string memberIds)
        {
            if (memberIds == string.Empty)
            {
                return null;
            }
            DataSet retSet = new DataSet();
            retSet = MySqlHelper.GetDataSet(Connection, "select MemberId from supplier where MemberId  in(" + memberIds + ")");
            List<string> listS = new List<string>();
            foreach (DataRow row in retSet.Tables[0].Rows)
            {
                string s = row["MemberId"].ToString();
                listS.Add(s);
            }
            string[] marray = listS.ToArray();
            return marray;
        }

        /// <summary>
        /// 插入新的供应商
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public int InsertSupplier(Supplier m)
        {
            MySqlParameter[] parm = {
                                  MySqlHelper.CreateInParam("@MemberId",     MySqlDbType.VarChar,  20,     m.Memberid    ),
                                  MySqlHelper.CreateInParam("@company",     MySqlDbType.VarChar,  1000,    m.Company     ),
                                  MySqlHelper.CreateInParam("@loginid",  MySqlDbType.VarChar,  20,    m.Loginid        ),
                                  MySqlHelper.CreateInParam("@ConsignCreateTime",  MySqlDbType.DateTime,  50, m.Consigncreatetime     ),
                                  MySqlHelper.CreateInParam("@consignStatus",  MySqlDbType.VarChar,  20,     m.Consignstatus),
                                  };
            int c=  MySqlHelper.ExecuteNonQuery(Connection, CommandType.Text, "INSERT INTO `supplier`( `MemberId`, `company`, `loginid`, `ConsignCreateTime`, `consignStatus`) VALUES(@MemberId, @company, @loginid, @ConsignCreateTime, @consignStatus)", parm);
            return c;
        }

        /// <summary>
        /// 查询商品返回已存在商品
        /// </summary>
        /// <param name="productids"></param>
        /// <returns></returns>
        public string[] QueryProducts(string productids)
        {
            if (productids == string.Empty)
            {
                return null;
            }
            DataSet retSet = new DataSet();
            retSet = MySqlHelper.GetDataSet(Connection, "select productID from productinfo where productID  in(" + productids + ")");
            List<string> listS = new List<string>();
            foreach (DataRow row in retSet.Tables[0].Rows)
            {
                string s = row["productID"].ToString();
                listS.Add(s);
            }
            string[] parray = listS.ToArray();
            return parray;
        }

        /// <summary>
        /// 插入productinfo表和goods表
        /// </summary>
        /// <param name="ptinfo"></param>
        /// <param name="pt"></param>
        /// <returns></returns>
        public int InsertProduct(ProductInfo ptinfo,Product pt)
        {
            MySqlParameter[] parm = {
                                   MySqlHelper.CreateInParam("@productID",     MySqlDbType.VarChar,  20,   ptinfo.Productid),
                                  MySqlHelper.CreateInParam("@productTitle",     MySqlDbType.VarChar,  1000,  ptinfo.Producttitle),
                                  MySqlHelper.CreateInParam("@desction",  MySqlDbType.MediumText,  0,     ptinfo.Desction),
                                  MySqlHelper.CreateInParam("@offerstatus",  MySqlDbType.VarChar,  20,     ptinfo.Offerstatus),
                                  MySqlHelper.CreateInParam("@supplystock",  MySqlDbType.Int32,  20,    ptinfo.Supplystock),
                                  MySqlHelper.CreateInParam("@catId",  MySqlDbType.Int32,  20,     ptinfo.Catid),
                                  MySqlHelper.CreateInParam("@skumodelstr",  MySqlDbType.MediumText,0,ptinfo.Skumodelstr),
                                  MySqlHelper.CreateInParam("@imagelist",  MySqlDbType.Text,0,ptinfo.Imagelist),
                                  MySqlHelper.CreateInParam("@detailpara",  MySqlDbType.MediumText,0,ptinfo.Detailpara),
                                  MySqlHelper.CreateInParam("@skuInfos", MySqlDbType.MediumText,0,ptinfo.Skuinfos),
                                   MySqlHelper.CreateInParam("@saleinfo", MySqlDbType.MediumText,0,ptinfo.Saleinfo),
                                       MySqlHelper.CreateInParam("@extendinfos", MySqlDbType.Text,0,ptinfo.Extendinfos),
                                    MySqlHelper.CreateInParam("@memberid", MySqlDbType.VarChar,50,ptinfo.Memberid)
                                  };

            int c = MySqlHelper.ExecuteNonQuery(Connection, CommandType.Text, "INSERT INTO `productinfo`(`productID`,`productTitle`, `desction`,`offerstatus`,`supplystock`," +
                "`catId`,`skumodelstr`,`imagelist`,`detailpara`,`skuInfos`,`saleinfo`,`extendinfos`,`memberid`) " +
                "VALUES (@productID,@productTitle,@desction,@offerstatus,@supplystock,@catId,@skumodelstr,@imagelist,@detailpara,@skuInfos,@saleinfo,@extendinfos,@memberid)", parm);
            if (c > 0)
            {
                Savegoods(pt);
            }
            return c;
        }

        /// <summary>
        /// 保存商品到goods表
        /// </summary>
        /// <param name="pt"></param>
        public void Savegoods(Product pt)
        {
            if (pt != null)
            {
                DateTime d = DateTime.Now;
                TimeSpan ts = d.ToUniversalTime() - new DateTime(1970, 1, 1);
                double td = ts.TotalSeconds;

                string sql = "INSERT INTO `goods`(`review_status`,`user_id`,`bar_code`,`default_shipping`,`desc_mobile`,`review_content`,`goods_shipai`,`goods_cause`,`cat_id`,`goods_sn`" +
            ",`goods_name`,`goods_number`,`market_price`,`shop_price`,`goods_thumb`,`goods_img`,`original_img`" +
            ",`is_real`,`is_on_sale`,`is_alone_sale`,`add_time`,`goods_desc`) " +
            "VALUES (5,0,'',0,'','','','',@cat_id,@goods_sn,@goods_name,@goods_number,@market_price,@shop_price,@goods_thumb,@goods_img," +
            "@original_img,@is_real,@is_on_sale,@is_alone_sale,@add_time,@goods_desc)";

                MySqlParameter[] parm ={ MySqlHelper.CreateInParam("@cat_id",     MySqlDbType.Int32,  20,   pt.Cat_id),
                                          MySqlHelper.CreateInParam("@goods_sn",     MySqlDbType.VarChar,  60,     pt.Goods_sn    ),
                                          MySqlHelper.CreateInParam("@goods_name",  MySqlDbType.VarChar,  120, pt.Goods_name   ),
                                          MySqlHelper.CreateInParam("@goods_number",  MySqlDbType.Int32,  20, (pt.Goods_number >1000?1000: pt.Goods_number)   ),
                                          MySqlHelper.CreateInParam("@market_price",  MySqlDbType.Decimal,  10,  pt.Market_price ),
                                          MySqlHelper.CreateInParam("@shop_price",  MySqlDbType.Decimal,  10,   pt.Shop_price),
                                          MySqlHelper.CreateInParam("@goods_thumb",  MySqlDbType.VarChar,  255,  pt.Goods_thumb),
                                          MySqlHelper.CreateInParam("@goods_img",  MySqlDbType.VarChar,  255,  pt.Goods_img),
                                          MySqlHelper.CreateInParam("@original_img",  MySqlDbType.VarChar,  255,  pt.Original_img),
                                          MySqlHelper.CreateInParam("@is_real",  MySqlDbType.Int32,  16,   pt.Is_real),
                                          MySqlHelper.CreateInParam("@is_on_sale",  MySqlDbType.Int32,  16, pt.Is_on_sale),
                                          MySqlHelper.CreateInParam("@is_alone_sale",  MySqlDbType.Int32,  16,   pt.Is_alone_sale),
                                          MySqlHelper.CreateInParam("@add_time",  MySqlDbType.Int32,  16,    td  ),
                                          MySqlHelper.CreateInParam("@goods_desc",  MySqlDbType.Text,  0,pt.Goods_desc),
                                          };

                MySqlHelper.ExecuteNonQuery(Connection, CommandType.Text, sql, parm);
            }
        }

        /// <summary>
        /// 根据1688分类ID获取大商创分类ID
        /// </summary>
        /// <param name="catid"></param>
        /// <returns></returns>
        public string QueryCatebyId(long catid)
        {
            DataSet retSet = new DataSet();
            retSet = MySqlHelper.GetDataSet(Connection, "select * from category where catid='" + catid.ToString () + "'");
            string gcatid = retSet.Tables[0].Rows[0]["gcatid"].ToString();
            if (gcatid==null ||gcatid=="")
            {
                gcatid = "0";
            }
            return gcatid;
        }

        /// <summary>
        /// 查询供应商
        /// </summary>
        /// <returns></returns>
        public DataSet Querysuppliers()
        {
            DataSet retSet = new DataSet();
            retSet = MySqlHelper.GetDataSet(Connection, " select id,MemberId, concat(company,'[',cast(goods_count as CHAR),']') as company from supplier ");
            return retSet;
        }

    }
}
