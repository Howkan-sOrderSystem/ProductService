namespace ProductService.Domain.Contracts.Services;

public interface IProductsService
{
    /// <summary>
    /// Get all products.
    /// </summary>
    public Task<IEnumerable<ProductEntity>> GetAllAsync(
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Get Product by ID.
    /// </summary>
    public Task<ProductEntity?> GetByIdAsync(Guid id,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Add new product.
    /// </summary>
    public Task<ProductEntity?> AddAsync(ProductEntity product, 
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Update product.
    /// </summary>
    public Task<ProductEntity?> UpdateAsync(ProductEntity product, 
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Delete product.
    /// </summary>
    public Task DeleteAsync(Guid id,
        CancellationToken cancellationToken = default);
}