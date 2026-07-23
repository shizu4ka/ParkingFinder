namespace ParkingFinder.Domain.Entities;

public class Car
{
    public Guid Id { get; set; } =  Guid.NewGuid();
    public string Model { get; set; }
    public string Color { get; set; }
    public string Number{ get; set; }
}