using System.Collections.Generic;
using System.Linq;
using System.Web;
using AngleSharp.Parser.Html;
using Job.Model.Entities;

namespace Job.Crawler
{
    public class Job51 : JobBase, ICrawler
    {
        private string SouUrl = "http://search.51job.com/jobsearch/search_result.php?jobarea={0}&keyword={1}&curr_page={2}";
        HtmlParser htmlParser = new HtmlParser();
        private readonly Dictionary<string, string> _cityDic = new Dictionary<string, string>();

        public Job51()
        {
            _cityDic.Add("无锡", HttpUtility.UrlEncode("070400,00"));
        }
        public List<JobInfo> CrawlerJob(string city, string kw, string pagenum)
        {
            var jobInfos = new List<JobInfo>();
            if (_cityDic.ContainsKey(city))
            {
                city = _cityDic[city];
            }
            var url = string.Format(SouUrl, HttpUtility.UrlEncode(kw), city, pagenum);
            var html = GetHtml(url);
            if (!string.IsNullOrEmpty(html))
            {
                var jobInfo = new JobInfo();
                var htmlDocument = htmlParser.Parse(html);
                var enumerable = htmlDocument.QuerySelector("div.resultListDiv").QuerySelectorAll("tr").Where(x => x.ClassName == "td0");
                foreach (var element in enumerable)
                {
                    jobInfo.JobTitle = element.QuerySelector("td.td1 a").InnerHtml;
                    jobInfo.JobLink = element.QuerySelector("td.td1 a").Attributes["href"].Value;
                    jobInfo.JobCompany = element.QuerySelector("td.td2 a").InnerHtml;
                    jobInfo.JobAddress = element.QuerySelector("td.td3 span").InnerHtml;
                    jobInfo.PublishDate = element.QuerySelector("td.td4 span").InnerHtml;
                }
                var jobhtml = GetHtml(jobInfo.JobLink);
                var document = htmlParser.Parse(jobhtml);
                var querySelector = document.QuerySelector("td.txt_2 jobdetail_xsfw_color");
                if (querySelector != null)
                    jobInfo.JobSalary = querySelector.InnerHtml;
                var selector = document.QuerySelector("div.jobdetail_divRight_span");
                if (selector != null)
                    jobInfo.JobWelfare = selector.InnerHtml;

                jobInfo.JobDetail = document.QuerySelector("td.wordBreakNormal job_detail").InnerHtml;
            }
            return jobInfos;
        }
    }
}