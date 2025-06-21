using uTimePlatform.Services.Domain.Model.Commands;
using uTimePlatform.Services.Domain.Model.ValueObjects;
namespace uTimePlatform.Services.Domain.Model.Aggregates;

public class Service
{
    public int Id { get; private set; }

    public Name Name { get; private set; }
    public Duration Duration { get; private set; }
    public Price Price { get; private set; }
    public Status Status { get; private set; }
    public SalonId SalonId { get; private set; }
    public string Description { get; private set; }

    // Constructor por defecto
    public Service()
    {
        Name = new Name();
        Duration = new Duration();
        Price = new Price();
        Status = new Status();
        SalonId = new SalonId();
        Description = string.Empty;
    }

    // Constructor manual
    public Service(string name, int duration, int price, bool status, int salonId, string description)
    {
        Name = new Name(name);
        Duration = new Duration(duration);
        Price = new Price(price);
        Status = new Status(status);
        SalonId = new SalonId(salonId);
        Description = description;
    }
    
    public Service(CreateServiceCommand command)
    {
        Name = new Name(command.Name);
        Duration = new Duration(command.Duration);
        Price = new Price(command.Price);
        Status = new Status(command.Status);
        SalonId = new SalonId(command.SalonId);
        Description = command.Description;
    }

    public void UpdateInformation(string name, int duration, int price, bool status, string description)
    {
        Name = new Name(name);
        Duration = new Duration(duration);
        Price = new Price(price);
        Status = new Status(status);
        Description = description;
    }
}