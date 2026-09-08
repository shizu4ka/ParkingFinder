using Microsoft.EntityFrameworkCore;
using ParkingFinder.Domain.Entities;

namespace ParkingFinder.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public DbSet<Parking_space> ParkingSpaces { get; set; }
    public DbSet<Car> Cars { get; set; }
    public DbSet<User> Users { get; set; }
    
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
        Database.EnsureCreated();
    }
}
