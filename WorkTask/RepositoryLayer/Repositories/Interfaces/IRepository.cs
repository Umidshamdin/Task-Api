using DomainLayer.Common;
using System.Linq.Expressions;

namespace RepositoryLayer.Repositories.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<List<T>> GetAllAsync();
        Task CreateAsync(T entity);
        Task<T> GetAsync(int id);
        Task DeleteAsync(T entity);
        Task UpdateAsync(T entity);
        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);
       // Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> predicate);
    }
}
