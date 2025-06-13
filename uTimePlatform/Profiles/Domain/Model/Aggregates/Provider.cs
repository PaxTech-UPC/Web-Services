using uTimePlatform.Profiles.Domain.Model.Commands;
using uTimePlatform.Profiles.Domain.Model.ValueObjects;

namespace uTimePlatform.Profiles.Domain.Model.Aggregates;

public class Provider
{
    public int Id { get; private set; }
    public CompanyName Name { get; private set; }

    public Provider()
    {
        Name = new CompanyName();
    }

    public Provider(string companyName)
    {
        Name = new CompanyName(companyName);
    }

    public Provider(CreateProviderCommand command)
    {
        Name = new CompanyName(command.CompanyName);
    }

    public void UpdateName(string companyName)
    {
        Name = new CompanyName(companyName);
    }
}