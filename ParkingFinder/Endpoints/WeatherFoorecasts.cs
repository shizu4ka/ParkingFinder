using Microsoft.AspNetCore.Http.HttpResults;
using ParkingFinder.Infrastructure;

namespace ParkingFinder.Endpoints;

public class WeatherForecasts : IEndpointGroup
{
    public static void Map(RouteGroupBuilder groupBuilder)
    {
        groupBuilder.MapGet(GetWeatherForecasts);
    }

    [EndpointSummary("Get Weather Forecasts")]
    [EndpointDescription("Retrieves a list of weather forecasts for the next few days.")]
    public static async Task<Ok<string>> GetWeatherForecasts()
    {
        return TypedResults.Ok("The weather is awesome today!");
    }
}
