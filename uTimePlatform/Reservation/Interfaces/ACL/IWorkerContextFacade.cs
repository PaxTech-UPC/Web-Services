using uTimePlatform.Workers.Domain.Model.Aggregates;

namespace uTimePlatform.Reservation.Interfaces.ACL;

public interface IWorkerContextFacade
{
    Task<Worker?> GetWorkerByIdAsync(int id);
}