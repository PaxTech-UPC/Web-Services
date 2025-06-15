using uTimePlatform.Workers.Domain.Model.Aggregates;
using uTimePlatform.Workers.Domain.Model.Queries;
using uTimePlatform.Workers.Domain.Repositories;
using uTimePlatform.Workers.Domain.Services;

namespace uTimePlatform.Workers.Application.Internal.QueryServices;

public class WorkerQueryService(IWorkerRepository workerRepository)
    : IWorkerQueryService
{
    public async Task<IEnumerable<Worker>> Handle(GetAllWorkerQuery query)
    {
        return await workerRepository.FindAllAsync();
    }

    public async Task<Worker?> Handle(GetWorkerByIdQuery query)
    {
        return await workerRepository.FindByIdAsync(query.Id);
    }

    public async Task<Worker?> Handle(GetWorkersBySalonIdQuery query)
    {
        return await workerRepository.FindByIdAsync(query.salonId);
    }
    
}