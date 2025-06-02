using AG.Hotels.Front.Api.Routes;
using Microsoft.AspNetCore.Builder;

namespace AG.Hotels.Front.Api.Extensions;

public static class HotelFrontRoutesExtension
{
    public static WebApplication UseHotelFrontRoutes(this WebApplication app, string path = "/front")
    {
        app
            .MapHotelsRoute(basePath: path, path: "/hotels")
            .MapRoomsRoute(basePath: path, path: "/rooms");

        return app;
    }
}