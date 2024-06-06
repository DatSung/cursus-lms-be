using System.Linq.Expressions;

namespace Cursus.LMS.DataAccess.IRepository;

public interface IRepository<T> where T : class
{
    Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null, string? includeProperties = null);
    Task<T?> GetAsync(Expression<Func<T, bool>> filter, string? includeProperties = null);
    Task AddAsync(T entity);
    Task AddRangeAsync(List<T> entities);
    void Remove(T entity);
    void RemoveRange(List<T> entities);
}