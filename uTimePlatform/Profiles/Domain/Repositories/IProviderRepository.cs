using uTimePlatform.Profiles.Domain.Model.Aggregates;
using uTimePlatform.Shared.Domain.Repositories;

namespace uTimePlatform.Profiles.Domain.Repositories;

public interface IProviderRepository: IBaseRepository<Provider>
{
    Task<IEnumerable<Provider>> FindAllAsync();

}