using cn.alibaba.open.param;
using com.alibaba.openapi.client;
using com.alibaba.openapi.client.policy;
using com.alibaba.product.param;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GCollection
{
    /// <summary>
    /// 获取阿里巴巴数据各项接口
    /// </summary>
public   class SpockLogic_r
    {
        /// <summary>
        /// 分类关联集合(1688分类ID ,购低网分类ID)
        /// </summary>
        public  Dictionary<string, int> diccate = new Dictionary<string, int>();

        /// <summary>
        /// 应用主窗体
        /// </summary>
        public  MForm mf = null;

        SyncAPIClient instance = null;

        /// <summary>
        /// 本地数据库链接字符串
        /// </summary>
        //  string str = "server=127.0.0.1;user id=root;password=123456;database=gcl";
       // string str = "server=47.92.113.67;user id=Fany;password=T5oxErqC7ihn7s4M;database=gcollection";
        string str = "server=192.168.2.88;user id=Fany;password=wang198912;database=gcollection";

        public Opergcc opgcc = null;
         
        public SpockLogic_r(MForm obj)
        {
            opgcc = new Opergcc();
            mf = obj;
            Loadrelcate();
            //create the connection information for accessing API server
            ClientPolicy clientPolicy = new ClientPolicy();
            clientPolicy.AppKey = "5176341";
            clientPolicy.SecretKey = "5H4K9bh7xD";
            clientPolicy.DefaultTimeout = 5000;

            //String refreshToken = "ecc43432-87f9-4bd6-b8c0-5a741820c5a2";

            //创建一个API请求对象
            instance = new SyncAPIClient(clientPolicy);
        }

        #region 采集1688数据操作
        /// <summary>
        /// 加载关联分类
        /// </summary>
        public void Loadrelcate()
        {
            DataSet ds = opgcc.querycate();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                int gcatid = 0;
                if (dr["gcatid"].ToString() != "" && dr["gcatid"] != null)
                {
                    gcatid = Convert.ToInt32(dr["gcatid"]);
                }
                if (diccate.Keys.Contains(dr["catid"].ToString()))
                {
                    diccate[dr["catid"].ToString()] = gcatid;
                }
                else
                {
                    diccate.Add(dr["catid"].ToString(), gcatid);
                }
            }
        }

        /// <summary>
        /// 获取供应商
        /// </summary>
        /// <param name="i"></param>
        /// <param name="pagesize"></param>
        public void start(int i, int pagesize,int allpage,int allcount)
        {
            AlibabarelationquerySuppliersParam qspara = new AlibabarelationquerySuppliersParam();
            qspara.setSupplierLoginId("");
            qspara.setCurrentPage(i);
            qspara.setPageSize(pagesize);
            AlibabarelationquerySuppliersResult qsres = instance.send<AlibabarelationquerySuppliersResult>(qspara);
            if (qsres == null)
            {
                if (i < allpage)
                {
                    for (int k = 0; k < pagesize; k++)
                    {
                        mf.setsprogress();
                    }
                }
                else
                {
                    for (int k = 0; k <  allcount-(pagesize*(i-1)); k++)
                    {
                        mf.setsprogress();
                    }
                }
                return;
            }
            Alibabarelationsuppliersresult ssse = qsres.getResult();
            AlibabarelationsupplierModel[] smodel = ssse.getRelationModels();
            DateTime dtStart = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));

            string memberIds = "";
            foreach (AlibabarelationsupplierModel m in smodel)
            {
                memberIds += "'" + m.getMemberId() + "'" + ",";
            }
            if (memberIds != "")
            {
                memberIds = memberIds.TrimEnd(',');
                DataSet retSet = new DataSet();
                retSet = MySqlHelper.GetDataSet(str, "select MemberId from supplier where MemberId  in(" + memberIds + ")");
                List<string> listS = new List<string>();
                foreach (DataRow row in retSet.Tables[0].Rows)
                {
                    string s = row["MemberId"].ToString();
                    listS.Add(s);
                }
                string[] marray = listS.ToArray();

                foreach (AlibabarelationsupplierModel m in smodel)
                {
                    if (!marray.Contains(m.getMemberId()))
                    {
                        DateTime today = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
                        long lTime = long.Parse(m.getConsignCreateTime().ToString() + "0000");
                        TimeSpan toNow = new TimeSpan(lTime);
                        today = today.Add(toNow);

                        MySqlParameter[] parm = {
                                  MySqlHelper.CreateInParam("@MemberId",     MySqlDbType.VarChar,  20,     m.getMemberId()       ),
                                  MySqlHelper.CreateInParam("@company",     MySqlDbType.VarChar,  1000,    m.getSupplierCompany()      ),
                                  MySqlHelper.CreateInParam("@loginid",  MySqlDbType.VarChar,  20,    m.getSupplierLoginId()         ),
                                  MySqlHelper.CreateInParam("@ConsignCreateTime",  MySqlDbType.DateTime,  50, today     ),
                                  MySqlHelper.CreateInParam("@consignStatus",  MySqlDbType.VarChar,  20,     m.getConsignStatus()      ),
                                  };
                        MySqlHelper.ExecuteNonQuery(str, CommandType.Text, "INSERT INTO `supplier`( `MemberId`, `company`, `loginid`, `ConsignCreateTime`, `consignStatus`) VALUES(@MemberId, @company, @loginid, @ConsignCreateTime, @consignStatus)", parm);
                    }
                    mf.setsprogress();
                }
            }
        }

        /// <summary>
        /// 获取供应商总数
        /// </summary>
        /// <returns></returns>
        public int getsuppliers()
        {
            AlibabarelationquerySuppliersParam qspara = new AlibabarelationquerySuppliersParam();
            qspara.setSupplierLoginId("");
            qspara.setCurrentPage(1);
            qspara.setPageSize(1);
            AlibabarelationquerySuppliersResult qsres = instance.send<AlibabarelationquerySuppliersResult>(qspara);
            if (qsres == null)
            {
                return 0;
            }
            Alibabarelationsuppliersresult ssse = qsres.getResult();
            int allcount = ssse.getCount() ?? 0;
            return allcount;
        }

        /// <summary>
        /// 获取供应商商品的总数
        /// </summary>
        /// <param name="member"></param>
        /// <returns></returns>
        public int getproduct(string member)
        {
            AlibabadistributorlistForAllConsignmentParam allconpara = new AlibabadistributorlistForAllConsignmentParam();
            allconpara.setKeyword("");
            allconpara.setSupplierMemberId(member);
            allconpara.setPageNo(1);
            allconpara.setPageSize(1);

            AlibabadistributorlistForAllConsignmentResult allresult = instance.send<AlibabadistributorlistForAllConsignmentResult>(allconpara);
            if (allresult == null)
            {
                return 0;
            }
            int allcount = allresult.getCount() ?? 0;
            return allcount;
        }

        /// <summary>
        /// 获取供应商商品
        /// </summary>
        /// <param name="cpage"></param>
        /// <param name="pagesize"></param>
        /// <param name="member"></param>
        public void getproductbypage(int cpage, int pagesize, string member,int allcount,int allpage)
        {
            AlibabadistributorlistForAllConsignmentParam allconpara = new AlibabadistributorlistForAllConsignmentParam();
            allconpara.setKeyword("");
            allconpara.setSupplierMemberId(member);
            allconpara.setPageNo(cpage);
            allconpara.setPageSize(pagesize);

            AlibabadistributorlistForAllConsignmentResult allresult = instance.send<AlibabadistributorlistForAllConsignmentResult>(allconpara);
            if (allresult == null)
            {
                if (cpage < allpage)
                {
                    for (int k = 0; k <pagesize; k++)
                    {
                        mf.setprogress();
                    }
                }
                else
                {
                    for (int k = 0; k < (allcount - (pagesize * (cpage - 1))); k++)
                    {
                        mf.setprogress();
                    }
                }
                return;
            }

            AlibabadaixiaoProductInfo[] proinfo = allresult.getProductInfo();
            string productids = "";
            foreach (AlibabadaixiaoProductInfo p in proinfo)
            {
                productids += "'" + p.getProductId() + "'" + ",";
            }

            if (productids != "")
            {
                productids = productids.TrimEnd(',');
                DataSet retSet = new DataSet();
                retSet = MySqlHelper.GetDataSet(str, "select productID from productinfo where productID  in(" + productids + ")");
                List<string> listS = new List<string>();
                foreach (DataRow row in retSet.Tables[0].Rows)
                {
                    string s = row["productID"].ToString();
                    listS.Add(s);
                }
                string[] parray = listS.ToArray();

                foreach (AlibabadaixiaoProductInfo p in proinfo)
                {
                    string pid = p.getProductId().ToString();
                    if (!parray.Contains(pid))
                    {
                        detailobj dobj = new detailobj();
                        dobj.memberid = member;
                        dobj.ap = p;

                        Thread th = new Thread(getdeatail);
                        th.IsBackground = true;
                        th.Start(dobj);
                    }
                    else
                    {
                        mf.setprogress();
                    }
                }
                if (cpage < allpage)
                {
                    for (int j = 0; j < pagesize - proinfo.Length; j++)
                    {
                        mf.setprogress();
                    }
                }
                else
                {
                    int ed = allcount - pagesize * (cpage - 1);
                    for (int j = 0; j < ed - proinfo.Length; j++)
                    {
                        mf.setprogress();
                    }
                }
            }
            else
            {
                if (cpage < allpage)
                {
                    for (int k = 0; k < pagesize; k++)
                    {
                        mf.setprogress();
                    }
                }
                else
                {
                    int ed = allcount - pagesize * (cpage - 1);
                    for (int j = 0; j < ed - proinfo.Length; j++)
                    {
                        mf.setprogress();
                    }
                }
            }
        }
        class detailobj
        {
            public AlibabadaixiaoProductInfo ap;
            public string memberid;
        }

        /// <summary>
        /// 获取商品详情
        /// </summary>
        /// <param name="obj"></param>
        public void getdeatail(object obj)
        {
            detailobj dobj = (obj as detailobj);
            AlibabadaixiaoProductInfo p = dobj.ap;
            if (p.getOfferStatus().ToUpper() != "PUBLISHED")
            {
                mf.setprogress();
                return;
            }
            string memberid = dobj.memberid;
            long proid = (long)p.getProductId();
            AlibabaagentproductgetParam propara = new AlibabaagentproductgetParam();
            propara.setProductID(proid);
            propara.setWebSite("1688");
            AlibabaagentproductgetResult prores = instance.send<AlibabaagentproductgetResult>(propara);
            if (prores == null)
            {
                mf.setprogress();
                return;
            }
            AlibabaproductProductInfo proproinfo = prores.getProductInfo();
            if (proproinfo == null)
            {
                mf.setprogress();
                return;
            }
            //产品属性
            AlibabaproductProductAttribute[] proattrs = proproinfo.getAttributes();
            //代销价格
            AlibabaproductProductExtendInfo[] proextens = proproinfo.getExtendInfos();
            //主图列表
            AlibabaproductProductImageInfo proimg = proproinfo.getImage();

            AlibabaproductProductSaleInfo prosale = proproinfo.getSaleInfo();

            AlibabaproductProductSKUInfo[] proskuinfos = proproinfo.getSkuInfos();

            //详情图片
            string desction = proproinfo.getDescription();

            //商品主图集合
            string[] imagelist = { "" };
            if (proimg != null)
            {
                imagelist = proimg.getImages();
            }

            string proattr = (proattrs!=null)?JsonConvert.SerializeObject(proattrs):"";
            string skuinfo = (proskuinfos != null) ? JsonConvert.SerializeObject(proskuinfos):"";
            string saleinfo = (prosale != null) ? JsonConvert.SerializeObject(prosale):"";
            string extendinfos = (proextens != null) ? JsonConvert.SerializeObject(proextens):"";

            // 规格名称和值
            Dictionary<string, List<string>> ht = new Dictionary<string, List<string>>();
            if (p.getSkuModelStr() != null)
            {
                JObject sm = (JObject)JsonConvert.DeserializeObject(p.getSkuModelStr());
                JToken mm = sm["skuList"];
                foreach (JToken j in mm.Children())
                {
                    JToken jc = j["attributeModelList"];
                    string spec = "";
                    foreach (JToken jcc in jc)
                    {
                        string key = jcc["targetAttributeName"] != null ? jcc["targetAttributeName"].ToString() : jcc["sourceAttributeName"].ToString();
                        string val = jcc["targetAttributeValue"] != null ? jcc["targetAttributeValue"].ToString() : jcc["sourceAttributeValue"].ToString();
                        if (ht.ContainsKey(key))
                        {
                            if (!ht[key].Contains(val))
                            {
                                ht[key].Add(val);
                            }
                        }
                        else
                        {
                            List<string> lt = new List<string>();
                            lt.Add(val);
                            ht.Add(key, lt);
                        }
                        spec += key + ":" + val + "    ";
                    }
                }

                //获取attribute表所需数据
                foreach (KeyValuePair<string, List<string>> kv in ht)
                {
                    string str = kv.Key + ":" + string.Join(",", kv.Value) + "\r\n";
                }
            }

            MySqlParameter[] parm = {
                                   MySqlHelper.CreateInParam("@productID",     MySqlDbType.VarChar,  20,     proid.ToString()       ),
                                  MySqlHelper.CreateInParam("@productTitle",     MySqlDbType.VarChar,  1000,     p.getProductTitle()       ),
                                  MySqlHelper.CreateInParam("@desction",  MySqlDbType.MediumText,  0,     desction         ),
                                  MySqlHelper.CreateInParam("@offerstatus",  MySqlDbType.VarChar,  20,     p.getOfferStatus()         ),
                                  MySqlHelper.CreateInParam("@supplystock",  MySqlDbType.Int32,  20,     (long)p.getSupplyStock()        ),
                                  MySqlHelper.CreateInParam("@catId",  MySqlDbType.Int32,  20,     (long)p.getCatId()        ),
                                  MySqlHelper.CreateInParam("@skumodelstr",  MySqlDbType.MediumText,0,p.getSkuModelStr()        ),
                                  MySqlHelper.CreateInParam("@imagelist",  MySqlDbType.Text,0,string.Join(",",imagelist)        ),
                                  MySqlHelper.CreateInParam("@detailpara",  MySqlDbType.MediumText,0,proattr       ),
                                  MySqlHelper.CreateInParam("@skuInfos", MySqlDbType.MediumText,0,skuinfo),
                                   MySqlHelper.CreateInParam("@saleinfo", MySqlDbType.MediumText,0,saleinfo),
                                       MySqlHelper.CreateInParam("@extendinfos", MySqlDbType.Text,0,extendinfos),
                                    MySqlHelper.CreateInParam("@memberid", MySqlDbType.VarChar,50,memberid)
                                  };

            int c= MySqlHelper.ExecuteNonQuery(str, CommandType.Text, "INSERT INTO `productinfo`(`productID`,`productTitle`, `desction`,`offerstatus`,`supplystock`," +
                "`catId`,`skumodelstr`,`imagelist`,`detailpara`,`skuInfos`,`saleinfo`,`extendinfos`,`memberid`) " +
                "VALUES (@productID,@productTitle,@desction,@offerstatus,@supplystock,@catId,@skumodelstr,@imagelist,@detailpara,@skuInfos,@saleinfo,@extendinfos,@memberid)", parm);
            if (c > 0)
            {
                Product pt = new Product();
                pt.Goods_sn = proid.ToString();
                pt.Goods_name = p.getProductTitle();
                pt.Goods_desc = desction;
                pt.Goods_number = (int)prosale.getAmountOnSale();
                pt.Cat_id = (int)p.getCatId();
                pt.Goods_thumb = p.getPicURI();

                int quotytype = (int)prosale.getQuoteType();
                if (quotytype == 0)
                {
                    pt.Shop_price = Convert.ToDecimal(p.getMaxPurchasePrice());
                    string sellprice = p.getSellPrice();
                    if (sellprice != "" && sellprice != null)
                    {
                        pt.Market_price = Convert.ToDecimal(sellprice);
                    }
                    else
                    {
                        decimal dl = 0m;
                        dl = GetpriceFromSkumodelstr(p);
                        if (dl > 0)
                        {
                            pt.Market_price = dl;
                        }
                        else
                        {
                            dl = GetpriceFromSaleinfo(prosale);
                            if (dl > 0)
                            {
                                pt.Market_price = dl;
                            }
                            else
                            {
                                pt.Market_price = pt.Shop_price * 1.2m;
                            }
                        }
                    }
                }
                else
                {
                    pt.Shop_price = Convert.ToDecimal(p.getMaxPurchasePrice());
                    string sellprice = p.getSellPrice();
                    if (sellprice != "" && sellprice != null)
                    {
                        string[] sprice = sellprice.Split('~');
                        if (sprice.Length > 1)
                        {
                            pt.Market_price = Convert.ToDecimal(sprice[1]);
                        }
                        else if (sprice.Length == 1)
                        {
                            pt.Market_price = Convert.ToDecimal(sprice[0]);
                        }
                    }
                    else
                    {
                        decimal dl = 0m;
                        dl = GetpriceFromSaleinfo(prosale);
                        if (dl > 0)
                        {
                            pt.Market_price = dl;
                        }
                        else
                        {
                            pt.Market_price = pt.Shop_price * 1.2m;
                        }
                    }
                }
                Savegoods(pt);
            }
            mf.setprogress();
        }

        /// <summary>
        /// 从skumodelstr中获取零售价格
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        private decimal GetpriceFromSkumodelstr(AlibabadaixiaoProductInfo p)
        {
            decimal dl = 0m;
            if (p.getSkuModelStr() != null && p.getSkuModelStr() != "")
            {
                JObject sm = (JObject)JsonConvert.DeserializeObject(p.getSkuModelStr());
                JToken mm = sm["skuList"];
                if (mm.Children().Count() > 0)
                {
                    foreach (JToken j in mm.Children())
                    {
                        if (j["retailPrice"].ToString() != "" && j["retailPrice"] != null)
                        {
                            dl = Convert.ToDecimal(j["retailPrice"]);
                        }
                    }
                }
            }

            return dl;
        }

        /// <summary>
        /// 从saleinfo中获取零售价格
        /// </summary>
        /// <param name="prosale"></param>
        /// <returns></returns>
        private decimal GetpriceFromSaleinfo(AlibabaproductProductSaleInfo prosale)
        {
            decimal dl = 0m;
            double rprice = prosale.getRetailprice() ?? 0;
            dl = Convert.ToDecimal(rprice);
            return dl;
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

                MySqlParameter[] parm ={ MySqlHelper.CreateInParam("@cat_id",     MySqlDbType.Int32,  20,   diccate[pt.Cat_id.ToString ()]),
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

                MySqlHelper.ExecuteNonQuery(this.str, CommandType.Text, sql, parm);
            }
        }

        /// <summary>
        /// 获取商品子分类请求方法
        /// </summary>
        /// <param name="catid">分类ID</param>
        public void getcategorys(object cid, DoWorkEventArgs e)
        {
            if (mf.querybkstatus())
            {
                e.Cancel = true;
                return;
            }
            long catid = (long)cid;
            AlibabacategorygetParam apara = new AlibabacategorygetParam();
            apara.setCategoryID(catid);
            apara.setWebSite("1688");
            AlibabacategorygetResult catres = instance.send<AlibabacategorygetResult>(apara);
            if (catres == null)
            {
                mf.setcprogress();
                return;
            }
            AlibabacategoryCategoryInfo[] aci = catres.getCategoryInfo();

            string catids = "";
            foreach (AlibabacategoryCategoryInfo c in aci)
            {
                catids += "'" + c.getCategoryID() + "'" + ",";
            }

            if (catids != "")
            {
                catids = catids.TrimEnd(',');
                DataSet retSet = new DataSet();
                retSet = MySqlHelper.GetDataSet(str, "select catid from category where catid  in(" + catids + ")");
                List<string> listS = new List<string>();
                foreach (DataRow row in retSet.Tables[0].Rows)
                {
                    string s = row["catid"].ToString();
                    listS.Add(s);
                }
               string[] marray = listS.ToArray();

                foreach (AlibabacategoryCategoryInfo c in aci)
                {
                    if (!marray.Contains(c.getCategoryID().ToString()))
                    {
                        MySqlParameter[] parm = {
                  MySqlHelper.CreateInParam("@catid", MySqlDbType.VarChar, 100, c.getCategoryID().ToString()),
                  MySqlHelper.CreateInParam("@catname",     MySqlDbType.VarChar,  100,    c.getName()      ),
                  MySqlHelper.CreateInParam("@parentIDs",     MySqlDbType.VarChar,  100,   string.Join("," ,c.getParentIDs())      ),
                    };
                        MySqlHelper.ExecuteNonQuery(str, CommandType.Text, "INSERT INTO `category`( `catid`, `catname`,`parentIDs`) VALUES (@catid,@catname,@parentIDs)", parm);
                        mf.setcprogress();
                    }
                    else
                    {
                        mf.setcprogress();
                    }
                    if (!(bool)c.getIsLeaf())
                    {
                        long[] cd = c.getChildIDs();
                        foreach (long ck in cd)
                        {
                            getcategorys(ck, e);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 获取商品分类请求方法
        /// </summary>
        /// <param name="e"></param>
        public void getcategory(DoWorkEventArgs e)
        {
            AlibabacategorygetParam apara = new AlibabacategorygetParam();
            apara.setCategoryID(0);
            apara.setWebSite("1688");
            AlibabacategorygetResult catres = instance.send<AlibabacategorygetResult>(apara);
            if (catres == null)
            {
                return;
            }
            AlibabacategoryCategoryInfo[] aci = catres.getCategoryInfo();
            long[] cd = aci[0].getChildIDs();
            foreach (long c in cd)
            {
                if (mf.querybkstatus())
                {
                    e.Cancel = true;
                    return;
                }
                else
                {
                    getcategorys(c, e);
                }
            }
        } 
        #endregion

    }
}
