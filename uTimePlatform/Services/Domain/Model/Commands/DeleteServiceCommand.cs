namespace uTimePlatform.Services.Domain.Model.Commands;

public record DeleteServiceCommand
{
    public int Id { get; }

    public DeleteServiceCommand(int id)
    {
        if (id <= 0)
            throw new ArgumentException("Service ID must be a positive number", nameof(id));
        Id = id;
    }
};