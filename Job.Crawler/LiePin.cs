using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using AngleSharp.Parser.Html;
using Job.Model.Entities;

namespace Job.Crawler
{
    public class LiePin : JobBase, ICrawler
    {
        private string SouUrl = "http://www.liepin.com/zhaopin/?key={0}&dqs={1}&curPage={2}";
        private readonly Dictionary<string, string> _cityDic = new Dictionary<string, string>();
        HtmlParser htmlParser = new HtmlParser();
        public LiePin()
        {
            _cityDic.Add("无锡", "060100");
            AEncoding = Encoding.UTF8;
        }
        public List<JobInfo> CrawlerJob(string city, string kw, string pagenum)
        {
            var jobInfos = new List<JobInfo>();

            if (_cityDic.ContainsKey(city))
            {
                city = _cityDic[city];
            }
            var url = string.Format(SouUrl, kw, city, pagenum);
            var html = GetHtml(url);
            if (!string.IsNullOrEmpty(html))
            {
                var htmlDocument = htmlParser.Parse(html);
                var elements = htmlDocument.QuerySelectorAll("ul.sojob-result-list li a");
                foreach (var element in elements)
                {
                    var title = element.Attributes["title"].Value;
                    var link = element.Attributes["href"].Value;
                    var salary = element.QuerySelector("dt.salary").InnerHtml;
                    var company = element.QuerySelector("dt.company").InnerHtml;
                    var citystring = element.QuerySelector("dt.city span").InnerHtml;
                    var date = element.QuerySelector("dt.date span").InnerHtml;
                    var jobInfo = new JobInfo()
                    {
                        JobTitle = title,
                        JobLink = link,
                        JobAddress = citystring,
                        JobCompany = company,
                        PublishDate = date,
                        JobSalary = salary
                    };
                    var jobhtml = GetHtml(link);
                    var document = htmlParser.Parse(jobhtml);
                    jobInfo.JobBaseInfo = document.QuerySelector("div.job-title-left").InnerHtml;
                    var querySelectorAll = document.QuerySelectorAll("div.job-main.main-message");
                    foreach (var query in querySelectorAll)
                    {
                        if (query.InnerHtml.Contains("薪酬福利"))
                        {
                            jobInfo.JobWelfare = query.InnerHtml;
                            continue;
                        }
                        if (query.InnerHtml.Contains("职位描述"))
                        {
                            jobInfo.JobDetail = query.InnerHtml;
                        }
                    }
                    jobInfos.Add(jobInfo);
                }
            }
            return jobInfos;
        }
    }
}