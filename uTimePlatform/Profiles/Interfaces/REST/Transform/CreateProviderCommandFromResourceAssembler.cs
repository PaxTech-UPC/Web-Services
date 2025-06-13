using uTimePlatform.Profiles.Domain.Model.Commands;
using uTimePlatform.Profiles.Interfaces.REST.Resources;

namespace uTimePlatform.Profiles.Interfaces.REST.Transform;

public static class CreateProviderCommandFromResourceAssembler
{

    public static CreateProviderCommand ToCommandFromResource(CreateProviderResource resource) =>
        new CreateProviderCommand(
            resource.CompanyName
        );  
}