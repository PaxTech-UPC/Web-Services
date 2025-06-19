using uTimePlatform.IAM.Domain.Model.Aggregates;
using uTimePlatform.Profiles.Domain.Model.Commands;
using uTimePlatform.Profiles.Domain.Model.ValueObjects;
using uTimePlatform.Reviews.Domain.Model.Aggregates;

namespace uTimePlatform.Profiles.Domain.Model.Aggregates;

public class Provider
{
    public int Id { get; private set; }
    public CompanyName Name { get; private set; }
    
    public ICollection<Review> Reviews { get; private set; } = new List<Review>();
    
    public int UserId { get; private set; }
    public User User { get; private set; }

    public Provider()
    {
        Name = new CompanyName();
    }

    public Provider(string companyName, int userId)
    {
        Name = new CompanyName(companyName);
        UserId = userId;
    }

    public Provider(CreateProviderCommand command)
    {
        Name = new CompanyName(command.CompanyName);
        UserId = command.UserId;
    }

    public void UpdateName(string companyName)
    {
        Name = new CompanyName(companyName);
    }
}