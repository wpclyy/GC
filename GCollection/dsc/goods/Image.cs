using System;
using System.IO;
using System.Text;
using com.goudiw;
using goudiw.sdk.client.policy;

namespace dscapi.dsc.goods
{
    public class Image: Request
    {
        public Image()
        {
            OceanApiId = new APIId();
            OceanApiId.NamespaceValue = "method";
            OceanApiId.Name = "dsc.goods.image.insert.post";
            OceanApiId.Strtypename = "type";
            OceanApiId.Strtypevalue = "goods_img";
            OceanApiId.Version = 1;
            RequestPolicyInstance = new RequestPolicy();
            RequestPolicyInstance.UseHttps = false;
            RequestPolicyInstance.HttpMethod = "POST";
        }

        int Id;//商品ID 
        /// <summary>
        /// 商品ID
        /// </summary>
        /// <value>The goods identifier.</value>
        public int getid()
        {
            return Id;
        }

        public void setid(int Id)
        {
            this.Id = Id;
        }
    }
}
