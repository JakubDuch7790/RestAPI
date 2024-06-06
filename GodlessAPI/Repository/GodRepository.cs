using GodlessAPI.Data;
using GodlessAPI.Models;
using GodlessAPI.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;

namespace GodlessAPI.Repository
{
    public class GodRepository : IGodRepository
    {
        private readonly ApplicationDbContext _context;

        public GodRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task Create(Godless god)
        {
            await _context.AddAsync(god);
            await _context.SaveChangesAsync();
        }

        public async Task<Godless> Get(Expression<Func<Godless, bool>> filter = null, bool tracked = true)
        {
            IQueryable<Godless> query = _context.Gods;

            if(!tracked)
            {
                query.AsNoTracking();
            }

            if (filter != null)
            {
                query = query.Where(filter);
            }

            return await query.FirstOrDefaultAsync();

        }

        public async Task<List<Godless>> GetAll(Expression<Func<Godless, bool>> filter = null)
        {
            IQueryable<Godless> query = _context.Gods;

            if(filter != null)
            {
                query = query.Where(filter);
            }

            return await query.ToListAsync();
        }

        public async Task Remove(Godless god)
        {
            _context.Gods.Remove(god);
            await _context.SaveChangesAsync();
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
