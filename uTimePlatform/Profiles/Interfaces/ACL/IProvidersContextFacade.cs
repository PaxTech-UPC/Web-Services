using uTimePlatform.Profiles.Domain.Model.Aggregates;

namespace uTimePlatform.Profiles.Interfaces.ACL;

public interface IProvidersContextFacade
{
    Task<int> CreateClient(string companyName, int userId);
    Task<Provider?> GetProviderByIdAsync(int id);
}
