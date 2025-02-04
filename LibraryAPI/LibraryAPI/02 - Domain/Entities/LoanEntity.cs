namespace LibraryAPI.Domain.Entities
{
    public class LoanEntity : BaseEntity<Guid>
    {
        public DateTime LoanDate { get; private set; }
        public DateTime? ReturnDate { get; private set; }
        public DateTime DueDate { get; private set; }
        public BookEntity Book { get; private set; }
        public Guid BookId { get; private set; }
        public UserEntity LoanTo { get; private set; }
        public Guid LoanToId { get; private set; }
        public bool IsActive { get { return !ReturnDate.HasValue; } }
        
        //Construtor para o EF
        public LoanEntity() { }

        public LoanEntity(DateTime dueDate, BookEntity book, UserEntity user)
        {
            LoanDate = DateTime.UtcNow;
            DueDate = dueDate;
            Book = book;
            BookId = book.Id;
            LoanTo = user;
            LoanToId = user.Id;
        }

        public void ReturnBook()
        {
            ReturnDate = DateTime.UtcNow;
            Book.ReturnBook();
        }
    }
}
