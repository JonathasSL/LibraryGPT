using LibraryAPI.Domain.Entities;

namespace LibraryAPI.Domain.Repositories
{
    public interface ILoanRepository : IRepository<LoanEntity, Guid>
    {
        Task<IEnumerable<LoanEntity>> GetByUser(Guid userId);
        Task<IEnumerable<LoanEntity>> GetByBook(string bookCopyId);
    }
}
