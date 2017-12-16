using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCollection
{
    public class ProductInfo
    {
        private string productid="";
        private string producttitle="";
        private string desction="";
        private long catid=0;
        private string skumodelstr="";
        private string detailpara="";
        private string offerstatus="";
        private long supplystock=0;
        private string skuinfos="";
        private string imagelist="";
        private string saleinfo="";
        private string extendinfos="";
        private string memberid="";

        /// <summary>
        /// 商品货号
        /// </summary>
        public string Productid
        {
            set { productid = value; }
            get { return productid; }
        }

        /// <summary>
        /// 商品标题
        /// </summary>
        public string Producttitle
        {
            set { producttitle = value; }
            get { return producttitle; }
        }

        /// <summary>
        /// 商品详情
        /// </summary>
        public string Desction
        {
            set { desction = value; }
            get { return desction; }
        }

        /// <summary>
        /// 1688商品分类ID
        /// </summary>
        public long Catid
        {
            set { catid = value; }
            get { return catid; }
        }

        /// <summary>
        /// sku规格字符串
        /// </summary>
        public string Skumodelstr
        {
            set {skumodelstr = value; }
            get { return skumodelstr; }
        }

        /// <summary>
        /// 商品属性
        /// </summary>
        public string Detailpara
        {
            set { detailpara = value; }
            get { return detailpara; }
        }

        /// <summary>
        /// 商品状态
        /// </summary>
        public string Offerstatus
        {
            set { offerstatus = value; }
            get { return offerstatus; }
        }

        /// <summary>
        /// 库存
        /// </summary>
        public long Supplystock
        {
            set {
                if (value < 0)
                {
                    supplystock = 0;
                }
                else
                {
                    supplystock = value;
                }
               }
            get { return supplystock; }
        }

        /// <summary>
        /// sku信息
        /// </summary>
        public string Skuinfos
        {
            set { skuinfos = value; }
            get { return skuinfos; }
        }

        /// <summary>
        /// 主图
        /// </summary>
        public string Imagelist
        {
            set { imagelist = value; }
            get { return imagelist; }
        }

        /// <summary>
        /// 销售信息
        /// </summary>
        public string Saleinfo
        {
            set { saleinfo = value; }
            get { return saleinfo; }
        }

        /// <summary>
        /// 扩展信息
        /// </summary>
        public string Extendinfos
        {
            set { extendinfos = value; }
            get { return extendinfos; }
        }

        /// <summary>
        /// 供应商ID
        /// </summary>
        public string Memberid
        {
            set { memberid = value; }
            get { return memberid; }
        }
    }
}
