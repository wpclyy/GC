using System;
using com.goudiw;
using goudiw.sdk.client.policy;

namespace dscapi.dsc.goods
{
    public class AttributeList: Request
    {
        public AttributeList()
        {
            OceanApiId = new APIId();
            OceanApiId.NamespaceValue = "method";
            OceanApiId.Name = "dsc.attribute.list.get";
            OceanApiId.Strtypename = "format";
            OceanApiId.Strtypevalue = "json";
            OceanApiId.Version = 1;
            RequestPolicyInstance = new RequestPolicy();
            RequestPolicyInstance.UseHttps = false;
            RequestPolicyInstance.HttpMethod = "GET";
        }

        int cat_id;// Number  可选      （唯一性）   属性类型ID
        public int getcat_id()
        {
            return cat_id;
        }

        public void setcat_id(int cat_id)
        {
            this.cat_id = cat_id;
        }

        int page=1;//   Number  可选  1   默认  列表分页当前页
        public int getpage()
        {
            return page;
        }

        public void setpage(int page)
        {
            this.page = page;
        }

        int page_size=15;//  Number  可选  15  默认  列表分页每页显示条数
        public int getpage_size()
        {
            return page_size;
        }

        public void setpage_size(int page_size)
        {
            this.page_size = page_size;
        }

        int attr_type;// 属性是否可选
        public int getattr_type()
        {
            return attr_type;
        }

        public void setattr_type(int attr_type)
        {
            this.attr_type = attr_type;
        }
    }
}
