namespace uTimePlatform.Profiles.Interfaces.REST.Resources;

public record CreateProviderResource(
    string CompanyName,
    int UserId
);