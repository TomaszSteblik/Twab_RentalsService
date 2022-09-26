using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentalService.Infrastructure.DAOs;

public class Rental
{
    [Key]
    [Required]
    public Guid Id { get; set; }
    [Required]
    public DateTime DateTimeFrom { get; set; }
    [Required]
    public DateTime DateTimeToDeclared { get; set; }
    public DateTime DateTimeToActual { get; set; }
    [ForeignKey(nameof(Car))]
    public Guid CarId { get; set; }
    [Required]
    public virtual Car Car { get; set; }
    [Required]
    public Guid RenterId { get; set; }
}