using Microsoft.EntityFrameworkCore;
using StudentApp.Context;
using StudentApp.Entities;
using StudentApp.Repositories.Interface;
using System.Linq.Expressions;

namespace StudentApp.Repositories.Implementation
{
    public class RepositoryAsync : IRepository
    {

        private readonly ApplicationDbContext _dbContext;
        public RepositoryAsync(ApplicationDbContext dbContext) 
        {
            _dbContext = dbContext;
        }
        public async Task<T> GetAsync<T>(Expression<Func<T, bool>> expression) where T : BaseEntity
        {
            IQueryable<T> query = _dbContext.Set<T>();
            return await query.Where(expression).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<T>> GetListAsync<T>(Expression<Func<T, bool>> expression) where T : BaseEntity
        {
            IQueryable<T> query = _dbContext.Set<T>();
            if (expression != null) query = query.Where(expression);
            return await query.ToListAsync();
        }

        public async Task<bool> ExistsAsync<T>(Expression<Func<T, bool>> expression)
        where T : BaseEntity
        {
            IQueryable<T> query = _dbContext.Set<T>();
            if (expression != null) return await query.AnyAsync(expression);
            return await query.AnyAsync();
        }
        public async Task<bool> DetachAllEntities()
        {
            var changedEntriesCopy1 = _dbContext.ChangeTracker.Entries().ToList();
            foreach (var entry in changedEntriesCopy1)
            {
                entry.State = EntityState.Detached;
            }
            await _dbContext.SaveChangesAsync();
            return true;

        }
        public Task UpdateAsync<T>(T entity)
        where T : BaseEntity
        {
            T exist = _dbContext.Set<T>().Find(entity.Id);

            if (exist != null)
            {
                _dbContext.Entry(exist).State = EntityState.Detached;
            }

            _dbContext.Set<T>().Update(entity);
            return Task.CompletedTask;
        }

        public async Task<Guid> CreateAsync<T>(T entity)
        where T : BaseEntity
        {
            await _dbContext.Set<T>().AddAsync(entity);
            return entity.Id;
        }

        public Task RemoveAsync<T>(T entity)
        where T : BaseEntity
        {
            _dbContext.Set<T>().Remove(entity);
            return Task.CompletedTask;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }

    }
}
