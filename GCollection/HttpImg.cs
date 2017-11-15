using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;

namespace GCollection
{
    class HttpImg
    {
        HttpClient httpClient = null;

        public HttpImg()
        {
            httpClient = new HttpClient();
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