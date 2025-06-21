using System.Net.Mime;
using uTimePlatform.Profiles.Domain.Model.Queries;
using uTimePlatform.Profiles.Domain.Services;
using uTimePlatform.Profiles.Interfaces.REST.Resources;
using uTimePlatform.Profiles.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace uTimePlatform.Profiles.Interfaces.REST;


[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[Tags("Providers")]
public class ProviderController(
    IProviderCommandService providerCommandService,
    IProviderQueryService providerQueryService)
    : ControllerBase
{
    [HttpPost]
    [SwaggerOperation(
        Summary = "Creates a provider",
        Description = "Creates a provider with given name, email, and password",
        OperationId = "CreateProvider")]
    [SwaggerResponse(201, "The provider was created", typeof(ProviderResource))]
    [SwaggerResponse(400, "The provider was not created")]
    public async Task<ActionResult> CreateProvider([FromBody] CreateProviderResource resource)
    {
        var createProviderCommand = CreateProviderCommandFromResourceAssembler.ToCommandFromResource(resource);
        var result = await providerCommandService.Handle(createProviderCommand);
        if (result is null) return BadRequest();
        return CreatedAtAction(nameof(GetProviderById), new { id = result.Id }, ProviderResourceFromEntityAssembler.ToResourceFromEntity(result));
    }

    [HttpGet("{id}")]
    [SwaggerOperation(
        Summary = "Gets a provider by ID",
        Description = "Gets a provider using its unique identifier",
        OperationId = "GetProviderById")]
    [SwaggerResponse(200, "The provider was found", typeof(ProviderResource))]
    [SwaggerResponse(404, "Provider not found")]
    public async Task<ActionResult> GetProviderById(int id)
    {
        var query = new GetProviderByIdQuery(id);
        var result = await providerQueryService.Handle(query);
        if (result is null) return NotFound();
        var resource = ProviderResourceFromEntityAssembler.ToResourceFromEntity(result);
        return Ok(resource);
    }
    

    [HttpGet]
    [SwaggerOperation(
        Summary = "Gets all providers",
        Description = "Returns a list of all providers",
        OperationId = "GetAllProviders")]
    [SwaggerResponse(200, "List of providers returned", typeof(IEnumerable<ProviderResource>))]
    public async Task<ActionResult> GetAllProviders()
    {
        var query = new GetAllProvidersQuery();
        var result = await providerQueryService.Handle(query);
        var resources = result.Select(ProviderResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }
}
