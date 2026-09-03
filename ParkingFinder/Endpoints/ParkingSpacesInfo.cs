using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ParkingFinder.Domain.Entities;
using ParkingFinder.Infrastructure;
using ParkingFinder.Infrastructure.Data;

namespace ParkingFinder.Endpoints;

public class ParkingSpacesInfo : IEndpointGroup
{
    public static string RoutePrefix => "/api"; 
    public static void Map(RouteGroupBuilder groupBuilder)
    {
        groupBuilder.MapGet("/parking-spaces", GetAllParkingSpaces);
        groupBuilder.MapPost("/parking-spaces", CreateParkingSpace);
        groupBuilder.MapPut("/parking-spaces", UpdateParkingSpace);
        groupBuilder.MapDelete("/parking-spaces", DeleteParkingSpace);
    }
    public static async Task<Ok<IReadOnlyList<Parking_space>>> GetAllParkingSpaces([FromServices] IParkingSpaceRepository repository)
    {
        var spaces = await repository.GetAllParkingSpacesAsync();
        return TypedResults.Ok(spaces);
    }

    public static async Task<Created<Parking_space>> CreateParkingSpace(
        [FromBody] Parking_space parkingSpace,
        [FromServices] IParkingSpaceRepository repository)
    {
        await repository.AddNewParkingSpace(parkingSpace);
        return TypedResults.Created($"/api/parking-spaces/{parkingSpace.Id}", parkingSpace);
    }
    
    public static async Task<Results<Ok<Parking_space>, NotFound>> UpdateParkingSpace(
        Guid id,
        [FromBody] Parking_space parkingSpace,
        [FromServices] IParkingSpaceRepository repository)
    {
        await repository.UpdateParkingSpace(id, parkingSpace);
        return TypedResults.Ok(parkingSpace);
    }
    
    public static async Task<Results<Ok, NotFound>> DeleteParkingSpace(
        Guid id,
        [FromServices] IParkingSpaceRepository repository)
    {
        await repository.DeleteParkingSpace(id);
        return TypedResults.Ok();
    }
}