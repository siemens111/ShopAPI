using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ShopApi.Abstractions;
using ShopApi.Db.Repositories;

namespace ShopApi.Db;

public static class Entry
{
    public static IServiceCollection AddPostgresStorage(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<AppDbContext>(options => options.UseNpgsql(connectionString));
        services.AddScoped<IProductRepository, ProductRepository>();
        return services;
    }
}