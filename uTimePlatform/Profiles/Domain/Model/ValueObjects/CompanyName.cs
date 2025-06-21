namespace uTimePlatform.Profiles.Domain.Model.ValueObjects;

public record CompanyName(string Value)
{
    public CompanyName() : this(String.Empty){}
    
}