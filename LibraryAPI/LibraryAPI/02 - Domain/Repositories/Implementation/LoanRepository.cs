using LibraryAPI.Application.Models;
using LibraryAPI.Domain.Entities;
using LibraryAPI.Infrasctructure.Data;
using Microsoft.EntityFrameworkCore;

namespace LibraryAPI.Domain.Repositories.Implementation
{
    public class LoanRepository : Repository<LoanEntity, Guid>, ILoanRepository
    {
        public async Task<IEnumerable<LoanEntity>> GetByUser(Guid userId)
        {
            return await SearchQuery().Where(entity => entity.LoanTo.Id == userId).ToListAsync();
        }

        public async Task<IEnumerable<LoanEntity>> GetByBook(string bookCopyId)
        {
            return await SearchQuery().Where(entity => entity.IsActive && entity.Book.CopyId == bookCopyId).ToListAsync();
        }

        public LoanRepository(ApplicationDbContext context) : base(context) { }
    }
}
