using uTimePlatform.Workers.Domain.Model.Aggregates;
using uTimePlatform.Workers.Domain.Model.Commands;
using uTimePlatform.Workers.Domain.Model.Queries;
using uTimePlatform.Workers.Domain.Services;
using uTimePlatform.Workers.Interfaces.ACL;

namespace uTimePlatform.Workers.Application.ACL;

public class WorkerContextFacade(
    IWorkerCommandService workerCommandService,
    IWorkerQueryService workerQueryService
) :  IWorkerContextFacade
{
    public async Task<int> CreateWorker(string firstName, string lastName, string specialization, string photoUrl, int ProviderId)
    {
        var command = new CreateWorkerCommand(firstName, lastName, specialization, photoUrl, ProviderId);
        var worker = await workerCommandService.Handle(command);
        return worker?.Id ?? 0;
    }
    
    public async Task<Worker?> GetWorkerByIdAsync(int id)
    {
        var query = new GetWorkerByIdQuery(id);
        return await workerQueryService.Handle(query);
    }
    
}