using uTimePlatform.Profiles.Domain.Model.Aggregates;
using uTimePlatform.Profiles.Interfaces.ACL;
using uTimePlatform.Reservation.Interfaces.ACL;

namespace uTimePlatform.Reservation.Application.ACL;

public class ProviderContextFacadeAdapter : IProviderContextFacade
{
    private readonly IProvidersContextFacade _providersContext;

    public ProviderContextFacadeAdapter(IProvidersContextFacade providersContext)
    {
        _providersContext = providersContext;
    }

    public async Task<Provider?> GetProviderByIdAsync(int id)
    {
        return await _providersContext.GetProviderByIdAsync(id);
    }
}