using uTimePlatform.Reviews.Domain.Services;
using uTimePlatform.Reviews.Domain.Model.Aggregates;
using uTimePlatform.Reviews.Domain.Model.Commands;
using uTimePlatform.Reviews.Domain.Repositories;
using uTimePlatform.Shared.Domain.Repositories;

namespace uTimePlatform.Reviews.Application.Internal.CommandServices;

public class ReviewCommandService(IReviewRepository reviewRepository, IUnitOfWork unitOfWork)
    : IReviewCommandService
{
    public async Task<Review?> Handle(CreateReviewCommand command)
    {
        var review = new Review(command);

        try
        {
            await reviewRepository.AddAsync(review);
            await unitOfWork.CompleteAsync();
        }
        catch (Exception)
        {
            return null;
        }
        
        return review;
    }

    public async Task<Review?> Handle(RespondToReviewCommand command)
    {
        try
        {
            var review = await reviewRepository.FindByIdAsync(command.ReviewId);
            if (review == null) return null;

            review.Respond(command.Response);
            reviewRepository.Update(review);
            await unitOfWork.CompleteAsync();

            return review;
        }
        catch (Exception)
        {
            return null;
        }
    }
}