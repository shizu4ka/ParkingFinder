using ParkingFinder.Domain.DTOs;
using ParkingFinder.Domain.Entities;

public interface IParkingSpaceRepository
{
    Task<IReadOnlyList<Parking_space>> GetAllParkingSpacesAsync();
    Task<IReadOnlyList<Parking_space>> GetParkingSpacesByFiltersAsync(ParkingSpacesFilters parkingSpacesFilters);
    Task AddNewParkingSpace(Parking_space parking_space);
    Task<bool> UpdateParkingSpace(Guid Id, Parking_space parking_space);
    Task<bool> DeleteParkingSpace(Guid Id);
}