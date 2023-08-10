namespace ProductService.Infrastructure.DependencyInjection;

public static class DatabaseConfiguration
{
    public static void AddDatabaseConfiguration(
        this IServiceCollection services, 
        IConfiguration configuration)
    {
        services.AddScoped<DbContext, AplicationContext>();

        services.AddDbContext<AplicationContext>(options => options.UseNpgsql(
            connectionString: configuration.GetConnectionString(name: "DbConnection")));
    }
}