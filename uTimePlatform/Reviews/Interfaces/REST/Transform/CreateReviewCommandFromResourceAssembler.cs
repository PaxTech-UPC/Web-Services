using uTimePlatform.Reviews.Domain.Model.Commands;
using uTimePlatform.Reviews.Interfaces.REST.Resources;

namespace uTimePlatform.Reviews.Interfaces.REST.Transform;

public static class CreateReviewCommandFromResourceAssembler
{

    public static CreateReviewCommand ToCommandFromResource(CreateReviewResource resource) =>
        new CreateReviewCommand(
            resource.ClientId,
            resource.ProviderId,
            resource.Content,
            resource.Rating
        );
}