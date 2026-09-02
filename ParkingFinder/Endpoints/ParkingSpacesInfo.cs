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
    }
    public static async Task<Ok<IReadOnlyList<Parking_space>>> GetAllParkingSpaces([FromServices] IParkingSpaceRepository repository)
    {
        var spaces = await repository.GetAllParkingSpacesAsync();
        return TypedResults.Ok(spaces);
    }
}