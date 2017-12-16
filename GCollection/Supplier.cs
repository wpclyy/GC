using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCollection
{
    public class Supplier
    {
        private string memberid="";
        private string company="";
        private string loginid="";
        private DateTime consigncreatetime;
        private string consignstatus="";
        private int goodscount=0;

        /// <summary>
        /// 供应商编号
        /// </summary>
        public string Memberid
        {
            set { memberid = value; }
            get { return memberid; }
        }

        /// <summary>
        /// 供应商名称
        /// </summary>
        public string Company
        {
            set { company = value; }
            get { return company; }
        }

        /// <summary>
        /// 登陆ID
        /// </summary>
        public string Loginid
        {
            set { loginid = value; }
            get { return loginid; }
        }

         /// <summary>
         /// 代销关系建立时间
         /// </summary>
        public DateTime Consigncreatetime
        {
            set { consigncreatetime = value; }
            get { return consigncreatetime; }
        }

        /// <summary>
        /// 代销状态
        /// </summary>
        public string Consignstatus
        {
            set { consignstatus = value; }
            get { return consignstatus; }
        }

        /// <summary>
        /// 商品数量
        /// </summary>
        public int Goodscount
        {
            set { goodscount = value; }
            get { return goodscount; }
        }

    }
}
