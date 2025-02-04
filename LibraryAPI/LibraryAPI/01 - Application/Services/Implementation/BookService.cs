using LibraryAPI.Application.Models;
using LibraryAPI.Domain.Entities;
using LibraryAPI.Domain.Enumerators;
using LibraryAPI.Domain.Repositories;

namespace LibraryAPI.Application.Services.Implementation
{
    public class BookService : CRUDService<Book, BookEntity, Guid>, IBookService
    {
        public override async Task<BookEntity> Create(Book model)
        {
            //TODO: Implementar Factory
            var entity = new BookEntity(model.Title, model.Author, model.CopyId);
            return repository.CreateAsync(entity).Result;
        }
        public override async Task<BookEntity>? Update(Guid id, Book book)
        {
            var Entity = await GetById(id);
            if (Entity == null)
                return null;


            //TODO: Implementar Factory
            Entity.Title = book.Title;
            Entity.Author = book.Author;
            Entity.CopyId = book.CopyId;
            Entity.Genre = ParseBookGenres(book.Genre);

            return await repository.Update(Entity);
        }

        private BookGenres? ParseBookGenres(string bookGenres)
        {
            bookGenres = bookGenres.Replace(" ", "");
            if (!string.IsNullOrWhiteSpace(bookGenres) && Enum.TryParse<BookGenres>(bookGenres, true, out var genre))
                return genre;
            return null;
        }

        public BookService(IBookRepository bookRepository) : base(bookRepository) { }

    }
}
