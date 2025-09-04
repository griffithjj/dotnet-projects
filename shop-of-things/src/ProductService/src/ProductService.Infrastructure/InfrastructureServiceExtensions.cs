using ProductService.Core.Interfaces;
using ProductService.Core.Services;
using ProductService.Infrastructure.Data;
using ProductService.Infrastructure.Data.Queries;
using ProductService.UseCases.Contributors.List;


namespace ProductService.Infrastructure;

public static class InfrastructureServiceExtensions
{
    public static IServiceCollection AddInfrastructureServices(
        this IServiceCollection services,
        ConfigurationManager config,
        ILogger logger)
    {
        string? connectionString = config.GetConnectionString("SqliteConnection");
        Guard.Against.Null(connectionString);
        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlite(connectionString));

        services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>))
            .AddScoped(typeof(IReadRepository<>), typeof(EfRepository<>))
            .AddScoped<IListContributorsQueryService, ListContributorsQueryService>()
            .AddScoped<IDeleteContributorService, DeleteContributorService>();


        logger.LogInformation("{Project} services registered", "Infrastructure");

        return services;
    }
}