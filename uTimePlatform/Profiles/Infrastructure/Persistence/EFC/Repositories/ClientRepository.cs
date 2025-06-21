using uTimePlatform.Profiles.Domain.Model.Aggregates;
using uTimePlatform.Profiles.Domain.Repositories;
using uTimePlatform.Shared.Infrastructure.Persistence.EFC.Configuration;
using uTimePlatform.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace uTimePlatform.Profiles.Infrastructure.Persistence.EFC.Repositories
{
    public class ClientRepository : BaseRepository<Client>, IClientRepository
    {
        public ClientRepository(AppDbContext context) : base(context) {}

        public async Task<IEnumerable<Client>> FindAllAsync()
        {
            return await Context.Set<Client>().ToListAsync();
        }
        
    }
}