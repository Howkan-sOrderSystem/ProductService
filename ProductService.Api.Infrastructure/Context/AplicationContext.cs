namespace ProductService.Api.Model.Context;

public class AplicationContext : DbContext
{
    public DbSet<ProductEntity> Products { get; set; }

    public AplicationContext(DbContextOptions<AplicationContext> options) : base(options) { }
}