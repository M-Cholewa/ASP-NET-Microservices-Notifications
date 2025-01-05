using Notify.Domain.Products;

namespace Notify.Application.Orders;

public interface IProductPriceDataApi
{
    Task<List<ProductPriceData>> Get();
}