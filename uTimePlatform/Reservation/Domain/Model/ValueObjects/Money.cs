namespace uTimePlatform.Reservation.Domain.Model.ValueObjects;

public record Money
{
    public decimal Amount { get; }
    public string Currency { get; }
    
    public Money() : this(0m,  string.Empty) { }

    public Money(decimal Amount, string Currency)
    {
        this.Amount = Amount;
        this.Currency = Currency;
    }
}