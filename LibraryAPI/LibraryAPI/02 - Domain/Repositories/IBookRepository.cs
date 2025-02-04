using LibraryAPI.Domain.Entities;

namespace LibraryAPI.Domain.Repositories
{
    public interface IBookRepository : IRepository<BookEntity, Guid>
    {
    }
}
