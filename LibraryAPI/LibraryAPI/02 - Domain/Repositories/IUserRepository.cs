using LibraryAPI.Domain.Entities;

namespace LibraryAPI.Domain.Repositories
{
    public interface IUserRepository : IRepository<UserEntity, Guid>
    {
    }
}
