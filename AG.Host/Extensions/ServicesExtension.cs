using AG.Hotels.Front.Api.Extensions;

namespace AG.Apis.Extensions;

public static class ServicesExtension
{
    public static IServiceCollection AddApis(this WebApplicationBuilder builder)
    {
        // Register APIs by Modules
        builder.Services.AddHotelFrontApi();
        
        return builder.Services;
    }
}