using System;
using com.goudiw;
using goudiw.sdk.client.policy;

namespace dscapi.dsc.goods
{
    public class Goods:Request
    {
        int Goods_id;//商品ID 
        /// <summary>
        /// 商品ID
        /// </summary>
        /// <value>The goods identifier.</value>
        public int getgoods_id()
        {
            return Goods_id;
        }

        public void setgoods_id(int Goods_id)
        {
            this.Goods_id = Goods_id;
        }


        int Cat_id;//分类ID
        /// <summary>
        /// 分类ID
        /// </summary>
        /// <value>The cat identifier.</value>
        public int getcat_id()
        {
            return Cat_id;
        }
        public void setcat_id(int Cat_id)
        {
            this.Cat_id = Cat_id;
        }

        int User_cat;//商家分类ID 
        /// <summary>
        /// 商家分类ID 
        /// </summary>
        /// <value>The user cat.</value>
        public int getuser_cat()
        {
            return User_cat;
        }
        public void setuser_cat(int User_cat)
        {
            this.User_cat = User_cat;
        }

        int User_id;//商家ID 
        /// <summary>
        /// 商家ID
        /// </summary>
        /// <value>The user identifier.</value>
        public int getuser_id()
        {
            return User_id;
        }
        public void setuser_id(int User_id)
        {
            this.User_id=User_id;
        }

        string Goods_sn;//商品货号
        /// <summary>
        /// 商品货号
        /// </summary>
        /// <value>The goods sn.</value>
        public string getgoods_sn()
        {
            return Goods_sn;
        }
        public void setgoods_sn(string Goods_sn)
        {
            this.Goods_sn = Goods_sn;
        }

        string Bar_code;//条形码
        /// <summary>
        /// 条形码
        /// </summary>
        /// <value>The bar code.</value>
        public string getbar_code()
        {
            return Bar_code;
        }

        public void setbar_code(string Bar_code)
        {
            this.Bar_code = Bar_code;
        }


        string Goods_name;//商品名称
        /// <summary>
        /// 商品名称
        /// </summary>
        /// <value>The name of the goods.</value>
        public string getgoods_name()
        {
            return Goods_name;
        }
        public void setgoods_name(string Goods_name)
        {
            this.Goods_name = Goods_name;
        }

        int Brand_id;//品牌ID
        /// <summary>
        /// 品牌ID
        /// </summary>
        /// <value>The brand identifier.</value>
        public int getbrand_id()
        {
            return Brand_id;
        }
        public void setbrand_id(int Brand_id)
        {
            this.Brand_id=Brand_id;
        }

        int Goods_number;//库存数量
        /// <summary>
        /// 库存数量
        /// </summary>
        /// <value>The goods number.</value>
        public int getgoods_number()
        {
            return Goods_number;
        }
        public void setgoods_number(int Goods_number)
        {
            this.Goods_number = Goods_number;
        }

        int Goods_weight;//(克)商品重量
        /// <summary>
        /// (克)商品重量
        /// </summary>
        /// <value>The goods weight.</value>
        public int getgoods_weight()
        {
            return Goods_weight;
        }
        public void setgoods_weight(int Goods_weight)
        {
            this.Goods_weight = Goods_weight;
        }

        float Market_price;//市场价格
        /// <summary>
        /// 市场价格
        /// </summary>
        /// <value>The market price.</value>
        public float getmarket_price()
        {
            return  Market_price;
        }
        public void setmarket_price(float Market_price)
        {
            this.Market_price = Market_price;
        }

        float Shop_price;//商品价格
        /// <summary>
        /// 商品价格
        /// </summary>
        /// <value>The shop price.</value>
        public float getshop_price()
        {
           return Shop_price;
        }

        public void setshop_price(float Shop_price)
        {
            this.Shop_price = Shop_price;
        }

        float Promote_price;//促销价格
        /// <summary>
        /// 促销价格
        /// </summary>
        /// <value>The promote price.</value>
        public float getpromote_price()
        {
            return Promote_price;
        }
        public void setpromote_price(float Promote_price)
        {
            this.Promote_price = Promote_price;
        }

        string Promote_start_date;//(1404115200)促销开始时间
        /// <summary>
        /// (1404115200)促销开始时间
        /// </summary>
        /// <value>The promote start date.</value>
        public string getpromote_start_date()
        {
            return Promote_start_date;
        }
        public void setpromote_start_date(string Promote_start_date)
        {
            this.Promote_start_date = Promote_start_date;
        }

        string Promote_end_date;//(1720512000)促销结束时间
        /// <summary>
        /// (1720512000)促销结束时间
        /// </summary>
        /// <value>The promote end date.</value>
        public string getpromote_end_date()
        {
            return Promote_end_date;
        }
        public void setpromote_end_date(string Promote_end_date)
        {
            this.Promote_end_date = Promote_end_date;
        }

        int Warn_number;//库存警告
        /// <summary>
        /// 库存警告
        /// </summary>
        /// <value>The warn number.</value>
        public int getwarn_number()
        {
            return Warn_number;
        }
        public void setwarn_number(int Warn_number)
        {
            this.Warn_number = Warn_number;
        }

        string Goods_brief;//商品简单描述
        /// <summary>
        /// 商品简单描述
        /// </summary>
        /// <value>The goods brief.</value>
        public string getgoods_brief()
        {
            return Goods_brief;
        }
        public void setgoods_brief(string Goods_brief)
        {
            this.Goods_brief = Goods_brief;
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

        string Desc_mobile;//手机商品详情描述
        /// <summary>
        /// 手机商品详情描述
        /// </summary>
        /// <value>The desc mobile.</value>
        public string getdesc_mobile()
        {
            return Desc_mobile;
        }
        public void setdesc_mobile(string Desc_mobile)
        {
            this.Desc_mobile = Desc_mobile;
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

        int Is_real;//是否是实物，1，是；0，否；比如虚拟卡就为0，不是实物
        /// <summary>
        /// 是否是实物，1，是；0，否；比如虚拟卡就为0，不是实物
        /// </summary>
        /// <value>The is real.</value>
        public int getis_real()
        {
            return Is_real;
        }
        public void setis_real(int Is_real)
        {
            this.Is_real = Is_real;
        }

        int Extension_code;//商品的扩展属性，比如像虚拟卡
        /// <summary>
        /// 商品的扩展属性，比如像虚拟卡
        /// </summary>
        /// <value>The extension code.</value>
        public int getextension_code()
        {
            return Extension_code;
        }
        public void setextension_code(int Extension_code)
        {
            this.Extension_code=Extension_code;
        }

        int Is_on_sale;//商品是否开放销售，1，是；0，否
       /// <summary>
        ///  商品是否开放销售，1，是；0，否
       /// </summary>
       /// <value>The is on sale.</value>
        public int getis_on_sale()
        {
            return Is_on_sale;
        }
        public void setis_on_sale(int Is_on_sale)
        {
            this.Is_on_sale=Is_on_sale;
        }

        int Is_alone_sale;//是否能单独销售，1，是；0，否；如果不能单独销售，则只能作为某商品的配件或者赠品销售
        /// <summary>
        /// 是否能单独销售，1，是；0，否；如果不能单独销售，则只能作为某商品的配件或者赠品销售
        /// </summary>
        /// <value>The is alone sale.</value>
        public int getis_alone_sale()
        {
            return Is_alone_sale;
        }
        public void setis_alone_sale(int Is_alone_sale)
        {
            this.Is_alone_sale = Is_alone_sale;
        }

        int Is_shipping;//商品是否开放销售，1，是；0，否
        /// <summary>
        /// 商品是否开放销售，1，是；0，否
        /// </summary>
        /// <value>The is shipping.</value>
        public int getis_shipping()
        {
            return Is_shipping;
        }

        public void setis_shipping(int Is_shipping)
        {
            this.Is_shipping = Is_shipping;
        }

        int Integral;//购买该商品可以使用的积分数量，估计应该是用积分代替金额消费
        /// <summary>
        /// 购买该商品可以使用的积分数量，估计应该是用积分代替金额消费
        /// </summary>
        /// <value>The integral.</value>
        public int getintegral()
        {
            return Integral;
        }
        public void setintegral(int Integral)
        {
            this.Integral = Integral;
        }

        string Add_time;//添加时间
        /// <summary>
        /// 添加时间
        /// </summary>
        /// <value>The add time.</value>
        public string getadd_time()
        {
            return Add_time;
        }
        public void setadd_time(string Add_time)
        {
            this.Add_time=Add_time;
        }

        int Sort_order;//商品排序
        /// <summary>
        /// 商品排序
        /// </summary>
        /// <value>The sort order.</value>
        public int getsort_order()
        {
           return Sort_order;
        }
        public void setsort_order(int Sort_order)
        {
            this.Sort_order=Sort_order;
        }

        int Is_best;//0：非精品，1：精品
        /// <summary>
        /// 0：非精品，1：精品
        /// </summary>
        /// <value>The is best.</value>
        public int getis_best()
        {
            return Is_best;
        }
        public void setis_best(int Is_best)
        {
            this.Is_best=Is_best;
        }

        int Is_new;//0：非新品，1：新品
        /// <summary>
        /// 0：非新品，1：新品
        /// </summary>
        /// <value>The is new.</value>
        public int getis_new()
        {
            return Is_new;
        }
        public void setis_new(int Is_new)
        {
            this.Is_new = Is_new;
        }


        int Is_hot;//0非精品，1精品
        /// <summary>
        /// 0非精品，1精品
        /// </summary>
        /// <value>The is hot.</value>
        public int getis_hot()
        {
            return Is_hot;
        }
        public void setis_hot(int Is_hot)
        {
            this.Is_hot = Is_hot;
        }

        int Is_promote;//商品是否促销，1，是；0，否
        /// <summary>
        /// 商品是否促销，1，是；0，否
        /// </summary>
        /// <value>The is promote.</value>
        public int getis_promote()
        {
            return Is_promote;
        }
        public void setis_promote(int Is_promote)
        {
            this.Is_promote = Is_promote;
        }

        int Is_volume;//商品是否阶梯价格，1，是；0，否
        /// <summary>
        /// 商品是否阶梯价格，1，是；0，否
        /// </summary>
        /// <value>The is volume.</value>
        public int getis_volume()
        {
            return Is_volume;
        }
        public void setis_volume(int Is_volume)
        {
            this.Is_volume= Is_volume;
        }

        int Is_fullcut;//商品是否阶满减，1，是；0，否
        /// <summary>
        /// 商品是否阶满减，1，是；0，否
        /// </summary>
        /// <value>The is fullcut.</value>
        public int getis_fullcut()
        {
            return Is_fullcut;
        }
        public void setis_fullcut(int Is_fullcut)
        {
            this.Is_fullcut = Is_fullcut;
        }

        int Last_update;//最后更新时间
        /// <summary>
        /// 最后更新时间
        /// </summary>
        /// <value>The last update.</value>
        public int getlast_update()
        {
            return Last_update;
        }
        public void setlast_update(int Last_update)
        {
            this.Last_update = Last_update;
        }

        int Goods_type;//商品所属类型ID
        /// <summary>
        /// 商品所属类型ID
        /// </summary>
        /// <value>The type of the goods.</value>
        public int getgoods_type()
        {
            return Goods_type;
        }
        public void setgoods_type(int Goods_type)
        {
            this.Goods_type = Goods_type;
        }

        int Give_integral;//赠送消费积分数
        /// <summary>
        /// 赠送消费积分数
        /// </summary>
        /// <value>The give integral.</value>
        public int getgive_integral()
        {
            return Give_integral;
        }
        public void setgive_integral(int Give_integral)
        {
            this.Give_integral = Give_integral;
        }

        int Rank_integral;//赠送等级积分数
        /// <summary>
        /// 赠送等级积分数
        /// </summary>
        /// <value>The rank integral.</value>
        public int getrank_integral()
        {
            return  Rank_integral;
        }

        public void setrank_integral(int Rank_integral)
        {
            this.Rank_integral = Rank_integral;
        }

        int Suppliers_id;//供货商ID
        /// <summary>
        /// 供货商ID
        /// </summary>
        /// <value>The suppliers identifier.</value>
        public int getsuppliers_id()
        {
            return Suppliers_id;
        }
        public void setsuppliers_id(int Suppliers_id)
        {
            this.Suppliers_id=Suppliers_id;
        }

        int Store_hot;// 0：非精品，1：精品（仅限店铺页显示）
        /// <summary>
        /// 0：非精品，1：精品（仅限店铺页显示）
        /// </summary>
        /// <value>The store hot.</value>
        public int getstore_hot()
        {
            return Store_hot;
        }
        public void setstore_hot(int Store_hot)
        {
            this.Store_hot = Store_hot;
        }

        int Store_new;//0：非新品，1：新品（仅限店铺页显示）
        /// <summary>
        /// 0：非新品，1：新品（仅限店铺页显示）
        /// </summary>
        /// <value>The store new.</value>
        public int getstore_new()
        {
            return Store_new;
        }
        public void setstore_new(int Store_new)
        {
            this.Store_new = Store_new;
        }

        int Store_best;//0：非热销，1：热销（仅限店铺页显示）
        /// <summary>
        /// 0：非热销，1：热销（仅限店铺页显示）
        /// </summary>
        /// <value>The store best.</value>
        public int getstore_best()
        {
            return Store_best;
        }
        public void setstore_best(int Store_best)
        {
            this.Store_best = Store_best;
        }

        int Is_xiangou;//商品是否限购，1，是；0，否
        /// <summary>
        /// 商品是否限购，1，是；0，否
        /// </summary>
        /// <value>The is xiangou.</value>
        public int getis_xiangou()
        {
            return Is_xiangou;
        }
        public void setis_xiangou(int Is_xiangou)
        {
            this.Is_xiangou = Is_xiangou;
        }

        string Xiangou_start_date;//(1480838400)限购开始时间
        /// <summary>
        /// (1480838400)限购开始时间
        /// </summary>
        /// <value>The xiangou start date.</value>
        public string getxiangou_start_date()
        {
            return Xiangou_start_date;
        }
        public void setxiangou_start_date(string Xiangou_start_date)
        {
            this.Xiangou_start_date = Xiangou_start_date;
        }

        string Xiangou_end_date;//(1575532800)限购结束时间
        /// <summary>
        /// (1575532800)限购结束时间
        /// </summary>
        /// <value>The xiangou end date.</value>
        public string getxiangou_end_date()
        {
            return Xiangou_end_date;
        }
        public void setxiangou_end_date(string Xiangou_end_date)
        {
            this.Xiangou_end_date = Xiangou_end_date;
        }

        int Xiangou_num;//限购数量
        /// <summary>
        /// 限购数量
        /// </summary>
        /// <value>The xiangou number.</value>
        public int getxiangou_num()
        {
            return Xiangou_num;
        }
        public void setxiangou_num(int Xiangou_num)
        {
            this.Xiangou_num = Xiangou_num;
        }

        int Review_status;//商品审核状态（1：未审核；2：审核未通过；3和4：审核已通过；5：无需审核；）
        /// <summary>
        /// 商品审核状态（1：未审核；2：审核未通过；3和4：审核已通过；5：无需审核；）
        /// </summary>
        /// <value>The review status.</value>
        public int getreview_status()
        {
            return Review_status;
        }
        public void setreview_status(int Review_status)
        {
            this.Review_status = Review_status;
        }


        int Sales_volume;//商品销量
        /// <summary>
        /// 商品销量
        /// </summary>
        /// <value>The sales volume.</value>
        public int getsales_volume()
        {
            return Sales_volume;
        }
        public void setsales_volume(int Sales_volume)
        {
            this.Sales_volume = Sales_volume;
        }


        int Model_price;//0 商品价格模式（0：默认模式；1：仓库模式；2：地区模式；）
        /// <summary>
        /// 0 商品价格模式（0：默认模式；1：仓库模式；2：地区模式；）
        /// </summary>
        /// <value>The model price.</value>
        public int getmodel_price()
        {
            return Model_price;
        }
        public void setmodel_price(int Model_price)
        {
            this.Model_price = Model_price;
        }

        int Model_inventory;//0 商品库存模式（0：默认模式；1：仓库模式；2：地区模式；）
        /// <summary>
        /// 0 商品库存模式（0：默认模式；1：仓库模式；2：地区模式；）
        /// </summary>
        /// <value>The integral.</value>
        public int getmodel_inventory()
        {
            return Model_inventory;
        }
        public void setmodel_inventory(int Model_inventory)
        {
            this.Model_inventory = Model_inventory;
        }

        int Model_attr;//0 商品属性模式（0：默认模式；1：仓库模式；2：地区模式；）
        /// <summary>
        /// 0 商品属性模式（0：默认模式；1：仓库模式；2：地区模式；）
        /// </summary>
        /// <value>The model attr.</value>
        public int getmodel_attr()
        {
            return Model_attr;
        }
        public void setmodel_attr(int Model_attr)
        {
            this.Model_attr = Model_attr;
        }

        int Stages;//1 分期类型（1：30天免息；3：分三期；6：分六期；9：分九期；12：分十二期；12：分二十四期；）
        /// <summary>
        /// 1 分期类型（1：30天免息；3：分三期；6：分六期；9：分九期；12：分十二期；12：分二十四期；）
        /// </summary>
        /// <value>The stages.</value>
        public int getstages()
        {
            return Stages;
        }
        public void setstages(int Stages)
        {
            this.Stages = Stages;
        }

        int Stages_rate;//20 分期百分比
        /// <summary>
        /// 20 分期百分比
        /// </summary>
        /// <value>The stages rate.</value>
        public int getstages_rate()
        {
            return Stages_rate;
        }
        public void setstages_rate(int Stages_rate)
        {
            this.Stages_rate = Stages_rate;
        }

        int Freight;//0 商品运费模式（0：按区域运费；1：按固定运费；2：按运费模板；）
        /// <summary>
        /// 0 商品运费模式（0：按区域运费；1：按固定运费；2：按运费模板；）
        /// </summary>
        /// <value>The freight.</value>
        public int getfreight()
        {
            return Freight;
        }
        public void setfreight(int Freight)
        {
            this.Freight = Freight;
        }

        float Shipping_fee;//6.60 固定运费金额
        /// <summary>
        /// 6.60 固定运费金额
        /// </summary>
        /// <value>The shipping fee.</value>
        public float getshipping_fee()
        {
            return Shipping_fee;
        }
        public void setshipping_fee(float Shipping_fee)
        {
            this.Shipping_fee = Shipping_fee;
        }

        int Tid;//商品运费模板ID
        /// <summary>
        /// 商品运费模板ID
        /// </summary>
        /// <value>The tid.</value>
        public int gettid()
        {
            return Tid;
        }
        public void settid(int Tid)
        {
            this.Tid = Tid;
        }

        public Goods()
        {
            OceanApiId = new APIId();
            OceanApiId.NamespaceValue = "method";
            OceanApiId.Name = "dsc.goods.insert.post";
            OceanApiId.Strtypename = "format";
            OceanApiId.Strtypevalue = "json";
            OceanApiId.Version = 1;
            RequestPolicyInstance = new RequestPolicy();
            RequestPolicyInstance.UseHttps = false;
            RequestPolicyInstance.HttpMethod = "POST";
        }
    }
}
