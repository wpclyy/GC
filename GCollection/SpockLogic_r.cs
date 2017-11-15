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
        // string str = "server=127.0.0.1;user id=root;password=123456;database=gcl";
        string str = "server=192.168.2.88;user id=Fany;password=wang198912;database=gcollection";
       // string str = "server=47.92.113.67;user id=Fany;password=T5oxErqC7ihn7s4M;database=gcollection";

        /// <summary>
        /// 购低网数据库链接字符串
        /// </summary>
        string strdsc = "server=127.0.0.1;user id=root;password=123456;database=dsc";
        public SpockLogic_r(MForm obj)
        {
            Loadrelcate();
            mf = obj;
            //create the connection information for accessing API server
            ClientPolicy clientPolicy = new ClientPolicy();
            clientPolicy.AppKey = "5176341";
            clientPolicy.SecretKey = "5H4K9bh7xD";
            clientPolicy.DefaultTimeout = 5000;

            //String refreshToken = "ecc43432-87f9-4bd6-b8c0-5a741820c5a2";

            //创建一个API请求对象
            instance = new SyncAPIClient(clientPolicy);
        }

        public SpockLogic_r()
        {
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

        /// <summary>
        /// 加载关联分类
        /// </summary>
        public void Loadrelcate()
        {
            DataSet ds = querycate();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                int gcatid = 0;
                if (dr["gcatid"].ToString() != "" && dr["gcatid"] != null)
                {
                    gcatid = Convert.ToInt32(dr["gcatid"]);
                }
                if (!diccate.Keys.Contains(dr["catid"].ToString()))
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
        public void start(int i, int pagesize)
        {
            AlibabarelationquerySuppliersParam qspara = new AlibabarelationquerySuppliersParam();
            qspara.setSupplierLoginId("");
            qspara.setCurrentPage(i);
            qspara.setPageSize(pagesize);
            AlibabarelationquerySuppliersResult qsres = instance.send<AlibabarelationquerySuppliersResult>(qspara);
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
                List<System.String> listS = new List<System.String>();
                foreach (DataRow row in retSet.Tables[0].Rows)
                {
                    string s = row["MemberId"].ToString();
                    listS.Add(s);
                }
                System.String[] marray = listS.ToArray();

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
            Alibabarelationsuppliersresult ssse = qsres.getResult();
            AlibabarelationsupplierModel[] smodel = ssse.getRelationModels();

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

            AlibabadaixiaoProductInfo[] proinfo = allresult.getProductInfo();
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
        public void getproductbypage(int cpage, int pagesize, string member)
        {
            AlibabadistributorlistForAllConsignmentParam allconpara = new AlibabadistributorlistForAllConsignmentParam();
            allconpara.setKeyword("");
            allconpara.setSupplierMemberId(member);
            allconpara.setPageNo(cpage);
            allconpara.setPageSize(pagesize);

            AlibabadistributorlistForAllConsignmentResult allresult = instance.send<AlibabadistributorlistForAllConsignmentResult>(allconpara);
            if (allresult == null)
            {
                mf.setprogress();
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
                List<System.String> listS = new List<System.String>();
                foreach (DataRow row in retSet.Tables[0].Rows)
                {
                    string s = row["productID"].ToString();
                    listS.Add(s);
                }
                System.String[] parray = listS.ToArray();

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

                        //getdeatail(p,member);
                        //Thread.Sleep(1000);
                    }
                    else
                    {
                        mf.setprogress();
                    }

                }
            }
        }
        class detailobj
        {
         public  AlibabadaixiaoProductInfo ap;
         public   string memberid;
        }

        /// <summary>
        /// 获取商品详情
        /// </summary>
        /// <param name="obj"></param>
        public void getdeatail(object obj)
        {
            detailobj dobj = (obj as detailobj);
            AlibabadaixiaoProductInfo p =dobj.ap;
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

            string proattr = JsonConvert.SerializeObject(proattrs);
            string skuinfo = JsonConvert.SerializeObject(proskuinfos);
            string saleinfo = JsonConvert.SerializeObject(prosale);
            string extendinfos = JsonConvert.SerializeObject(proextens);

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
            MySqlHelper.ExecuteNonQuery(str, CommandType.Text, "INSERT INTO `productinfo`(`productID`,`productTitle`, `desction`,`offerstatus`,`supplystock`," +
                "`catId`,`skumodelstr`,`imagelist`,`detailpara`,`skuInfos`,`saleinfo`,`extendinfos`,`memberid`) " +
                "VALUES (@productID,@productTitle,@desction,@offerstatus,@supplystock,@catId,@skumodelstr,@imagelist,@detailpara,@skuInfos,@saleinfo,@extendinfos,@memberid)", parm);
            Product pt = new Product();
            pt.Goods_sn = proid.ToString();
            pt.Goods_name = p.getProductTitle();
            pt.Goods_desc = desction;
            pt.Goods_number = (int)p.getSupplyStock();
            pt.Cat_id = (int)p.getCatId();
            pt.Shop_price = Convert.ToDecimal(p.getMinPurchasePrice());

            string sellprice = p.getSellPrice();
            if (sellprice != "")
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
            else {
                pt.Market_price = pt.Shop_price * 1.2m;
            }
            pt.Goods_thumb = p.getPicURI();
            Savegoods(pt);
            mf.setprogress();
        }

        /// <summary>
        /// 获取商品详情
        /// </summary>
        /// <param name="p">可代销产品信息</param>
        public void getdeatail(AlibabadaixiaoProductInfo p,string mid)
        {
            if (p.getOfferStatus().ToUpper() != "PUBLISHED")
            {
                mf.setprogress();
                return;
            }
            string memberid = mid;
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

            string proattr = JsonConvert.SerializeObject(proattrs);
            string skuinfo = JsonConvert.SerializeObject(proskuinfos);
            string saleinfo = JsonConvert.SerializeObject(prosale);
            string extendinfos = JsonConvert.SerializeObject(proextens);

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
                                       MySqlHelper.CreateInParam("@extendinfos", MySqlDbType.MediumText,0,extendinfos),
                                    MySqlHelper.CreateInParam("@memberid", MySqlDbType.VarChar,50,memberid)
                                  };
            MySqlHelper.ExecuteNonQuery(str, CommandType.Text, "INSERT INTO `productinfo`(`productID`,`productTitle`, `desction`,`offerstatus`,`supplystock`," +
                "`catId`,`skumodelstr`,`imagelist`,`detailpara`,`skuInfos`,`saleinfo`,`extendinfos`,`memberid`) " +
                "VALUES (@productID,@productTitle,@desction,@offerstatus,@supplystock,@catId,@skumodelstr,@imagelist,@detailpara,@skuInfos,@saleinfo,@extendinfos,@memberid)", parm);
            Product pt = new Product();
            pt.Goods_sn = proid.ToString();
            pt.Goods_name = p.getProductTitle();
            pt.Goods_desc = desction;
            pt.Goods_number = (int)p.getSupplyStock();
            pt.Cat_id = (int)p.getCatId();
            pt.Shop_price = Convert.ToDecimal(p.getMinPurchasePrice());
            pt.Market_price = pt.Shop_price * 1.2m;
            pt.Goods_thumb = p.getPicURI();
            Savegoods(pt);
            mf.setprogress();
        }

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
                List<System.String> listS = new List<System.String>();
                foreach (DataRow row in retSet.Tables[0].Rows)
                {
                    string s = row["catid"].ToString();
                    listS.Add(s);
                }
                System.String[] marray = listS.ToArray();

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
        public bool UpdateProducts(string conditions,string goods_sn)
        {
            string sql = "update goods set ";
            string where = "  where goods_sn in(" + goods_sn + ")";
            sql += conditions + where;
            int c = MySqlHelper.ExecuteNonQuery(str, CommandType.Text, sql);
            if (c >=0)
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
            string sql = "update  goods set  goods_name='" + p.Goods_name + "', market_price="+p.Market_price+",shop_price="+p.Shop_price
                +  ",integral="+p.Integral+",cat_id="+p.Cat_id+",brand_id="+p.Brand_id+",goods_number="+p.Goods_number+",goods_weight="+p.Goods_weight
                +",is_best="+p.Is_best+",is_new="+p.Is_new+",is_hot="+p.Is_hot+",is_shipping="+p.Is_shipping+",is_on_sale="+p.Is_on_sale
                +",goods_desc='"+p.Goods_desc+"'";
             string where=   "  where goods_sn='" + p.Goods_sn + "'";
            sql += where;
            int c = MySqlHelper.ExecuteNonQuery(str, CommandType.Text, sql);
            if (c >=0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 上传商品
        /// </summary>
        /// <returns></returns>
        public bool Uploadgoods(DataTable dt)
        {
            if (dt != null && dt.Rows.Count > 0)
            {
                List<string> lstsql = new List<string>();
                List<MySqlParameter[]> lstparms = new List<MySqlParameter[]>();
               
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    object pcount = MySqlHelper.ExecuteScalar(this.strdsc, CommandType.Text, "select count(*) from dsc_goods where goods_sn='" + dt.Rows[i]["goods_sn"] + "'");
                    if (Convert.ToInt32(pcount) > 0)
                    {
                        //string sql = "update  `dsc_goods`  set cat_id=@cat_d,goods_name=@goods_name,goods_number=@goods_number," +
                        //    "market_price=@market_price,shop_price=@shop_price,goods_thumb=@goods_thumb,goods_img=@goods_img," +
                        //    "original_img=@original_img,is_real=@is_real,is_on_sale=@is_on_sale，is_alone_sale=@is_alone_sale，goods_desc=@goods_desc"+
                        //    " where goods_sn=@goods_sn";
                        continue;
                    }
                    else
                        {
                        string sql = "INSERT INTO `dsc_goods`(`review_status`,`user_id`,`bar_code`,`default_shipping`,`desc_mobile`,`review_content`,`goods_shipai`,`goods_cause`,`cat_id`,`goods_sn`" +
                ",`goods_name`,`goods_number`,`market_price`,`shop_price`,`goods_thumb`,`goods_img`,`original_img`" +
                ",`is_on_sale`,`is_shipping`,`add_time`,`goods_desc`,`is_best`,`is_new`,`is_hot`,`goods_weight`,`brand_id`,`integral`) " +
                "VALUES (5,0,'',0,'','','','',@cat_id,@goods_sn,@goods_name,@goods_number,@market_price,@shop_price,@goods_thumb,@goods_img," +
                "@original_img,@is_on_sale,@is_shipping,@add_time,@goods_desc,@is_best,@is_new,@is_hot,@goods_weight,@brand_id,@integral)";
                        lstsql.Add(sql);
                    }
                    DateTime d = DateTime.Now;
                    TimeSpan ts = d.ToUniversalTime() - new DateTime(1970, 1, 1);
                    double td = ts.TotalSeconds;

                    MySqlParameter[] parm ={ MySqlHelper.CreateInParam("@cat_id",     MySqlDbType.Int32,  20,    dt.Rows[i]["cat_id"] ),
                                          MySqlHelper.CreateInParam("@goods_sn",     MySqlDbType.VarChar,  60,     dt.Rows[i]["goods_sn"]      ),
                                          MySqlHelper.CreateInParam("@goods_name",  MySqlDbType.VarChar,  120, dt.Rows[i]["goods_name"]      ),
                                          MySqlHelper.CreateInParam("@goods_number",  MySqlDbType.UInt16,  5, dt.Rows[i]["goods_number"]      ),
                                          MySqlHelper.CreateInParam("@market_price",  MySqlDbType.Decimal,  10,     dt.Rows[i]["market_price"]       ),
                                          MySqlHelper.CreateInParam("@shop_price",  MySqlDbType.Decimal,  10,    dt.Rows[i]["shop_price"]      ),
                                          MySqlHelper.CreateInParam("@goods_thumb",  MySqlDbType.VarChar,  255,   dt.Rows[i]["goods_thumb"]      ),
                                          MySqlHelper.CreateInParam("@goods_img",  MySqlDbType.VarChar,  255,   dt.Rows[i]["goods_thumb"] ),
                                          MySqlHelper.CreateInParam("@original_img",  MySqlDbType.VarChar,  255,   dt.Rows[i]["goods_thumb"]       ),
                                          MySqlHelper.CreateInParam("@is_on_sale",  MySqlDbType.Int32,  16,  dt.Rows[i]["is_on_sale"]       ),
                                          MySqlHelper.CreateInParam("@is_shipping",  MySqlDbType.Int32,  16,  dt.Rows[i]["is_shipping"]       ),
                                          MySqlHelper.CreateInParam("@is_best",  MySqlDbType.Int32,  16,  dt.Rows[i]["is_best"]       ),
                                          MySqlHelper.CreateInParam("@is_new",  MySqlDbType.Int32,  16,  dt.Rows[i]["is_new"]       ),
                                          MySqlHelper.CreateInParam("@is_hot",  MySqlDbType.Int32,  16,  dt.Rows[i]["is_hot"]       ),
                                          MySqlHelper.CreateInParam("@brand_id",  MySqlDbType.Int32,  20,  dt.Rows[i]["brand_id"]       ),
                                          MySqlHelper.CreateInParam("@goods_weight",  MySqlDbType.Decimal,  16,  dt.Rows[i]["goods_weight"]       ),
                                          MySqlHelper.CreateInParam("@integral",  MySqlDbType.Int32,  16,  dt.Rows[i]["integral"]     ),
                                          MySqlHelper.CreateInParam("@add_time",  MySqlDbType.Int32,  16,    td  ),
                                          MySqlHelper.CreateInParam("@goods_desc",  MySqlDbType.Text,  0, dt.Rows[i]["goods_desc"]    ),
                                          };
                    lstparms.Add(parm);
                }
                string[] sqls = lstsql.ToArray();
                MySqlParameter[][] parms = lstparms.ToArray();
                if (sqls.Length > 0)
                {
                    bool b = MySqlHelper.ExecuteTransaction(this.strdsc, CommandType.Text, sqls, parms);
                    return b;
                }
                else {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 保存商品到goods表
        /// </summary>
        /// <param name="pt"></param>
        public void Savegoods(Product pt)
        {
            if (pt!=null)
            { 
                DateTime d = DateTime.Now;
                TimeSpan ts = d.ToUniversalTime() - new DateTime(1970, 1, 1);
                double td = ts.TotalSeconds;

                    string sql= "INSERT INTO `goods`(`review_status`,`user_id`,`bar_code`,`default_shipping`,`desc_mobile`,`review_content`,`goods_shipai`,`goods_cause`,`cat_id`,`goods_sn`" +
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
        public int  Relcate(string  catid,string gcatid,string gcatname)
        {
            string sqlrelcate = "update category set gcatid='"+ gcatid + "',gcatname='"+ gcatname + "'  where catid='"+ catid + "'";
            string sqlcatgoods = "select productID from productinfo where catId='"+catid+"'";
            string sqlr = "update goods set cat_id=" + gcatid + " where goods_sn in (" + sqlcatgoods+")";

            string[] sql = new string[2];
            sql[0] = sqlrelcate;
            sql[1] = sqlr;
            MySqlParameter[][] parms= new MySqlParameter[2][];
            parms[0] = null;
            parms[1] = null;
            bool b= MySqlHelper.ExecuteTransaction(str, CommandType.Text,sql, parms);
            if (b)
            {
                Application.DoEvents();
                if (diccate.ContainsKey(catid))
                {
                    diccate[catid] = Convert.ToInt32(gcatid);
                }
                else
                {
                    diccate.Add(catid, Convert.ToInt32(gcatid));
                }
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
            object obj = MySqlHelper.ExecuteScalar(str,CommandType.Text, "select count(*) from goods where cat_id="+catid);
            c =Convert.ToInt32( obj);
            return c;
        }

        /// <summary>
        /// 查询分类商品数量
        /// </summary>
        /// <returns></returns>
        public DataTable Hasgoods()
        {
            string sql = "select cat_id, count(*) as count from goods group by cat_id";
            DataSet ds= MySqlHelper.GetDataSet(str,sql);
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
            string sql = "update goods set status=1 where goods_sn in("+ goods_sn + ")";
            int c = MySqlHelper.ExecuteNonQuery(str, CommandType.Text, sql);
            return c;
        }

        /// <summary>
        /// 根据商品编码获取商品信息
        /// </summary>
        /// <param name="productid"></param>
        /// <returns></returns>
        public DataTable QueryGoodsbyProductid(string  productid)
        {
            string sql = "select * from productinfo where productID='"+ productid + "'";
            DataSet ds = MySqlHelper.GetDataSet(str, sql);
            return ds.Tables[0];
        }

    }
}
