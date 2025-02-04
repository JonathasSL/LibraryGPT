namespace LibraryAPI.Application.Models
{
    public class Loan : BaseModel<Guid>
    {
        public DateTime LoanDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public DateTime DueDate { get; set; }
        public Guid BookId { get; set; }
        public Guid UserId { get; set; }
        public bool IsActive { get; set; }
    }
}
