using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Job.DAL.IRepositories
{
    public interface IBaseRepository<T> where T : class
    {
        IQueryable<T> GetAll();
        IQueryable<T> ReadAll();
        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);
        T GetById(long id);
        void Add(T entity);
        void AddRange(List<T> entities);
        void Delete(T entity);
        void Update(T entity);
        Task<List<T>> GetAllAsync();
    }
}
