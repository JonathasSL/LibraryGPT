using LibraryAPI.Application.Models;
using LibraryAPI.Domain.Entities;

namespace LibraryAPI.Application.Services
{
    public interface IUserService : ICRUDService<User, UserEntity, Guid>
    {
    }
}
