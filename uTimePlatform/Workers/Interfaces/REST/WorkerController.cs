using System.Net.Mime;
using uTimePlatform.Workers.Domain.Model.Queries;
using uTimePlatform.Workers.Domain.Services;
using uTimePlatform.Workers.Interfaces.REST.Resources;
using uTimePlatform.Workers.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace uTimePlatform.Workers.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[Tags("Workers")]

public class WorkerController(IWorkerCommandService workerCommandService, IWorkerQueryService workerQueryService)
: ControllerBase
{
    [HttpPost]
    [SwaggerOperation(
        Summary = "Creates a worker",
        Description = "Creates a worker with given name, specialization, and photoUrl",
        OperationId = "CreateWorker")]
    [SwaggerResponse(201, "The worker was created", typeof(WorkerResource))]
    [SwaggerResponse(400, "The worker was not created")]
    public async Task<ActionResult> CreateWorker([FromBody] CreateWorkerResource resource)
    {
        var createWorkerCommand = CreateWorkerCommandFromResourceAssembler.ToCommandFromResource(resource);
        var result=await workerCommandService.Handle(createWorkerCommand);
        if(result is null)return BadRequest();
        return CreatedAtAction(nameof(GetWorkerById), new { id = result.Id }, WorkerResourceFromEntityAssembler.ToResourceFromEntity(result));
    }

    [HttpGet("{id}")]
    [SwaggerOperation(
        Summary = "Gets a worker by ID",
        Description = "Gets a worker using its unique identifier",
        OperationId = "GetWorkerById")]
    [SwaggerResponse(200, "The worker was found", typeof(WorkerResource))]
    [SwaggerResponse(404, "Worker not found")]

    public async Task<ActionResult> GetWorkerById([FromRoute] int id)
    {
        var query = new GetWorkerByIdQuery(id);
        var result=await workerQueryService.Handle(query);
        if (result is null) return NotFound();
        var resource = WorkerResourceFromEntityAssembler.ToResourceFromEntity(result);
        return Ok(resource);
    }

    [HttpGet]
    [SwaggerOperation(
        Summary = "Gets all workers",
        Description = "Returns a list of all workers",
        OperationId = "GetAllWorkers")]
    [SwaggerResponse(200, "List of workers returned", typeof(IEnumerable<WorkerResource>))]
    public async Task<ActionResult> GetAllWorkers()
    {
        var query = new GetAllWorkerQuery();
        var result = await workerQueryService.Handle(query);
        var resources = result.Select(WorkerResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }
}