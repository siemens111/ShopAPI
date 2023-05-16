using Microsoft.EntityFrameworkCore;
using ShopApi.Abstractions;
using ShopApi.Entities;

namespace ShopApi.Db.Repositories;

class ProductRepository : IProductRepository
{
    private readonly AppDbContext _context;

    public ProductRepository(AppDbContext context) => _context = context;

    public async Task<IEnumerable<ProductEntity>> GetProductsWithCategoryAsync()
    {
        var productEntities = await _context.Products
            .Include(p => p.CategoryLinks)
            .ThenInclude(l => l.Category)
            .OrderBy(p => p.Name)
            .AsNoTracking()
            .ToListAsync();

        return productEntities;
    }
}