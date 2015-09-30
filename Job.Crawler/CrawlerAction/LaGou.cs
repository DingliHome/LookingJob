using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using AngleSharp.Dom;
using AngleSharp.Dom.Html;
using AngleSharp.Parser.Html;
using Job.Crawler.ResponseJsonData;
using Job.Model.Entities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;

namespace Job.Crawler.CrawlerAction
{
    public class LaGou : JobBase, ICrawler
    {
        private string Url = "http://www.lagou.com/jobs/positionAjax.json?px=default&gx={1}&city={0}";
        private HtmlParser _parser = new HtmlParser();

        public LaGou()
        {
            AEncoding = Encoding.UTF8;
        }
        public List<JobInfo> CrawlerJob(string city, string kw, string pagenum)
        {
            var jobInfos = new List<JobInfo>();
            try
            {
                string url = string.Format(Url, HttpUtility.UrlEncode(city), HttpUtility.UrlEncode("全职"));
                var postdata = string.Format("first={0}&pn={1}&kd={2}", false, pagenum, HttpUtility.UrlEncode(kw));//pn 第几页
                string resultjson = PostHtml(url, postdata);
                var laGouJobs = JsonConvert.DeserializeObject<LaGouJobs>(resultjson);
                if (laGouJobs != null && laGouJobs.Success)
                {
                    foreach (var item in laGouJobs.Content.Result)
                    {
                        var jobInfo = new JobInfo();
                        jobInfo.JobAddress = item.City;
                        jobInfo.JobLink = string.Format("http://www.lagou.com/jobs/{0}.html", item.PositionId);
                        jobInfo.JobTitle = item.PositionName;
                        jobInfo.JobCompany = item.CompanyShortName;
                        jobInfo.JobSalary = item.Salary;
                        jobInfo.JobWelfare = item.PositionAdvantage + string.Join(",", item.CompanyLabelList);
                        jobInfo.PublishDate = item.CreateTime;
                        jobInfo.CompanyType = item.IndustryField + "," + item.FinanceStage;
                        jobInfo.JobBaseInfo = string.Format("经验{0},{1}以上,{2}", item.WorkYear, item.Education, item.JobNature);
                        string detailhtml = GetHtml(jobInfo.JobLink);
                        if (!string.IsNullOrEmpty(detailhtml))
                        {
                            IHtmlDocument document = _parser.Parse(detailhtml);
                            IElement element = document.QuerySelector("dl.job_detail").QuerySelector("dd.job_bt");
                            if (element != null)
                            {
                                jobInfo.JobDetail = element.InnerHtml;
                            }
                        }
                        jobInfos.Add(jobInfo);
                    }


                }
            }
            catch (Exception e)
            {
            }
            return jobInfos;
        }
    }
}
