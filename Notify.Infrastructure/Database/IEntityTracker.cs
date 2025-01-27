using Notify.Domain.SeedWork;

namespace Notify.Infrastructure.Database;

internal interface IEntityTracker
{
    void Clear();

    IReadOnlyList<Entity> Get();
    T? Find<T>(Guid id) where T : Entity;

    void Track<T>(T entity) where T : Entity; 
}