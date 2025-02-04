using LibraryAPI.Application.Services.Implementation;
using LibraryAPI.Infrasctructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);
var logger = builder.Services.BuildServiceProvider().GetRequiredService<ILogger<Program>>();
// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(options => options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.RegisterAllScopedDependencies(logger);

builder.Services.AddSingleton<LoanManager>();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    dbContext.Database.Migrate();
    //dbContext.Database.EnsureCreated();
    if (dbContext.Database.HasPendingModelChanges())
        logger.LogCritical("[dbContext] Existem mudan�as pendentes no modelo");
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
                    logger.LogError(e.Message);
                    throw;
                }
            }else
                logger.LogWarning($"[DI] Implementa��o n�o encontrada para: {interfaceType}, {implementationType}");
        }
    }
}

