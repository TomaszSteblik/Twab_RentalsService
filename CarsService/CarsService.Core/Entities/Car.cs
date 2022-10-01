using CarsService.Core.Exceptions;

namespace CarsService.Core.Entities;

public class Car
{
    public Guid Id { get; set; }
    public string Model { get; set; }
    public double DollarsPerHour { get; set; }
    public bool IsRented { get; set; }
    public byte[] Picture { get; set; }
    public Guid OwnerId { get; set; }

    public Car(string model, double dollarsPerHour, byte[] picture, Guid ownerId)
    {
        Id = Guid.NewGuid();
        Model = model;
        DollarsPerHour = dollarsPerHour;
        IsRented = false;
        Picture = picture;
        OwnerId = ownerId;
    }

    public Car()
    {
        
    }

    public void Validate()
    {
        if (string.IsNullOrWhiteSpace(Model))
            throw new InvalidCarModelException("Model name cannot be empty or whitespace.");
        if (DollarsPerHour < 0)
            throw new NegativePriceException("Price for rental per hour cannot be less than 0.");
        if (OwnerId == Guid.Empty)
            throw new NoOwnerException("Car need to have an owner.");
    }
}