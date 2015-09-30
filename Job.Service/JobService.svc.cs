using System;
using System.Collections.Generic;
using Job.Crawler;
using Job.Crawler.CrawlerAction;
using Job.Model.Entities;

namespace Job.Service
{
    public class JobService : IJobService
    {
        private ZhaoPin _zhaoPin = new ZhaoPin();
        public JobService()
        {

        }
        public List<JobInfo> CrawlerJob(string jobplatform, string city, string kw, string pagenum)
        {
            List<JobInfo> jobInfo = new List<JobInfo>();
            switch (jobplatform)
            {
                case "ZhaoPin":
                    jobInfo = _zhaoPin.CrawlerJob(city, kw, pagenum);
                    break;
            }
            return jobInfo;
        }
    }

}
