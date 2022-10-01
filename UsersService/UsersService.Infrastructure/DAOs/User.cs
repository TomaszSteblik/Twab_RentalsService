using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace UsersService.Infrastructure.DAOs;

public class User
{
    [BsonId]
    [BsonRepresentation(BsonType.String)]
    public string Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime BirthDate { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Username { get; set; }
    public string ProfilePictureBase64 { get; set; }
}