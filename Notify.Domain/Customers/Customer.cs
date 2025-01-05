using Notify.Domain.Customers.Events;
using Notify.Domain.Customers.Rules;
using Notify.Domain.Orders.Events;
using Notify.Domain.SeedWork;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Notify.Domain.Customers;

public class Customer : Entity, IAggregateRoot
{
    [BsonRepresentation(BsonType.String)]
    public string Name { get; private set; }    
        
    public static Customer Create(string name)
    {
        CheckRule(new CustomerNameNotEmptyOnlyLettersRule(name));

        return new(name);
    }

    private Customer(string name) : base(Guid.NewGuid())
    {
        Name = name ?? throw new ArgumentNullException(nameof(name));

        AddDomainEvent(new CustomerCreatedEvent(Id));
    }
}