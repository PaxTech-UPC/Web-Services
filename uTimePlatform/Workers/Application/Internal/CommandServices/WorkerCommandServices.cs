using uTimePlatform.Workers.Domain.Model.Aggregates;
using uTimePlatform.Workers.Domain.Model.Commands;
using uTimePlatform.Workers.Domain.Repositories;
using uTimePlatform.Workers.Domain.Services;
using uTimePlatform.Shared.Domain.Repositories;

namespace uTimePlatform.Workers.Application.Internal.CommandServices;

public class WorkerCommandServices(IWorkerRepository workerRepository, IUnitOfWork unitOfWork)
: IWorkerCommandService
{
    public async Task<Worker?> Handle(CreateWorkerCommand command)
    {
        var worker = new Worker(command);

        try
        {
            await workerRepository.AddAsync(worker);
            await unitOfWork.CompleteAsync();
        }
        catch (Exception)
        {
            return null;
        }
        return worker;
    }
}