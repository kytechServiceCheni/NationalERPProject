using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Linq.Expressions;
using National.Domain.Logic.IRepository;
using National.Repository.Entity;

namespace National.Domain.Logic.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly NationalContext _context;
        private DbSet<T> table = null;
        public GenericRepository(NationalContext context)
        {
            _context = context;
            table = _context.Set<T>();
        }
        public async Task<int> Add(T entity)
        {
            try
            {
                await table.AddAsync(entity);
               return _context.SaveChanges();
                //await Save();
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
        public async Task AddRange(IEnumerable<T> entities)
        {
            try
            {
                await table.AddRangeAsync(entities);
                //await Save();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<IEnumerable<T>> Find(Expression<Func<T, bool>> expression)
        {
            return await table.Where(expression).ToListAsync();
        }
        public async Task<IEnumerable<T>> GetAll()
        {
            return await table.ToListAsync();
        }
        public async Task<T> GetById(int id)
        {
            return await table.FindAsync(id);
        }
        public async Task Remove(T entity)
        {
            try
            {
                table.Remove(entity);
                //await Save();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public async Task RemoveRange(IEnumerable<T> entities)
        {
            try
            {
                table.RemoveRange(entities);
                // await Save();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task Update(T entity)
        {
            try
            {
                table.Attach(entity);
                _context.Entry(entity).State = EntityState.Modified;
                //await Save();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
