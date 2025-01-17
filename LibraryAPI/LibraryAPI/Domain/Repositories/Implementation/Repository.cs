using LibraryAPI.Domain.Entities;
using LibraryAPI.Domain.Repositories;
using LibraryAPI.Infrasctructure.Data;
using Microsoft.EntityFrameworkCore;

namespace LibraryAPI.Domain.Repositories.Implementation
{
    public class Repository<T, TId> : IRepository<T> where T : BaseEntity<TId>
    {
        protected readonly ApplicationDbContext _context;
        protected readonly DbSet<T> _dbSet;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task Update(T entity)
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            entity.RemovedOn = DateTime.UtcNow;
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
        }

    }
}
