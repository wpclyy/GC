using System;
namespace entity
{
    public class Attribute
    {
        int Attr_id;// Number      属性ID
        public int attr_id
        {
            get { return Attr_id; }
            set { Attr_id = value; }
        }
        int Cat_id;// Number 属性类型ID
        public int cat_id
        {
            get { return Cat_id; }
            set { Cat_id = value; }
        }

        string Attr_name;// String      属性名称
        public string attr_name
        {
            get { return Attr_name; }
            set { Attr_name = value; }
        }

        int Attr_cat_type;//   Number 分类筛选样式
        public int attr_cat_type
        {
            get { return Attr_cat_type; }
            set { Attr_cat_type = value; }
        }

        int Attr_input_type;// Number      该属性值的录入方式
        public int attr_input_type
        {
            get { return Attr_input_type; }
            set { Attr_input_type = value; }
        }

        int Attr_type;//   Number 属性是否可选
        public int attr_type
        {
            get { return Attr_type; }
            set { Attr_type = value; }
        }

        string Attr_values;// Text        可选值列表
        public string attr_values
        {
            get { return Attr_values; }
            set { Attr_values = value; }
        }

        int Attr_index;//  Number 能否进行检索
        public int attr_index
        {
            get { return Attr_index; }
            set { Attr_index = value; }
        }

        int Sort_order;// Number      排序
        public int sort_order
        {
            get { return Sort_order; }
            set { Sort_order = value; }
        }

        int Is_linked;//   Number 相同属性值的商品是否关联
        public int is_linked
        {
            get { return Is_linked; }
            set { Is_linked = value; }
        }
    }
}
