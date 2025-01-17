using LibraryAPI.Application.Models;
using LibraryAPI.Domain.Entities;
using LibraryAPI.Domain.Repositories;

namespace LibraryAPI.Application.Services.Implementation
{
    public class BookService : IBookService
    {
        public async Task<BookEntity> CreateCopy(Book model)
        {
            var book = new BookEntity(model.Title, model.Author, model.CopyId);
            return _bookRepository.AddAsync(book).Result;
        }

        public async Task<List<BookEntity>> GetAllBooksAsync()
        {
            return _bookRepository.GetAllAsync().Result.ToList();
        }

        private readonly IBookRepository _bookRepository;
        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

    }
}
