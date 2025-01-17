using LibraryAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Security.Principal;

namespace LibraryAPI.Infrasctructure.Data;

public class ApplicationDbContext : DbContext
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var types = Assembly.GetExecutingAssembly().GetTypes();
        var entities = types.Where(type => type.IsClass && !type.IsAbstract && type.Name.EndsWith("Entity"));

        foreach (var entityType in entities)
        {
            var tableName = entityType.Name.Replace("Entity","");
            modelBuilder.Entity(entityType).ToTable(tableName);
            /*
            var method = typeof(ModelBuilder)
                .GetMethod("Entity", new Type[] { });

            var generic = method.MakeGenericMethod(entityType);
            generic.Invoke(modelBuilder, null);
            */
        }

        base.OnModelCreating(modelBuilder);
    }
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }

    //public DbSet<BookEntity> Books { get; set; }
}
