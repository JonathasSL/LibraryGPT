namespace LibraryAPI.Application.Models
{
    public class Book : BaseModel<Guid>
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public string CopyId { get; set; }
        public bool IsAvailable { get; set; } = true;
    }
}
