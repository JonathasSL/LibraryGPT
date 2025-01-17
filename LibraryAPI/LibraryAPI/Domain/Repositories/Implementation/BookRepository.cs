using LibraryAPI.Domain.Entities;
using LibraryAPI.Domain.Repositories;
using LibraryAPI.Infrasctructure.Data;

namespace LibraryAPI.Domain.Repositories.Implementation
{
    public class BookRepository : Repository<BookEntity>, IBookRepository
    {
        public BookRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
