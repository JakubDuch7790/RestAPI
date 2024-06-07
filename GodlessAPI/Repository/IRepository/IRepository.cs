using GodlessAPI.Models;
using System.Linq.Expressions;

namespace GodlessAPI.Repository.IRepository
{
    public interface IRepository
    {
        Task CreateAsync(Godless entity);
        Task<List<Godless>> GetAllAsync(Expression<Func<Godless, bool>> filter = null);
        Task<Godless> GetAsync(Expression<Func<Godless, bool>> filter = null, bool tracked = true);
        Task SaveAsync();
        Task UpdateAsync(Godless entity);
        Task RemoveAsync(Godless entity);

    }
}
