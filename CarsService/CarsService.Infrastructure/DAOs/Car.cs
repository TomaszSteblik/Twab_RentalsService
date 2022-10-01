using System.ComponentModel.DataAnnotations;

namespace CarsService.Infrastructure.DAOs;

public class Car
{
    [Key]
    public Guid Id { get; set; }
    [Required]
    public string Model { get; set; }
    [Required]
    public double DollarsPerHour { get; set; }
    [Required]
    public bool IsRented { get; set; }
    [Required]
    public Guid OwnerId { get; set; }
    public string PictureBase64 { get; set; }
}