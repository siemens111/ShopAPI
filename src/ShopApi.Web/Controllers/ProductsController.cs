using JsonApiSerializer.JsonApi;
using Microsoft.AspNetCore.Mvc;
using ShopApi.Abstractions;
using ShopApi.Entities;

namespace ShopApi.Web.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IProductRepository _productRepository;

    public ProductsController(IProductRepository productRepository) => _productRepository = productRepository;

    [HttpGet]
    [Route("with-category")]
    [Produces("application/vnd.api+json")]
    [ProducesResponseType(typeof(DocumentRoot<IEnumerable<ProductEntity>>), 200)]
    public async Task<IActionResult> GetProductsWithCategories()
    {
        var productEntities = await _productRepository.GetProductsWithCategoryAsync();
        var result = new DocumentRoot<IEnumerable<ProductEntity>>();
        result.Data = productEntities;
        return Ok(result);
    }
}
