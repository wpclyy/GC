using cn.alibaba.open.param;
using com.alibaba.openapi.client;
using com.alibaba.openapi.client.policy;
using com.alibaba.product.param;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace GCollection
{
    public class CaiJi
    {
        SyncAPIClient instance = null;

        public CaiJi()
        {
            ClientPolicy clientPolicy = new ClientPolicy();
            clientPolicy.AppKey = "5176341";
            clientPolicy.SecretKey = "5H4K9bh7xD";
            clientPolicy.DefaultTimeout = 5000;
            instance = new SyncAPIClient(clientPolicy);
        }

        /// <summary>
        /// 采集商品分类方法
        /// </summary>
        /// <param name="e"></param>
        public void CjCategory(DoWorkEventArgs e)
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
                if (Program.mf.querybkstatus())
                {
                    e.Cancel = true;
                    return;
                }
                else
                {
                    CjChildrenCategory(c,e);
                }
            }
        }

        /// <summary>
        /// 遍历采集下级分类方法
        /// </summary>
        /// <param name="catid"></param>
        /// <param name="e"></param>
        public void CjChildrenCategory(long catid, DoWorkEventArgs e)
        {
            if (Program.mf.querybkstatus())
            {
                e.Cancel = true;
                return;
            }
            AlibabacategorygetParam apara = new AlibabacategorygetParam();
            apara.setCategoryID(catid);
            apara.setWebSite("1688");
            AlibabacategorygetResult catres = instance.send<AlibabacategorygetResult>(apara);
            if (catres == null)
            {
                Program.mf.setcprogress();
                return;
            }
            AlibabacategoryCategoryInfo[] aci = catres.getCategoryInfo();
            if (aci == null)
            {
                Program.mf.setcprogress();
                return;
            }
            string catids = "";
            foreach (AlibabacategoryCategoryInfo c in aci)
            {
                catids += "'" + c.getCategoryID() + "'" + ",";
            }
            if (catids != "")
            {
                catids = catids.TrimEnd(',');
                string[] marray = null;//已存在商品分类数组
                CaiJiSql cs = new CaiJiSql();
                marray= cs.QueryCate(catids);
                foreach (AlibabacategoryCategoryInfo c in aci)
                {
                    if (marray!=null && marray.Contains(c.getCategoryID().ToString()))
                    {
                        /*已经存在该分类*/
                    }
                    else
                    {
                        /*不在该商品分类*/
                        Category cate = new Category();
                        cate.Catid = (c.getCategoryID()??0).ToString ();
                        cate.Catname = c.getName();
                        cate.Parentids = string.Join(",", c.getParentIDs());
                        cs.InsertCate(cate);
                    }
                    Program.mf.setcprogress();
                    if (!(c.getIsLeaf()??false))
                    {
                        /*不是叶子分类*/
                        long[] cd = c.getChildIDs();
                        foreach (long ck in cd)
                        {
                            CjChildrenCategory(ck,e);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 获取供应商总数
        /// </summary>
        /// <returns></returns>
        public int GetSuppliersCount()
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
        /// 采集供应商方法
        /// </summary>
        /// <param name="i"></param>
        /// <param name="pagesize"></param>
        public void CjSuppliers(int i, int pagesize, int allpage, int allcount)
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
                        Program.mf.setsprogress();
                    }
                }
                else
                {
                    for (int k = 0; k < allcount - (pagesize * (i - 1)); k++)
                    {
                        Program.mf.setsprogress();
                    }
                }
                return;
            }
            Alibabarelationsuppliersresult ssse = qsres.getResult();
            AlibabarelationsupplierModel[] smodel = ssse.getRelationModels();

            string memberIds = "";
            foreach (AlibabarelationsupplierModel m in smodel)
            {
                memberIds += "'" + m.getMemberId() + "'" + ",";
            }
            if (memberIds != "")
            {
                memberIds = memberIds.TrimEnd(',');
                string[] marray = null;
                CaiJiSql cs = new CaiJiSql();
                marray= cs.QuerySuppliers(memberIds);
                foreach (AlibabarelationsupplierModel m in smodel)
                {
                    if (marray!=null && marray.Contains(m.getMemberId()))
                    {
                        /*已存在该供应商*/
                        Program.mf.setsprogress();
                    }
                    else {
                        /*不存在该供应商*/
                        Supplier supp = new Supplier();
                        supp.Memberid = m.getMemberId();
                        supp.Company = m.getSupplierCompany();
                        supp.Loginid = m.getSupplierLoginId();
                        supp.Consignstatus = m.getConsignStatus();

                        DateTime today = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
                        long lTime = long.Parse(m.getConsignCreateTime().ToString() + "0000");
                        TimeSpan toNow = new TimeSpan(lTime);
                        today = today.Add(toNow);
                        supp.Consigncreatetime = today;

                        cs.InsertSupplier(supp);
                        Program.mf.setsprogress();
                    }
                }
            }
        }

        /// <summary>
        /// 获取单个供应商商品总数
        /// </summary>
        /// <param name="member"></param>
        /// <returns></returns>
        public int GetProductCount(string member)
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

        class detailobj
        {
            public AlibabadaixiaoProductInfo ap;
            public string memberid;
        }

         /// <summary>
         /// 采集商品列表信息
         /// </summary>
         /// <param name="cpage"></param>
         /// <param name="pagesize"></param>
         /// <param name="member"></param>
         /// <param name="allcount"></param>
         /// <param name="allpage"></param>
        public void CjProduct(int cpage, int pagesize, string member, int allcount, int allpage)
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
                    for (int k = 0; k < pagesize; k++)
                    {
                       Program.mf.setprogress();
                    }
                }
                else
                {
                    for (int k = 0; k < (allcount - (pagesize * (cpage - 1))); k++)
                    {
                        Program.mf.setprogress();
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
                string[] parray = null;
                CaiJiSql cs = new CaiJiSql();
                parray=cs.QueryProducts(productids);
                foreach (AlibabadaixiaoProductInfo p in proinfo)
                {
                    string pid = p.getProductId().ToString();
                    if (parray!=null && parray.Contains(pid))
                    {
                        /*已存在该商品*/
                        Program.mf.setprogress();
                    }
                    else
                    {
                        /*不存在该商品*/
                        detailobj dobj = new detailobj();
                        dobj.memberid = member;
                        dobj.ap = p;

                        Thread th = new Thread(GetProductDeatail);
                        th.IsBackground = true;
                        th.Start(dobj);
                    }
                }
                if (cpage < allpage)
                {
                    for (int j = 0; j < pagesize - proinfo.Length; j++)
                    {
                        Program.mf.setprogress();
                    }
                }
                else
                {
                    int ed = allcount - pagesize * (cpage - 1);
                    for (int j = 0; j < ed - proinfo.Length; j++)
                    {
                        Program.mf.setprogress();
                    }
                }
            }
            else
            {
                if (cpage < allpage)
                {
                    for (int k = 0; k < pagesize; k++)
                    {
                        Program.mf.setprogress();
                    }
                }
                else
                {
                    int ed = allcount - pagesize * (cpage - 1);
                    for (int j = 0; j < ed - proinfo.Length; j++)
                    {
                        Program.mf.setprogress();
                    }
                }
            }
        }

        /// <summary>
        /// 采集商品详情
        /// </summary>
        /// <param name="obj"></param>
        public void GetProductDeatail(object obj)
        {
            detailobj dobj = (obj as detailobj);
            AlibabadaixiaoProductInfo p = dobj.ap;
            if (p.getOfferStatus().ToUpper() != "PUBLISHED")
            {
                Program.mf.setprogress();
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
                Program.mf.setprogress();
                return;
            }
            AlibabaproductProductInfo proproinfo = prores.getProductInfo();
            if (proproinfo == null)
            {
                Program.mf.setprogress();
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

            string proattr = (proattrs != null) ? JsonConvert.SerializeObject(proattrs) : "";
            string skuinfo = (proskuinfos != null) ? JsonConvert.SerializeObject(proskuinfos) : "";
            string saleinfo = (prosale != null) ? JsonConvert.SerializeObject(prosale) : "";
            string extendinfos = (proextens != null) ? JsonConvert.SerializeObject(proextens) : "";
            string skumodelstr = p.getSkuModelStr();

            string producttitle = proproinfo.getSubject();
            string offerstatus = proproinfo.getStatus();
            long supplystock = (long)(prosale.getAmountOnSale()??0);
            long catid = proproinfo.getCategoryID()??0;
            int dsccatid = 0;
            decimal shop_price = 0m;
            decimal market_price = 0m;
            decimal[] price = GetShoppriceAndMarketprice(p,prosale);
            shop_price = price[0];
            market_price = price[1];

            CaiJiSql cs = new CaiJiSql();
            dsccatid = Convert.ToInt32(cs.QueryCatebyId(catid));

            ProductInfo ptinfo = new ProductInfo();
            ptinfo.Productid = proid.ToString ();
            ptinfo.Producttitle = producttitle;
            ptinfo.Desction = desction;
            ptinfo.Catid = catid;
            ptinfo.Skumodelstr = skumodelstr;
            ptinfo.Detailpara = proattr;
            ptinfo.Offerstatus = offerstatus;
            ptinfo.Supplystock = supplystock;
            ptinfo.Skuinfos = skuinfo;
            ptinfo.Imagelist = string.Join(",", imagelist);
            ptinfo.Saleinfo = saleinfo;
            ptinfo.Extendinfos = extendinfos;
            ptinfo.Memberid = memberid;

            Product pt = new Product();
            pt.Goods_sn = proid.ToString();
            pt.Goods_name = producttitle;
            pt.Goods_desc = desction;
            pt.Goods_number = (int)supplystock;
            pt.Cat_id = dsccatid;
            pt.Goods_thumb = imagelist[0];
            pt.Shop_price = shop_price;
            pt.Market_price = market_price;

            cs.InsertProduct(ptinfo, pt);
            Program.mf.setprogress();
        }

        /// <summary>
        /// 获取代销价和零售价格
        /// </summary>
        private decimal[] GetShoppriceAndMarketprice(AlibabadaixiaoProductInfo p,AlibabaproductProductSaleInfo prosale)
        {
            decimal shop_price = 0m;
            decimal market_price = 0m;
            int quotytype = (int)prosale.getQuoteType();
            if (quotytype == 0)
            {
                shop_price = Convert.ToDecimal(p.getMaxPurchasePrice());
                string sellprice = p.getSellPrice();
                if (sellprice != "" && sellprice != null)
                {
                    market_price = Convert.ToDecimal(sellprice);
                }
                else
                {
                    decimal dl = 0m;
                    dl = GetpriceFromSkumodelstr(p);
                    if (dl > 0)
                    {
                        market_price = dl;
                    }
                    else
                    {
                        dl = GetpriceFromSaleinfo(prosale);
                        if (dl > 0)
                        {
                            market_price = dl;
                        }
                        else
                        {
                            market_price = shop_price * 1.2m;
                        }
                    }
                }
            }
            else
            {
                shop_price = Convert.ToDecimal(p.getMaxPurchasePrice());
                string sellprice = p.getSellPrice();
                if (sellprice != "" && sellprice != null)
                {
                    string[] sprice = sellprice.Split('~');
                    if (sprice.Length > 1)
                    {
                        market_price = Convert.ToDecimal(sprice[1]);
                    }
                    else if (sprice.Length == 1)
                    {
                        market_price = Convert.ToDecimal(sprice[0]);
                    }
                }
                else
                {
                    decimal dl = 0m;
                    dl = GetpriceFromSaleinfo(prosale);
                    if (dl > 0)
                    {
                        market_price = dl;
                    }
                    else
                    {
                        market_price = shop_price * 1.2m;
                    }
                }
            }

            decimal[] price = new decimal[2];
            price[0] = shop_price;
            price[1] = market_price;
            return price;
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


    }
}