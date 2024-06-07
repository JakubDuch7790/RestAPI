using GodlessAPI.Data;
using GodlessAPI.Models;
using GodlessAPI.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;

namespace GodlessAPI.Repository
{
    public class GodRepository : Repository<Godless>, IGodRepository
    {
        private readonly ApplicationDbContext _context;

        public GodRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Godless> UpdateAsync(Godless god)
        {
            _context.Gods.Update(god);
            await _context.SaveChangesAsync();
            return god;
        }

    }
}
