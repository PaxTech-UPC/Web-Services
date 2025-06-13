using uTimePlatform.Profiles.Domain.Model.Commands;
using uTimePlatform.Profiles.Domain.Model.ValueObjects;

namespace uTimePlatform.Profiles.Domain.Model.Aggregates;

public class Client
{
    public int Id { get; private set; }

    public PersonName Name { get; private set; }

    public string FullName => Name.FullName;

    public Client()
    {
        Name = new PersonName();
    }

    public Client(string firstname, string lastname)
    {
        Name = new PersonName(firstname, lastname);
    }

    public Client(CreateClientCommand command)
    {
        Name = new PersonName(command.FirstName, command.LastName);
    }
}