using uTimePlatform.Profiles.Domain.Model.Commands;

namespace uTimePlatform.Profiles.Domain.Model.Aggregates;

public class Client
{
    public int Id { get; private set;  }

    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string Email { get; private set; }
    public DateTime BirthDate { get; private set; }
    
    
    protected Client()
    {
        FirstName = string.Empty;
        LastName = string.Empty;
        Email = string.Empty;
        BirthDate = DateTime.Now;
    }

    public Client(CreateClientCommand command)
    {
        FirstName = command.FirstName;
        LastName = command.LastName;
        Email = command.Email;
        BirthDate = command.BirthDate;
    }
}