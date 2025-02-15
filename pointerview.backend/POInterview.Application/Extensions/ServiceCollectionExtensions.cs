using Microsoft.Extensions.DependencyInjection;
using POInterview.Application.Contracts;
using POInterview.Application.Services;

namespace POInterview.Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplicationLayer(this IServiceCollection services)
    {
        services.AddScoped<IResourceService, ResourceService>();
        services.AddScoped<IBookingService, BookingService>();

        return services;
    }
}
