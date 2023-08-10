var builder = WebApplication.CreateBuilder(args);

RegisterServices(services: builder.Services);

var app = builder.Build();

Configure(app, env: builder.Environment);

app.Run();

void RegisterServices(IServiceCollection services)
{
    services.AddDatabaseConfiguration(configuration: builder.Configuration);

    services.AddRepositories();

    services.AddServices();

    services.AddEndpointsApiExplorer();

    services.AddSwaggerGen();

    services.AddLoggingConfiguration(hostBuilder: builder.Host);

    services.AddControllers();
}

void Configure(WebApplication app, IHostEnvironment env)
{
    if (!env.IsProduction())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();

    app.MapControllers();
}