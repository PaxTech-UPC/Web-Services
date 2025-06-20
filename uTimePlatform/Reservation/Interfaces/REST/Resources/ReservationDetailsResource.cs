using uTimePlatform.Profiles.Interfaces.REST.Resources;
using uTimePlatform.Workers.Interfaces.REST.Resources;

namespace uTimePlatform.Reservation.Interfaces.REST.Resources;

public record ReservationDetailsResource(
        int Id,
        int ClientId,
        ProviderResource Provider,
        PaymentResource Payment,
        TimeSlotResource TimeSlot,
        WorkerResource Worker
    );