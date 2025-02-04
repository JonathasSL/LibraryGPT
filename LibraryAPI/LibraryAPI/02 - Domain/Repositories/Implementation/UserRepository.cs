using LibraryAPI.Domain.Entities;
using LibraryAPI.Infrasctructure.Data;

namespace LibraryAPI.Domain.Repositories.Implementation
{
    public class UserRepository : Repository<UserEntity, Guid>, IUserRepository
    {
        public UserRepository(ApplicationDbContext context) : base(context) { }
    }
}
