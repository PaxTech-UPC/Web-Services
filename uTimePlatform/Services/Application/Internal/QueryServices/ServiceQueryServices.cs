using uTimePlatform.Services.Domain.Model.Aggregates;
using uTimePlatform.Services.Domain.Model.Queries;
using uTimePlatform.Services.Domain.Repositories;
using uTimePlatform.Services.Domain.Services;

namespace uTimePlatform.Services.Application.Internal.QueryServices;

public class ServiceQueryService(IServiceRepository serviceRepository)
    : IServiceQueryService
{
    public async Task<IEnumerable<Service>> Handle(GetAllServicesQuery query)
    {
        return await serviceRepository.FindAllAsync();
    }

    public async Task<Service?> Handle(GetServiceById query)
    {
        return await serviceRepository.FindByIdAsync(query.Id); 
    }

    public async Task<IEnumerable<Service>> Handle(GetServiceBySalonIdQuery query)
    {
        return await serviceRepository.FindBySalonIdAsync(query.SalonId); 
    }
}