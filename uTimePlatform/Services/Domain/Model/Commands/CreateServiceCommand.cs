namespace uTimePlatform.Services.Domain.Model.Commands;

public record CreateServiceCommand(string Name, int Duration, int Price, bool Status, int SalonId, string Description);