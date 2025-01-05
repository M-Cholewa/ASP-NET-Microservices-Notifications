using MediatR;

namespace Notify.Domain.SeedWork;

public interface IDomainEvent : INotification
{
    DateTime OccurredOn { get; }
}