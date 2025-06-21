namespace uTimePlatform.Reviews.Domain.Model.Commands;

public record CreateReviewCommand(
    int ClientId,
    int ProviderId,
    string Content,
    int Rating
);