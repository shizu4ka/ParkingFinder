namespace ParkingFinder.Domain.Entities;

public class User
{
    public Guid Id { get; set; } =  Guid.NewGuid();
    public string Name { get; set; }
    public string Surname { get; set; }
    public string PhoneNumber{ get; set; }
    public Guid CarId { get; set; }
}