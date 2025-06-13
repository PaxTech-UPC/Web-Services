using uTimePlatform.Profiles.Domain.Model.Aggregates;
using uTimePlatform.Profiles.Interfaces.REST.Resources;

namespace uTimePlatform.Profiles.Interfaces.REST.Transform;

public static class ProviderResourceFromEntityAssembler
{
    public static ProviderResource ToResourceFromEntity(Provider entity) =>
        new ProviderResource(
            entity.Id,
            entity.Name.Value
        );
}