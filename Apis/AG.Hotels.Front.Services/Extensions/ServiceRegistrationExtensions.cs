using AG.Hotels.Front.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace AG.Hotels.Front.Services.Extensions;

public static class ServiceRegistrationExtensions
{
    public static IServiceCollection AddHotelFrontServices(this IServiceCollection services) 
    {
        services.AddScoped<IHotelsService, HotelsService>();
        services.AddScoped<IRoomsService, RoomsService>();

        return services;
    }
}