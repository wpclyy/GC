using System;
using com.goudiw;
using goudiw.sdk.client.policy;

namespace dscapi.dsc.goods
{
    public class Attributeupdate: Request
    {
        public Attributeupdate(string attr_id)
        {
            OceanApiId = new APIId();
            OceanApiId.NamespaceValue = "method";
            OceanApiId.Name = "dsc.attribute.update.post";
            OceanApiId.Strtypename = "format";
            OceanApiId.Strtypevalue = "json";
            OceanApiId.Version = 1;
            OceanApiId.Filedname = "attr_id";
            OceanApiId.Filedvalue = attr_id;
            RequestPolicyInstance = new RequestPolicy();
            RequestPolicyInstance.UseHttps = false;
            RequestPolicyInstance.HttpMethod = "POST";
        }

        int cat_id;//属性类型ID
        public int getcat_id()
        {
            return cat_id;
        }

        public void setcat_id(int cat_id)
        {
            this.cat_id = cat_id;
        }

        string attr_name;//属性名称
        public string getattr_name()
        {
            return attr_name;
        }

        public void setattr_name(string attr_name)
        {
            this.attr_name = attr_name;
        }

        int attr_cat_type;//分类筛选样式
        public int getattr_cat_type()
        {
            return attr_cat_type;
        }

        public void setattr_cat_type(int attr_cat_type)
        {
            this.attr_cat_type = attr_cat_type;
        }

        int attr_input_type;//      该属性值的录入方式

        public int getattr_input_type()
        {
            return attr_input_type;
        }

        public void setattr_input_type(int attr_input_type)
        {
            this.attr_input_type = attr_input_type;
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

        string attr_values;//        可选值列表
        public string getattr_values()
        {
            return attr_values;
        }

        public void setattr_values(string attr_values)
        {
            this.attr_values = attr_values;
        }

        int attr_index;// 能否进行检索
        public int getattr_index()
        {
            return attr_index;
        }

        public void setattr_index(int attr_index)
        {
            this.attr_index = attr_index;
        }

        int sort_order;//      排序
        public int getsort_order()
        {
            return sort_order;
        }

        public void setsort_order(int sort_order)
        {
            this.sort_order = sort_order;
        }

        int is_linked;// 相同属性值的商品是否关联
        public int getis_linked()
        {
            return is_linked;
        }

        public void setis_linked(int is_linked)
        {
            this.is_linked = is_linked;
        }
    }
}
