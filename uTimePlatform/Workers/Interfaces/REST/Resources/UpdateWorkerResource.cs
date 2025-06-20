namespace uTimePlatform.Workers.Interfaces.REST.Resources;

public record UpdateWorkerResource(
    string FirstName,
    string LastName,
    string Specialization,
    string PhotoUrl
);