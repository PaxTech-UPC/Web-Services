using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using uTimePlatform.Services.Domain.Model.Commands;
using uTimePlatform.Services.Domain.Model.Queries;
using uTimePlatform.Services.Domain.Services;
using uTimePlatform.Services.Interfaces.REST.Resources;
using uTimePlatform.Services.Interfaces.REST.Transform;

namespace uTimePlatform.Services.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[Tags("Services")]
public class ServiceController(IServiceCommandService commandService, IServiceQueryService queryService)
    : ControllerBase
{
    [HttpPost]
    [SwaggerOperation(Summary = "Creates a service", OperationId = "CreateService")]
    [SwaggerResponse(201, "Service created", typeof(ServiceResource))]
    [SwaggerResponse(400, "Invalid input")]
    public async Task<IActionResult> Create([FromBody] CreateServiceResource resource)
    {
        var command = CreateServiceCommandFromResourceAssembler.ToCommandFromResource(resource);
        var result = await commandService.Handle(command);
        if (result == null) return BadRequest("Service creation failed");

        var serviceResource = ServiceResourceFromEntityAssembler.ToResourceFromEntity(result);
        return CreatedAtAction(nameof(GetById), new { id = result.Id }, serviceResource);
    }

    [HttpGet("{id}")]
    [SwaggerOperation(Summary = "Gets a service by ID", OperationId = "GetServiceById")]
    [SwaggerResponse(200, "Service found", typeof(ServiceResource))]
    [SwaggerResponse(404, "Service not found")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var result = await queryService.Handle(new GetServiceById(id));
        if (result == null) return NotFound("Service not found");

        return Ok(ServiceResourceFromEntityAssembler.ToResourceFromEntity(result));
    }

    [HttpGet]
    [SwaggerOperation(Summary = "Gets all services", OperationId = "GetAllServices")]
    [SwaggerResponse(200, "Services list", typeof(IEnumerable<ServiceResource>))]
    public async Task<IActionResult> GetAll()
    {
        var result = await queryService.Handle(new GetAllServicesQuery());
        var resources = result.Select(ServiceResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }

    [HttpPut("{id}")]
    [SwaggerOperation(Summary = "Updates a service", OperationId = "UpdateService")]
    [SwaggerResponse(200, "Service updated", typeof(ServiceResource))]
    [SwaggerResponse(404, "Service not found")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateServiceResource resource)
    {
        var command = UpdateServiceCommandFromResourceAssembler.ToCommandFromResource(id, resource);
        var result = await commandService.Handle(command);
        if (result == null) return NotFound("Service not found");

        return Ok(ServiceResourceFromEntityAssembler.ToResourceFromEntity(result));
    }

    [HttpDelete("{id}")]
    [SwaggerOperation(Summary = "Deletes a service", OperationId = "DeleteService")]
    [SwaggerResponse(200, "Service deleted")]
    [SwaggerResponse(404, "Service not found")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        var query = new GetServiceById(id);
        var service = await queryService.Handle(query);
        if (service == null)
            return NotFound("Service not found");

        var command = new DeleteServiceCommand(id);
        await commandService.Handle(command);

        return Ok("Service with given id successfully deleted");
    }
}
