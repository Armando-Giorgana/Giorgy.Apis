using AG.Hotels.Front.Api.Extensions;

namespace AG.Apis.Extensions;

public static class ConfigurationsExtension
{
    public static WebApplication UseApisRoutes(this WebApplication app)
    {
        app.Logger.LogInformation("Setting up APIs routes...");
        // Use APIs routes by modules
        app.UseHotelFrontRoutes();
        
        app.Logger.LogInformation("Api's routes configured successfully.");
        
        return app;
    }
}