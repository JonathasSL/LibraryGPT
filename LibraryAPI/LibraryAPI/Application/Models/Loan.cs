namespace LibraryAPI.Application.Models
{
    public class Loan
    {
        public Guid Id { get; set; }
        public DateTime LoanDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public DateTime DueDate { get; set; }
        public Book Book { get; set; }
        public User User { get; set; }
        public bool IsActive { get { return !ReturnDate.HasValue; } }

        /*
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
        */
    }
}
