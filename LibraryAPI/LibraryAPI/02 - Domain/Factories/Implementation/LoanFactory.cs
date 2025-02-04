using LibraryAPI.Application.Models;
using LibraryAPI.Domain.Entities;
using LibraryAPI.Domain.Repositories;

namespace LibraryAPI.Domain.Factories.Implementation
{
    public class LoanFactory : ILoanFactory
    {
        private readonly IBookRepository _bookRepository;
        private readonly IUserRepository _userRepository;

        public LoanFactory(
            IBookRepository bookRepository,
            IUserRepository userRepository)
        {
            _bookRepository = bookRepository;
            _userRepository = userRepository;
        }

        public async Task<LoanEntity> CreateAsync(Loan model)
        {
            if (model != null)
            {
                var book = await _bookRepository.GetByIdAsync(model.BookId);
                var user = await _userRepository.GetByIdAsync(model.UserId);

                if (user == null || book == null)
                    return null;

                var dueDate = DateTime.UtcNow.AddDays(14);

                return new LoanEntity(dueDate, book, user);
            }

            return null;
        }

        public async Task<LoanEntity> CreateAsync(DateTime dueDate, BookEntity bookEntity, UserEntity userEntity)
        {
            if (userEntity == null || bookEntity == null || dueDate <= DateTime.UtcNow)
                return null;

            return new LoanEntity(dueDate, bookEntity, userEntity);
        }
    }
}
