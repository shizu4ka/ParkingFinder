using Microsoft.EntityFrameworkCore;
using ParkingFinder.Domain.Entities;
using ParkingFinder.Infrastructure.Data;


public class ParkingSpaceRepository : IParkingSpaceRepository
{
    private readonly AppDbContext _db;

    public ParkingSpaceRepository(AppDbContext db)
    {
        _db = db;
    }

    public async Task<IReadOnlyList<Parking_space>> GetAllParkingSpacesAsync()
    {
        return await _db.ParkingSpaces
            .AsNoTracking()
            .Include(s => s.Car!)
            .ToListAsync();
    }

    public async Task<IReadOnlyList<Parking_space>> GetParkingSpacesByFiltersAsync(string filters)
    {
        //TODO
        throw new NotImplementedException();
    }

    public async Task AddNewParkingSpace(Parking_space parking_space)
    {
        var newSpace = new Parking_space
        {
        Id =  parking_space.Id,
        Number =  parking_space.Number,
        Building = parking_space.Building,
        Available =  parking_space.Available,
        Floor =  parking_space.Floor,
        Car =  parking_space.Car
        };
        await _db.ParkingSpaces.AddAsync(newSpace);
        await _db.SaveChangesAsync();
    }

    public Task UpdateParkingSpace(Parking_space parking_space)
    {
        throw new NotImplementedException();
        //TODO
    }

    public Task DeleteParkingSpace(Parking_space parking_space)
    {
        throw new NotImplementedException();
        //TODO
    }
}