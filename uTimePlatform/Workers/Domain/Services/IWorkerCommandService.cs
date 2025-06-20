using uTimePlatform.Workers.Domain.Model.Aggregates;
using uTimePlatform.Workers.Domain.Model.Commands;

namespace uTimePlatform.Workers.Domain.Services;

public interface IWorkerCommandService
{
    Task<Worker?> Handle(CreateWorkerCommand command);
    Task<Worker?> Handle(UpdateWorkerCommand command);

    Task<Worker?> Handle(DeleteWorkerCommand command);
}