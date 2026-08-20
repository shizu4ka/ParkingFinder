using System.Diagnostics.CodeAnalysis;

namespace ParkingFinder.Infrastructure;

public static class EndpointRouteBuilderExtensions
{
    /// <inheritdoc cref="EndpointRouteBuilderExtensions"/>
    public static RouteHandlerBuilder MapGet(this IEndpointRouteBuilder builder, Delegate handler,
        [StringSyntax("Route")] string pattern = "")
    {
        return builder.MapGet(pattern, handler)
            .WithName(handler.Method.Name);
    }

    /// <inheritdoc cref="EndpointRouteBuilderExtensions"/>
    public static RouteHandlerBuilder MapPost(this IEndpointRouteBuilder builder, Delegate handler,
        [StringSyntax("Route")] string pattern = "")
    {
        return builder.MapPost(pattern, handler)
            .WithName(handler.Method.Name);
    }

    /// <inheritdoc cref="EndpointRouteBuilderExtensions"/>
    public static RouteHandlerBuilder MapPut(this IEndpointRouteBuilder builder, Delegate handler,
        [StringSyntax("Route")] string pattern)
    {
        return builder.MapPut(pattern, handler)
            .WithName(handler.Method.Name);
    }

    /// <inheritdoc cref="EndpointRouteBuilderExtensions"/>
    public static RouteHandlerBuilder MapPatch(this IEndpointRouteBuilder builder, Delegate handler,
        [StringSyntax("Route")] string pattern)
    {
        return builder.MapPatch(pattern, handler)
            .WithName(handler.Method.Name);
    }

    /// <inheritdoc cref="EndpointRouteBuilderExtensions"/>
    public static RouteHandlerBuilder MapDelete(this IEndpointRouteBuilder builder, Delegate handler,
        [StringSyntax("Route")] string pattern)
    {
        return builder.MapDelete(pattern, handler)
            .WithName(handler.Method.Name);
    }
}