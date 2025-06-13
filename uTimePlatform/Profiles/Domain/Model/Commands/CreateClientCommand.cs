namespace uTimePlatform.Profiles.Domain.Model.Commands;

public record CreateClientCommand(
    string FirstName,
    string LastName
    );