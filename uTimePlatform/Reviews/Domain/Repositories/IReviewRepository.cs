using uTimePlatform.Reviews.Domain.Model.Aggregates;
using uTimePlatform.Shared.Domain.Repositories;
namespace uTimePlatform.Reviews.Domain.Repositories;

public interface IReviewRepository : IBaseRepository<Review>
{
    Task<IEnumerable<Review>> GetAllReviewsAsync();
}