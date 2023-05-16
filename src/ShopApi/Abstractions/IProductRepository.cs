using ShopApi.Entities;

namespace ShopApi.Abstractions;

public interface IProductRepository
{
    Task<IEnumerable<ProductEntity>> GetProductsWithCategoryAsync();
}