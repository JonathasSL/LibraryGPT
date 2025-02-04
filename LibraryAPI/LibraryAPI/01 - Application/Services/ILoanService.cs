using LibraryAPI.Application.Models;
using LibraryAPI.Domain.Entities;

namespace LibraryAPI.Application.Services
{
    public interface ILoanService : ICRUDService<Loan, LoanEntity, Guid>
    {
        Task<IEnumerable<LoanEntity>> GetByUser(Guid id);
        Task<LoanEntity> ReturnCopy(Guid id);
    }
}
