namespace uTimePlatform.Reviews.Interfaces.REST.Resources;

public record CreateReviewResource(
    int ClientId,
    int ProviderId,
    string Content,
    int Rating
);