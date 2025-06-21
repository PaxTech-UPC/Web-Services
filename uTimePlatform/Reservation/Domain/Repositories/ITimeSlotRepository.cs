using uTimePlatform.Reservation.Domain.Model.Aggregates;
using uTimePlatform.Shared.Domain.Repositories;

namespace uTimePlatform.Reservation.Domain.Repositories;

public interface ITimeSlotRepository : IBaseRepository<TimeSlots>
{
    Task<List<TimeSlots>> FindAllAsync();
}