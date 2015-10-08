using System;
using System.Data.Entity;
using System.Threading.Tasks;
using Job.DAL.IRepositories;
using Job.DAL.Repositories;
using Job.Model.Entities;

namespace Job.DAL.UnitOfWork
{
    public class UnitOfWork<TContext> : IUnitOfWork<TContext> where TContext : DbContext, new()
    {
        private readonly DbContext _dataContext;
        private IBaseRepository<JobInfo> _jobInfoRepository;

        public UnitOfWork()
        {
            _dataContext = new TContext();
        }

        public virtual int Commit()
        {
            int saveChanges = 0;
            try
            {
                saveChanges = _dataContext.SaveChanges();
            }
            catch (Exception e)
            {
                saveChanges = 0;
            }
            return saveChanges;
        }

        public virtual Task<int> CommitAsync()
        {
            return _dataContext.SaveChangesAsync();
        }

        public IBaseRepository<JobInfo> JobInfoRepository
        {
            get { return _jobInfoRepository ?? (_jobInfoRepository = new JobInfoRepository(_dataContext)); }
        }

        public void Dispose()
        {
            if (_dataContext != null)
                _dataContext.Dispose();
        }
    }

    public interface IUnitOfWork<TContext> where TContext : DbContext, IDisposable
    {
        int Commit();
        Task<int> CommitAsync();

        IBaseRepository<JobInfo> JobInfoRepository { get; }
    }
}
