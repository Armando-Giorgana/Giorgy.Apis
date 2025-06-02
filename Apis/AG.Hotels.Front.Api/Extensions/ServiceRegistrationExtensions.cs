using AG.Hotels.Front.Api.Endpoints;
using AG.Hotels.Front.Services.Extensions;
using AG.Repositories.SqlServer.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace AG.Hotels.Front.Api.Extensions;

public static class ServiceRegistrationExtensions
{
    public static IServiceCollection AddHotelFrontApi(this IServiceCollection services)
    {
        services.AddHotelFrontRepositories();
        services.AddHotelFrontServices();
        
        // Register endpoints
        services.AddScoped<IHotelsEndpoint, HotelsEndpoint>();
        services.AddScoped<IRoomsEndpoint, RoomsEndpoint>();

        return services;
    }
}