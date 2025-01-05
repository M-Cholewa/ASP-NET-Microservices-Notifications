using Ardalis.GuardClauses;
using Notify.Domain.Customers;
using Notify.Infrastructure.Database;
using Notify.Infrastructure.Exceptions;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notify.Infrastructure.Repositories
{
    internal class CustomerRepository(OrdersContext context, IEntityTracker entityTracker) : ICustomerRepository
    {

        private readonly OrdersContext _context = context ?? throw new ArgumentNullException(nameof(context));
        private readonly IEntityTracker _entityTracker = entityTracker ?? throw new ArgumentNullException(nameof(entityTracker));


        public void Add(Customer customer)
        {
            Guard.Against.Null(customer, nameof(customer), "Customer is required.");
            _entityTracker.Track(customer);
        }

        public async Task<Customer> GetByIdAsync(Guid id)
        {
            var customer = _entityTracker.Find<Customer>(id);
            if (customer != null) return customer;

            customer = await _context.Customers.Find(c => c.Id == id).FirstOrDefaultAsync();

            if (customer == null)
            {
                throw new CustomerNotExistsException(id);
            }

            _entityTracker.Track(customer);

            return customer;
        }

    }
}
