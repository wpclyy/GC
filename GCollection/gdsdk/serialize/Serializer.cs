using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace goudiw.sdk.serialize
{
    public interface Serializer
    {

        //返回该反序列化接口支持的数据协议.
         String supportedContentType();

        //序列化方法
         Dictionary<String, Object> serialize(Object serializer);
    }
}
