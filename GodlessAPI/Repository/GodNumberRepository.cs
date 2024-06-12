using GodlessAPI.Data;
using GodlessAPI.Models;
using GodlessAPI.Repository.IRepository;

namespace GodlessAPI.Repository
{
    public class GodNumberRepository : Repository<GodNumber>, IGodNumberRepository
    {
        private readonly ApplicationDbContext _context;

        public GodNumberRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext) 
        {
            _context = applicationDbContext;
        }

        public async Task<GodNumber> UpdateAsync(GodNumber entity)
        {
            entity.UpdateDate = DateTime.Now;

            _context.GodsNumbers.Update(entity);

            await _context.SaveChangesAsync();

            return entity;
        }
    }
}
