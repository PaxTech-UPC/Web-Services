using uTimePlatform.Workers.Domain.Model.Commands;
using uTimePlatform.Workers.Interfaces.REST.Resources;

namespace uTimePlatform.Workers.Interfaces.REST.Transform;

public static class CreateWorkerCommandFromResourceAssembler
{
    public static CreateWorkerCommand ToCommandFromResource(CreateWorkerResource resource) =>
        new CreateWorkerCommand(
            resource.FirstName,
            resource.LastName,
            resource.Specialization,
            resource.PhotoUrl
        );
}