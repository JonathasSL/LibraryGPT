using LibraryAPI.Application.Models;
using LibraryAPI.Domain.Entities;

namespace LibraryAPI.Application.Services
{
    public interface IBookService
    {
        Task<BookEntity> Create(Book model);
        Task<List<BookEntity>> GetAllAsync();
        Task<BookEntity> GetById(Guid id);
        Task<BookEntity> Update(Book book);
        Task<BookEntity> Delete(Guid id);
    }
}
