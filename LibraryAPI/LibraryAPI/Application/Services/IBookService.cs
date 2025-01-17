using LibraryAPI.Application.Models;
using LibraryAPI.Domain.Entities;

namespace LibraryAPI.Application.Services
{
    public interface IBookService
    {
        Task<BookEntity> CreateCopy(Book model);
        Task<List<BookEntity>> GetAllBooksAsync();
    }
}
