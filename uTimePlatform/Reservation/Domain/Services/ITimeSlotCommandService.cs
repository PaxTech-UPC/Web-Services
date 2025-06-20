using uTimePlatform.Reservation.Domain.Model.Aggregates;
using uTimePlatform.Reservation.Domain.Model.Commands;

namespace uTimePlatform.Reservation.Domain.Services;

public interface ITimeSlotCommandService
{
    Task<TimeSlots?> Handle(CreateTimeSlotCommand command);
}