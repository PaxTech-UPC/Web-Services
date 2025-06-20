using uTimePlatform.Reservation.Domain.Model.Aggregates;
using uTimePlatform.Shared.Domain.Repositories;

namespace uTimePlatform.Reservation.Domain.Repositories;

public interface IPaymentRepository : IBaseRepository<Payments>
{
    Task<List<Payments>> FindAllAsync();
}