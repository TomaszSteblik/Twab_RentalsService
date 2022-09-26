namespace RentalService.Core.Entities;

public class Car
{
    public Guid Id { get; set; }
    public string Model { get; set; }
    public double DollarsPerHours { get; set; }
    public bool IsRented { get; set; }
    public Guid OwnerId { get; set; }

    public Car(string model, double pricePerHours, Guid userId)
    {
        Id = Guid.NewGuid();
        IsRented = false;
        Model = model;
        DollarsPerHours = pricePerHours;
        OwnerId = userId;
    }

    public Car()
    {
        
    }
}