using uTimePlatform.IAM.Domain.Model.Aggregates;
using uTimePlatform.Profiles.Domain.Model.Commands;
using uTimePlatform.Profiles.Domain.Model.ValueObjects;

namespace uTimePlatform.Profiles.Domain.Model.Aggregates;

public class Client
{
    public int Id { get; private set; }

    public PersonName Name { get; private set; }

    public string FullName => Name.FullName;
    
    public int UserId { get; private set; }
    public User User { get; private set; }

    public Client()
    {
        Name = new PersonName();
    }

    public Client(string firstname, string lastname, int userId)
    {
        Name = new PersonName(firstname, lastname);
        UserId = userId;
    }

    public Client(CreateClientCommand command)
    {
        Name = new PersonName(command.FirstName, command.LastName);
        UserId = command.UserId;
    }
}