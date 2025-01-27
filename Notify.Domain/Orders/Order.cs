﻿using Notify.Domain.Orders.Events;
using Notify.Domain.Orders.Rules;
using Notify.Domain.Products;
using Notify.Domain.SeedWork;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Notify.Domain.Orders;

public class Order : Entity, IAggregateRoot
{
    [BsonRepresentation(BsonType.String)]
    public Guid CustomerId { get; private set; }

    public List<OrderProduct> Products { get; private set; }

    private Order(Guid id, Guid customerId, List<OrderProduct> orderProducts) : base(id)
    {
        CustomerId = customerId;
        Products = orderProducts ?? throw new ArgumentNullException(nameof(orderProducts));
    }
    
    private Order(Guid customerId, List<OrderProduct> orderProducts) : base(Guid.NewGuid())
    {
        CustomerId = customerId;
        Products = orderProducts ?? throw new ArgumentNullException(nameof(orderProducts));

        AddDomainEvent(new OrderAddedEvent(Id, customerId));
    }

    public static Order Create(
        Guid customerId,
        List<OrderProductData> orderProductsData,
        List<ProductPriceData> allProductPriceData)
    {
        List<OrderProduct> orderProducts = [];

        foreach (var orderProductData in orderProductsData)
        {
            var productPriceData = allProductPriceData.First(x => x.ProductId == orderProductData.ProductId);

            var orderProduct = OrderProduct.Create(orderProductData.ProductId, orderProductData.Quantity, productPriceData.UnitPrice);

            orderProducts.Add(orderProduct);
        }

        CheckRule(new OrderMustHaveAtLeastOneProductRule(orderProducts));
        CheckRule(new OrderMaxCostRule(orderProducts));

        return new Order(customerId, orderProducts);
    }
}