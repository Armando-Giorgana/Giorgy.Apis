using AG.Hotels.Front.Models;
using AG.Hotels.Front.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AG.Hotels.Front.Api.Routes;

public static class HotelsRoute
{
    public static WebApplication MapHotelsRoute(this WebApplication app, string basePath, string path = "/hotels")
    {
        var group = app.MapGroup($"{basePath}{path}");

        group.MapGet("/", ([FromServices] IHotelsService service) =>
        {
            var result = service.GeAll();
            
            return Results.Ok(result);
        });
        
        group.MapGet("/{id:long}", ([FromServices] IHotelsService service, long id) =>
        {
            var result = service.GeById(id);
            
            return result is not null
                ? Results.Ok(result) 
                : Results.NotFound();
        });
        
        group.MapPost("/", ([FromServices] IHotelsService service, [FromBody] HotelModel model) =>
        {
            var result = service.Create(model);
            
            return Results.Created($"{basePath}{path}/{result.Id}", result);
        });
        
        group.MapPut("/{id:long}", ([FromServices] IHotelsService service, long id, [FromBody] HotelModel model) =>
        {
            model.Id = id;

            var result = service.Update(model);
            
            return Results.Ok(result);
        });
        
        group.MapDelete("/{id:long}", ([FromServices] IHotelsService service, long id) =>
        {
            service.Delete(id);
            
            return Results.NoContent();
        });
            
        return app;
    } 
}