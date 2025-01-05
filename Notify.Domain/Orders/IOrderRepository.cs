namespace Notify.Domain.Orders;

public interface IOrderRepository
{
    Task<Order> GetByIdAsync(Guid id);

    void Add(Order order);
}