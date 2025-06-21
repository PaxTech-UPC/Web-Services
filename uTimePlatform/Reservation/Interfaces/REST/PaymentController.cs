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
[Tags("Payments")]
public class PaymentController(
    IPaymentCommandService paymentCommandService,
    IPaymentQueryService paymentQueryService)
    : ControllerBase
{
    [HttpPost]
    [AllowAnonymous]
    [SwaggerOperation(
        Summary = "Creates a payment",
        Description = "Creates a new payment with amount, currency, and status",
        OperationId = "CreatePayment")]
    [SwaggerResponse(201, "Payment was created", typeof(PaymentResource))]
    [SwaggerResponse(400, "Invalid request")]
    public async Task<IActionResult> Create([FromBody] CreatePaymentResource resource)
    {
        var command = CreatePaymentCommandFromResourceAssembler.ToCommandFromResource(resource);
        var result = await paymentCommandService.Handle(command);
        if (result == null) return BadRequest("Failed to create payment");

        var paymentResource = PaymentResourceFromEntityAssembler.ToResourceFromEntity(result);
        return CreatedAtAction(nameof(GetById), new { id = result.Id }, paymentResource);
    }

    [HttpGet("{id}")]
    [AllowAnonymous]
    [SwaggerOperation(
        Summary = "Gets a payment by ID",
        Description = "Returns payment data for given ID",
        OperationId = "GetPaymentById")]
    [SwaggerResponse(200, "Payment was found", typeof(PaymentResource))]
    [SwaggerResponse(404, "Payment not found")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await paymentQueryService.Handle(new GetPaymentByIdQuery(id));
        if (result == null) return NotFound();

        var paymentResource = PaymentResourceFromEntityAssembler.ToResourceFromEntity(result);
        return Ok(paymentResource);
    }

    [HttpGet]
    [AllowAnonymous]
    [SwaggerOperation(
        Summary = "Gets all payments",
        Description = "Returns a list of all payments",
        OperationId = "GetAllPayments")]
    [SwaggerResponse(200, "Payments retrieved", typeof(IEnumerable<PaymentResource>))]
    public async Task<IActionResult> GetAll()
    {
        var query = new GetAllPaymentsQuery();
        var result = await paymentQueryService.Handle(query);
        var resources = result.Select(PaymentResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }
}