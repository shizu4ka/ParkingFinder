using Microsoft.EntityFrameworkCore;
using ParkingFinder.Domain.DTOs;
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
            .ToListAsync();
    }

    public async Task<IReadOnlyList<Parking_space>> GetParkingSpacesByFiltersAsync(
        ParkingSpacesFilters parkingSpacesFilters)
    {
        IQueryable<Parking_space> query = _db.ParkingSpaces;
        if (parkingSpacesFilters.ParkingSpacesFilterId.HasValue)
        {
            query = query.Where(p => p.Id == parkingSpacesFilters.ParkingSpacesFilterId.Value);
        }

        if (parkingSpacesFilters.ParkingSpacesFilterNumber.HasValue)
        {
            query = query.Where(p => p.Number == parkingSpacesFilters.ParkingSpacesFilterNumber);
        }

        if (parkingSpacesFilters.ParkingSpacesFilterBuilding != null)
        {
            query = query.Where(p => p.Building == parkingSpacesFilters.ParkingSpacesFilterBuilding);
        }

        if (parkingSpacesFilters.ParkingSpacesFilterAvailable.HasValue)
        {
            query = query.Where(p => p.Available == parkingSpacesFilters.ParkingSpacesFilterAvailable.Value);
        }

        if (parkingSpacesFilters.ParkingSpacesFilterFloor.HasValue)
        {
            query = query.Where(p => p.Floor == parkingSpacesFilters.ParkingSpacesFilterFloor.Value);
        }

        if (parkingSpacesFilters.ParkingSpacesFilterCarId.HasValue)
        {
            query = query.Where(p => p.CarId == parkingSpacesFilters.ParkingSpacesFilterCarId.Value);
        }

        return await query.ToListAsync();
    }

    public async Task AddNewParkingSpace(Parking_space parking_space)
    {
        var newSpace = new Parking_space
        {
            Id = parking_space.Id,
            Number = parking_space.Number,
            Building = parking_space.Building,
            Available = parking_space.Available,
            Floor = parking_space.Floor,
            CarId = parking_space.CarId
        };
        await _db.ParkingSpaces.AddAsync(newSpace);
        await _db.SaveChangesAsync();
    }

    //TODO do exception handling
    public async Task<bool> UpdateParkingSpace(Guid Id, Parking_space parking_space)
    {
        var newSpace = _db.ParkingSpaces.Find(Id);

        if (newSpace == null) return false;

        newSpace.Number = parking_space.Number;
        newSpace.Building = parking_space.Building;
        newSpace.Available = parking_space.Available;
        newSpace.Floor = parking_space.Floor;
        newSpace.CarId = parking_space.CarId;

        await _db.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteParkingSpace(Guid Id)
    {
        var space = await _db.ParkingSpaces.FindAsync(Id);
        if (space == null) return false;
        _db.ParkingSpaces.Remove(space);
        await _db.SaveChangesAsync();
        return true;
    }
}