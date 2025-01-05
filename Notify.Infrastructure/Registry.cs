using Notify.Application.Orders;
using Notify.Domain.Customers;
using Notify.Domain.Orders;
using Notify.Domain.SeedWork;
using Notify.Infrastructure.Database;
using Notify.Infrastructure.Metrics;
using Notify.Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;

namespace Notify.Infrastructure;

public static class Registry
{
    public static void RegistryInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IOrderRepository, OrderRepository>();
        services.AddScoped<ICustomerRepository, CustomerRepository>();
        services.AddScoped<IProductPriceDataApi, ProductPriceDataApi>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IDomainEventsDispatcher, DomainEventsDispatcher>();
        services.AddScoped<IEntityTracker, EntityTracker>();

        var mongoDbSettings = configuration.GetSection("MongoDB").Get<MongoDbSettings>() ?? throw new InvalidOperationException("MongoDB settings are not configured properly.");
            
        if (string.IsNullOrEmpty(mongoDbSettings.ConnectionString))
            throw new InvalidOperationException("MongoDB connection string is not configured.");
            
        services.AddSingleton<IMongoClient>(_ => new MongoClient(mongoDbSettings.ConnectionString));

        services.AddSingleton(provider =>
        {
            var client = provider.GetRequiredService<IMongoClient>();
            if (string.IsNullOrEmpty(mongoDbSettings.DatabaseName))
                throw new InvalidOperationException("MongoDB database name is not configured.");
            var database = client.GetDatabase(mongoDbSettings.DatabaseName);
            return new OrdersContext(database);
        });

        services.AddSingleton<IMetricsService, MetricsService>();
    }
}