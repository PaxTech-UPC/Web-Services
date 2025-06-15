namespace uTimePlatform.Workers.Domain.Model.Commands;

public record UpdateWorkerCommand(long id, String name, String specialization, String photoUrl);