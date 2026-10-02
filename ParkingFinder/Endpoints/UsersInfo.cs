using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ParkingFinder.Domain.DTOs;
using ParkingFinder.Domain.Entities;
using ParkingFinder.Domain.Interfaces;
using ParkingFinder.Infrastructure;

namespace ParkingFinder.Endpoints;

public class UsersInfo : IEndpointGroup
{
    public static string RoutePrefix => "/api";

    public static void Map(RouteGroupBuilder groupBuilder)
    {
        groupBuilder.MapGet("/users", GetAllUsers);
        groupBuilder.MapPost("/users", CreateUser);
        groupBuilder.MapPut("/users", UpdateUser);
        groupBuilder.MapDelete("/users", DeleteUser);
        groupBuilder.MapGet("/users/filter", GetUsersByFilters);
    }

    public static async Task<Ok<IReadOnlyList<User>>> GetAllUsers([FromServices] IUserRepository repository)
    {
        var users = await repository.GetAllUsersAsync();
        return TypedResults.Ok(users);
    }
    
    public static async Task<Created<User>> CreateUser(
        [FromBody] User user,
        [FromServices] IUserRepository repository)
    {
        await repository.AddNewUser(user);
        return TypedResults.Created($"/api/users/{user.Id}", user);
    }
    
    public static async Task<Results<Ok<User>, NotFound>> UpdateUser(
        Guid id,
        [FromBody] User user,
        [FromServices] IUserRepository repository)
    {
        await repository.UpdateUser(id, user);
        return TypedResults.Ok(user);
    }
    
    public static async Task<Results<Ok, NotFound>> DeleteUser(
        Guid id,
        [FromServices] IUserRepository repository)
    {
        await repository.DeleteUser(id);
        return TypedResults.Ok();
    }

    public static async Task<Ok<IReadOnlyList<User>>> GetUsersByFilters(
        [AsParameters] UsersFilters filters,
        [FromServices] IUserRepository repository)
    {
        var users = await repository.GetUsersByFiltersAsync(filters);
        return TypedResults.Ok(users);
    }
}