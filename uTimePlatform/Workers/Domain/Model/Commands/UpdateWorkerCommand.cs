namespace uTimePlatform.Workers.Domain.Model.Commands;

public record UpdateWorkerCommand(int id, String name, String specialization, String photoUrl);