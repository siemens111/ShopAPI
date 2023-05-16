using Microsoft.EntityFrameworkCore;
using ShopApi.Entities;

namespace ShopApi.Db;

class AppDbContext : DbContext
{
    public DbSet<ProductEntity> Products { get; set; }

    public DbSet<CategoryEntity> Categories { get; set; }

    public DbSet<ProductCategoryLinkEntity> ProductCategoryLinks { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
}
