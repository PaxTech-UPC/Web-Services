namespace uTimePlatform.Services.Domain.Model.ValueObjects;

public record SalonId
{
    public int Value { get; }

    public SalonId() => Value = 0;

    public SalonId(int value)
    {
        if (value < 0)
            throw new ArgumentException("Salon ID must be non-negative", nameof(value));
        Value = value;
    }
}