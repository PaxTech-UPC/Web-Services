using uTimePlatform.Reviews.Domain.Model.Aggregates;
using uTimePlatform.Reviews.Interfaces.REST.Resources;

namespace uTimePlatform.Reviews.Interfaces.REST.Transform;

public static class ReviewResourceFromEntityAssembler
{
    public static ReviewResource ToResourceFromEntity(Review entity) =>
        new ReviewResource(
            entity.Id,
            entity.ProviderResponse ?? string.Empty // Puede ser null ya que puede o no resppnder el proveedor
        );
}