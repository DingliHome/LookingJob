using System.Collections.Generic;
using Job.Model.Entities;

namespace Job.Crawler
{
    public interface ICrawler
    {
        List<JobInfo> CrawlerJob(string city,string kw,string pagenum);
    }
}