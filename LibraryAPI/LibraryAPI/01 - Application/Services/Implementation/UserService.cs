using LibraryAPI.Application.Models;
using LibraryAPI.Domain.Entities;
using LibraryAPI.Domain.Repositories;

namespace LibraryAPI.Application.Services.Implementation
{
    public class UserService : CRUDService<User, UserEntity, Guid>, IUserService
    {
        public UserService(IUserRepository userRepository) : base(userRepository) { }

        public override Task<UserEntity> Create(User model)
        {
            var entity = new UserEntity(model.Name, model.Email, model.Password);
            return repository.CreateAsync(entity);
        }

        public override async Task<UserEntity>? Update(Guid id, User model)
        {
            var entity = await GetById(id);
            if (entity == null)
                return null;

            entity.ChangeName(model.Name);
            entity.ChangeEmail(model.Email);
            entity.ChangePassword(model.Password);

            return await repository.Update(entity);
        }
    }
}
