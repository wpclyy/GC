using System;
using com.goudiw;
using goudiw.sdk.client.policy;

namespace dscapi.dsc.goods
{
    public class GoodsAttr: Request
    {
        public GoodsAttr()
        {OceanApiId = new APIId();
            OceanApiId.NamespaceValue = "method";
            OceanApiId.Name = "dsc.goods.attr.insert.post";
            OceanApiId.Strtypename = "format";
            OceanApiId.Strtypevalue = "json";
            OceanApiId.Version = 1;
            RequestPolicyInstance = new RequestPolicy();
            RequestPolicyInstance.UseHttps = false;
            RequestPolicyInstance.HttpMethod = "POST";
        }

        int Goods_id;//   Number      商品ID
        public int getgoods_id()
        {
            return Goods_id;
        }
        public void setgoods_id(int Goods_id)
        {
            this.Goods_id = Goods_id;
        }

        string Attr_id;//    String      属性ID
        public string getattr_id()
        {
            return Attr_id;
        }
        public void setattr_id(string Attr_id)
        {
            this.Attr_id = Attr_id;
        }

        string Attr_value;//  Number      属性名称
        public string getattr_value()
        {
            return Attr_value;
        }
        public void setattr_value(string Attr_value)
        {
            this.Attr_value = Attr_value;
        }

        string Color_value;//     String      属性颜色
        public string getcolor_value()
        {
            return Color_value;
        }
        public void setcolor_value(string Color_value)
        {
            this.Color_value = Color_value;
        }

        string Attr_price;//  String      属性价格
        public string getattr_price()
        {
            return Attr_price;
        }
        public void setattr_price(string Attr_price)
        {
            this.Attr_price = Attr_price;
        }

        string Attr_sort;//   String      属性排序
        public string getattr_sort()
        {
            return Attr_sort;
        }
        public void setattr_sort(string Attr_sort)
        {
            this.Attr_sort = Attr_sort;
        }

        string Attr_img_flie;//   String      属性图片
        public string getattr_img_flie()
        {
            return Attr_img_flie;
        }
        public void setattr_img_flie(string Attr_img_flie)
        {
            this.Attr_img_flie = Attr_img_flie;
        }

        string Attr_gallery_flie;//   String      属性相册图
        public string getattr_gallery_flie()
        {
            return Attr_gallery_flie;
        }
        public void setattr_gallery_flie(string Attr_gallery_flie)
        {
            this.Attr_gallery_flie = Attr_gallery_flie;
        }

        string Attr_img_site;//   String      属性跳转链接地址
        public string getattr_img_site()
        {
            return Attr_img_site;
        }
        public void setattr_img_site(string Attr_img_site)
        {
            this.Attr_img_site = Attr_img_site;
        }

        string Attr_checked;//   String 
        public string getattr_checked()
        {
            return Attr_checked;
        }
        public void setattr_checked(string Attr_checked)
        {
            this.Attr_checked = Attr_checked;
        }


    }
}
