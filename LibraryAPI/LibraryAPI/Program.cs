using LibraryAPI.Application.Services.Implementation;
using LibraryAPI.Infrasctructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
var logger = builder.Services.BuildServiceProvider().GetRequiredService<ILogger<Program>>();
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.RegisterAllScopedDependencies(logger);

builder.Services.AddSingleton<LoanManager>();
//builder.Services.AddTransient<IFactory<Book>, BookFactory>();
//builder.Services.AddTransient<IFactory<User>, UserFactory>();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));
    //.LogTo(Console.WriteLine, LogLevel.Information));

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    //dbContext.Database.Migrate();
    dbContext.Database.EnsureCreated();
}

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

public static class ServiceCollectionExtensions
{
    public static void RegisterAllScopedDependencies(this IServiceCollection services, ILogger logger)
    {
        var assembly = Assembly.GetExecutingAssembly();
        
        var types = assembly.GetTypes();
        var interfaces = types.Where(type => type.IsInterface && type.Name.StartsWith("I")).ToList();

        foreach (var interfaceType in interfaces)
        {
            var implementationType = types.FirstOrDefault(type => type.IsClass && !type.IsAbstract && type.Name.Equals(interfaceType.Name.Substring(1)));

            if (implementationType != null && !services.Any(service => service.ServiceType == implementationType))
            {
                try
                {
                    logger.LogInformation($"[DI] Registrando: {interfaceType}, {implementationType}");
                    services.AddScoped(interfaceType, implementationType);
                }
                catch (Exception e)
                {
                    logger.LogCritical(e.Message);
                    throw;
                }
            }else
                logger.LogWarning($"[DI] Implementação não encontrada para: {interfaceType}, {implementationType}");
        }
    }
}


/*

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

var bookFactory = new BookFactory("Livro de Exemplo", "Autor Exemplo");
var userFactory = new UserFactory("Nome de exemplo", "Email exemplo");

// Criar um livro usando a fábrica
var book1 = bookFactory.Create();
Console.WriteLine($"Livro Criado: {book.Title} - {book.Author}");

// Criar um usuário usando a fábrica
var user1 = userFactory.Create();
Console.WriteLine($"Usuário Criado: {user.Name} - {user.Email}");

//EndFactory
*/