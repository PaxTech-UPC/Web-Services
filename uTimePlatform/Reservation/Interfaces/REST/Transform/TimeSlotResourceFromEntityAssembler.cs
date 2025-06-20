using uTimePlatform.Reservation.Domain.Model.Aggregates;
using uTimePlatform.Reservation.Interfaces.REST.Resources;

namespace uTimePlatform.Reservation.Interfaces.REST.Transform;

public static class TimeSlotResourceFromEntityAssembler
{
    public static TimeSlotResource ToResourceFromEntity(TimeSlots timeSlot)
    {
        return new TimeSlotResource(
            timeSlot.Id,
            timeSlot.startTime,
            timeSlot.endTime,
            timeSlot.status,
            timeSlot.Type.Type // Si `Type` es un ValueObject con propiedad `Type`
        );
    }
}