namespace uTimePlatform.Workers.Domain.Model.Commands;

public record UpdateWorkerCommand(int Id, string FirstName, string LastName, string Specialization, string PhotoUrl);
