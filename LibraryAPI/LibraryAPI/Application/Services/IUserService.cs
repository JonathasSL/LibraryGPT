using LibraryAPI.Application.Models;

namespace LibraryAPI.Application.Services
{
    public interface IUserService
    {
        User CreateUser(string name, string email);
    }
}
