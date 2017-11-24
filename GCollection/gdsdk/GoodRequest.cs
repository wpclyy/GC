using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text.RegularExpressions;
using com.goudiw;
using dscapi.dsc.goods;
using goudiw.sdk.client.policy;
using HtmlAgilityPack;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace dscapi.gdsdk
{
    public class GoodRequest
    {
        SyncAPIClient instance = null;
        string alistr = "";
        public DeserialSpec dspec = null;
        public GoodRequest(string alistr)
        {
            ClientPolicy clientPolicy = new ClientPolicy();
            clientPolicy.AppKey = "4291F75C-A7B9-4DB3-AADC-234490550B14";
            instance = new SyncAPIClient(clientPolicy);
            //解析规格
            dspec = new DeserialSpec(instance, alistr);
            this.alistr = alistr;
        }

        /// <summary>
        /// 总商品采集方法
        /// </summary>
        /// <returns>The submit.</returns>
        /// <param name="dr">Dr.</param>
        /// <param name="goodstypecatid">属性分类.</param>
        /// <param name="category_id">商品分类</param>
        public void Submit(DataRow dr,int goodstypecatid,int category_id)
        {
            string[] imglt = dr["imagelist"].ToString().Split(',');
            string saleinfo = dr["saleinfo"].ToString();
            string goodsname = dr["productTitle"].ToString();
            string productID = dr["productID"].ToString();
            string desction = dr["desction"].ToString();
            string spec = dr["skumodelstr"].ToString();
            string specinfo = dr["skuInfos"].ToString();
            string detailpara = dr["detailpara"].ToString();
            int cat_id = setgoodstypecat(goodsname);
            int goods_id = setgoods(category_id, goodsname, productID, cat_id, 1,0,0,0,0, 0f,0f,1000,0);
            Dictionary<string, JObject> uploadimg = updategoodsdesc(goods_id, imglt, desction);

            setspec(spec, specinfo, goods_id, cat_id, uploadimg);

            dspec.GoodDetailPara(detailpara, goods_id, cat_id);
            Console.WriteLine("规格值去重并提交\r\n");

            Console.WriteLine("---------" + dr["productTitle"].ToString() + "--------");
        }


        /// <summary>
        /// 添加属性类型
        /// </summary>
        /// <returns>The setgoodstypecat.</returns>
        /// <param name="goodsname">Goodsname.</param>
        public int setgoodstypecat(string goodsname)
        {
            GoodsType gt = new GoodsType();
            gt.setuser_id(0);
            gt.setcat_name(goodsname);
            gt.setenabled(1);
            gt.setattr_group("");
            string obj = instance.send<string>(gt);
            JObject sm = (JObject)JsonConvert.DeserializeObject(obj);
            if (sm["result"].ToString() == "success")
            {
                return int.Parse(sm["id"].ToString());
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// 插入商品基本信息
        /// </summary>
        /// <returns>The setgoods.</returns>
        /// <param name="category_id">Category identifier.</param>
        /// <param name="saleinfo">Saleinfo.</param>
        /// <param name="goodsname">Goodsname.</param>
        /// <param name="productID">Product identifier.</param>
        /// <param name="cat_id">Cat identifier.</param>
        /// <param name="spec">Spec.</param>
        /// <param name="on_sale">是否上架</param>
        public int setgoods( int category_id,string goodsname,string productID,int cat_id,int on_sale,int is_shipping,int is_best,int is_new,int is_hot,float shop_price,float maket_price,int amountonsale,int brand_id)
        {
            //产品价格
            float reprice = 0;
            float retailprice = 0;
            reprice = shop_price ;
            retailprice = maket_price ;

            //插入商品
            Goods gd = new Goods();
            gd.setcat_id(category_id);
            gd.setuser_id(0);
            gd.setgoods_name(goodsname);
            gd.setbrand_id(brand_id);
            gd.setgoods_sn(productID);
            gd.setgoods_number(amountonsale);
            gd.setmarket_price(retailprice);
            gd.setshop_price(reprice);
            gd.setreview_status(3);
            gd.setis_alone_sale(1);
            gd.setis_real(1);
            gd.setis_on_sale(on_sale);
            gd.setis_shipping(is_shipping);
            gd.setis_best(is_best);
            gd.setis_hot(is_hot);
            gd.setis_new(is_new);
            gd.setgoods_type(cat_id);
            string obj = instance.send<string>(gd);
            JObject sm = (JObject)JsonConvert.DeserializeObject(obj);

            //商品规格
            if (sm["result"].ToString() == "success")
            {
                return int.Parse(sm["id"].ToString());
            }
            else{
                return 0;
            }
        }

        /// <summary>
        /// 更新商品基本信息
        /// </summary>
        /// <returns>The updategoodsdesc.</returns>
        /// <param name="goods_id">Goods identifier.</param>
        /// <param name="imglt">Imglt.</param>
        /// <param name="desction">Desction.</param>
        public Dictionary<string, JObject> updategoodsdesc(int goods_id,string[] imglt,string desction)
        {
            //图片上传后保存图片地址和所对应的ID,以便下面做对比
            Dictionary<string, JObject> uploadimg = new Dictionary<string, JObject>();
            //商品相册

            List<string> imglist = new List<string>();
            foreach (string i in imglt)
            {
                if (!imglist.Contains(i))
                {
                    imglist.Add(i);
                }
            }

            Console.WriteLine("插入商品基本信息");
            //插入图片

            Image img = new Image();
            img.setid(goods_id);

            Stream s = null;
            using (HttpClientClass hc = new HttpClientClass())
            {
                s = hc.htmlimg(alistr + imglist[0]);
            }
            string result = instance.sendimg<string>(new UploadParameterType { UploadStream = s, FileNameValue = "goudiw.jpg" }, img);
            JObject im = (JObject)JsonConvert.DeserializeObject(result);
            if (im["error"].ToString() == "0")
            {
                Console.WriteLine("上传封面图片\r\n");
                uploadimg.Add(imglist[0], im);
            }
            //更新产品封面图片
            Goodupdate gu = new Goodupdate(goods_id.ToString());
            gu.setgoods_thumb(im["data"]["goods_thumb"].ToString());
            gu.setgoods_img(im["data"]["goods_img"].ToString());
            gu.setoriginal_img(im["data"]["original_img"].ToString());

            string gdobj = instance.send<string>(gu);
            JObject upgd = (JObject)JsonConvert.DeserializeObject(gdobj);
            Console.WriteLine("更新封面图片\r\n");
            for (int g = 1; g < imglist.Count; g++)
            {
                s = null;
                using (HttpClientClass hc = new HttpClientClass())
                {
                    s = hc.htmlimg(alistr + imglist[g]);
                }
                result = instance.sendimg<string>(new UploadParameterType { UploadStream = s, FileNameValue = "goudiw.jpg" }, img);
                im = (JObject)JsonConvert.DeserializeObject(result);
                if (im["error"].ToString() == "0")
                {
                    uploadimg.Add(imglist[g], im);
                }
            }
            Console.WriteLine("上传相册图片\r\n");
            //更新商品详情
            gu = new Goodupdate(goods_id.ToString());
            //解析阿里巴巴商品详情信息，获取其中图片
            DeHtml dh = new DeHtml();
            HtmlDocument dc = dh.htmlformat(desction);
            HtmlNode rootnode = dc.DocumentNode;
            HtmlNodeCollection aa = rootnode.SelectNodes("//img");
            string imagesrc = "";
            foreach (HtmlNode imgs in aa)
            {
                string src = imgs.Attributes["src"] != null ? imgs.Attributes["src"].Value : "";
                src = RegexURL(src);
                imagesrc += src != "" ? " <p><img src=\"" + src + "\"/></p>" : "";
            }

            gu.setgoods_desc(imagesrc);

            gdobj = instance.send<string>(gu);
            upgd = (JObject)JsonConvert.DeserializeObject(gdobj);

            return uploadimg;
        }

        /// <summary>
        /// 设置商品规格
        /// </summary>
        /// <returns>The setspec.</returns>
        /// <param name="dr">Dr.</param>
        /// <param name="goods_id">Goods identifier.</param>
        /// <param name="cat_id">Cat identifier.</param>
        /// <param name="uploadimg">Uploadimg.</param>
        public void setspec(string skumodelstr, string specinfo,int goods_id,int cat_id,Dictionary<string, JObject> uploadimg)
        {
            Dictionary<string, entity.Attribute> speclist = dspec.Deserial(skumodelstr, instance, cat_id);
            Console.WriteLine("解析规格数据\r\n");
            JArray goods_attr = dspec.QuChong(skumodelstr,specinfo, speclist, goods_id, uploadimg);
            if (goods_attr != null)
            {
                foreach (JToken j in goods_attr)
                {
                    string price = j["price"].ToString();
                    string retailPrice = j["retailPrice"].ToString();
                    //List<string> attridlist = new List<string>();
                    //foreach (JToken t in j["attributes"].Children())
                    //{
                    //    attridlist.Add(t["attValueID"].ToString());
                    //}
                    //string[] attids = attridlist.ToArray();
                    //string attridstr = string.Join("|", attids);

                    List<string> listgoodsattrids = new List<string>(); ;
                    foreach (KeyValuePair<string, entity.Attribute> sl in speclist)
                    {
                        entity.Attribute attr = sl.Value;
                        List<string> speval = new List<string>(attr.attr_values.Split(new string[] { "\r\n" }, StringSplitOptions.None));
                        foreach (JToken t in j["attributes"].Children())
                        {
                            if (speval.Contains(t["attributeValue"].ToString()))
                            {
                                listgoodsattrids.Add(t["attValueID"].ToString());
                                break;
                            }
                        }
                    }
                    string[] attids = listgoodsattrids.ToArray();
                    string attridstr = string.Join("|", attids);
                    Products pd = new Products();
                    pd.setgoods_id(goods_id);
                    pd.setgoods_attr(attridstr);
                    pd.setproduct_price(price);
                    pd.setproduct_market_price(retailPrice);
                    pd.setproduct_number(1000);
                    string result = instance.send<string>(pd);
                    JObject im = (JObject)JsonConvert.DeserializeObject(result);
                }

            }
        }


        /// <summary>
        /// 解析地址判断是否为正确url地址
        /// </summary>
        /// <returns>The URL.</returns>
        /// <param name="url">URL.</param>
        public string RegexURL(string url)
        {
            string Pattern = @"^(http|https|ftp)\://[a-zA-Z0-9\-\.]+\.[a-zA-Z]{2,3}(:[a-zA-Z0-9]*)?/?([a-zA-Z0-9\-\._\?\,\'/\\\+&$%\$#\=~])*$";
            Regex r = new Regex(Pattern);
            Match m = r.Match(url);
            if (m.Success)
            {
                return url.Trim();
            }
            else{
                return "";
            }
        }

    }
}
