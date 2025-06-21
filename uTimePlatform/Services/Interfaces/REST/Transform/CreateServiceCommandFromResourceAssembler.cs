using uTimePlatform.Services.Domain.Model.Commands;
using uTimePlatform.Services.Interfaces.REST.Resources;

namespace uTimePlatform.Services.Interfaces.REST.Transform;

public static class CreateServiceCommandFromResourceAssembler
{
    public static CreateServiceCommand ToCommandFromResource(CreateServiceResource resource)
    {
        return new CreateServiceCommand(
            resource.Name,
            resource.Duration,
            resource.Price,
            resource.Status,
            resource.SalonId,
            resource.Description
        );
    }
}