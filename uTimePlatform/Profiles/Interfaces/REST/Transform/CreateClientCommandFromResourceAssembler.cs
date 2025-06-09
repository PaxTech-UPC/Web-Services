using uTimePlatform.Profiles.Domain.Model.Commands;
using uTimePlatform.Profiles.Interfaces.REST.Resources;

namespace uTimePlatform.Profiles.Interfaces.REST.Transform;

public static class CreateClientCommandFromResourceAssembler
{

    public static CreateClientCommand ToCommandFromResource(CreateClientResource resource) =>
        new CreateClientCommand(resource.FirstName, resource.LastName, resource.Email, resource.BirthDate);  
}
