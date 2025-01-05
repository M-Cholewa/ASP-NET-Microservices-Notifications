using Notify.Application.Configuration.Queries;
using Notify.Contracts.Shared;

namespace Notify.Application.Orders.CustomerOrder.Queries;

public class GetOrderQuery(Guid orderId, Guid customerId) : IQuery<OrderDto>
{
    public Guid OrderId { get; } = orderId;
    public Guid CustomerId { get; } = customerId;
}