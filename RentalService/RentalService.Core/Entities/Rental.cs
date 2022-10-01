namespace RentalService.Core.Entities;

public class Rental
{
    public Guid Id { get; set; }
    public DateTime DateTimeFrom { get; set; }
    public DateTime DateTimeToDeclared { get; set; }
    public DateTime DateTimeToActual { get; set; }
    public Car Car { get; set; }
    public Guid UserId { get; set; }

    public Rental(DateTime end, Car car, Guid userId)
    {
        Id = Guid.NewGuid();
        DateTimeFrom = DateTime.Now;
        DateTimeToDeclared = end;
        Car = car;
        car.IsRented = true;
        UserId = userId;
    }

    public Rental()
    {
        
    }

    public void EndRental()
    {
        Car.IsRented = false;
        DateTimeToActual = DateTime.Now;
    }

    public void StartRental()
    {
        Car.IsRented = true;
    }
    
}