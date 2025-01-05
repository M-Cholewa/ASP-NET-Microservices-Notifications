using AutoMapper;
using Notify.Application.Configuration.Queries;
using Notify.Contracts.Shared;
using Notify.Domain.Customers;
using Notify.Domain.Orders;

namespace Notify.Application.Orders.CustomerOrder.Queries
{
    public class GetCustomerQueryHandler(ICustomerRepository customerRepository, IMapper mapper)
        : IQueryHandler<GetCustomerQuery, CustomerDto>
    {
        private readonly IMapper _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        private readonly ICustomerRepository _customerRepository = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));

        public async Task<CustomerDto> Handle(GetCustomerQuery request, CancellationToken cancellationToken)
        {
            var customer = await _customerRepository.GetByIdAsync(request.CustomerId);
            return _mapper.Map<CustomerDto>(customer);
        }
    }
}
