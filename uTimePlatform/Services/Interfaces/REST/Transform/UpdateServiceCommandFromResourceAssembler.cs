using uTimePlatform.Services.Domain.Model.Commands;
using uTimePlatform.Services.Interfaces.REST.Resources;

namespace uTimePlatform.Services.Interfaces.REST.Transform;

public static class UpdateServiceCommandFromResourceAssembler
{
    public static UpdateServiceCommand ToCommandFromResource(int id, UpdateServiceResource resource)
    {
        return new UpdateServiceCommand(
            id,
            resource.Name,
            resource.Duration,
            resource.Price,
            resource.Status,
            resource.Description
        );
    }
}