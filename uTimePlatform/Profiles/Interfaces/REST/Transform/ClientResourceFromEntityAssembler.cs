using uTimePlatform.Profiles.Domain.Model.Aggregates;
using uTimePlatform.Profiles.Interfaces.REST.Resources;

namespace uTimePlatform.Profiles.Interfaces.REST.Transform;

public static class ClientResourceFromEntityAssembler
{
    public static ClientResource ToResourceFromEntity(Client entity) =>
        new ClientResource(entity.Id, entity.FirstName, entity.LastName, entity.Email, entity.BirthDate);
}