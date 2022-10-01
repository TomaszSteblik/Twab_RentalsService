using System.ComponentModel.DataAnnotations;

namespace RentalService.Infrastructure.DAOs;

public class Car
{
    [Key]
    public Guid Id { get; set; }
    [Required]
    public string Model { get; set; }
    [Required]
    public double DollarsPerHours { get; set; }
    [Required]
    public bool IsRented { get; set; }
    public virtual ICollection<Rental> Rentals { get; set; }
    [Required]
    public Guid OwnerId { get; set; }
}