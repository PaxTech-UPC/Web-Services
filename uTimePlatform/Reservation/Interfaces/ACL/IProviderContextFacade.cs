using uTimePlatform.Profiles.Domain.Model.Aggregates;

namespace uTimePlatform.Reservation.Interfaces.ACL;

public interface IProviderContextFacade
{
    Task<Provider?> GetProviderByIdAsync(int id);
}