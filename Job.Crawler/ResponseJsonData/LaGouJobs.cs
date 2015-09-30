using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Job.Crawler.ResponseJsonData
{
    public class LaGouJobs
    {
        [JsonProperty("resubmitToken")]
        public object ResubmitToken { get; set; }

        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("requestId")]
        public object RequestId { get; set; }

        [JsonProperty("msg")]
        public object Msg { get; set; }

        [JsonProperty("code")]
        public int Code { get; set; }

        [JsonProperty("content")]
        public Content Content { get; set; }
    }

    public class Content
    {

        [JsonProperty("totalCount")]
        public int TotalCount { get; set; }

        [JsonProperty("hasNextPage")]
        public bool HasNextPage { get; set; }

        [JsonProperty("pageNo")]
        public int PageNo { get; set; }

        [JsonProperty("pageSize")]
        public int PageSize { get; set; }

        [JsonProperty("totalPageCount")]
        public int TotalPageCount { get; set; }

        [JsonProperty("currentPageNo")]
        public int CurrentPageNo { get; set; }

        [JsonProperty("hasPreviousPage")]
        public bool HasPreviousPage { get; set; }

        [JsonProperty("result")]
        public Result[] Result { get; set; }

        [JsonProperty("start")]
        public int Start { get; set; }
    }
    public class Result
    {

        [JsonProperty("positionId")]
        public int PositionId { get; set; }

        [JsonProperty("positionName")]
        public string PositionName { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("companyId")]
        public int CompanyId { get; set; }

        [JsonProperty("createTime")]
        public string CreateTime { get; set; }

        [JsonProperty("positionFirstType")]
        public string PositionFirstType { get; set; }

        [JsonProperty("education")]
        public string Education { get; set; }

        [JsonProperty("workYear")]
        public string WorkYear { get; set; }

        [JsonProperty("jobNature")]
        public string JobNature { get; set; }

        [JsonProperty("salary")]
        public string Salary { get; set; }

        [JsonProperty("companyShortName")]
        public string CompanyShortName { get; set; }

        [JsonProperty("financeStage")]
        public string FinanceStage { get; set; }

        [JsonProperty("industryField")]
        public string IndustryField { get; set; }

        [JsonProperty("companyName")]
        public string CompanyName { get; set; }

        [JsonProperty("positionType")]
        public string PositionType { get; set; }

        [JsonProperty("companyLogo")]
        public string CompanyLogo { get; set; }

        [JsonProperty("positionAdvantage")]
        public string PositionAdvantage { get; set; }

        [JsonProperty("leaderName")]
        public string LeaderName { get; set; }

        [JsonProperty("companySize")]
        public string CompanySize { get; set; }

        [JsonProperty("companyLabelList")]
        public string[] CompanyLabelList { get; set; }

        [JsonProperty("score")]
        public int Score { get; set; }

        [JsonProperty("formatCreateTime")]
        public string FormatCreateTime { get; set; }

        [JsonProperty("countAdjusted")]
        public bool CountAdjusted { get; set; }

        [JsonProperty("adjustScore")]
        public int AdjustScore { get; set; }

        [JsonProperty("relScore")]
        public int RelScore { get; set; }

        [JsonProperty("randomScore")]
        public int RandomScore { get; set; }

        [JsonProperty("calcScore")]
        public bool CalcScore { get; set; }

        [JsonProperty("orderBy")]
        public int OrderBy { get; set; }

        [JsonProperty("showOrder")]
        public object ShowOrder { get; set; }

        [JsonProperty("haveDeliver")]
        public bool HaveDeliver { get; set; }

        [JsonProperty("adWord")]
        public int AdWord { get; set; }

        [JsonProperty("createTimeSort")]
        public object CreateTimeSort { get; set; }

        [JsonProperty("hrScore")]
        public int HrScore { get; set; }

        [JsonProperty("positonTypesMap")]
        public object PositonTypesMap { get; set; }

        [JsonProperty("totalCount")]
        public int TotalCount { get; set; }

        [JsonProperty("searchScore")]
        public double SearchScore { get; set; }
    }

}
