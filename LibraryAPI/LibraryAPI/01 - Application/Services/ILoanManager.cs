using LibraryAPI.Application.Models;
using LibraryAPI.Domain.Entities;

namespace LibraryAPI.Application.Services
{
    public interface ILoanManager
    {
        Task<LoanEntity> BorrowBook(UserEntity user, BookEntity book);
        Task<LoanEntity> ReturnBook(BookEntity book);
        Task<IEnumerable<LoanEntity>> GetActiveLoans();
    }
}
