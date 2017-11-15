using System;
using System.IO;
using System.Net.Http;
using System.Text.RegularExpressions;

namespace com.goudiw
{
    class HttpClientClass:IDisposable
    {
        HttpClient httpClient = null;
        //int i = 1;
        public HttpClientClass()
        {
            httpClient = new HttpClient();
        }


        public string htmlstring(string url)
        {
            httpClient.MaxResponseContentBufferSize = 2560000;
            httpClient.DefaultRequestHeaders.Add("user-agent", "Mozilla/5.0 (Windows NT 6.1; Win64; x64; rv:47.0) Gecko/20100101 Firefox/47.0");
            HttpResponseMessage response = httpClient.GetAsync(new Uri(url)).Result;
            httpClient.Dispose();
            return response.Content.ReadAsStringAsync().Result;
        }

        public Stream htmlimg(string url)
        {
            string Pattern = @"^(http|https|ftp)\://[a-zA-Z0-9\-\.]+\.[a-zA-Z]{2,3}(:[a-zA-Z0-9]*)?/?([a-zA-Z0-9\-\._\?\,\!\'/\\\+&$%\$#\=~])*$";
            Regex r = new Regex(Pattern);
            Match m = r.Match(url);
            if (!m.Success)
            {
                url = "http:" + url;
            }
            try
            {
                httpClient.MaxResponseContentBufferSize = 25600000;
                httpClient.DefaultRequestHeaders.Add("user-agent", "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/36.0.1985.143 Safari/537.36");
                HttpResponseMessage response = httpClient.GetAsync(new Uri(url)).Result;
                httpClient.Dispose();
                return response.Content.ReadAsStreamAsync().Result;
            }
            catch
            {
                return new MemoryStream();
            }
        }

        public void Dispose()
        {
            httpClient.Dispose();            
            httpClient = null;
        }
    }
}
