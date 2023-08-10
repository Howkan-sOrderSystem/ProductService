namespace ProductService.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IProductsService _productService;

    public ProductsController(IProductsService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    public async Task<ActionResult<List<ProductEntity>>> GetProductsAsync()
    {
        var products = await _productService.GetAllAsync();

        return Ok(products ?? Enumerable.Empty<ProductEntity>());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ProductEntity>> GetProductsByIdAsync(Guid id)
    {
        var products = await _productService.GetByIdAsync(id);

        if (products is null)
        {
            return NotFound();
        }

        return Ok(products);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ProductEntity>> DeleteProductsAsync(Guid id)
    {
        var products = await _productService.GetByIdAsync(id);

        if (products is null)
        {
            return NotFound();
        }

        await _productService.DeleteAsync(products.Id);

        return NoContent();
    }

    [HttpPost]
    public async Task<IActionResult> CreateProduct(ProductEntity product)
    {
        await _productService.AddAsync(product);

        return CreatedAtAction(nameof(GetProductsAsync), new { id = product.Id }, product);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateProducts(ProductEntity product)
    {
        var findedProduct = await _productService.UpdateAsync(product);

        if (findedProduct is null)
        {
            return NotFound();
        }

        return Ok(findedProduct);
    }
}