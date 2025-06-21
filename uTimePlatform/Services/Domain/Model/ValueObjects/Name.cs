namespace uTimePlatform.Services.Domain.Model.ValueObjects;

public record Name
{
    public string Value { get; }

    public Name() => Value = string.Empty;

    public Name(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("Name cannot be empty", nameof(value));
        Value = value;
    }

    public override string ToString() => Value;
}