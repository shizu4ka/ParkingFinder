using ParkingFinder.Domain.Entities;

namespace ParkingFinder.Domain.DTOs;

public class ParkingSpacesFilters
{
    public Guid? ParkingSpacesFilterId { get; set; }
    public int? ParkingSpacesFilterNumber { get; set; }
    public string? ParkingSpacesFilterBuilding { get; set; }
    public bool? ParkingSpacesFilterAvailable { get; set; }
    public int? ParkingSpacesFilterFloor { get; set; }
    public Guid? ParkingSpacesFilterCarId { get; set; }
}