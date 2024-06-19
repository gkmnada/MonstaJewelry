using System.Linq.Expressions;

namespace Application.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<List<T>> ListAsync();
        Task CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task<T> GetAsync(string id);
        Task<List<T>> ListByFilterAsync(Expression<Func<T, bool>> filter);
        Task<T> GetByFilterAsync(Expression<Func<T, bool>> filter);
    }
}
