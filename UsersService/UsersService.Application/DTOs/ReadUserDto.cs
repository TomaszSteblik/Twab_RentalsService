namespace UsersService.Application.DTOs;

public class ReadUserDto
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime BirthDate { get; set; }
    public string Username { get; set; }
    public byte[] ProfilePicture { get; set; }
}