using VolvoTrucks.Core.Entities;

namespace VolvoTrucks.Application;

public interface ITrucksContext
{
    public TEntity FindOrFail<TEntity>(params object?[] keyValues)
        where TEntity : class;
    public TEntity? Find<TEntity>(params object?[]? keyValues)
        where TEntity : class;
    public void Save();
    public TEntity AddEntity<TEntity>(TEntity entity) where TEntity : BaseEntity;
    public void RemoveEntity(object entity);
    public IQueryable<TEntity> Query<TEntity>() where TEntity : BaseEntity;
}