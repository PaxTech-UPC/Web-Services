using uTimePlatform.Services.Domain.Model.Aggregates;
using uTimePlatform.Services.Interfaces.REST.Resources;

namespace uTimePlatform.Services.Interfaces.REST.Transform;

public static class ServiceResourceFromEntityAssembler
{
    public static ServiceResource ToResourceFromEntity(Service entity)
    {
        return new ServiceResource(
            entity.Id,
            entity.Name.Value,
            entity.Duration.Value,
            entity.Price.Value,
            entity.Status.Value,
            entity.SalonId.Value,
            entity.Description
        );
    }
}