using uTimePlatform.Reservation.Domain.Model.Aggregates;
using uTimePlatform.Reservation.Domain.Model.Queries;

namespace uTimePlatform.Reservation.Domain.Services;

public interface ITimeSlotQueryService
{
    Task<TimeSlots?> Handle(GetTimeSlotByIdQuery  query);
    Task<IEnumerable<TimeSlots>?> Handle (GetAllTimeSlotsQuery query);
}