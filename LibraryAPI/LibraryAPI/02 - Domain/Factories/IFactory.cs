using LibraryAPI.Application.Models;

namespace LibraryAPI.Domain.Factories;

public interface IFactory<TModel,TEntity> 
    where TEntity : class
    where TModel : class
{
    Task<TEntity> CreateAsync(TModel model);
}
