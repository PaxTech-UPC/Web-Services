namespace uTimePlatform.Profiles.Interfaces.REST.Resources;

public record ClientResource(
    int Id,
    string FirstName,
    string LastName,
    string Email,
    DateTime BirthDate
);