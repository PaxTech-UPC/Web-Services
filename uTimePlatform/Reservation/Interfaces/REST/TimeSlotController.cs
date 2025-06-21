using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using uTimePlatform.IAM.Infrastructure.Pipeline.Middleware.Attributes;
using uTimePlatform.Reservation.Domain.Model.Queries;
using uTimePlatform.Reservation.Domain.Services;
using uTimePlatform.Reservation.Interfaces.REST.Resources;
using uTimePlatform.Reservation.Interfaces.REST.Transform;

namespace uTimePlatform.Reservation.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[Tags("TimeSlots")]
public class TimeSlotController(
    ITimeSlotCommandService commandService,
    ITimeSlotQueryService queryService)
    : ControllerBase
{
    [HttpPost]
    [AllowAnonymous]
    [SwaggerOperation(
        Summary = "Create a new time slot",
        Description = "Creates a time slot with start time, end time, status and type",
        OperationId = "CreateTimeSlot")]
    [SwaggerResponse(201, "Time slot created", typeof(TimeSlotResource))]
    [SwaggerResponse(400, "Invalid input")]
    public async Task<IActionResult> Create([FromBody] CreateTimeSlotResource resource)
    {
        var command = CreateTimeSlotCommandFromResourceAssembler.ToCommandFromResource(resource);
        var result = await commandService.Handle(command);

        if (result is null) return BadRequest("Failed to create time slot");

        var timeSlotResource = TimeSlotResourceFromEntityAssembler.ToResourceFromEntity(result);
        return CreatedAtAction(nameof(GetById), new { id = result.Id }, timeSlotResource);
    }

    [HttpGet("{id}")]
    [AllowAnonymous]
    [SwaggerOperation(
        Summary = "Get a time slot by ID",
        Description = "Returns a time slot by its ID",
        OperationId = "GetTimeSlotById")]
    [SwaggerResponse(200, "Time slot found", typeof(TimeSlotResource))]
    [SwaggerResponse(404, "Time slot not found")]
    public async Task<IActionResult> GetById(int id)
    {
        var query = new GetTimeSlotByIdQuery(id);
        var result = await queryService.Handle(query);

        if (result == null) return NotFound();

        var resource = TimeSlotResourceFromEntityAssembler.ToResourceFromEntity(result);
        return Ok(resource);
    }

    [HttpGet]
    [AllowAnonymous]
    [SwaggerOperation(
        Summary = "Get all time slots",
        Description = "Returns all available time slots",
        OperationId = "GetAllTimeSlots")]
    [SwaggerResponse(200, "List of time slots", typeof(IEnumerable<TimeSlotResource>))]
    public async Task<IActionResult> GetAll()
    {
        var result = await queryService.Handle(new GetAllTimeSlotsQuery());
        var resources = result.Select(TimeSlotResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }
}