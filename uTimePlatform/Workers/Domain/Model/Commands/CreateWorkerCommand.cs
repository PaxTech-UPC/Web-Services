namespace uTimePlatform.Workers.Domain.Model.Commands;

public record CreateWorkerCommand(String name, String specialization, String photoUrl);