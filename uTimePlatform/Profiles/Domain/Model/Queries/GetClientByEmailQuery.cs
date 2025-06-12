using uTimePlatform.Profiles.Domain.Model.ValueObjects;

namespace uTimePlatform.Profiles.Domain.Model.Queries;

public record GetClientByEmailQuery(EmailAddress Email);