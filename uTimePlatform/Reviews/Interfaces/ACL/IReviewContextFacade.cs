using uTimePlatform.Reviews.Domain.Model.ValueObjects;

namespace uTimePlatform.Reviews.Interfaces.ACL;

public interface IClientsContextFacade
{
    Task<bool> ClientExistsAsync(Guid clientId);
}