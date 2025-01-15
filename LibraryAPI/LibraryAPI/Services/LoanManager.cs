using LibraryAPI.Models;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace LibraryAPI.Services
{
    public class LoanManager
    {
        //Singleton Instance
        private static LoanManager _instance;
        private static ILogger<LoanManager> _logger;
        
        // Lista para gerenciar os empréstimos (substituir por banco de dados em projetos maiores)
        private readonly List<Loan> _Loans;

        private readonly int _LoanLimitDays = 14;

        private LoanManager() { _Loans = new List<Loan>(); }

        public static LoanManager Instance
        {
            get { return _instance ?? new LoanManager(); }
        }

        public string BorrowBook(User user, Book book)
        {
            string result;
            if (book == null && !book.IsAvailable)
                result = $"O livro '{book.Title}' não está disponível no momento";
            else
            {
                var loan = new Loan(book, user, dueDate: DateTime.UtcNow.AddDays(_LoanLimitDays));
                _Loans.Add(loan);
                result = $"O livro '{book.Title}' foi emprestado com sucesso para '{user.Name}' Data de devolução: {loan.DueDate.ToShortDateString()}";
            }

            _logger.LogInformation(message: result);
            return result;
        }

        public string ReturnBook(Book book)
        {
            string result;
            var loan = _Loans.FirstOrDefault(loan => loan.IsActive && loan.Book.Id == book.Id);

            if (loan == null)
                result = $"O livro '{book.Title}' não está associado a nenhum empréstimo ativo.";
            else
            {
                loan.ReturnBook();
                result = $"O livro '{book.Title}' foi devolvido com sucesso.";
            }

            _logger.LogInformation(message: result);
            return result;
        }

        public List<Loan> GetActiveLoans() => _Loans.Where(loan => loan.IsActive).ToList();
    }
}
