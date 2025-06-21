using uTimePlatform.Profiles.Domain.Model.Aggregates;
using uTimePlatform.Profiles.Domain.Repositories;
using uTimePlatform.Shared.Infrastructure.Persistence.EFC.Configuration;
using uTimePlatform.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace uTimePlatform.Profiles.Infrastructure.Persistence.EFC.Repositories
{
    public class ProviderRepository : BaseRepository<Provider>, IProviderRepository
    {
        public ProviderRepository(AppDbContext context) : base(context) {}

        public async Task<IEnumerable<Provider>> FindAllAsync()
        {
            return await Context.Set<Provider>().ToListAsync();
        }
        
    }
}