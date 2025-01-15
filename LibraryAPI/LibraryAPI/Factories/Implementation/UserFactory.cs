using LibraryAPI.Models;

namespace LibraryAPI.Factories.Implementation
{
    public class UserFactory : IFactory<User>
    {
        private string _name;
        private string _email;

        public UserFactory(string name, string email)
        {
            _name = name;
            _email = email;
        }

        public User Create()
        {
            return new User
            {
                Name = _name,
                Email = _email
            };
        }
    }
}
