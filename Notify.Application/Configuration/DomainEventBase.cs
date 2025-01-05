using Notify.Domain.SeedWork;

namespace Notify.Application.Configuration;

public class DomainEventBase : IDomainEvent
{
    public DateTime OccurredOn { get; } = DateTime.Now;
}