using GodlessAPI.Models;
using System.Linq.Expressions;

namespace GodlessAPI.Repository.IRepository;

public interface IRepository<T> where T : class
{
    Task CreateAsync(T entity);
    Task<List<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null);
    Task<T> GetAsync(Expression<Func<T, bool>> filter = null, bool tracked = true);
    Task SaveAsync();
    Task RemoveAsync(T entity);

}
