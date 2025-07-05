using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using uTimePlatform.IAM.Infrastructure.Pipeline.Middleware.Attributes;
using uTimePlatform.Reservation.Domain.Model.Queries;
using uTimePlatform.Reservation.Domain.Services;
using uTimePlatform.Reservation.Interfaces.ACL;
using uTimePlatform.Reservation.Interfaces.REST.Resources;
using uTimePlatform.Reservation.Interfaces.REST.Transform;
using uTimePlatform.Services.Domain.Model.ValueObjects;

namespace uTimePlatform.Reservation.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[Tags("Reservations")]
public class ReservationController(
    IReservationCommandService reservationCommandService,
    IReservationQueryService reservationQueryService,
    IProviderContextFacade providerFacade,
    IPaymentContextFacade paymentFacade,
    ITimeSlotQueryService timeSlotService,
    IWorkerContextFacade workerFacade)
    : ControllerBase
{
    [HttpPost]
    [AllowAnonymous]
    [SwaggerOperation(
        Summary = "Creates a reservation",
        Description = "Creates a reservation for a client, worker, and time slot",
        OperationId = "CreateReservation")]
    [SwaggerResponse(201, "Reservation was created", typeof(ReservationResource))]
    [SwaggerResponse(400, "Invalid request")]
    public async Task<IActionResult> Create([FromBody] CreateReservationResource resource)
    {
        var command = CreateReservationCommandFromResourceAssembler.ToCommandFromResource(resource);
        var reservation = await reservationCommandService.Handle(command);
        if (reservation == null) return BadRequest("Failed to create reservation");

        var reservationResource = ReservationResourceFromEntityAssembler.ToResourceFromEntity(reservation);

        return CreatedAtAction(nameof(GetById), new { id = reservation.Id }, reservationResource);
    }

    // GET /api/v1/reservations/{id}
    [HttpGet("{id}")]
    [AllowAnonymous]
    [SwaggerOperation(
        Summary = "Gets a reservation by ID (basic)",
        Description = "Returns basic reservation info by ID",
        OperationId = "GetReservationById")]
    [SwaggerResponse(200, "Reservation found", typeof(ReservationResource))]
    [SwaggerResponse(404, "Reservation not found")]
    public async Task<IActionResult> GetById(int id)
    {
        var query = new GetReservationByIdQuery(id);
        var reservation = await reservationQueryService.Handle(query);
        if (reservation == null) return NotFound();

        var resource = ReservationResourceFromEntityAssembler.ToResourceFromEntity(reservation);
        return Ok(resource);
    }

// GET /api/v1/reservations/{id}/details
    [HttpGet("{id}/details")]
    [AllowAnonymous]
    [SwaggerOperation(
        Summary = "Gets a reservation with full details",
        Description = "Returns reservation including provider, payment, time slot and worker info",
        OperationId = "GetReservationDetailsById")]
    [SwaggerResponse(200, "Reservation details found", typeof(ReservationDetailsResource))]
    [SwaggerResponse(404, "Reservation not found")]
    public async Task<IActionResult> GetDetailsById(int id)
    {
        var query = new GetReservationByIdQuery(id);
        var reservation = await reservationQueryService.Handle(query);
        if (reservation == null) return NotFound();

        var reservationResource = await ReservationDetailsResourceFromEntityAssembler.ToResourceFromEntityAsync(
            reservation, providerFacade, paymentFacade, timeSlotService, workerFacade);

        return Ok(reservationResource);
    }
    
    // GET /api/v1/reservations
    [HttpGet]
    [AllowAnonymous]
    [SwaggerOperation(
        Summary = "Gets all reservations (basic)",
        Description = "Returns a list of all reservations with basic info",
        OperationId = "GetAllReservations")]
    [SwaggerResponse(200, "Reservations found", typeof(IEnumerable<ReservationResource>))]
    public async Task<IActionResult> GetAll()
    {
        var query = new GetAllReservationsQuery();
        var reservations = await reservationQueryService.Handle(query);

        var result = reservations
            .Select(reservation => ReservationResourceFromEntityAssembler.ToResourceFromEntity(reservation))
            .ToList();

        return Ok(result);
    }

}