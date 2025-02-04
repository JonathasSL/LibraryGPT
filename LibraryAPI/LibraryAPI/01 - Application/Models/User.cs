namespace LibraryAPI.Application.Models
{
    public class User : BaseModel<Guid>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
