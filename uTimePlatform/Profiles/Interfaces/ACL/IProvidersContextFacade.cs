namespace uTimePlatform.Profiles.Interfaces.ACL;

public interface IProvidersContextFacade
{
    Task<int> CreateClient(string companyName, int userId);
}
