namespace uTimePlatform.Services.Interfaces.REST.Resources;

public record CreateServiceResource(
    string Name,
    int Duration,
    int Price,
    bool Status,
    int SalonId,
    string Description
);