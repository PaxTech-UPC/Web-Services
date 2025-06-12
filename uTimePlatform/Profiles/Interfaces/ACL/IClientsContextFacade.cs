
namespace uTimePlatform.Profiles.Interfaces.ACL;

public interface IClientsContextFacade
{
    Task<int> CreateClient(
        string firstName, 
        string lastName, 
        string email, 
        DateTime birthDate);
    
    Task<int> FetchClientIdByEmail(string email);
}