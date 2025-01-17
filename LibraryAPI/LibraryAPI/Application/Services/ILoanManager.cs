using LibraryAPI.Application.Models;

namespace LibraryAPI.Application.Services
{
    public interface ILoanManager
    {
        string BorrowBook(User user, Book book);
        string ReturnBook(Book book);
        List<Loan> GetActiveLoans();
    }
}
