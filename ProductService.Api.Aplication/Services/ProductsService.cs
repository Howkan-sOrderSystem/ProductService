namespace ProductService.Application.Services;

public sealed class ProductsService : IProductsService
{
    private readonly IProductsRepository _repository;

    public ProductsService(IProductsRepository repository)
    {
        _repository = repository;
    }

    public async Task<ProductEntity?> AddAsync(
        ProductEntity product,
        CancellationToken cancellationToken = default) =>
        await _repository.AddAsync(product, cancellationToken);

    public async Task DeleteAsync(Guid id, 
        CancellationToken cancellationToken = default) => 
        await _repository.DeleteAsync(id, cancellationToken);

    public async Task<ProductEntity?> GetByIdAsync(Guid id, 
        CancellationToken cancellationToken = default) => 
        await _repository.FirstOrDefaultAsync(id, cancellationToken);

    public async Task<IEnumerable<ProductEntity>> GetAllAsync(
        CancellationToken cancellationToken = default) => 
        await _repository.GetAllAsync(cancellationToken);

    public async Task<ProductEntity?> UpdateAsync(
        ProductEntity product,
        CancellationToken cancellationToken = default) => 
        await _repository.UpdateAsync(product, cancellationToken);
}