using LibraryAPI.Domain.Entities;
using LibraryAPI.Domain.Repositories;

namespace LibraryAPI.Application.Services.Implementation;

public abstract class CRUDService<TModel, TEntity, TId> : ICRUDService<TModel, TEntity, TId>
    where TModel : class
    where TEntity : BaseEntity<TId>
    where TId : struct
{
    protected readonly IRepository<TEntity,TId> repository;
    //protected readonly IMapper _mapper;

    public CRUDService(IRepository<TEntity, TId> repository)
    {
        this.repository = repository;
    }

    public abstract Task<TEntity> Create(TModel model);

    public virtual async Task<TEntity>? Delete(TId id)
    {
        var entity = await GetById(id);
        if (entity == null)
            return null;

        await repository.SoftDeleteAsync(entity);
        return entity;
    }

    public virtual async Task<IEnumerable<TEntity>>? GetAllAsync()
    {
        return await repository.GetAllAsync();
    }

    public virtual async Task<TEntity>? GetById(TId id)
    {
        return await repository.GetByIdAsync(id);
    }

    public virtual Task<TEntity>? Update(TId id, TModel model)
    {
        throw new NotImplementedException();
    }
}
