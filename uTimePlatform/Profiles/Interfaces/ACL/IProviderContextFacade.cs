namespace uTimePlatform.Profiles.Interfaces.ACL;

public interface IProviderContextFacade
{
    Task<int> CreateClient(
        string companyName);
}