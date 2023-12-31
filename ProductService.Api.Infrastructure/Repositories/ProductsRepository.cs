﻿namespace ProductService.Api.Repository;

public sealed class ProductsRepository : IProductsRepository
{
    private readonly AplicationContext _context;

    public ProductsRepository(AplicationContext aplicationContext)
    {
        _context = aplicationContext;
    }

    public async Task<IEnumerable<ProductEntity>> GetAllAsync(
        CancellationToken cancellationToken = default)
    {
        return await _context.Products.ToListAsync(cancellationToken);
    }

    public async Task<ProductEntity?> FirstOrDefaultAsync(Guid id,
        CancellationToken cancellationToken = default)
    {
        return await _context.Products.FirstOrDefaultAsync(p => p.Id == id, cancellationToken: cancellationToken);
    }

    public async Task<ProductEntity?> AddAsync(ProductEntity product,
        CancellationToken cancellationToken = default)
    {
        await _context.Products.AddAsync(product, cancellationToken);

        await _context.SaveChangesAsync(cancellationToken);

        return product;
    }

    public async Task DeleteAsync(Guid id,
        CancellationToken cancellationToken = default)
    {
        var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id, cancellationToken);

        if (product is null)
        {
            return;
        }

        _context.Products.Remove(product);

        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<ProductEntity?> UpdateAsync(ProductEntity product,
        CancellationToken cancellationToken = default)
    {
        var findedProduct = await _context.Products.FirstOrDefaultAsync(p => p.Id == product.Id, cancellationToken);

        if (findedProduct is null)
        {
            return null;
        }

        findedProduct.Name = product.Name;
        findedProduct.Price = product.Price;
        findedProduct.Description = product.Description;

        await _context.SaveChangesAsync(cancellationToken);

        return findedProduct;
    }
}