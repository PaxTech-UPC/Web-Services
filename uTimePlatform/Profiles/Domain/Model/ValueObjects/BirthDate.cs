using Google.Protobuf.WellKnownTypes;

namespace uTimePlatform.Profiles.Domain.Model.ValueObjects;

public record BirthDate
{
    public DateTime Value { get; }

    public BirthDate() : this(DateTime.UtcNow) {}

    public BirthDate(DateTime value)
    {
        if (value > DateTime.UtcNow)
            throw new ArgumentException("Birth date cannot be in the future.");

        Value = value;
    }

    // Constructor que recibe un Timestamp (para convertirlo internamente a DateTime)
    public BirthDate(Timestamp timestamp) : this(timestamp.ToDateTime()) {}

    public BirthDate(string date)
    {
        if (!DateTime.TryParse(date, out var parsedDate))
            throw new ArgumentException("Invalid date format.");

        if (parsedDate > DateTime.UtcNow)
            throw new ArgumentException("Birth date cannot be in the future.");

        Value = parsedDate.ToUniversalTime();
    }

    public Timestamp ToTimestamp() => Timestamp.FromDateTime(Value);

    public int Age
    {
        get
        {
            var birthDate = Value;
            var today = DateTime.UtcNow.Date;
            int age = today.Year - birthDate.Year;
            if (birthDate.Date > today.AddYears(-age)) age--;
            return age;
        }
    }

    public bool IsAdult => Age >= 18;

    public string FormattedDate => Value.ToString("yyyy-MM-dd");
}