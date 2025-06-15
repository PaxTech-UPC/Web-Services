namespace uTimePlatform.Workers.Interfaces.ACL;

public interface IWorkerContextFacade
{
    Task<int> CreateWorker(string name, string specialization, string phoneNumber);
}