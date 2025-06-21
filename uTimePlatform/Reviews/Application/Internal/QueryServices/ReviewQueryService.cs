using uTimePlatform.Reviews.Domain.Model.Queries;
using uTimePlatform.Reviews.Domain.Model.Aggregates;
using uTimePlatform.Reviews.Domain.Repositories;
using uTimePlatform.Reviews.Domain.Services;

namespace uTimePlatform.Reviews.Application.Internal.QueryServices;

public class ReviewQueryService(IReviewRepository reviewRepository)
    : IReviewQueryService
{
    public async Task<IEnumerable<Review>> Handle(GetAllReviewQuery query)
    {
        return await reviewRepository.GetAllReviewsAsync();
    }
    
    public async Task<Review?> Handle(GetReviewByIdQuery  query)
    {
        return await reviewRepository.FindByIdAsync(query.Id);
    }
}
