using System;
using com.goudiw;
using goudiw.sdk.client.policy;

namespace dscapi.dsc.goods
{
    public class GoodsType: Request
    {
        public GoodsType()
        {
            OceanApiId = new APIId();
            OceanApiId.NamespaceValue = "method";
            OceanApiId.Name = "dsc.goodstype.insert.post";
            OceanApiId.Strtypename = "format";
            OceanApiId.Strtypevalue = "json";
            OceanApiId.Version = 1;
            RequestPolicyInstance = new RequestPolicy();
            RequestPolicyInstance.UseHttps = false;
            RequestPolicyInstance.HttpMethod = "POST";
        }

        int user_id;//     Number 商家ID
        public int getuser_id()
        {
            return user_id;
        }

        public void setuser_id(int user_id)
        {
            this.user_id = user_id;
        }
        string cat_name;// String      属性类型名称
        public string getcat_name()
        {
            return cat_name;
        }

        public void setcat_name(string cat_name)
        {
            this.cat_name = cat_name;
        }
        int enabled;//     Number 默认值 1
        public int getenabled()
        {
            return enabled;
        }

        public void setenabled(int enabled)
        {
            this.enabled = enabled;
        }
        string attr_group;// Text        分组
        public string getattr_group()
        {
            return attr_group;
        }

        public void setattr_group(string attr_group)
        {
            this.attr_group = attr_group;
        }
    }
}
