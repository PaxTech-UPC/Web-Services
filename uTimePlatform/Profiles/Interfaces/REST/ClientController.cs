using System.Net.Mime;
using uTimePlatform.Profiles.Domain.Model.Queries;
using uTimePlatform.Profiles.Domain.Services;
using uTimePlatform.Profiles.Interfaces.REST.Resources;
using uTimePlatform.Profiles.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using uTimePlatform.Profiles.Domain.Model.ValueObjects;


namespace uTimePlatform.Profiles.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[Tags("Clients")]
public class ClientController(
    IClientCommandService clientCommandService,
    IClientQueryService clientQueryService)
    : ControllerBase
{
    [HttpPost]
    [SwaggerOperation(
        Summary = "Creates a client",
        Description = "Creates a client with given name, email, and password",
        OperationId = "CreateClient")]
    [SwaggerResponse(201, "The client was created", typeof(ClientResource))]
    [SwaggerResponse(400, "The client was not created")]
    public async Task<ActionResult> CreateClient([FromBody] CreateClientResource resource)
    {
        var createClientCommand = CreateClientCommandFromResourceAssembler.ToCommandFromResource(resource);
        var result = await clientCommandService.Handle(createClientCommand);
        if (result is null) return BadRequest();
        return CreatedAtAction(nameof(GetClientById), new { id = result.Id }, ClientResourceFromEntityAssembler.ToResourceFromEntity(result));
    }

    [HttpGet("{id}")]
    [SwaggerOperation(
        Summary = "Gets a client by ID",
        Description = "Gets a client using its unique identifier",
        OperationId = "GetClientById")]
    [SwaggerResponse(200, "The client was found", typeof(ClientResource))]
    [SwaggerResponse(404, "Client not found")]
    public async Task<ActionResult> GetClientById(int id)
    {
        var query = new GetClientByIdQuery(id);
        var result = await clientQueryService.Handle(query);
        if (result is null) return NotFound();
        var resource = ClientResourceFromEntityAssembler.ToResourceFromEntity(result);
        return Ok(resource);
    }

    [HttpGet("by-email")]
    [SwaggerOperation(
        Summary = "Gets a client by email",
        Description = "Gets a client using the email address",
        OperationId = "GetClientByEmail")]
    [SwaggerResponse(200, "The client was found", typeof(ClientResource))]
    [SwaggerResponse(404, "Client not found")]
    public async Task<ActionResult> GetClientByEmail([FromQuery] string email)
    {
        var query = new GetClientByEmailQuery(new EmailAddress(email)); // ✅ FIX
        var result = await clientQueryService.Handle(query);
        if (result is null) return NotFound();
        var resource = ClientResourceFromEntityAssembler.ToResourceFromEntity(result);
        return Ok(resource);
    }


    [HttpGet]
    [SwaggerOperation(
        Summary = "Gets all clients",
        Description = "Returns a list of all clients",
        OperationId = "GetAllClients")]
    [SwaggerResponse(200, "List of clients returned", typeof(IEnumerable<ClientResource>))]
    public async Task<ActionResult> GetAllClients()
    {
        var query = new GetAllClientsQuery();
        var result = await clientQueryService.Handle(query);
        var resources = result.Select(ClientResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }
}
