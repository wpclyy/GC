using com.goudiw;
using goudiw.sdk.client.policy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace GDHttp.dsc.goods.attr.list
{
    [DataContract(Namespace = "com.alibaba.openapi.client")]
    public class gdwgoodsattrlit:Request
    {

        public gdwgoodsattrlit()
        {
            OceanApiId = new APIId();
            OceanApiId.NamespaceValue = "method";
            OceanApiId.Name = "dsc.goods.attr.list.get";
            OceanApiId.Version = 1;
            RequestPolicyInstance = new RequestPolicy();
            RequestPolicyInstance.UseHttps = false;
            RequestPolicyInstance.HttpMethod = "GET";
        }

        [DataMember(Order = 1)]
        private string goods_id;

        /**
       * @return 模糊查询关键字
    */
        public string getGoods_id()
        {
            return goods_id;
        }

        /**
         * 设置模糊查询关键字     *
         * 参数示例：<pre></pre>     
                 * 此参数必填
              */
        public void setGoods_id(string keyword)
        {
            this.goods_id = keyword;
        }

        [DataMember(Order = 2)]
        private string supplierMemberId;

        /**
       * @return 供应商memberId
    */
        public string getSupplierMemberId()
        {
            return supplierMemberId;
        }

        /**
         * 设置供应商memberId     *
         * 参数示例：<pre></pre>     
                 * 此参数必填
              */
        public void setSupplierMemberId(string supplierMemberId)
        {
            this.supplierMemberId = supplierMemberId;
        }

        [DataMember(Order = 3)]
        private int? pageNo;

        /**
       * @return 页码。取值范围:大于零的整数;默认值为1，即返回第一页数据
    */
        public int? getPageNo()
        {
            return pageNo;
        }

        /**
         * 设置页码。取值范围:大于零的整数;默认值为1，即返回第一页数据     *
         * 参数示例：<pre>5</pre>     
                 * 此参数必填
              */
        public void setPageNo(int pageNo)
        {
            this.pageNo = pageNo;
        }

        [DataMember(Order = 4)]
        private int? pageSize;

        /**
       * @return 返回列表结果集每页条数。取值范围:大于零的整数;默认为20条，网页端默认10条
    */
        public int? getPageSize()
        {
            return pageSize;
        }

        /**
         * 设置返回列表结果集每页条数。取值范围:大于零的整数;默认为20条，网页端默认10条     *
         * 参数示例：<pre>20</pre>     
                 * 此参数必填
              */
        public void setPageSize(int pageSize)
        {
            this.pageSize = pageSize;
        }

    }
}
