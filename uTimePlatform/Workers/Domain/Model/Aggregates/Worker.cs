using uTimePlatform.Workers.Domain.Model.Aggregates;
using uTimePlatform.Workers.Domain.Model.Commands;
using uTimePlatform.Workers.Domain.Model.ValueObjects;

namespace uTimePlatform.Workers.Domain.Model.Aggregates;

public class Worker
{
    public int Id { get; private set; }

    public PersonName Name { get; private set; }

    public string FullName => Name.FullName;
    public string Specialization { get; private set; }

    public string PhotoUrl { get; private set; }

    public Worker()
    {
        Name = new PersonName();
        Specialization = string.Empty;
        PhotoUrl = string.Empty;
    }

    public Worker(string firstName, string lastName, string specialization, string photoUrl)
    {
        Name = new PersonName(firstName, lastName);
        Specialization = specialization;
        PhotoUrl = photoUrl;
    }

    public Worker(CreateWorkerCommand command)
    {
        Name = new PersonName(command.FirstName, command.LastName);
        Specialization = command.specialization;
        PhotoUrl = command.photoUrl;
    }
    public void UpdateInformation(string firstName, string lastName, string specialization, string photoUrl)
    {
        Name = new PersonName(firstName, lastName);
        Specialization = specialization;
        PhotoUrl = photoUrl;
    }


}