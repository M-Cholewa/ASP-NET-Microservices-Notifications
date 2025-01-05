using AutoMapper;
using Notify.Application.Configuration.Commands;
using Notify.Domain.Customers;
using Notify.Domain.Orders;
using Notify.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notify.Application.Orders.CustomerOrder.Commands
{
    public class CreateCustomerCommandHandler(
    ICustomerRepository customerRepository,
    IUnitOfWork unitOfWork)
    : ICommandHandler<CreateCustomerCommand, Guid>
    {
        private readonly ICustomerRepository _customerRepository = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
        private readonly IUnitOfWork _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));

        public async Task<Guid> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = Customer.Create(request.CustomerName);

            _customerRepository.Add(customer);
            
            await _unitOfWork.CommitAsync(cancellationToken);

            return customer.Id;
        }

    }
}
