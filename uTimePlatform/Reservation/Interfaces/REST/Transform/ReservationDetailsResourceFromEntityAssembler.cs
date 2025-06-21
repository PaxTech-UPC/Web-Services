using uTimePlatform.Profiles.Domain.Model.Aggregates;
using uTimePlatform.Profiles.Interfaces.ACL;
using uTimePlatform.Profiles.Interfaces.REST.Resources;
using uTimePlatform.Profiles.Interfaces.REST.Transform;
using uTimePlatform.Reservation.Domain.Model.Queries;
using uTimePlatform.Reservation.Domain.Services;
using uTimePlatform.Reservation.Interfaces.ACL;
using uTimePlatform.Reservation.Interfaces.REST.Resources;
using uTimePlatform.Workers.Domain.Model.Aggregates;
using uTimePlatform.Workers.Interfaces.REST.Resources;
using uTimePlatform.Workers.Interfaces.REST.Transform;

namespace uTimePlatform.Reservation.Interfaces.REST.Transform;

public static class ReservationDetailsResourceFromEntityAssembler
{
    public static async Task<ReservationDetailsResource> ToResourceFromEntityAsync(
        Domain.Model.Aggregates.Reservation reservation,
        IProviderContextFacade providerFacade,
        IPaymentContextFacade paymentFacade,
        ITimeSlotQueryService timeSlotService,
        IWorkerContextFacade workerFacade)
    {
        var providerEntity = await providerFacade.GetProviderByIdAsync(reservation.SalonId);
        if (providerEntity == null) throw new Exception("Provider not found");
        var provider = ProviderResourceFromEntityAssembler.ToResourceFromEntity(providerEntity);

        var workerEntity = await workerFacade.GetWorkerByIdAsync(reservation.WorkerId);
        if (workerEntity == null) throw new Exception("Worker not found");
        var worker = WorkerResourceFromEntityAssembler.ToResourceFromEntity(workerEntity);

        var payment = await paymentFacade.GetPaymentByIdAsync(reservation.PaymentId);
        if (payment == null) throw new Exception("Payment not found");
        var paymentResource = PaymentResourceFromEntityAssembler.ToResourceFromEntity(payment);

        var timeSlot = await timeSlotService.Handle(new GetTimeSlotByIdQuery(reservation.TimeSlotId));
        if (timeSlot == null) throw new Exception("TimeSlot not found");
        var timeSlotResource = TimeSlotResourceFromEntityAssembler.ToResourceFromEntity(timeSlot);

        return new ReservationDetailsResource(
            reservation.Id,
            reservation.ClientId,
            provider,
            paymentResource,
            timeSlotResource,
            worker
        );
    }
}
