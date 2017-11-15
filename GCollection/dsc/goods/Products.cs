using System;
using com.goudiw;
using goudiw.sdk.client.policy;

namespace dscapi.dsc.goods
{
    public class Products: Request
    {
        public Products()
        {
            OceanApiId = new APIId();
            OceanApiId.NamespaceValue = "method";
            OceanApiId.Name = "gdw.products.insert.post";
            OceanApiId.Strtypename = "format";
            OceanApiId.Strtypevalue = "json";
            OceanApiId.Version = 1;
            RequestPolicyInstance = new RequestPolicy();
            RequestPolicyInstance.UseHttps = false;
            RequestPolicyInstance.HttpMethod = "POST";
        }



        int goods_id;
        public int getgoods_id()
        {
            return goods_id;
        }
        public void setgoods_id(int goods_id)
        {
            this.goods_id = goods_id;
        }

        string goods_attr;
        public string getgoods_attr()
        {
            return goods_attr;
        }
        public void setgoods_attr(string goods_attr)
        {
            this.goods_attr = goods_attr;
        }

        string product_sn;
        public string getproduct_sn()
        {
            return product_sn;
        }
        public void setproduct_sn(string product_sn)
        {
            this.product_sn = product_sn;
        }

        string bar_code;
        public string getbar_code()
        {
            return bar_code;
        }
        public void setbar_code(string bar_code)
        {
            this.bar_code = bar_code;
        }

        int product_number;
        public int getproduct_number()
        {
            return product_number;
        }
        public void setproduct_number(int product_number)
        {
            this.product_number = product_number;
        }

        string product_price;
        public string getproduct_price()
        {
            return product_price;
        }
        public void setproduct_price(string product_price)
        {
            this.product_price = product_price;
        }

        string product_market_price;
        public string getproduct_market_price()
        {
            return product_market_price;
        }
        public void setproduct_market_price(string product_market_price)
        {
            this.product_market_price = product_market_price;
        }

        int product_warn_number;
        public int getproduct_warn_number()
        {
            return product_warn_number;
        }
        public void setproduct_warn_number(int product_warn_number)
        {
            this.product_warn_number = product_warn_number;
        }
    }
}
