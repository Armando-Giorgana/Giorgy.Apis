using Microsoft.Extensions.DependencyInjection;

namespace AG.Repositories.SqlServer.Extensions;

public static class ServiceRegistrationExtensions
{
    public static IServiceCollection AddHotelFrontRepositories(this IServiceCollection services)
    {
        // TODO: Register the Database Connection with RepoDB
        
        services.AddSingleton<IDataStoreMockup, HotelFrontDataStoreMockup>();
        
        services.AddScoped<IHotelsRepository, HotelsRepository>();
        services.AddScoped<IRoomsRepository, RoomsRepository>();
        
        return services;
    }
}