using System;
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
        protected readonly DbContextBase _dbContext = new DbContextBase();
        protected DbSet<T> DbSet;
        public BaseRepository()
        {
            DbSet = _dbContext.Set<T>();
        }
        public IQueryable<T> GetAll()
        {
            return DbSet;
        }

        public IQueryable<T> ReadAll()
        {
            return DbSet.AsNoTracking();
        }

        public IQueryable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            return DbSet.Where(predicate);
        }

        public void Add(T entity)
        {
            DbSet.Add(entity);
            _dbContext.SaveChanges();
        }

        public void Delete(T entity)
        {
            DbSet.Attach(entity);
            DbSet.Remove(entity);
            _dbContext.SaveChanges();
        }

        public void Edit(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await DbSet.FindAsync(id);
        }

        public async Task AddAsync(T entity)
        {
            DbSet.Add(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task EditAsync(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            DbSet.Attach(entity);
            DbSet.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
