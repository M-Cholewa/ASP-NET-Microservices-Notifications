using Notify.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notify.Domain.Customers.Events
{
    public class CustomerCreatedEvent(Guid customerId) : DomainEventBase
    {
        public Guid CustomerId { get; } = customerId;
    }
}
