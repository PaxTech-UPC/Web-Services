using uTimePlatform.Profiles.Domain.Model.Aggregates;
using uTimePlatform.Shared.Domain.Repositories;

namespace uTimePlatform.Profiles.Domain.Repositories;

public interface IClientRepository: IBaseRepository<Client>
{
    Task<IEnumerable<Client>> FindAllAsync();

}