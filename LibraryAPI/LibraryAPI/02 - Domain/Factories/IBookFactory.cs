using LibraryAPI.Application.Models;
using LibraryAPI.Domain.Entities;

namespace LibraryAPI.Domain.Factories
{
    public interface IBookFactory //: IFactory<BookEntity>
    {
        BookEntity Create(Book book);
    }
}