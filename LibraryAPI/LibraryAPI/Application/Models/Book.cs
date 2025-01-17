namespace LibraryAPI.Application.Models
{
    public class Book : BaseModel<Guid>
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public bool IsAvailable { get; set; } = true;
        public string CopyId { get; set; }
    }
}
