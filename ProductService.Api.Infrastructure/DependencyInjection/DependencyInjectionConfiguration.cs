using ProductService.Api.Repository;
using ProductService.Application.Services;
using ProductService.Domain.Contracts.Services;

namespace ProductService.Infrastructure.DependencyInjection;

public static class DependencyInjectionConfiguration
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IProductsRepository, ProductsRepository>();

        return services;
    }

    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IProductsService, ProductsService>();
        
        return services;
    }
} 