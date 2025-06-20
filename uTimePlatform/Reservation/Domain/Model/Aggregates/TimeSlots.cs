using uTimePlatform.Reservation.Domain.Model.Commands;
using uTimePlatform.Reservation.Domain.Model.ValueObjects;

namespace uTimePlatform.Reservation.Domain.Model.Aggregates;

public class TimeSlots
{
    public int Id { get; private set; }
    public DateTime startTime { get; private set; }
    public DateTime endTime { get; private set; }
    public bool status { get; private set; }
    public TimeSlotType Type { get; private set; }

    public TimeSlots() { }

    public TimeSlots(CreateTimeSlotCommand command)
    {
        startTime = command.startTime;
        endTime = command.endTime;
        status = command.status;
        Type = new TimeSlotType(command.type);
    }
}