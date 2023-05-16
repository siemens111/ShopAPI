using ShopApi.Abstractions;

namespace ShopApi.Entities;

public class CategoryEntity : IEntity
{
    public int Id { get; set; }

    public string Name { get; set; }

    public IEnumerable<ProductCategoryLinkEntity> ProductLinks { get; set; }
}