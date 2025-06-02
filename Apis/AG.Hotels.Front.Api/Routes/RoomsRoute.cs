using AG.Hotels.Front.Api.Endpoints;
using AG.Hotels.Front.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AG.Hotels.Front.Api.Routes;

public static class RoomsRoute
{
    public static WebApplication MapRoomsRoute(this WebApplication app, string basePath, string path = "/rooms")
    {
        var group = app.MapGroup($"{basePath}{path}");
        
        group.MapGet("/", ([FromServices] IRoomsEndpoint endpoint) =>
        {
            var result = endpoint.GetRooms();
            
            return Results.Ok(result);
        });
        
        group.MapGet("/{id:long}", ([FromServices] IRoomsEndpoint endpoint, long id) =>
        {
            var result = endpoint.GetRoomById(id);
            
            return result is not null
                ? Results.Ok(result) 
                : Results.NotFound();
        });
        
        group.MapPost("/", ([FromServices] IRoomsEndpoint endpoint, [FromBody] RoomModel model) =>
        {
            var result = endpoint.CreateRoom(model);
            
            return Results.Created($"{basePath}{path}/{result.Id}", result);
        });
        
        group.MapPut("/{id:long}", ([FromServices] IRoomsEndpoint endpoint, long id, [FromBody] RoomModel model) =>
        {
            model.Id = id;

            var result = endpoint.UpdateRoom(id, model);
            
            return Results.Ok(result);
        });
        
        group.MapDelete("/{id:long}", ([FromServices] IRoomsEndpoint endpoint, long id) =>
        {
            endpoint.DeleteRoom(id);
            
            return Results.NoContent();
        });
            
        return app;
    }
}