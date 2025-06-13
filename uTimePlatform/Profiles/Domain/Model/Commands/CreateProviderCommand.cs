namespace uTimePlatform.Profiles.Domain.Model.Commands;

public record CreateProviderCommand(
    string CompanyName, int UserId
);