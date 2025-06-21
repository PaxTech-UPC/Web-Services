using uTimePlatform.Profiles.Domain.Model.Commands;
using uTimePlatform.Profiles.Domain.Services;
using uTimePlatform.Profiles.Interfaces.ACL;

namespace uTimePlatform.Profiles.Application.ACL;

public class ProvidersContextFacade(
    IProviderCommandService providerCommandService
) : IProvidersContextFacade
{

    public async Task<int> CreateClient(string companyName, int userId)
    {
        var command = new CreateProviderCommand(companyName, userId);
        var provider = await providerCommandService.Handle(command);
        return provider?.Id ?? 0;
    }
}