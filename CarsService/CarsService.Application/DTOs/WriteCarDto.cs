namespace CarsService.Application.DTOs;

public class WriteCarDto
{
    public string Model { get; set; }
    public double DollarsPerHour { get; set; }
    public byte[] Picture { get; set; }
    public Guid OwnerId { get; set; }
}