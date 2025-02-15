using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using POInterview.Infrastructure.Data;

namespace POInterview.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructureLayer(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnectionString");
        services.AddDbContext<ApplicationDbContext>(options => options.UseSqlite(connectionString), ServiceLifetime.Scoped);
        
        return services;
    }
}
