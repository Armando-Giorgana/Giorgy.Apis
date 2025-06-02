using AG.Hotels.Front.Models;
using AG.Hotels.Front.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AG.Hotels.Front.Api.Routes;

public static class RoomsRoute
{
    public static WebApplication MapRoomsRoute(this WebApplication app, string basePath, string path = "/rooms")
    {
        var group = app.MapGroup($"{basePath}{path}");
        
        group.MapGet("/", ([FromServices] IRoomsService service) =>
        {
            var result = service.GeAll();
            
            return Results.Ok(result);
        });
        
        group.MapGet("/{id:long}", ([FromServices] IRoomsService service, long id) =>
        {
            var result = service.GeById(id);
            
            return result is not null
                ? Results.Ok(result) 
                : Results.NotFound();
        });
        
        group.MapPost("/", ([FromServices] IRoomsService service, [FromBody] RoomModel model) =>
        {
            var result = service.Create(model);
            
            return Results.Created($"{basePath}{path}/{result.Id}", result);
        });
        
        group.MapPut("/{id:long}", ([FromServices] IRoomsService service, long id, [FromBody] RoomModel model) =>
        {
            model.Id = id;

            var result = service.Update(model);
            
            return Results.Ok(result);
        });
        
        group.MapDelete("/{id:long}", ([FromServices] IRoomsService service, long id) =>
        {
            service.Delete(id);
            
            return Results.NoContent();
        });
            
        return app;
    }
}