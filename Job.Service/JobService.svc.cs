using System;
using Job.Crawler;
using Job.Model.Entities;

namespace Job.Service
{
    public class JobService : IJobService
    {
        private ZhaoPin _zhaoPin = new ZhaoPin();
        public JobService()
        {

        }
        public JobInfo CrawlerJob(string jobplatform, string city, string kw, string pagenum)
        {
            JobInfo jobInfo = null;
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
