using LibraryAPI.Domain.Entities;
using LibraryAPI.Infrasctructure.Data;

namespace LibraryAPI.Domain.Repositories.Implementation
{
    public class BookRepository : Repository<BookEntity, Guid>, IBookRepository
    {
        public BookRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
