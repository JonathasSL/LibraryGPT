using LibraryAPI.Application.Models;
using LibraryAPI.Domain.Entities;

namespace LibraryAPI.Domain.Factories
{
    public interface IUserFactory //: IFactory<UserEntity>
    {
        UserEntity Create(User user);
    }
}
