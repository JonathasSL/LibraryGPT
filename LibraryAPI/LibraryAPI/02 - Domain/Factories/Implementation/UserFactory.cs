using LibraryAPI.Application.Models;
using LibraryAPI.Domain.Entities;

namespace LibraryAPI.Domain.Factories.Implementation
{
    public class UserFactory : IUserFactory
    {
        public UserEntity Create(User user)
        {
            return new UserEntity(user.Name, user.Email, user.Password);
        }

    }
}
