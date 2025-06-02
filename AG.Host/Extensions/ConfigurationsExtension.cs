using AG.Hotels.Front.Api.Extensions;

namespace AG.Apis.Extensions;

public static class ConfigurationsExtension
{
    public static WebApplication UseApisRoutes(this WebApplication app)
    {
        // Use APIs routes by modules
        app.UseHotelFrontRoutes();
        
        return app;
    }
}