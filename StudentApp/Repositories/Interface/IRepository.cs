using StudentApp.Dtos;
using StudentApp.Entities;
using System.Linq.Expressions;

namespace StudentApp.Repositories.Interface
{
    public interface IRepository
    {
        Task<T> GetAsync<T>(Expression<Func<T, bool>> expression) where T : BaseEntity;
        Task<IEnumerable<T>> GetListAsync<T>(Expression<Func<T, bool>> expression = null) where T : BaseEntity;
        Task<bool> ExistsAsync<T>(Expression<Func<T, bool>> expression)
        where T : BaseEntity;
        Task UpdateAsync<T>(T entity)
        where T : BaseEntity;
        Task<int> SaveChangesAsync();
        Task<Guid> CreateAsync<T>(T entity)
        where T : BaseEntity;
        Task RemoveAsync<T>(T entity)
        where T : BaseEntity;

    }
}
