using System.Collections.Generic;
using System.IO;
using System.Text;

namespace com.goudiw
{
    /// <summary>
    /// 上传文件 - 请求参数类
    /// </summary>
    public class UploadParameterType
    {
        public UploadParameterType()
        {
            FileNameKey = "file";
            Encoding = Encoding.UTF8;
        }

        /// <summary>
        /// 文件名称key
        /// </summary>
        public string FileNameKey { get; set; }
        /// <summary>
        /// 文件名称value
        /// </summary>
        public string FileNameValue { get; set; }
        /// <summary>
        /// 编码格式
        /// </summary>
        public Encoding Encoding { get; set; }
        /// <summary>
        /// 上传文件的流
        /// </summary>
        public Stream UploadStream { get; set; }
    }
}
