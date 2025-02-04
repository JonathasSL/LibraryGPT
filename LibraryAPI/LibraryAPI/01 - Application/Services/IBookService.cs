using LibraryAPI.Application.Models;
using LibraryAPI.Domain.Entities;

namespace LibraryAPI.Application.Services
{
    public interface IBookService : ICRUDService<Book, BookEntity, Guid>
    {
    }
}
