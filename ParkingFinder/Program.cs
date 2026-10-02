using Microsoft.EntityFrameworkCore;
using ParkingFinder.Domain.Interfaces;
using ParkingFinder.Infrastructure;
using ParkingFinder.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<RouteOptions>(options => 
{
    options.LowercaseUrls = true; 
});

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"),
        b => b.MigrationsAssembly("ParkingFinder.Infrastructure")));

builder.Services.AddScoped<IParkingSpaceRepository, ParkingSpaceRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(options =>
    {
        //Added Swagger for test
        options.SwaggerEndpoint("/openapi/v1.json", "ParkingFinder API v1");
    });
}

app.UseHttpsRedirection();

app.MapEndpoints(typeof(Program).Assembly);

app.Run();