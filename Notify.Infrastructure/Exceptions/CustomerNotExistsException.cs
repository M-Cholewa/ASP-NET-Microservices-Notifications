using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notify.Infrastructure.Exceptions
{
    /// <summary>
    /// Exception that is thrown when customer does not exist
    /// </summary>
    public class CustomerNotExistsException(Guid customerId) : Exception($"Customer with id {customerId} does not exist")
    {
        public Guid CustomerId { get; } = customerId;
    }
}
