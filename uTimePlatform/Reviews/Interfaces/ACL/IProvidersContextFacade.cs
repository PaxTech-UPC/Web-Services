namespace uTimePlatform.Reviews.Interfaces.ACL;

public interface IProvidersContextFacade
{
    Task<bool> ProviderExistsAsync(Guid providerId);
}