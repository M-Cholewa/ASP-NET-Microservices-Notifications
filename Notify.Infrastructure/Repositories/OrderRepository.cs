using Ardalis.GuardClauses;
using Notify.Domain.Orders;
using Notify.Infrastructure.Database;
using Notify.Infrastructure.Exceptions;
using MongoDB.Driver;

namespace Notify.Infrastructure.Repositories;

internal class OrderRepository(OrdersContext context, IEntityTracker entityTracker) : IOrderRepository
{
    private readonly OrdersContext _context = context ?? throw new ArgumentNullException(nameof(context));
    private readonly IEntityTracker _entityTracker = entityTracker ?? throw new ArgumentNullException(nameof(entityTracker));

    public void Add(Order order)
    {
        Guard.Against.Null(order, nameof(order), "Order is required.");
        _entityTracker.Track(order);
    }

    public async Task<Order> GetByIdAsync(Guid id)
    {
        var order = _entityTracker.Find<Order>(id);
        if (order != null) return order;
            
        order = await _context.Orders.Find(c => c.Id == id).FirstOrDefaultAsync();
            
        if (order == null)
        {
            throw new OrderNotExistsException(id);
        }
        _entityTracker.Track(order);

        return order;
    }
}