using Humanizer;
using LibraryAPI.Domain.Entities;
using LibraryAPI.Domain.Factories;
using LibraryAPI.Domain.Factories.Implementation;
using LibraryAPI.Domain.Repositories;
using LibraryAPI.Domain.Repositories.Implementation;

namespace LibraryAPI.Application.Services.Implementation;

public class LoanManager : ILoanManager
{
    //Singleton Instance
    private static LoanManager _instance;
    private static readonly object _lock = new object();

    private readonly ILogger<LoanManager> _logger;
    private readonly IServiceProvider _serviceProvider;
    private readonly int _LoanLimitDays = 14;

    public LoanManager(IServiceProvider serviceProvider, ILogger<LoanManager> logger)
    {
        _serviceProvider = serviceProvider;
        _logger = logger;
    }

    public static LoanManager Instance(ILogger<LoanManager> logger, IServiceProvider serviceProvider)
    {
        if (_instance == null)
        {
            lock (_lock)
            {
                if (_instance == null)
                    _instance = new LoanManager(serviceProvider, logger);
            }
        }
        return _instance;
    }

    public async Task<LoanEntity> BorrowBook(UserEntity user, BookEntity book)
    {
        if (user == null) throw new ArgumentNullException(nameof(user));
        if (book == null) throw new ArgumentNullException(nameof(book));

        if (!book.IsAvailable)
        {
            _logger.LogInformation($"O livro '{book.Title}' não está disponível no momento");
            return null;
        }

        try
        {
            LoanEntity inMemoryEntity;
            using (var scope = _serviceProvider.CreateScope())
            {
                var loanFactory = scope.ServiceProvider.GetRequiredService<ILoanFactory>();
                inMemoryEntity = await loanFactory.CreateAsync(DateTime.UtcNow.AddDays(_LoanLimitDays), book, user);
            }

            LoanEntity savedEntity;
            using (var scope = _serviceProvider.CreateScope())
            {
                var loanRepository = scope.ServiceProvider.GetRequiredService<ILoanRepository>();
                savedEntity = await loanRepository.CreateAsync(inMemoryEntity);
            }

            _logger.LogInformation($"O livro '{book.Title}' foi emprestado com sucesso para '{user.Name}' Data de devolução: {savedEntity.DueDate.Humanize(utcDate: true)}");
            return savedEntity;
        }
        catch (Exception e)
        {
            _logger.LogError(message: $"Ocorreu um erro ao tentar emprestar o livro '{book.Title}' para '{user.Name}'", e);
            throw;
        }

        return null;
    }

    public async Task<LoanEntity> ReturnBook(BookEntity book)
    {
        string result;
        if (book == null) throw new ArgumentNullException(nameof(book));

        LoanEntity loan = null;
        using (var scope = _serviceProvider.CreateScope())
        {
            var loanRepository = scope.ServiceProvider.GetRequiredService<ILoanRepository>();
            loan = (await loanRepository.GetByBook(book.CopyId)).ToList().FirstOrDefault();

            if (loan == null)
            {
                _logger.LogInformation($"O livro '{book.Title}' não está associado a nenhum empréstimo ativo.");
                return null;
            }
            try
            {
                loan.ReturnBook();
                loan = await loanRepository.Update(loan);
                result = $"O livro '{book.Title}' foi devolvido com sucesso.";
            }
            catch (Exception e)
            {
                _logger.LogError($"Não foi possível retornar o livro: {book.Title}");
                throw;
            }
        }

        _logger.LogInformation(message: result);
        return loan;
    }

    public async Task<IEnumerable<LoanEntity>> GetActiveLoans()
    {
        using (var scope = _serviceProvider.CreateScope())
        {
            var loanRepository = scope.ServiceProvider.GetRequiredService<ILoanRepository>();
            return (await loanRepository.GetAllAsync()).Where(loan => loan.IsActive);
        }
    }
}
