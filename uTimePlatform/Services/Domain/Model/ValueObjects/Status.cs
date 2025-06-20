namespace uTimePlatform.Services.Domain.Model.ValueObjects;

public record Status
{
    public bool Value { get; }

    public Status() => Value = true; // o false por defecto, tú decides

    public Status(bool value) => Value = value;
}