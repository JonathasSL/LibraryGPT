using LibraryAPI.Application.Models;
using LibraryAPI.Domain.Entities;

namespace LibraryAPI.Domain.Factories.Implementation
{
    public class BookFactory : IBookFactory
    {
        public BookEntity Create(Book book)
        {
            return new BookEntity(book.Title, book.Author, book.CopyId);
        }
    }
}
