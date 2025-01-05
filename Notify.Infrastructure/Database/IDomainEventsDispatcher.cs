using Notify.Domain.SeedWork;

namespace Notify.Infrastructure.Database;

internal interface IDomainEventsDispatcher
{
    Task DispatchEventsAsync(IEnumerable<Entity> entities);
}