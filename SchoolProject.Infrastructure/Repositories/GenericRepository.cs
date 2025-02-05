using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SchoolProject.Infrastructure.Data;
using SchoolProject.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace SchoolProject.Infrastructure.Repositories
{
    public class GenericRepositoryAsync<T>(ApplicationDbContext context) : IGenericRepositoryAsync<T> where T : class
    {
        #region CRUD
        public virtual IQueryable<T> GetAllNoTracking() => context.Set<T>().AsNoTracking().AsQueryable();
        public virtual IQueryable<T> GetAllAsTracking() => context.Set<T>().AsQueryable();
        public virtual async Task<T> GetByIdAsync(int id) => await context.Set<T>().FindAsync(id);
        public virtual async Task<T> AddAsync(T entity)
        {
            await context.Set<T>().AddAsync(entity);
            await context.SaveChangesAsync();
            return entity;
        }
        public virtual async Task AddRangeAsync(IEnumerable<T> entities)
        {
            await context.Set<T>().AddRangeAsync(entities);
            await context.SaveChangesAsync();
        }
        public virtual async Task UpdateAsync(T entity)
        {
            context.Set<T>().Update(entity);
            await context.SaveChangesAsync();
        }
        public virtual async Task UpdateRangeAsync(IEnumerable<T> entities)
        {
            context.Set<T>().UpdateRange(entities);
            await context.SaveChangesAsync();
        }
        public virtual async Task DeleteAsync(T entity)
        {
            context.Set<T>().Remove(entity);
            await context.SaveChangesAsync();
        }
        public virtual async Task DeleteRangeAsync(IEnumerable<T> entities)
        {
            context.Set<T>().RemoveRange(entities);
            await context.SaveChangesAsync();
        }
        #endregion
        #region Special Methods
        public virtual async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate) => await context.Set<T>().Where(predicate).ToListAsync();
        public virtual async Task<IEnumerable<T>> GetPagedAsync(int pageNumber, int pageSize) => await context.Set<T>().Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
        #endregion
        #region Transaction
        public async Task<IDbContextTransaction> BeginTransactionAsync() => await context.Database.BeginTransactionAsync();
        public async Task CommitAsync()
        {
            if (context.Database.CurrentTransaction != null)
                await context.Database.CommitTransactionAsync();
        }
        public async Task RollBackAsync()
        {
            if (context.Database.CurrentTransaction != null)
                await context.Database.RollbackTransactionAsync();
        }
        #endregion
    }
}

