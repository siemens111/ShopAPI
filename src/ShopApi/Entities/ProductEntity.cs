using ShopApi.Abstractions;

namespace ShopApi.Entities;

public class ProductEntity : IEntity
{
    public int Id { get; set; }

    public string Name { get; set; }

    public IEnumerable<ProductCategoryLinkEntity> CategoryLinks { get; set; }
}