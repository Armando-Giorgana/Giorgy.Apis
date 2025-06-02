using AG.Hotels.Front.Services.Extensions;
using AG.Repositories.SqlServer.Extensions;

namespace AG.Apis.Extensions;

public static class ServicesExtension
{
    public static IServiceCollection AddApis(this WebApplicationBuilder builder)
    {
        // Register APIs by Modules
        builder.Services.AddHotelFrontRepositories();
        builder.Services.AddHotelFrontServices();
        
        return builder.Services;
    }
}