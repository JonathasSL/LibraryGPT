namespace LibraryAPI.Models
{
    public class Loan 
    {
        public Guid Id { get; private set; }
        public DateTime LoanDate { get; private set; }
        public DateTime? ReturnDate { get; private set; }
        public DateTime DueDate { get; private set; }
        public Book Book { get; private set; }
        public User User { get; private set; }
        public bool IsActive { get { return !ReturnDate.HasValue; } }


        public Loan(Book book, User user, DateTime dueDate)
        {
            Id = Guid.NewGuid();
            LoanDate = DateTime.Now;
            
            Book = book;
            User = user;
            DueDate = dueDate;

            Book.SetAsBorrowed();
        }

        public void ReturnBook(DateTime? returnDate = null)
        {
            ReturnDate = returnDate ?? DateTime.UtcNow;
            Book.ReturnBook();
        }

    }
}
