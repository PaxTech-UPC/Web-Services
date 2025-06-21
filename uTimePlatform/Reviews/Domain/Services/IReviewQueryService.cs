using uTimePlatform.Reviews.Domain.Model.Aggregates;
using uTimePlatform.Reviews.Domain.Model.Queries;
namespace uTimePlatform.Reviews.Domain.Services;

public interface IReviewQueryService
{
    Task<Review?> Handle(GetReviewByIdQuery query);
    Task<IEnumerable<Review>> Handle(GetAllReviewQuery query);

} 