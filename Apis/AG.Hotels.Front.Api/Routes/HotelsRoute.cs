using AG.Hotels.Front.Api.Endpoints;
using AG.Hotels.Front.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AG.Hotels.Front.Api.Routes;

public static class HotelsRoute
{
    public static WebApplication MapHotelsRoute(this WebApplication app, string basePath, string path = "/hotels")
    {
        var group = app.MapGroup($"{basePath}{path}")
            .WithTags("Hotels")
            .WithOpenApi()
            .WithSummary("Hotels API");

        group.MapGet("/", ([FromServices] IHotelsEndpoint endpoint) =>
        {
            var result = endpoint.GetHotels();
            
            return Results.Ok(result);
        })
        .WithDescription("Retrieves a list of all hotels.");
        
        group.MapGet("/{id:long}", ([FromServices] IHotelsEndpoint endpoint, long id) =>
        {
            var result = endpoint.GetHotelById(id);
            
            return result is not null
                ? Results.Ok(result) 
                : Results.NotFound();
        })
        .WithDescription("Retrieves a room by id.");
        
        group.MapPost("/", ([FromServices] IHotelsEndpoint endpoint, [FromBody] HotelModel model) =>
        {
            var result = endpoint.CreateHotel(model);
            
            return Results.Created($"{basePath}{path}/{result.Id}", result);
        })
        .WithDescription("Creates a room by id.");
        
        group.MapPut("/{id:long}", ([FromServices] IHotelsEndpoint endpoint, long id, [FromBody] HotelModel model) =>
        {
            var result = endpoint.UpdateHotel(id, model);
            
            return Results.Ok(result);
        })
        .WithDescription("Updates a room by id.");
        
        group.MapDelete("/{id:long}", ([FromServices] IHotelsEndpoint endpoint, long id) =>
        {
            endpoint.DeleteHotel(id);
            
            return Results.NoContent();
        })
        .WithDescription("Deletes a room by id.");
            
        return app;
    } 
}