using System.Collections.Generic;
using System.Text;
using System.Web;
using AngleSharp.Parser.Html;
using Job.Model.Entities;

namespace Job.Crawler.CrawlerAction
{
    public class ZhaoPin : JobBase, ICrawler
    {
        private string SouUrl = "http://sou.zhaopin.com/jobs/searchresult.ashx?jl={0}&kw={1}&p={2}&isadv=0";
        private HtmlParser parser = new HtmlParser();

        public ZhaoPin()
        {
            AEncoding = Encoding.UTF8;
        }
        public List<JobInfo> CrawlerJob(string city, string kw, string pagenum)
        {
            var jobInfos = new List<JobInfo>();
            var url = string.Format(SouUrl, HttpUtility.UrlEncode(city), kw, pagenum);
            var html = GetHtml(url);
            if (!string.IsNullOrEmpty(html))
            {
                var document = parser.Parse(html);
                var elements = document.QuerySelectorAll("table.newlist");
                foreach (var element in elements)
                {
                    string zwmc, gsmc, zwyx, gzdd, gxsj, link;
                    var querySelector = element.QuerySelector("td.zwmc a");
                    if (querySelector == null)
                        continue;
                    zwmc = querySelector.InnerHtml;
                    link = element.QuerySelector("td.zwmc a").Attributes["href"].Value;
                    gsmc = element.QuerySelector("td.gsmc a").InnerHtml;
                    zwyx = element.QuerySelector("td.zwyx").InnerHtml;
                    gzdd = element.QuerySelector("td.gzdd").InnerHtml;
                    gxsj = element.QuerySelector("td.gxsj span").InnerHtml;

                    var jobInfo = new JobInfo()
                    {
                        JobTitle = zwmc,
                        JobAddress = gzdd,
                        JobCompany = gsmc,
                        JobSalary = zwyx,
                        JobLink = link,
                        PublishDate = gxsj
                    };
                    var detail = GetHtml(link);
                    var htmlDocument = parser.Parse(detail);
                    jobInfo.JobWelfare = htmlDocument.QuerySelector("div .welfare-tab-box")
                           .InnerHtml.Replace("<span>", "")
                           .Replace("</span>", "");
                    jobInfo.JobBaseInfo = htmlDocument.QuerySelector("div.terminalpage-left").QuerySelector("ul.terminal-ul")
                           .InnerHtml.Replace("<li>", "")
                           .Replace("</li>", "")
                           .Replace("<span>", "")
                           .Replace("</span>", "").Replace("<strong>", "").Replace("</strong>", "");
                    jobInfo.JobDetail = htmlDocument.QuerySelector("div.tab-inner-cont").InnerHtml.Replace("<p>", "").Replace("</p>", "").Replace("<br/>", "").Replace("<br>","").Replace("</br>","").Replace("<h2>", "").Replace("</h2>", "").Replace(" ","");
                    jobInfos.Add(jobInfo);
                }
            }
            return jobInfos;
        }
    }
}