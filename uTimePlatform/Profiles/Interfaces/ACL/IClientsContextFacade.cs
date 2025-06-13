
namespace uTimePlatform.Profiles.Interfaces.ACL;

public interface IClientsContextFacade
{
    Task<int> CreateClient(
        string firstName, 
        string lastName);
    
}