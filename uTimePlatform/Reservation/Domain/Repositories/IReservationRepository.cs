using uTimePlatform.Reservation.Domain.Model.Aggregates;
using uTimePlatform.Shared.Domain.Repositories;

namespace uTimePlatform.Reservation.Domain.Repositories;

public interface IReservationRepository : IBaseRepository<Model.Aggregates.Reservation>
{
    Task<List<Model.Aggregates.Reservation>> FindAllAsync();
}