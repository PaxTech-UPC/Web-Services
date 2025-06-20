namespace uTimePlatform.Reservation.Domain.Model.ValueObjects;

public record TimeSlotType
{
    public string Type { get; }
    
    public TimeSlotType() : this(string.Empty) { }

    public TimeSlotType(string Type)
    {
        this.Type = Type;
    }
}