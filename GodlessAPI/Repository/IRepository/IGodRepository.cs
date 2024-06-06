using GodlessAPI.Models;
using System.Linq.Expressions;

namespace GodlessAPI.Repository.IRepository
{
    public interface IGodRepository
    {
        Task Create(Godless god);
        Task<List<Godless>> GetAll(Expression<Func<Godless>> filter = null);
        Task<Godless> Get(Expression<Func<Godless>> filter = null, bool tracked = true);

        Task Save();
        Task Remove(Godless god);



    }
}
