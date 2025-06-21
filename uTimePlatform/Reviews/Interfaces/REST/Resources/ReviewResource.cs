namespace uTimePlatform.Reviews.Interfaces.REST.Resources;

public record ReviewResource(
    int ReviewId,
    int ClientId,
    int ProviderId,
    string Content,
    int Rating,
    string Response
);