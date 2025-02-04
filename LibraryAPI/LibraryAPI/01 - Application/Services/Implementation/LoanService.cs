using LibraryAPI.Application.Models;
using LibraryAPI.Domain.Entities;
using LibraryAPI.Domain.Repositories;

namespace LibraryAPI.Application.Services.Implementation;

public class LoanService : CRUDService<Loan, LoanEntity, Guid>, ILoanService
{
    private readonly IBookService _bookService;
    private readonly IUserService _userService;
    private readonly ILoanRepository _repository;
    private readonly ILoanManager _loanManager;

    public LoanService(IBookService bookService, IUserService userService, ILoanRepository repository, ILoanManager loanManager) : base(repository)
    {
        _bookService = bookService;
        _userService = userService;
        _repository = repository;
        _loanManager = loanManager;
    }

    public async Task<IEnumerable<LoanEntity>> GetByUser(Guid id)
    {
        if (id == Guid.Empty)
            return null;

        return await _repository.GetByUser(id);
    }

    public override async Task<LoanEntity> Create(Loan model)
    {
        if (model != null)
        {
            var book = await _bookService.GetById(model.BookId);
            var user = await _userService.GetById(model.UserId);

            if (book == null || user == null)
                return null;

            return await _loanManager.BorrowBook(user, book);
        }
        return null;
    }
    
    public async Task<LoanEntity> ReturnCopy(Guid id)
    {
        var loanEntity = await _repository.GetByIdAsync(id);
        
        if (loanEntity == null || !loanEntity.IsActive)
            return null;

        loanEntity.ReturnBook();

        return await _repository.Update(loanEntity);
    }
}
