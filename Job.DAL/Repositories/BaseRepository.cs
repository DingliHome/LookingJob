using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Job.DAL.IRepositories;

namespace Job.DAL.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected readonly DbContext _dbContext;
        
        public BaseRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        private DbSet<T> Dbset
        {
            get { return _dbContext.Set<T>(); }
        } 
        public IQueryable<T> GetAll()
        {
            return Dbset;
        }

        public IQueryable<T> ReadAll()
        {
            return Dbset.AsNoTracking();
        }

        public IQueryable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            return Dbset.Where(predicate);
        }

        public T GetById(long id)
        {
            T find = Dbset.Find(id);
            return find;
        }

        public void Add(T entity)
        {
            Dbset.Add(entity);
        }

        public void AddRange(List<T> entities)
        {
            _dbContext.Set<T>().AddRange(entities);
        }

        public void Delete(T entity)
        {
            Dbset.Remove(entity);
        }

        public void Update(T entity)
        {
            Dbset.Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await Dbset.ToListAsync();
        }
    }
}
