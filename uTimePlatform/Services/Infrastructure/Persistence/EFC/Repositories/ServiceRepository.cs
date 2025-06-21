using Microsoft.EntityFrameworkCore;
using uTimePlatform.Services.Domain.Model.Aggregates;
using uTimePlatform.Services.Domain.Model.ValueObjects;
using uTimePlatform.Services.Domain.Repositories;
using uTimePlatform.Shared.Infrastructure.Persistence.EFC.Configuration;
using uTimePlatform.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace uTimePlatform.Services.Infrastructure.Persistence.EFC.Repositories;

public class ServiceRepository : BaseRepository<Service>, IServiceRepository
{
    public ServiceRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Service>> FindAllAsync()
    {
        return await Context.Set<Service>().ToListAsync();
    }

    public async Task<IEnumerable<Service>> FindBySalonIdAsync(int salonId)
    {
        return await Context.Set<Service>()
            .Where(s => s.SalonId.Value == salonId)
            .ToListAsync();
    }

    public async Task<bool> ExistsBySalonIdAndNameAsync(int salonId, string name)
    {
        return await Context.Set<Service>()
            .AnyAsync(s => s.SalonId.Value == salonId && s.Name.Value == name);
    }

    public async Task<IEnumerable<Service>> FindByNameAndSalonIdAsync(string name, int salonId)
    {
        return await Context.Set<Service>()
            .Where(s => s.Name.Value == name && s.SalonId.Value == salonId)
            .ToListAsync();
    }
}