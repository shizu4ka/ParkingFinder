using ParkingFinder.Domain.Entities;

namespace ParkingFinder.Domain.DTOs;

public class ParkingSpacesFilters
{
    public Guid? Id { get; set; }
    public int? Number { get; set; }
    public string? Building { get; set; }
    public bool? Available { get; set; }
    public int? Floor { get; set; }
    public Guid? CarId { get; set; }
}