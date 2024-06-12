using GodlessAPI.Models;

namespace GodlessAPI.Repository.IRepository
{
    public interface IGodNumberRepository : IRepository<GodNumber>
    {
        Task<GodNumber> UpdateAsync(GodNumber entity);
    }
}
