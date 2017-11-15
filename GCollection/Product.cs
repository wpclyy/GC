using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCollection
{
 public   class Product
    {
        private string status;
        private string goods_sn="";
        private string goods_name = "";
        private int brand_id=0;
        private int goods_number=1000;
        private decimal goods_weight=0;
        private decimal market_price=0.00m;
        private decimal shop_price=0.00m;
        private int is_best=0;
        private int is_new=0;
        private int is_hot=0;
        private int is_on_sale=1;
        private int is_alone_sale=1;
        private int is_shipping=0;
        private int freight=0;
        private string goods_brief="";
        private string goods_desc="";
        private int cat_id;
        private int is_real=1;
        private int integral=0;
        private int is_delete=0;
        private int is_xiangou=0;
        private int xiangou_num=0;
        private int xiangou_start_date=0;
        private int xiangou_end_date=0;
        private int add_time=0;
        private int last_update=0;
        private string goods_img="";
        private string goods_thumb="";
        private string original_img="";

        /// <summary>
        /// 商品状态
        /// </summary>
        public string Status
        {
            get { return status; }
            set {
                status = value;
            }
        }

        /// <summary>
        /// 商品货号
        /// </summary>
        public string Goods_sn
        {
            get { return goods_sn; }
            set
            {
                goods_sn = value;
            }
        }

        /// <summary>
        /// 商品名称
        /// </summary>
        public string Goods_name
        {
            get { return goods_name; }
            set
            {
                goods_name = value;
            }
        }

        /// <summary>
        /// 商品品牌
        /// </summary>
        public int Brand_id
        {
            get { return brand_id; }
            set
            {
                brand_id = value;
            }
        }

        /// <summary>
        /// 商品库存
        /// </summary>
        public int Goods_number
        {
            get { return goods_number; }
            set
            {
                goods_number = value;
            }
        }

        /// <summary>
        /// 商品重量(千克)
        /// </summary>
        public decimal Goods_weight
        {
            get { return goods_weight; }
            set
            {
                goods_weight = value;
            }
        }

        /// <summary>
        /// 市场价格
        /// </summary>
        public decimal Market_price
        {
            get { return market_price; }
            set
            {
                market_price = value;
            }
        }

        /// <summary>
        /// 本店价格
        /// </summary>
        public decimal Shop_price
        {
            get { return shop_price; }
            set
            {
                shop_price = value;
            }
        }

        /// <summary>
        /// 是否精品
        /// </summary>
        public int Is_best
        {
            get { return is_best; }
            set
            {
                is_best = value;
            }
        }

        /// <summary>
        /// 是否新品
        /// </summary>
        public int Is_new
        {
            get { return is_new; }
            set
            {
                is_new = value;
            }
        }

        /// <summary>
        /// 热销
        /// </summary>
        public int Is_hot
        {
            get { return is_hot; }
            set
            {
                is_hot = value;
            }
        }

        /// <summary>
        /// 是否上架
        /// </summary>
        public int Is_on_sale
        {
            get { return is_on_sale; }
            set
            {
                is_on_sale = value;
            }
        }

        /// <summary>
        /// 是否作为普通商品销售
        /// </summary>
        public int Is_alone_sale
        {
            get { return is_alone_sale; }
            set
            {
                is_alone_sale = value;
            }
        }

        /// <summary>
        /// 是否免运费
        /// </summary>
        public int Is_shipping
        {
            get { return is_shipping; }
            set
            {
                is_shipping = value;
            }
        }

        /// <summary>
        /// 运费模式
        /// </summary>
        public int Freight
        {
            get { return freight; }
            set
            {
                freight = value;
            }
        }


        /// <summary>
        /// 商品简短描述
        /// </summary>
        public string Goods_brief
        {
            get { return goods_brief; }
            set
            {
                goods_brief = value;
            }
        }

        /// <summary>
        /// 商品详细描述
        /// </summary>
        public string Goods_desc
        {
            get { return goods_desc; }
            set
            {
                goods_desc = value;
            }
        }

        /// <summary>
        /// 商品分类ID
        /// </summary>
        public int Cat_id
        {
            get { return cat_id; }
            set
            {
                cat_id = value;
            }
        }

        /// <summary>
        /// 是否实体商品
        /// </summary>
        public int Is_real
        {
            get { return is_real; }
            set
            {
                is_real = value;
            }
        }

        /// <summary>
        /// 积分购买金额
        /// </summary>
        public int Integral
        {
            get { return integral; }
            set
            {
                integral = value;
            }
        }

        /// <summary>
        /// 是否删除
        /// </summary>
        public int Is_delete
        {
            get { return is_delete; }
            set
            {
                is_delete = value;
            }
        }

        /// <summary>
        /// 是否限购
        /// </summary>
        public int Is_xiangou
        {
            get { return is_xiangou; }
            set
            {
                is_xiangou = value;
            }
        }

        /// <summary>
        /// 限购数量
        /// </summary>
        public int Xiangou_num
        {
            get { return xiangou_num; }
            set
            {
                xiangou_num = value;
            }
        }

        /// <summary>
        /// 限购开始时间
        /// </summary>
        public int Xiangou_start_date
        {
            get { return xiangou_start_date; }
            set
            {
                xiangou_start_date = value;
            }
        }

        /// <summary>
        /// 限购结束时间
        /// </summary>
        public int Xiangou_end_date
        {
            get { return xiangou_end_date; }
            set
            {
                xiangou_end_date = value;
            }
        }

        /// <summary>
        /// 商品新增时间
        /// </summary>
        public int Add_time
        {
            get { return add_time; }
            set
            {
                add_time = value;
            }
        }

        /// <summary>
        /// 商品最后修改时间
        /// </summary>
        public int Last_update
        {
            get { return last_update; }
            set
            {
                last_update = value;
            }
        }

        /// <summary>
        /// 商品图片
        /// </summary>
        public string Goods_img
        {
            get { return goods_img; }
            set
            {
                if (value == null)
                {
                    goods_img = "";
                }
                else
                {
                    goods_img = value;
                }
            }
        }

        /// <summary>
        /// 商品主图
        /// </summary>
        public string Goods_thumb
        {
            get { return goods_thumb; }
            set
            {
                if (value == null)
                {
                    goods_thumb = "";
                }
                else
                {
                    goods_thumb = value;
                }
            }
        }

        /// <summary>
        /// 商品原始图
        /// </summary>
        public string Original_img
        {
            get { return original_img; }
            set
            {
                if (value == null)
                {
                    original_img = "";
                }
                else
                {
                    original_img = value;
                }
            }
        }

    }
}
