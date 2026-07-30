using ParkingFinder.Domain.Entities;

public interface IParkingSpaceRepository
{
    Task<IReadOnlyList<Parking_space>> GetAllParkingSpacesAsync();
    Task<IReadOnlyList<Parking_space>> GetParkingSpacesByFiltersAsync(string filters); // should create dto
    Task AddNewParkingSpace(Parking_space parking_space);
    Task UpdateParkingSpace(Parking_space parking_space);
    Task DeleteParkingSpace(Parking_space parking_space);
}