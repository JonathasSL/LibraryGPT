using LibraryAPI.Domain.Entities;
using LibraryAPI.Infrasctructure.Data;
using Microsoft.EntityFrameworkCore;

namespace LibraryAPI.Domain.Repositories.Implementation;

public class Repository<T, TId> : IRepository<T, TId>
    where T : BaseEntity<TId> 
    where TId : struct
{
    protected readonly ApplicationDbContext _context;
    protected readonly DbSet<T> _dbSet;

    public Repository(ApplicationDbContext context)
    {
        _context = context;
        _dbSet = _context.Set<T>();
    }
    
    protected IQueryable<T> SearchQuery() => _dbSet.Where(entity => !entity.RemovedOn.HasValue);

    public async Task<T> GetByIdAsync(TId id)
    {
        return await _dbSet.FindAsync(id);
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _dbSet.Where(entity => !entity.RemovedOn.HasValue).ToListAsync();
    }

    public async Task<T> CreateAsync(T entity)
    {
        await _dbSet.AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<T> Update(T entity)
    {
        entity.LastModifiedDate = DateTime.UtcNow;
        _dbSet.Update(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task SoftDeleteAsync(T entity)
    {
        entity.RemovedOn = DateTime.UtcNow;
        _dbSet.Update(entity);
        await _context.SaveChangesAsync();
    }
}
