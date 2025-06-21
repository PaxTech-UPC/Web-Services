using uTimePlatform.Workers.Domain.Model.Aggregates;
using uTimePlatform.Workers.Domain.Model.Queries;

namespace uTimePlatform.Workers.Domain.Services;

public interface IWorkerQueryService
{
    Task<IEnumerable<Worker>> Handle(GetAllWorkerQuery query);

    Task<Worker?> Handle(GetWorkerByIdQuery query);
    
    Task<Worker?> Handle(GetWorkersBySalonIdQuery query);
}