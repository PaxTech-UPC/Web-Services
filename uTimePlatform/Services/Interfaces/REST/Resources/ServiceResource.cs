namespace uTimePlatform.Services.Interfaces.REST.Resources;

public record ServiceResource(
    int Id,
    string Name,
    int Duration,
    int Price,
    bool Status,
    int SalonId,
    string Description
);