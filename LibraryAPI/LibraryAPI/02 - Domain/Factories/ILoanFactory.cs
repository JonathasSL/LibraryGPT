using LibraryAPI.Application.Models;
using LibraryAPI.Domain.Entities;

namespace LibraryAPI.Domain.Factories;
public interface ILoanFactory //: IFactory<Loan,LoanEntity>
{
    Task<LoanEntity> CreateAsync(DateTime dueDate, BookEntity bookEntity, UserEntity userEntity);
}
