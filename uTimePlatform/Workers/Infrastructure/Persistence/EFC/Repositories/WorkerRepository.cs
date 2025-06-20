using uTimePlatform.Workers.Domain.Model.Aggregates;
using uTimePlatform.Workers.Domain.Repositories;
using uTimePlatform.Shared.Infrastructure.Persistence.EFC.Configuration;
using uTimePlatform.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace uTimePlatform.Workers.Infrastructure.Persistence.EFC.Repositories;

public class WorkerRepository : BaseRepository<Worker>, IWorkerRepository
{
    public WorkerRepository(AppDbContext context) : base(context) {}

    public async Task<IEnumerable<Worker>> FindAllAsync()
    {
        return await Context.Set<Worker>().ToListAsync();
    }
    
}