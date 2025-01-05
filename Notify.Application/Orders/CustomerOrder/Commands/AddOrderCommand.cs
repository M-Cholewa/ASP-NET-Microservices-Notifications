using Notify.Application.Configuration.Commands;
using Notify.Contracts.Shared;

namespace Notify.Application.Orders.CustomerOrder.Commands;

public class AddOrderCommand(
    Guid customerId,
    List<ProductDto> products) : CommandBase<Guid>
{
    public Guid CustomerId { get; } = customerId;

    public List<ProductDto> Products { get; } = products ?? throw new ArgumentNullException(nameof(products));
}