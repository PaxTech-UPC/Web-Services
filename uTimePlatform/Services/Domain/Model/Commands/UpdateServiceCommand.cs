namespace uTimePlatform.Services.Domain.Model.Commands;

public record UpdateServiceCommand(int Id, string Name, int Duration, int Price, bool Status, string Description);