namespace uTimePlatform.Workers.Domain.Model.Commands;

public record UpdateWorkerCommand(int id, string name, string specialization, string photoUrl);