using System;
using com.goudiw;
using goudiw.sdk.client.policy;

namespace dscapi.dsc.goods
{
    public class Goodupdate: Request
    {
        public Goodupdate(String goodid)
        {
            OceanApiId = new APIId();
            OceanApiId.NamespaceValue = "method";
            OceanApiId.Name = "dsc.goods.update.post";
            OceanApiId.Strtypename = "format";
            OceanApiId.Strtypevalue = "json";
            OceanApiId.Version = 1;
            OceanApiId.Filedname = "goods_id";
            OceanApiId.Filedvalue = goodid;
            RequestPolicyInstance = new RequestPolicy();
            RequestPolicyInstance.UseHttps = false;
            RequestPolicyInstance.HttpMethod = "POST";
        }


        string Goods_thumb;//商品缩略图
        /// <summary>
        /// 商品缩略图
        /// </summary>
        /// <value>The goods thumb.</value>
        public string getgoods_thumb()
        {
            return Goods_thumb;
        }
        public void setgoods_thumb(string Goods_thumb)
        {
            this.Goods_thumb = Goods_thumb;
        }

        string Goods_img;//商品的实际大小图片
        /// <summary>
        /// 商品的实际大小图片
        /// </summary>
        /// <value>The goods image.</value>
        public string getgoods_img()
        {
            return Goods_img;
        }
        public void setgoods_img(string Goods_img)
        {
            this.Goods_img = Goods_img;
        }


        string Original_img;//商品原图
        /// <summary>
        /// 商品原图
        /// </summary>
        /// <value>The original image.</value>
        public string getoriginal_img()
        {
            return Original_img;
        }
        public void setoriginal_img(string Original_img)
        {
            this.Original_img = Original_img;
        }

        string Goods_desc;//商品详情描述
        /// <summary>
        /// 商品详情描述
        /// </summary>
        /// <value>The goods desc.</value>
        public string getgoods_desc()
        {
            return Goods_desc;
        }
        public void setgoods_desc(string Goods_desc)
        {
            this.Goods_desc = Goods_desc;
        }

    }
}
