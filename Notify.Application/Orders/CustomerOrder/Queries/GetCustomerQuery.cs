using Notify.Application.Configuration.Queries;
using Notify.Contracts.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notify.Application.Orders.CustomerOrder.Queries
{
    public class GetCustomerQuery(Guid customerId) : IQuery<CustomerDto>
    {
        public Guid CustomerId { get; } = customerId;
    }
}
