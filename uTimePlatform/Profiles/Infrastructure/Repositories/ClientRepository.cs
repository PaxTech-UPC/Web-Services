using uTimePlatform.Profiles.Domain.Model.Aggregates;
using uTimePlatform.Profiles.Domain.Repositories;
using uTimePlatform.Shared.Infrastructure.Persistence.EFC.Configuration;
using uTimePlatform.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace uTimePlatform.Profiles.Infrastructure.Repositories;

public class ClientRepository(AppDbContext context) : BaseRepository<Client>(context), IClientRepository
{
    
    /// <inheritdoc />
    public async Task<IEnumerable<Client>> FindAllAsync()
    {
        return await Context.Set<Client>().ToListAsync();
    }

    /// <inheritdoc />
    public async Task<Client?> FindByEmailAsync(string email)
    {
        return await Context.Set<Client>().FirstOrDefaultAsync(c => c.Email == email);
    }
}