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
        void Add(T entity);
        void Delete(T entity);
        void Edit(T entity);
        void Save();

        Task<T> GetByIdAsync(int id);

        Task AddAsync(T entity);

        Task EditAsync(T entity);

        Task DeleteAsync(T entity);
    }
}
