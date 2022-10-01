namespace UsersService.Application.DTOs;

public class AddUserDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int BirthDateYear { get; set; }
    public int BirthDateMonth { get; set; }
    public int BirthDateDay { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Username { get; set; }
    public byte[] ProfilePicture { get; set; }
}