using uTimePlatform.Services.Domain.Model.Aggregates;
using uTimePlatform.Services.Domain.Model.Queries;

namespace uTimePlatform.Services.Domain.Services;

public interface IServiceQueryService
{
    Task<IEnumerable<Service>> Handle(GetAllServicesQuery query);
    Task<IEnumerable<Service>> Handle(GetServiceBySalonIdQuery query);
    Task<Service?> Handle(GetServiceById query);
}