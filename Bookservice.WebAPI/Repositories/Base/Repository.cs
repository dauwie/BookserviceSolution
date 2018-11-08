using Bookservice.WebAPI.Data;
using Bookservice.Lib.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Bookservice.WebAPI.Repositories
{
    public class Repository<T> : IRepository<T> where T : EntityBase
    {
        protected readonly BookServiceContext _bookServiceContext;
        
        public Repository(BookServiceContext context)
        {
            _bookServiceContext = context;
        }

        public virtual async Task<T> GetById(int id)
        {
            return await _bookServiceContext.Set<T>().FindAsync(id);
        }
        
        public virtual async Task<T> Add(T entity)
        {
            _bookServiceContext.Set<T>().Add(entity);
            try
            {
                await _bookServiceContext.SaveChangesAsync();
            }
            catch (Exception)
            {

                return null;
            }

            return entity;
        }
               
        public virtual async Task<T> Delete(T entity)
        {
            _bookServiceContext.Set<T>().Remove(entity);
            try
            {
                await _bookServiceContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                return null;
            }
            return entity;
        }

        public virtual async Task<T> Delete(int id)
        {
            var entity = await GetById(id);
            if (entity == null) return null;
            return await Delete(entity);
        }

        public virtual IQueryable<T> GetAll()
        {
            return _bookServiceContext.Set<T>().AsNoTracking();
        }
               
        public virtual IQueryable<T> GetFiltered(Expression<Func<T, bool>> predicate)
        {
            return _bookServiceContext.Set<T>().Where(predicate).AsNoTracking();
        }

        public virtual async Task<IEnumerable<T>> ListAll()
        {
            return await GetAll().ToListAsync();
        }

        public virtual async Task<IEnumerable<T>> ListFiltered(Expression<Func<T, bool>> predicate)
        {
            return await GetFiltered(predicate).ToListAsync();
        }

        public virtual async Task<T> Update(T entity)
        {
            _bookServiceContext.Entry(entity).State = EntityState.Modified;
            try
            {
                await _bookServiceContext.SaveChangesAsync();
            }
            catch (Exception)
            {

                return null;
            }
            return entity;
        }

        private async Task<bool> Exists(int id)
        {
            return await _bookServiceContext.Set<T>().AnyAsync(e => e.Id == id);
        }
    }
}
