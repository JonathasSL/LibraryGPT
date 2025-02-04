namespace LibraryAPI.Application.Services
{
    public interface ICRUDService<TModel, TEntity, TId> 
        where TModel : class 
        where TEntity : class
    {
        Task<TEntity> Create(TModel model);
        Task<IEnumerable<TEntity>>? GetAllAsync();
        Task<TEntity>? GetById(TId id);
        Task<TEntity>? Update(TId id, TModel model);
        Task<TEntity>? Delete(TId id);
    }
}
