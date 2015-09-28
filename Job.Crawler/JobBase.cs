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
        protected virtual string GetHtml(string url)
        {
            var result = "";
            try
            {
                var webRequest = (HttpWebRequest) WebRequest.Create(url);
                webRequest.Method = "Get";
                webRequest.Proxy = null;
                webRequest.UserAgent ="Mozilla/5.0 (Windows NT 6.3; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/39.0.2171.95 Safari/537.36";
                using (var response = (HttpWebResponse) webRequest.GetResponse())
                using (var responseStream = response.GetResponseStream())
                using (var sr = new StreamReader(responseStream, Encoding.UTF8))
                {
                    result = sr.ReadToEnd();
                }
                webRequest = null;
            }
            catch (Exception e)
            {
            }
            return result;
        }
    }
}
