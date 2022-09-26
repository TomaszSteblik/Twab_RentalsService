namespace RentalService.Application.DTOs;

public class GetCarDto
{
    public Guid Id { get; set; }
    public string Model { get; set; }
    public double DollarsPerHours { get; set; }
    public bool IsRented { get; set; }
}