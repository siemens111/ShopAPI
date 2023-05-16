using ShopApi.Abstractions;

namespace ShopApi.Entities;

public class ProductCategoryLinkEntity : IEntity
{

    public int Id { get; set; }

    public ProductEntity Product { get; set; }

    public CategoryEntity Category { get; set; }
}