using Notify.Application.Configuration.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notify.Application.Orders.CustomerOrder.Commands
{
    public class CreateCustomerCommand(string customerName) : CommandBase<Guid>
    {
        public string CustomerName { get; } = customerName ?? throw new ArgumentNullException(nameof(customerName));
    }
}
