namespace LibraryAPI.Models
{
    public class Book
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public bool IsAvailable { get; set; } = true;

        public void SetAsBorrowed() => IsAvailable = false;

        public void ReturnBook() => IsAvailable = true;

        public Book()
        {
            Id = Guid.NewGuid();
        }
    }
}
