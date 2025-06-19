using uTimePlatform.Reviews.Domain.Model.Aggregates;
using uTimePlatform.Reviews.Domain.Repositories;
using uTimePlatform.Shared.Infrastructure.Persistence.EFC.Configuration;
using uTimePlatform.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace uTimePlatform.Reviews.Infrastructure.Persistence.EFC.Repositories
{
    public class ReviewRepository : BaseRepository<Review>, IReviewRepository
    {
        public ReviewRepository(AppDbContext context) : base(context) {}

        public async Task<IEnumerable<Review>> GetAllReviewsAsync()
        {
            return await Context.Set<Review>().ToListAsync();
        }
        
    }
}