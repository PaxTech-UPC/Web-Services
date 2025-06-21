using System.Net.Mime;
using uTimePlatform.Reviews.Domain.Model.Queries;
using uTimePlatform.Reviews.Domain.Services;
using uTimePlatform.Reviews.Interfaces.REST.Resources;
using uTimePlatform.Reviews.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using uTimePlatform.IAM.Infrastructure.Pipeline.Middleware.Attributes;

namespace uTimePlatform.Reviews.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[Tags("Reviews")]

public class ReviewController(
    IReviewCommandService reviewCommandService,
    IReviewQueryService reviewQueryService)
    : ControllerBase
{
    [HttpPost]
    [AllowAnonymous]
    [SwaggerOperation(
        Summary = "Creates a reviews",
        Description = "",
        OperationId = "CreateReview")]
    [SwaggerResponse(201, "The review was created", typeof(ReviewResource))]
    [SwaggerResponse(400, "The review was not created")]
    public async Task<ActionResult> CreateReview([FromBody] CreateReviewResource resource)
    {
        var createReviewCommand = CreateReviewCommandFromResourceAssembler.ToCommandFromResource(resource);
        var result = await reviewCommandService.Handle(createReviewCommand);
        if (result is null) return BadRequest();
        return CreatedAtAction(nameof(GetReviewById), new { id = result.Id }, ReviewResourceFromEntityAssembler.ToResourceFromEntity(result));
    }

    [HttpGet("{id}")]
    [AllowAnonymous]
    [SwaggerOperation(
        Summary = "Gets a review by ID",
        Description = "Gets a review using its unique identifier",
        OperationId = "GetReviewById")]
    [SwaggerResponse(200, "The client was found", typeof(ReviewResource))]
    [SwaggerResponse(404, "Client not found")]
    public async Task<ActionResult> GetReviewById(int id)
    {
        var query = new GetReviewByIdQuery(id);
        var result = await reviewQueryService.Handle(query);
        if (result is null) return NotFound();
        var resource = ReviewResourceFromEntityAssembler.ToResourceFromEntity(result);
        return Ok(resource);
    }

    [HttpGet]
    [AllowAnonymous]
    [SwaggerOperation(
        Summary = "Gets all reviews",
        Description = "Returns a list of all reviews",
        OperationId = "GetAllReviews")]
    [SwaggerResponse(200, "List of reviews returned", typeof(IEnumerable<ReviewResource>))]
    public async Task<ActionResult> GetAllReviews()
    {
        var query = new GetAllReviewQuery();
        var result = await reviewQueryService.Handle(query);
        var resources = result.Select(ReviewResourceFromEntityAssembler.ToResourceFromEntity).ToList();
        return Ok(resources);
    }
}