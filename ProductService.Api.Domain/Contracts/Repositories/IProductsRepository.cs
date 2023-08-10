namespace ProductService.Domain.Contracts.Repositories;

public interface IProductsRepository
{
    /// <summary>
    /// Get all products.
    /// </summary>
    public Task<IEnumerable<ProductEntity>> GetAllAsync(
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Get product by ID.
    /// </summary>
    public Task<ProductEntity?> FirstOrDefaultAsync(Guid id,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Add new product.
    /// </summary>
    public Task<ProductEntity?> AddAsync(
        ProductEntity product,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Update product by ID.
    /// </summary>
    public Task<ProductEntity?> UpdateAsync(
        ProductEntity product, 
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Delete product by ID.
    /// </summary>
    public Task DeleteAsync(Guid id, 
        CancellationToken cancellationToken = default);
}