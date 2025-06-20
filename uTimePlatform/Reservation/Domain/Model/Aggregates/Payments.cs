using uTimePlatform.Profiles.Domain.Model.Commands;
using uTimePlatform.Reservation.Domain.Model.Commands;
using uTimePlatform.Reservation.Domain.Model.ValueObjects;

namespace uTimePlatform.Reservation.Domain.Model.Aggregates;

public class Payments
{
    public int Id { get; private set; }
    public Money Money { get; private set; }
    public bool Status { get; private set; }
    
    public Payments() { }

    public Payments(CreatePaymentCommand command)
    {
        Money = new Money(command.Amount, command.Currency);
        Status = command.Status;
    }
}