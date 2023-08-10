namespace ProductService.Api.Configurations;

public static class LoggingConfigurations
{
    public static void AddLoggingConfiguration(
        this IServiceCollection services, 
         ConfigureHostBuilder hostBuilder)
    {
        hostBuilder.UseSerilog(
            configureLogger: (context, services, configuration) =>
            configuration.ReadFrom.Configuration(configuration: context.Configuration)
            .ReadFrom.Services(services));
    }
}