using System.Collections.Generic;
using System.Data;
using dscapi.dsc.goods;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.IO;

namespace com.goudiw
{
    public class DeserialSpec
    {
        SyncAPIClient instance = null;
        string alistr = "";
        public DeserialSpec(SyncAPIClient instance,string alistr)
        {
            this.instance = instance;
            this.alistr = alistr;
        }

        /// <summary>
        /// 解析阿里巴巴数据中的规格信息，对比现有规格，有则增加
        /// </summary>
        /// <returns>The deserial.</returns>
        /// <param name="dr">阿里巴巴数据集</param>
        /// <param name="instance">实例化api</param>
        /// <param name="cat_id">商品类型</param>
        public Dictionary<string, entity.Attribute>  Deserial(string spec,SyncAPIClient instance,int cat_id)
        {
            JObject spsm = (JObject)JsonConvert.DeserializeObject(spec);
            Dictionary<string, List<string>> specdic = new Dictionary<string, List<string>>();
            if (spsm != null)
            {
                JToken skuList = spsm["skuList"];
                //解析出来的规格和值

                foreach (JToken j in skuList.Children())
                {
                    JToken jc = j["attributeModelList"];
                    foreach (JToken jcc in jc)
                    {
                        string key = "";
                        string val = "";
                        if (jcc["sourceAttributeValue"] != null && jcc["sourceAttributeName"].ToString() != "")
                        {
                            key = jcc["sourceAttributeName"].ToString();
                            val = jcc["sourceAttributeValue"].ToString();
                        }
                        else if (jcc["targetAttributeValue"] != null && jcc["targetAttributeValue"].ToString() != "")
                        {
                            key = jcc["targetAttributeName"].ToString();
                            val = jcc["targetAttributeValue"].ToString();
                        }

                        if (specdic.ContainsKey(key))
                        {
                            if (!specdic[key].Contains(val))
                            {
                                specdic[key].Add(val);
                            }
                        }
                        else
                        {
                            List<string> lt = new List<string>();
                            lt.Add(val);
                            specdic.Add(key, lt);
                        }
                    }
                }
            }

            AttributeList al = new AttributeList();
            al.setcat_id(cat_id);
            al.setattr_type(1);
            string alobj = instance.send<string>(al);
            JObject alsm = (JObject)JsonConvert.DeserializeObject(alobj);
            //现有规格属性
            JToken list = alsm["info"]["list"];

            //相同规格属性值对比，现有值中没有则增加
            Dictionary<string,entity.Attribute> reloadspec = new Dictionary<string, entity.Attribute>();
            foreach(KeyValuePair<string,List<string>> att in specdic)
            {
                    dscapi.dsc.goods.Attribute at = new dscapi.dsc.goods.Attribute();
                    at.setcat_id(cat_id);
                    at.setattr_name(att.Key);
                    at.setattr_cat_type(0);
                    at.setattr_input_type(1);
                    at.setattr_type(1);
                    string sval = "";
                    foreach (string v in att.Value)
                    {
                        if (sval.Trim() == "")
                        {
                            sval = v;
                        }
                        else
                        {
                            sval += "\r\n" + v;
                        }
                    }
                    at.setattr_values(sval);
                    string result = instance.send<string>(at);
                    JObject obj = (JObject)JsonConvert.DeserializeObject(result);
                    entity.Attribute ae = new entity.Attribute();
                    ae.attr_id = int.Parse(obj["id"].ToString());
                    ae.cat_id = cat_id;
                    ae.attr_name = att.Key;
                    ae.attr_cat_type = 0;
                    ae.attr_input_type = 1;
                    ae.attr_type = 1;
                    ae.attr_values = sval;
                    ae.attr_index = 0;
                    ae.sort_order = 0;
                    ae.is_linked = 0;
                    reloadspec.Add(att.Key, ae);
            }
            return reloadspec;
        }

        /// <summary>
        /// Qus the chong.
        /// </summary>
        /// <returns>The chong.</returns>
        /// <param name="dr">Dr.</param>
        /// <param name="speclist">Speclist.</param>
        /// <param name="goods_id">Goods identifier.</param>
        /// <param name="uploadimg">Uploadimg.</param>
        public JArray QuChong(string skumodelstr,string specinfo, Dictionary<string, entity.Attribute> speclist, int goods_id, Dictionary<string, JObject> uploadimg)
        {
            Stream s = null;
            string result = "";
            Image img = new Image();
            img.setid(goods_id);
            List<string> goods_attr = new List<string>();

            //规格匹配包括价格，第二次使用该字段数据
            //解析规格对应图片
           
            JObject obj = (JObject)JsonConvert.DeserializeObject(skumodelstr);
            if (obj != null)
            {
                JToken jt = obj["skuList"];
                object oo = JsonConvert.DeserializeObject(specinfo);
                JArray spinfosm = (JArray)oo;
                if (oo != null)
                {
                    //合并相同属性值
                    Dictionary<string, string> qucongspec = new Dictionary<string, string>();

                    foreach (JToken ssm in spinfosm)
                    {
                        foreach (JToken d in ssm["attributes"].Children())
                        {
                            string attributeValue = d["attributeValue"].ToString();
                            string skuImageUrl = d["skuImageUrl"].ToString();
                            if (!qucongspec.ContainsKey(attributeValue))
                            {
                                qucongspec.Add(attributeValue, skuImageUrl);
                            }
                        }

                    }

                    //获取属性值所属ID
                    Dictionary<string, string[]> newval = new Dictionary<string, string[]>();
                    foreach (KeyValuePair<string, string> jj in qucongspec)
                    {

                        foreach (KeyValuePair<string, entity.Attribute> sl in speclist)
                        {
                            entity.Attribute attr = sl.Value;
                            //和现有规格比较是否已存在
                            List<string> speval = new List<string>(attr.attr_values.Split(new string[] { "\r\n" }, StringSplitOptions.None));
                            //判断图片是否已在图片相册中，有则获取现有相册中图片地址，没有则上传图片获取返回图片地址
                            if (speval.Contains(jj.Key) && jj.Value.Trim() != "")
                            {

                                GoodsAttr ga = new GoodsAttr();
                                ga.setattr_id(attr.attr_id.ToString());
                                ga.setgoods_id(goods_id);
                                ga.setattr_value(jj.Key);

                                string goods_thumb = "";
                                string goods_img = "";
                                if (uploadimg.ContainsKey(jj.Value))
                                {
                                    JObject oop = uploadimg[jj.Value];
                                    goods_thumb = oop["data"]["goods_thumb"].ToString();
                                    goods_img = oop["data"]["goods_img"].ToString();
                                }
                                else
                                {
                                    using (HttpClientClass hc = new HttpClientClass())
                                    {
                                        s = hc.htmlimg(alistr + jj.Value);
                                    }
                                    result = instance.sendimg<string>(new UploadParameterType { UploadStream = s, FileNameValue = "goudiw.jpg" }, img);
                                    JObject oop = (JObject)JsonConvert.DeserializeObject(result);
                                    goods_thumb = oop["data"]["goods_thumb"].ToString();
                                    goods_img = oop["data"]["goods_img"].ToString();
                                }
                                ga.setattr_img_flie(goods_thumb);
                                ga.setattr_gallery_flie(goods_img);
                                ga.setattr_checked("0");
                                result = instance.send<string>(ga);
                                JObject attrresult = (JObject)JsonConvert.DeserializeObject(result);
                                if (attrresult["result"].ToString() == "success")
                                {
                                    checkattr(ref spinfosm, jt, jj.Key, attrresult["id"].ToString());
                                }
                            }
                            else if (speval.Contains(jj.Key))
                            {
                                GoodsAttr ga = new GoodsAttr();
                                ga.setattr_id(attr.attr_id.ToString());
                                ga.setgoods_id(goods_id);
                                ga.setattr_value(jj.Key);
                                ga.setattr_img_flie("");
                                ga.setattr_gallery_flie("");
                                ga.setattr_checked("0");
                                result = instance.send<string>(ga);
                                JObject attrresult = (JObject)JsonConvert.DeserializeObject(result);
                                if (attrresult["result"].ToString() == "success")
                                {
                                    checkattr(ref spinfosm, jt, jj.Key, attrresult["id"].ToString());
                                }
                            }
                        }
                    }
                }
                return spinfosm;
            }else{
                return null;
            }

        }

        /// <summary>
        /// 商品詳情規格參數
        /// </summary>
        /// <param name="dr">Dr.</param>
        /// <param name="goods_id">Goods identifier.</param>
        public void GoodDetailPara(string detailpara,int goods_id,int cat_id)
        {
            //商品詳情參數
            JArray obj = (JArray)JsonConvert.DeserializeObject(detailpara);
            foreach(JToken d in obj)
            {
                string attributeName = d["attributeName"].ToString();
                string val = d["value"].ToString();
                dscapi.dsc.goods.Attribute at = new dscapi.dsc.goods.Attribute();
                at.setcat_id(cat_id);
                at.setattr_name(attributeName);
                at.setattr_cat_type(0);
                at.setattr_input_type(0);
                at.setattr_type(0);
                at.setattr_values("");
                string result = instance.send<string>(at);
                JObject attrobj = (JObject)JsonConvert.DeserializeObject(result);

                if (attrobj["result"].ToString() == "success")
                {
                    GoodsAttr ga = new GoodsAttr();
                    ga.setattr_id(attrobj["id"].ToString());
                    ga.setgoods_id(goods_id);
                    ga.setattr_value(val);
                    ga.setattr_img_flie("");
                    ga.setattr_gallery_flie("");
                    ga.setattr_checked("0");
                    result = instance.send<string>(ga);
                    JObject attrresult = (JObject)JsonConvert.DeserializeObject(result);
                }
            }
        }



        private void checkattr(ref JArray spinfosm, JToken jt,string attrval ,string attr_id)
        {
            foreach (JToken j in jt.Children())
            {
                foreach (JToken t in j["attributeModelList"].Children())
                {

                    string key = "";
                    string val = "";
                    if (t["sourceAttributeValue"] != null && t["sourceAttributeName"].ToString() != "")
                    {
                        key = t["sourceAttributeName"].ToString();
                        val = t["sourceAttributeValue"].ToString();
                    }
                    else if (t["targetAttributeValue"] != null && t["targetAttributeValue"].ToString() != "")
                    {
                        key = t["targetAttributeName"].ToString();
                        val = t["targetAttributeValue"].ToString();
                    }

                    if (val.Trim() == attrval)
                    {
                        t["attr_id"] = attr_id;
                    }
                }
            }

            foreach (JToken sp in spinfosm)
            {
                foreach(JToken attr in sp["attributes"].Children())
                {
                    if (attr["attributeValue"].ToString() == attrval)
                    {
                        attr["attValueID"] = attr_id;
                    }
                }


                foreach (JToken j in jt.Children())
                {
                    if (sp["skuId"].ToString() == j["skuId"].ToString())
                    {
                        sp["retailPrice"] = j["retailPrice"].ToString();//代銷價
                        sp["price"] = j["proxyPrice"].ToString();
                    }
                }
            }
        }
    }
}
