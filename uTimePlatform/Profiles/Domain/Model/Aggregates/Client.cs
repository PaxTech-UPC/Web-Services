using uTimePlatform.Profiles.Domain.Model.Commands;
using uTimePlatform.Profiles.Domain.Model.ValueObjects;

namespace uTimePlatform.Profiles.Domain.Model.Aggregates;

public class Client
{
    public int Id { get; private set; }

    public PersonName Name { get; private set; }
    public EmailAddress Email { get; private set; }
    public BirthDate BirthDate { get; private set; }

    public string FullName => Name.FullName;
    public string EmailAddress => Email.Address;
    public string BirthDateString => BirthDate.FormattedDate;

    public Client()
    {
        Name = new PersonName();
        Email = new EmailAddress();
        BirthDate = new BirthDate();
    }

    public Client(string firstname, string lastname, string email, string birthdate)
    {
        Name = new PersonName(firstname, lastname);
        Email = new EmailAddress(email);
        var parsedDate = DateTime.Parse(birthdate).ToUniversalTime();
        BirthDate = new BirthDate(parsedDate);
    }

    public Client(CreateClientCommand command)
    {
        Name = new PersonName(command.FirstName, command.LastName);
        Email = new EmailAddress(command.Email);
        BirthDate = new BirthDate(command.BirthDate.ToUniversalTime());
    }
}