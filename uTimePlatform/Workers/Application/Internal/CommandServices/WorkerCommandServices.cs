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

    public async Task<Worker?> Handle(UpdateWorkerCommand command)
    {
        var worker = await workerRepository.FindByIdAsync(command.Id);
        if (worker is null) return null;

        worker.UpdateInformation(command.FirstName, command.LastName, command.Specialization, command.PhotoUrl);

        try
        {
            workerRepository.Update(worker);
            await unitOfWork.CompleteAsync();
        }
        catch (Exception)
        {
            return null;
        }

        return worker;
    }
    
    public async Task<Worker?> Handle(DeleteWorkerCommand command)
    {
        var worker = await workerRepository.FindByIdAsync(command.Id);
        if (worker is null) return null;

        try
        {
            workerRepository.Remove(worker);
            await unitOfWork.CompleteAsync();
        }
        catch (Exception)
        {
            return null;
        }

        return worker;
    }
}