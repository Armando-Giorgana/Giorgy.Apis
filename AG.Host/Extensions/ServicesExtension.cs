using AG.Hotels.Front.Api.Extensions;

namespace AG.Apis.Extensions;

public static class ServicesExtension
{
    public static IServiceCollection AddApis(this WebApplicationBuilder builder)
    {
        var loggerFactory = builder.Services.BuildServiceProvider().GetRequiredService<ILoggerFactory>();
        var logger = loggerFactory.CreateLogger(typeof(ServicesExtension));
        
        logger.LogInformation("Starting to register APIs...");
        
        // Register APIs by Modules
        builder.Services.AddHotelFrontApi();

        logger.LogInformation("APIs have been registered successfully.");
        
        return builder.Services;
    }
}