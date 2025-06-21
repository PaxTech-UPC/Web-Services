namespace uTimePlatform.Services.Domain.Model.ValueObjects;

public record Price
{
    public int Value { get; }

    public Price() => Value = 0;

    public Price(int value)
    {
        if (value < 0)
            throw new ArgumentException("Price must be non-negative", nameof(value));
        Value = value;
    }
}