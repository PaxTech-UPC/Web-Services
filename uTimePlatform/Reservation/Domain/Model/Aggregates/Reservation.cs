using uTimePlatform.Profiles.Domain.Model.Aggregates;
using uTimePlatform.Reservation.Domain.Model.Commands;
using uTimePlatform.Reservation.Domain.Model.ValueObjects;
using uTimePlatform.Workers.Domain.Model.Aggregates;

namespace uTimePlatform.Reservation.Domain.Model.Aggregates;

public class Reservation
{
    /* Falta services */
    
    public int Id { get; private set; }
    public int SalonId { get; private set; }

    public int ClientId { get; private set; }
    public Client Client { get; private set; } = null!;
    public int PaymentId { get; private set; }
    public Payments Payment { get; private set; } = null!;

    public int TimeSlotId { get; private set; }
    public TimeSlots TimeSlot { get; private set; } = null!;

    public int WorkerId { get; private set; }
    public Worker Worker { get; private set; } = null!;
    
    public Reservation() { }

    public Reservation(CreateReservationCommand command)
    {
        SalonId = command.SalonId;
        ClientId = command.ClientId;
        PaymentId = command.PaymentId;
        TimeSlotId = command.TimeSlotId;
        WorkerId = command.WorkerId;
    }
}