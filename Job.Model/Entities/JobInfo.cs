using System.Runtime.Serialization;

namespace Job.Model.Entities
{
    [DataContract]
    public class JobInfo
    {
        [DataMember]
        public long Id { get; set; }
        /// <summary>
        /// 职位名称
        /// </summary>
         [DataMember]
        public string JobTitle { get; set; }
        /// <summary>
        /// 外部链接
        /// </summary>
        public string JobLink { get; set; }
        /// <summary>
        /// 公司
        /// </summary>
        public string JobCompany { get; set; }
        /// <summary>
        /// 工资薪资
        /// </summary>
         [DataMember]
        public string JobSalary { get; set; }
        /// <summary>
        /// 工作地点
        /// </summary>
         [DataMember]
        public string JobAddress { get; set; }
        /// <summary>
        /// 发布日期
        /// </summary>
         [DataMember]
        public string PublishDate { get; set; }
        /// <summary>
        /// 公司性质
        /// </summary>
         [DataMember]
        public string CompanyType { get; set; }
        /// <summary>
        /// 工作福利
        /// </summary>
        public string JobWelfare { get; set; }

        public string JobBaseInfo { get; set; }
        public string JobDetail { get; set; }
    }
}
