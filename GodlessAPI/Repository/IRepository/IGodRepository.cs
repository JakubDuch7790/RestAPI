using GodlessAPI.Models;
using System.Linq.Expressions;

namespace GodlessAPI.Repository.IRepository
{
    public interface IGodRepository : IRepository<Godless>
    {
        Task<Godless> UpdateAsync(Godless entity);
    }
}
