﻿namespace Notify.Domain.SeedWork;

public class DomainEventBase : IDomainEvent
{
    public DateTime OccurredOn { get; } = DateTime.Now;
}