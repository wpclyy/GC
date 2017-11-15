using com.goudiw;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.IO;
using System.Web;
using Newtonsoft.Json;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;
using System.Text.RegularExpressions;
using goudiw.sdk.client.policy;
using goudiw.sdk.client.serialize;
using goudiw.sdk.serialize;

namespace goudiw.sdk.http
{
    public class HttpClient
    {
        private ClientPolicy clientPolicy;

        public HttpClient(ClientPolicy clientPolicy)
        {
            this.clientPolicy = clientPolicy;
        }

        public String request<T>(Request request, RequestPolicy requestPolicy, String accessToken)
        {
            System.GC.Collect();
            StringBuilder path = createProtocolRequestPath(requestPolicy, request);
            Dictionary<String, Object> parameters = createParameterDictionary(requestPolicy, request, accessToken);
            StringBuilder queryBuilder = new StringBuilder();
            signature(path.ToString(), parameters, requestPolicy, clientPolicy);
            if ("GET".Equals(requestPolicy.HttpMethod))
            {

                String queryString = createParameterStr_double(parameters);
                String uriStr = buildRequestUri(requestPolicy, request);
                uriStr = uriStr + "&" + queryString;
                Uri uri = new Uri(uriStr);
                HttpWebRequest httpWebRequest = WebRequest.Create(uri) as HttpWebRequest;

                httpWebRequest.Method = "GET";
                httpWebRequest.KeepAlive = false;
                httpWebRequest.AllowAutoRedirect = true;
                httpWebRequest.ContentType = "application/x-www-form-urlencoded";
                httpWebRequest.UserAgent = "Ocean/NET-SDKClient";

                HttpWebResponse response = httpWebRequest.GetResponse() as HttpWebResponse;
                Stream responseStream = response.GetResponseStream();

                StreamReader sr = new StreamReader(responseStream, Encoding.UTF8);
                string strhtml = sr.ReadToEnd();
                //DeSerializer deSerializer = SerializerProvider.getInstance().getDeSerializer(requestPolicy.ResponseProtocol);
                //ResponseWrapper rw = deSerializer.deSerialize(responseStream, typeof(T), Encoding.UTF8.EncodingName);
                responseStream.Close();
                response.Close();
                if (httpWebRequest != null)
                {
                    httpWebRequest.Abort();
                    httpWebRequest = null;
                }
                return strhtml;
            }
            else
            {

                string postString = createParameterStr(parameters);
                postString = "data=" + postString;
     
                byte[] postData = Encoding.UTF8.GetBytes(postString);
                String uriStr = buildRequestUri(requestPolicy, request);
                Uri uri = new Uri(uriStr);
                HttpWebRequest httpWebRequest = WebRequest.Create(uri) as HttpWebRequest;

                httpWebRequest.Method = "POST";
                httpWebRequest.KeepAlive = false;
                httpWebRequest.AllowAutoRedirect = true;
                httpWebRequest.ContentType = "application/x-www-form-urlencoded";
                httpWebRequest.UserAgent = "Ocean/NET-SDKClient";
                httpWebRequest.ContentLength = postData.Length;

                System.IO.Stream outputStream = httpWebRequest.GetRequestStream();
                outputStream.Write(postData, 0, postData.Length);
                outputStream.Close();
                try
                {
                    HttpWebResponse response = httpWebRequest.GetResponse() as HttpWebResponse;
                    Stream responseStream = response.GetResponseStream();

                    StreamReader sr = new StreamReader(responseStream, Encoding.UTF8);
                    string strhtml = sr.ReadToEnd();

                    //DeSerializer deSerializer = SerializerProvider.getInstance().getDeSerializer(requestPolicy.ResponseProtocol);
                    //ResponseWrapper rw = deSerializer.deSerialize(responseStream, typeof(T), Encoding.UTF8.EncodingName);
                    responseStream.Close();
                    response.Close();

                    if (httpWebRequest != null)
                    {
                        httpWebRequest.Abort();
                        httpWebRequest = null;
                    }
                    return strhtml;
                }
                catch (System.Net.WebException webException)
                {
                    HttpWebResponse response = webException.Response as HttpWebResponse;
                    Stream responseStream = response.GetResponseStream();
                    DeSerializer deSerializer = SerializerProvider.getInstance().getDeSerializer(requestPolicy.ResponseProtocol);
                    Exception rw = deSerializer.buildException(responseStream,500, Encoding.UTF8.EncodingName);
                    //throw rw;

                    return "失败";
                }
            }
        }

        /// <summary>
        /// 上传执行 方法
        /// </summary>
        /// <param name="parameter">上传文件请求参数</param>
        public string Execute(UploadParameterType parameter,Request request,RequestPolicy requestPolicy)
        {
            StringBuilder path = createProtocolRequestPath(requestPolicy, request);
            Dictionary<String, Object> parameters = createParameterDictionary(requestPolicy, request, "");
            StringBuilder queryBuilder = new StringBuilder();
            signature(path.ToString(), parameters, requestPolicy, clientPolicy);
            String queryString = createParameterStr_double(parameters);
            String uriStr = buildRequestUri(requestPolicy, request);
            uriStr = uriStr + "&" + queryString;
            using (MemoryStream memoryStream = new MemoryStream())
            {
                // 1.分界线
                string boundary = string.Format("----{0}", DateTime.Now.Ticks.ToString("x")),       // 分界线可以自定义参数
                    beginBoundary = string.Format("--{0}\r\n", boundary),
                    endBoundary = string.Format("\r\n--{0}--\r\n", boundary);
                byte[] beginBoundaryBytes = parameter.Encoding.GetBytes(beginBoundary),endBoundaryBytes = parameter.Encoding.GetBytes(endBoundary);
                // 2.组装开始分界线数据体 到内存流中
                memoryStream.Write(beginBoundaryBytes, 0, beginBoundaryBytes.Length);
                // 3.组装 上传文件附加携带的参数 到内存流中
                //if (parameter.PostParameters != null && parameter.PostParameters.Count > 0)
                //{
                //    foreach (string[] keyValuePair in parameter.PostParameters)
                //    {
                //        string parameterHeaderTemplate = string.Format("Content-Disposition: form-data; name=\"{0}\"\r\n\r\n{1}\r\n{2}", keyValuePair[0], keyValuePair[1], beginBoundary);
                //        byte[] parameterHeaderBytes = parameter.Encoding.GetBytes(parameterHeaderTemplate);
                //        memoryStream.Write(parameterHeaderBytes, 0, parameterHeaderBytes.Length);application/octet-stream
                //    }
                //}
                // 4.组装文件头数据体 到内存流中
                string fileHeaderTemplate = string.Format("Content-Disposition: form-data; name=\"{0}\"; filename=\"{1}\"\r\nContent-Type: image/jpeg\r\n\r\n", parameter.FileNameKey, parameter.FileNameValue);
                byte[] fileHeaderBytes = parameter.Encoding.GetBytes(fileHeaderTemplate);
                memoryStream.Write(fileHeaderBytes, 0, fileHeaderBytes.Length);
                // 5.组装文件流 到内存流中
                byte[] buffer = new byte[1024 * 1024 * 1];

                Stream ss = parameter.UploadStream;
                if (ss != null)
                {
                    ss.Seek(0, SeekOrigin.Begin);

                    int size = ss.Read(buffer, 0, buffer.Length);
                    while (size > 0)
                    {
                        memoryStream.Write(buffer, 0, size);
                        size = parameter.UploadStream.Read(buffer, 0, buffer.Length);
                    }
                    ss.Dispose();
                }
                // 6.组装结束分界线数据体 到内存流中
                memoryStream.Write(endBoundaryBytes, 0, endBoundaryBytes.Length);
                // 7.获取二进制数据
                byte[] postBytes = memoryStream.ToArray();


                // 8.HttpWebRequest 组装
                HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(new Uri(uriStr, UriKind.RelativeOrAbsolute));
                webRequest.Method = "POST";
                webRequest.Timeout = 100000;
                webRequest.ContentType = string.Format("multipart/form-data; boundary={0}", boundary);
                webRequest.ContentLength = postBytes.Length;
                if (Regex.IsMatch(uriStr, "^https://"))
                {
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls;
                    ServicePointManager.ServerCertificateValidationCallback = CheckValidationResult;
                }
                // 9.写入上传请求数据
                using (Stream requestStream = webRequest.GetRequestStream())
                {
                    requestStream.Write(postBytes, 0, postBytes.Length);
                }


                // 10.获取响应
                using (HttpWebResponse webResponse = (HttpWebResponse)webRequest.GetResponse())
                {
                    using (StreamReader reader = new StreamReader(webResponse.GetResponseStream(), parameter.Encoding))
                    {
                        string body = reader.ReadToEnd();
                        reader.Dispose();
                        reader.Close();
                        return body;
                    }
                }

            }
        }
        static bool CheckValidationResult(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors)
        {
            return true;
        }

        private String buildRequestUri(RequestPolicy requestPolicy, Request request)
        {
            String schema = "http";
            int port = clientPolicy.HttpPort;
            if (requestPolicy.UseHttps)
            {
                schema = "https";
                port = clientPolicy.HttpsPort;
            }
            StringBuilder relativeBuilder = new StringBuilder(schema);
            relativeBuilder.Append("://");
            relativeBuilder.Append(clientPolicy.ServerHost);
            if (port != 80 && port != 443)
            {
                relativeBuilder.Append(":");
                relativeBuilder.Append(port);
            }


            relativeBuilder.Append("/api.php");
            

            relativeBuilder.Append("?");
            relativeBuilder.Append(createProtocolRequestPath(requestPolicy, request));
            return relativeBuilder.ToString();
        }

        private StringBuilder createProtocolRequestPath(RequestPolicy requestPolicy, Request request)
        {

            StringBuilder relativeBuilder = new StringBuilder();
            relativeBuilder.Append("app_key");
            relativeBuilder.Append("=").Append(clientPolicy.AppKey);
            relativeBuilder.Append("&").Append(request.OceanApiId.NamespaceValue);
            relativeBuilder.Append("=").Append(request.OceanApiId.Name);
            relativeBuilder.Append("&").Append(request.OceanApiId.Strtypename);
            relativeBuilder.Append("=").Append(request.OceanApiId.Strtypevalue);
            if(request.OceanApiId.Filedname!=""&&request.OceanApiId.Filedvalue!="")
            {
                relativeBuilder.Append("&").Append(request.OceanApiId.Filedname);
                relativeBuilder.Append("=").Append(request.OceanApiId.Filedvalue);
            }
            return relativeBuilder;

        }

        private String createParameterStr(Dictionary<String, Object> parameters)
        {
            return JsonConvert.SerializeObject(parameters);
            //StringBuilder paramBuilder = new StringBuilder();
            //foreach (KeyValuePair<string, object> kvp in parameters)
            //{
            //    String encodedValue = null;
            //    if (kvp.Value != null)
            //    {
            //        String tempValue = kvp.Value.ToString();
            //        byte[] byteArray = System.Text.Encoding.UTF8.GetBytes(tempValue);
            //        encodedValue = HttpUtility.UrlEncode(byteArray, 0, byteArray.Length);   
            //    }
            //    paramBuilder.Append(kvp.Key).Append("=").Append(encodedValue);
            //    paramBuilder.Append("&");
            //}
            //return paramBuilder.ToString();
        }

        private String createParameterStr_double(Dictionary<String, Object> parameters)
        {
            StringBuilder paramBuilder = new StringBuilder();
            foreach (KeyValuePair<string, object> kvp in parameters)
            {
                String encodedValue = null;
                if (kvp.Value != null)
                {
                    String tempValue = kvp.Value.ToString();
                    byte[] byteArray = System.Text.Encoding.UTF8.GetBytes(tempValue);
                    encodedValue = HttpUtility.UrlEncode(byteArray, 0, byteArray.Length);   
                }
                paramBuilder.Append(kvp.Key).Append("=").Append(encodedValue);
                paramBuilder.Append("&");
            }
            return paramBuilder.ToString();
        }

        private Dictionary<String, Object> createParameterDictionary(RequestPolicy requestPolicy, Request request, String accessToken)
        {

            Serializer serializer = SerializerProvider.getInstance().getSerializer(requestPolicy.RequestProtocol);

            Dictionary<String, Object> parameters = serializer.serialize(request);
            //if (!requestPolicy.RequestProtocol.Equals(requestPolicy.ResponseProtocol))
            //{
            //    parameters.Add("_aop_responseFormat", requestPolicy.ResponseProtocol);
            //}
            //if (requestPolicy.RequestSendTimestamp)
            //{
            //    parameters.Add("_aop_timestamp", DateUtil.currentTimeMillis());
            //}
            //parameters.Add("_aop_datePattern", DateUtil.getDatePattern());
            //if (accessToken != null)
            //{
            //    parameters.Add("access_token", accessToken);
            //}
            return parameters;
        }

        private void signature(String path, Dictionary<String, Object> parameters, RequestPolicy requestPolicy, ClientPolicy clientPolicy)
        {
            if (!requestPolicy.UseSignture)
            {
                return;
            }
            if (clientPolicy.AppKey == null)
            {
                return;
            }
        }


        private WebClient createWebClient()
        {

            WebClient client = new WebClient();
            client.Headers.Add("user-agent", "Ocean/SDK Client");

            return client;
        }
    }
}
