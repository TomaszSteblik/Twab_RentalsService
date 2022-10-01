namespace CarsService.Application.DTOs;

public class ReadCarDto
{
    public Guid Id { get; set; }
    public string Model { get; set; }
    public double DollarsPerHour { get; set; }
    public bool IsRented { get; set; }
    public byte[] Picture { get; set; }
    public Guid OwnerId { get; set; }
}