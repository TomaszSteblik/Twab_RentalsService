namespace RentalService.Application.DTOs;

public class AddRentalDto
{
    public Guid CarId { get; set; }
    public int RentalTimeInMinutes { get; set; }
    public Guid UserId { get; set; }
}