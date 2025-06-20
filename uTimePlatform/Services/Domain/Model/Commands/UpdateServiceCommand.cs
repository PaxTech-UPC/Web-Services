namespace uTimePlatform.Services.Domain.Model.Commands;

public record UpdateServiceCommand(string Name, int Duration, int Price, bool Status, string Description);