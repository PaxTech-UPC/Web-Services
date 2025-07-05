using uTimePlatform.Profiles.Domain.Model.Aggregates;
using uTimePlatform.Profiles.Domain.Model.Commands;
using uTimePlatform.Profiles.Domain.Model.Queries;
using uTimePlatform.Profiles.Domain.Services;
using uTimePlatform.Profiles.Interfaces.ACL;

namespace uTimePlatform.Profiles.Application.ACL;

public class ProvidersContextFacade(
    IProviderCommandService providerCommandService,
    IProviderQueryService providerQueryService
) : IProvidersContextFacade
{
    public async Task<int> CreateClient(string companyName, int userId)
    {
        var command = new CreateProviderCommand(companyName, userId);
        var provider = await providerCommandService.Handle(command);
        return provider?.Id ?? 0;
    }
    
    public async Task<Provider?> GetProviderByIdAsync(int id)
    {
        var query = new GetProviderByIdQuery(id);
        return await providerQueryService.Handle(query);
    }
    
}