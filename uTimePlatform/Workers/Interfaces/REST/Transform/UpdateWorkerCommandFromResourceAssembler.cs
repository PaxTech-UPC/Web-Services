using uTimePlatform.Workers.Domain.Model.Commands;
using uTimePlatform.Workers.Interfaces.REST.Resources;

namespace uTimePlatform.Workers.Interfaces.REST.Transform;

public static class UpdateWorkerCommandFromResourceAssembler
{
    public static UpdateWorkerCommand ToCommandFromResource(int id, UpdateWorkerResource resource)
    {
        return new UpdateWorkerCommand(id, resource.FirstName, resource.LastName, resource.Specialization, resource.PhotoUrl);
    }
}