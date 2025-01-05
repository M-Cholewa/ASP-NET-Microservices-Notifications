using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notify.Contracts
{
    public class CustomerCreateRequest(string customerName)
    {
        public string CustomerName { get; } = customerName ?? throw new ArgumentNullException(nameof(customerName));
    }
}
