using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace National.Domain.Logic.IRepository
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetById(int id);
        Task<IEnumerable<T>> GetAll();
        Task<IEnumerable<T>> Find(Expression<Func<T, bool>> expression);
        Task<int> Add(T entity);
        Task AddRange(IEnumerable<T> entities);
        Task Remove(T entity);
        Task RemoveRange(IEnumerable<T> entities);
        Task Update(T entitiy);
        void Save();
    }
}
