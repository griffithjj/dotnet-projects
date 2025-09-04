using OrderService.Core.Interfaces;
using OrderService.Core.Services;
using OrderService.Infrastructure.Data;
using OrderService.Infrastructure.Data.Queries;
using OrderService.UseCases.Contributors.List;


namespace OrderService.Infrastructure;

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