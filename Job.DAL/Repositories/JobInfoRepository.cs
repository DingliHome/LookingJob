using System.Data.Entity;
using Job.DAL.IRepositories;
using Job.Model.Entities;

namespace Job.DAL.Repositories
{
    public class JobInfoRepository : BaseRepository<JobInfo>, IJobInfoRepository
    {
        public JobInfoRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
