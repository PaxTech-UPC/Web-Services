using uTimePlatform.Workers.Domain.Model.Aggregates;
using uTimePlatform.Shared.Domain.Repositories;

namespace uTimePlatform.Workers.Domain.Repositories;

public interface IWorkerRepository: IBaseRepository<Worker>
{
    Task<IEnumerable<Worker>> FindAllAsync();
    
}