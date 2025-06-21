using uTimePlatform.Profiles.Domain.Model.Aggregates;
using uTimePlatform.Profiles.Domain.Model.Queries;

namespace uTimePlatform.Profiles.Domain.Services;

public interface IProviderQueryService
{
    Task<IEnumerable<Provider>> Handle(GetAllProvidersQuery query);

    Task<Provider?> Handle(GetProviderByIdQuery query);

}