namespace uTimePlatform.Services.Interfaces.REST.Resources;

public record UpdateServiceResource(
    string Name,
    int Duration,
    int Price,
    bool Status,
    string Description
);