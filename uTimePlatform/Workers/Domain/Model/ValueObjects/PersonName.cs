namespace uTimePlatform.Workers.Domain.Model.ValueObjects;

public record PersonName(string FirstName, string LastName)
{
    public PersonName() : this(String.Empty, String.Empty){}
    
    public PersonName(string firstName): this(firstName,string.Empty){}
    
    public string FullName => $"{FirstName} {LastName}";
}