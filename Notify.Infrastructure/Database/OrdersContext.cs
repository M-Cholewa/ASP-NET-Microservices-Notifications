﻿using Ardalis.GuardClauses;
using Notify.Domain.Customers;
using Notify.Domain.Orders;
using MongoDB.Driver;

namespace Notify.Infrastructure.Database;

public sealed class OrdersContext(IMongoDatabase database)
{
    public IMongoDatabase Database { get; } = Guard.Against.Null(database, nameof(database));
    public IMongoCollection<Order> Orders => Database.GetCollection<Order>("Orders");
    public IMongoCollection<Customer> Customers => Database.GetCollection<Customer>("Customers");
}