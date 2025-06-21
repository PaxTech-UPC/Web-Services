using uTimePlatform.Profiles.Domain.Model.Aggregates;
using uTimePlatform.Profiles.Domain.Model.Queries;

namespace uTimePlatform.Profiles.Domain.Services;

public interface IClientQueryService
{
    Task<IEnumerable<Client>> Handle(GetAllClientsQuery query);

    Task<Client?> Handle(GetClientByIdQuery query);
    
}