using LibraryAPI.Application.Models;
using LibraryAPI.Domain.Entities;
using LibraryAPI.Domain.Repositories;

namespace LibraryAPI.Application.Services.Implementation
{
    public class BookService : IBookService
    {
        public async Task<BookEntity> Create(Book model)
        {
            var book = new BookEntity(model.Title, model.Author, model.CopyId);
            return _bookRepository.AddAsync(book).Result;
        }

        public async Task<List<BookEntity>> GetAllAsync()
        {
            return _bookRepository.GetAllAsync().Result.ToList();
        }

        public Task<BookEntity> GetById(Guid id)
        {
            return _bookRepository.GetByIdAsync(id);
        }

        public Task<BookEntity> Update(Book book)
        {
            var Entity = _bookRepository.GetByIdAsync(book.Id).Result;
            if (Entity == null)
                return null;

            Entity.Title = book.Title;
            Entity.Author = book.Author;
            Entity.CopyId = book.CopyId;
            //Entity.Genre = book.Genre;

            return _bookRepository.Update(Entity);
        }

        public async Task<BookEntity> Delete(Guid id)
        {
            var entity = await _bookRepository.GetByIdAsync(id);
            if (entity == null)
                return null;
            
            await _bookRepository.DeleteAsync(entity);
            return entity;
        }

        private readonly IBookRepository _bookRepository;
        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

    }
}
