using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using POInterview.Infrastructure.Data;
using POInterview.Infrastructure.Data.Entities;
using POInterview.Infrastructure.Data.Repositories;
using POInterview.Infrastructure.MessageBrokers;

namespace POInterview.Infrastructure.Configuration;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructureLayer(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnectionString");
        services.AddDbContext<ApplicationDbContext>(options => options.UseSqlite(connectionString), ServiceLifetime.Scoped);

        // Add repositories
        services.AddScoped<IRepository<Resource>, ResourceRepository>();
        services.AddScoped<IRepository<Booking>, BookingRepository>();
        services.AddScoped<IMessagePublisher, EmailPublisher>();

        return services;
    }
}
