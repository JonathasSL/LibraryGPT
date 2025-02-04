namespace LibraryAPI.Domain.Entities
{
    public class UserEntity : BaseEntity<Guid>
    {
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }

        public UserEntity(string name, string email, string password) : base()
        {
            Name = name;
            Email = email;
            Password = password;
        }

        public void ChangeName(string name)
        {
            Name = name;
            SetAsUpdated();
        }

        public void ChangeEmail(string email)
        {
            Email = email;
            SetAsUpdated();
        }

        public void ChangePassword(string password)
        {
            Password = password;
            SetAsUpdated();
        }
    }
}
