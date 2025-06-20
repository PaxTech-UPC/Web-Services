namespace uTimePlatform.Services.Domain.Model.ValueObjects;

public record Duration
{
    public int Value { get; }

    public Duration() => Value = 0;

    public Duration(int value)
    {
        if (value < 0)
            throw new ArgumentException("Duration must be non-negative", nameof(value));
        Value = value;
    }
}