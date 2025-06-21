using uTimePlatform.Reviews.Application.Internal.CommandServices;
using uTimePlatform.Reviews.Domain.Model.Aggregates;
using uTimePlatform.Reviews.Domain.Model.Commands;

namespace uTimePlatform.Reviews.Domain.Services;

public interface IReviewCommandService
{
    Task<Review?> Handle(CreateReviewCommand command); 
    Task<Review?> Handle(RespondToReviewCommand command);
}