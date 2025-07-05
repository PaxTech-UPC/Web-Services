namespace uTimePlatform.Workers.Domain.Model.Commands;

public record CreateWorkerCommand(
    string FirstName,
    string LastName, 
    string specialization, 
    string photoUrl,
    int ProviderId);