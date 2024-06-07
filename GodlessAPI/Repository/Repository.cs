using GodlessAPI.Data;
using GodlessAPI.Models;
using GodlessAPI.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace GodlessAPI.Repository;

public class Repository<T> : IRepository<T> where T : class
{
    private readonly ApplicationDbContext _context;

    internal DbSet<T> dbSet; 
    public Repository(ApplicationDbContext context)
    {
        _context = context;

        this.dbSet = _context.Set<T>();
    }
    public async Task CreateAsync(T entity)
    {
        await _context.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<T> GetAsync(Expression<Func<T, bool>> filter = null, bool tracked = true)
    {
        IQueryable<T> query = dbSet;

        if (!tracked)
        {
            query.AsNoTracking();
        }

        if (filter != null)
        {
            query = query.Where(filter);
        }

        return await query.FirstOrDefaultAsync();

    }

    public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null)
    {
        IQueryable<T> query = dbSet;

        if (filter != null)
        {
            query = query.Where(filter);
        }

        return await query.ToListAsync();
    }

    public async Task RemoveAsync(T entity)
    {
        dbSet.Remove(entity);
        await _context.SaveChangesAsync();
    }

    public async Task SaveAsync()
    {
        await _context.SaveChangesAsync();
    }
}
