using uTimePlatform.Workers.Domain.Model.Aggregates;
using uTimePlatform.Workers.Interfaces.REST.Resources;

namespace uTimePlatform.Workers.Interfaces.REST.Transform;

public static class WorkerResourceFromEntityAssembler
{
    public static WorkerResource ToResourceFromEntity(Worker entity) =>
        new WorkerResource(entity.Id, entity.Name.FirstName, entity.Name.LastName, entity.Specialization, entity.PhotoUrl);
}