using LibraryAPI.Domain.Enumerators;

namespace LibraryAPI.Domain.Entities
{
    public class BookEntity : BaseEntity<Guid>
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public BookGenres? Genre { get; set; }
        public bool IsAvailable { get; set; } = true;
        public string CopyId { get; set; }


        public void SetAsBorrowed() => IsAvailable = false;

        public void ReturnBook() => IsAvailable = true;

        public BookEntity(string title, string author, string copyId)
        {
            Id = Guid.NewGuid();
            Title = title;
            Author = author;
            CopyId = copyId;
        }
    }
}
