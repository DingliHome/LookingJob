using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Job.Model.Entities;

namespace Job.Service
{
    [ServiceContract]
    public interface IJobService
    {
        [OperationContract]
        List<JobInfo> CrawlerJob(string jobplatform, string city, string kw, string pagenum);

    }
}
