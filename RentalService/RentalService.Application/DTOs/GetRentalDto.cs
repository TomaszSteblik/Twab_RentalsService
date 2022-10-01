namespace RentalService.Application.DTOs;

public class GetRentalDto
{
    public Guid Id { get; set; }
    public DateTime DateTimeFrom { get; set; }
    public DateTime DateTimeToDeclared { get; set; }
    public DateTime DateTimeToActual { get; set; }
    public GetCarDto Car { get; set; }
}