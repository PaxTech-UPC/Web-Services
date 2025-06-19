using uTimePlatform.Profiles.Domain.Model.Aggregates;
using uTimePlatform.Reviews.Domain.Model.Aggregates;
using uTimePlatform.Reviews.Domain.Model.Commands;
using uTimePlatform.Reviews.Domain.Model.ValueObjects;

namespace uTimePlatform.Reviews.Domain.Model.Aggregates;


public class Review
{
    public int Id { get; private set; }
    public int SalonId { get; private set; } // FK a salon o proveedor
    public Provider Salon  { get; private set; }
    public int ClientId { get; private set; } // FK a cliente
    public Client Client { get; private set; }
    public int Rating { get; private set; }
    public Comment Comment { get; private set; }    // Value Object
    
    public bool Read { get; private set; }
    public string? ProviderResponse { get; private set; } // Opcional por si el proveedor o salon responde

    public Review()
    {
        Comment = new Comment();
    }
    
    public Review(CreateReviewCommand command)
    {
        SalonId = command.ProviderId;
        ClientId = command.ClientId;
        Comment = new Comment(command.Content);
        Rating = command.Rating;
        Read = false;
    }
    
    public void MarkAsRead() => Read = true;
    public void Respond(string providerResponse) => ProviderResponse = providerResponse;
}