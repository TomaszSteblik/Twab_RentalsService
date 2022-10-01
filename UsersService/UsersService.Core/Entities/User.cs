using System.Net.Mail;
using UsersService.Core.Exceptions;

namespace UsersService.Core.Entities;

public class User
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateOnly BirthDate { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Username { get; set; }
    public byte[] ProfilePicture { get; set; }

    private const int MinimalLegalAge = 18;
    private const int MaximumLegalAge = 130;

    public User(string firstName, string lastName, DateOnly birthDate, string email, string password, string username, byte[] profilePicture)
    {
        Id = Guid.NewGuid();
        FirstName = firstName;
        LastName = lastName;
        BirthDate = birthDate;
        Email = email;
        Password = password;
        Username = username;
        ProfilePicture = profilePicture;
    }

    public User()
    {
        
    }

    public void Validate()
    {
        if (string.IsNullOrWhiteSpace(Username))
            throw new UserInvalidException($"User cannot have empty username.");
        if (string.IsNullOrWhiteSpace(FirstName))
            throw new UserInvalidException($"User cannot have empty first name.");
        if (string.IsNullOrWhiteSpace(LastName))
            throw new UserInvalidException($"User cannot have empty last name.");
        if (string.IsNullOrWhiteSpace(Email))
            throw new UserInvalidException($"User need to have email specified.");

        if (MailAddress.TryCreate(Email, out _))
            throw new UserInvalidException($"Invalid email");
        
        var todayDateOnly = DateOnly.FromDateTime(DateTime.Today);

        if (BirthDate.AddYears(MinimalLegalAge) > todayDateOnly)
            throw new UserInvalidException($"Minimal required age is {MinimalLegalAge}.");
        if(todayDateOnly.AddYears(-MaximumLegalAge) > BirthDate)
            throw new UserInvalidException($"Maximal age is {MaximumLegalAge}.");

        if (string.IsNullOrWhiteSpace(Password))
            throw new UserInvalidException("Password cannot be empty");
        if (Password.Length < 8)
            throw new UserInvalidException("Password need to have at least 8 characters");
    }
}