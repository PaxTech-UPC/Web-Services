using uTimePlatform.Profiles.Domain.Model.Aggregates;
using uTimePlatform.Profiles.Domain.Model.Queries;
using uTimePlatform.Profiles.Domain.Repositories;
using uTimePlatform.Profiles.Domain.Services;

namespace uTimePlatform.Profiles.Application.Internal.QueryServices;

public class ProviderQueryService(IProviderRepository providerRepository)
    : IProviderQueryService
{
    public async Task<IEnumerable<Provider>> Handle(GetAllProvidersQuery query)
    {
        return await providerRepository.FindAllAsync();
    }

    public async Task<Provider?> Handle(GetProviderByIdQuery query)
    {
        return await providerRepository.FindByIdAsync(query.Id);
    }
        
}