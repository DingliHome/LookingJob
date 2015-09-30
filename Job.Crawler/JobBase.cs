using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Job.Crawler
{
    public abstract class JobBase
    {
        private Log4Help.Log4NetHelp _loger = Log4Help.LogFactory.GetLogger(typeof(JobBase));

        public JobBase()
        {
            AEncoding = Encoding.Default;
        }
        public Encoding AEncoding { get; set; }
        protected virtual string GetHtml(string url)
        {
            var result = string.Empty;
            try
            {
                var webRequest = (HttpWebRequest)WebRequest.Create(url);
                webRequest.Method = "Get";
                webRequest.Proxy = null;
                webRequest.UserAgent = "Mozilla/5.0 (Windows NT 6.3; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/39.0.2171.95 Safari/537.36";
                using (var response = (HttpWebResponse)webRequest.GetResponse())
                using (var responseStream = response.GetResponseStream())
                using (var sr = new StreamReader(responseStream, AEncoding))
                {
                    result = sr.ReadToEnd();
                }
                webRequest = null;
            }
            catch (Exception e)
            {
                _loger.Error(e);
            }
            return result;
        }

        protected virtual string PostHtml(string url, string postdata)
        {
            var result = string.Empty;
            try
            {
                HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url);
                webRequest.Method = "Post";
                //webRequest.Proxy = null;
                webRequest.KeepAlive = true;
                webRequest.ContentType = "application/x-www-form-urlencoded";    //模拟头
                webRequest.UserAgent = "Mozilla/5.0 (Windows NT 6.3; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/39.0.2171.95 Safari/537.36";
                Stream stream = webRequest.GetRequestStream();
                byte[] bytes = Encoding.UTF8.GetBytes(postdata);
                stream.Write(bytes, 0, bytes.Length);
                stream.Close();
                HttpWebResponse webResponse = (HttpWebResponse)webRequest.GetResponse();
                var streamReader = new StreamReader(webResponse.GetResponseStream(), AEncoding);
                result = streamReader.ReadToEnd();
                streamReader.Dispose();
                streamReader.Close();
                webResponse.Close();
                webRequest.Abort();
            }
            catch (Exception e)
            {
                _loger.Error(e);
            }
            return result;
        }
    }
}
