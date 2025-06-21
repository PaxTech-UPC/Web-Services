using uTimePlatform.Services.Domain.Model.Aggregates;
using uTimePlatform.Shared.Domain.Repositories;

namespace uTimePlatform.Services.Domain.Repositories;

public interface IServiceRepository : IBaseRepository<Service>
{
    Task<IEnumerable<Service>> FindAllAsync();
    Task<IEnumerable<Service>> FindBySalonIdAsync(int salonId);
}