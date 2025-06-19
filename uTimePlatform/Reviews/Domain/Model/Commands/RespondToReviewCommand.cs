namespace uTimePlatform.Reviews.Domain.Model.Commands;

public record RespondToReviewCommand(
    int ReviewId, // ID de una reseña ya existente
    string? Response // La respuesta que dará el proveedor
);