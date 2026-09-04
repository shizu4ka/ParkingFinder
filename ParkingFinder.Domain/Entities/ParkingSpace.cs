namespace ParkingFinder.Domain.Entities;

public class Parking_space
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public int Number { get; set; }
    public string Building {get; set;}
    public bool Available { get; set; }
    public int Floor {  get; set; }
    public Guid? CarId {get; set;}
}