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
        public async Task CreateAsync(Godless god)
        {
            await _context.AddAsync(god);
            await _context.SaveChangesAsync();
        }

        public async Task<Godless> GetAsync(Expression<Func<Godless, bool>> filter = null, bool tracked = true)
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

        public async Task<List<Godless>> GetAllAsync(Expression<Func<Godless, bool>> filter = null)
        {
            IQueryable<Godless> query = _context.Gods;

            if(filter != null)
            {
                query = query.Where(filter);
            }

            return await query.ToListAsync();
        }

        public async Task RemoveAsync(Godless god)
        {
            _context.Gods.Remove(god);
            await _context.SaveChangesAsync();
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Godless god)
        {
            _context.Gods.Update(god);
            await SaveAsync();
        }

    }
}
