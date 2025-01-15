using LibraryAPI.Data;
using LibraryAPI.Factories.Implementation;
using LibraryAPI.Models;
using LibraryAPI.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<LibraryContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


//begin manager
var loanManager = LoanManager.Instance;
//var logger = new Logger<>();

var user = new User()
{
    Name = "João",
    Email = "joao@example.com"
};

var book = new Book()
{
    Title = "Clean Code",
    Author = "Rober C. Marting",
    IsAvailable = true,
};

var borrowResult = loanManager.BorrowBook(user, book);
Console.WriteLine(borrowResult);

var borrowAgain = loanManager.BorrowBook(user,book);
Console.WriteLine(borrowAgain);

var returnResult = loanManager.ReturnBook(book);
Console.WriteLine(returnResult);
//End manager


//beginFactory

var bookFactory = new BookFactory();
var userFactory = new UserFactory();

// Criar um livro usando a fábrica
var book1 = bookFactory.Create();
book1.Title = "Livro de Exemplo";
book1.Author = "Autor Exemplo";
Console.WriteLine($"Livro Criado: {book.Title} - {book.Author}");

// Criar um usuário usando a fábrica
var user1 = userFactory.Create();
user1.Name = "Nome de exemplo";
user1.Email = "Email exemplo";
Console.WriteLine($"Usuário Criado: {user.Name} - {user.Email}");

//EndFactory