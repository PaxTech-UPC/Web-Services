using uTimePlatform.Workers.Domain.Model.Aggregates;

namespace uTimePlatform.Workers.Interfaces.ACL;

public interface IWorkerContextFacade
{
    Task<int> CreateWorker(string name, string specialization, string phoneNumber, string photoUrl);
    Task<Worker?> GetWorkerByIdAsync(int id);

}