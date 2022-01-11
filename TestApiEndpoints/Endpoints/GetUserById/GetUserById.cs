using Application.Handlers.Queries.GetUserById;
using Ardalis.ApiEndpoints;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace TestApiEndpoints.Endpoints.GetUserById;

[Route("api/users")]
public class GetUserById : BaseAsyncEndpoint
    .WithRequest<Request>
    .WithResponse<Response>
{
    private readonly IMediator _mediator;
    private readonly IValidator<Request> _validator;
    private readonly ILogger<GetUserById> _logger;

    public GetUserById(IMediator mediator, IValidator<Request> validator, ILogger<GetUserById> logger)
    {
        _mediator = mediator;
        _validator = validator;
        _logger = logger;
    }

    /// <summary>
    /// Get the user corresponding to the given id
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpGet]
    public override async Task<ActionResult<Response>> HandleAsync([FromQuery] Request request, CancellationToken cancellationToken = default)
    {
        try
        {
            var result = await _validator.ValidateAsync(request, cancellationToken);

            if (!result.IsValid)
            {
                return BadRequest(result.ToString());
            }

            var response = await _mediator.Send(request, cancellationToken);

            if (response.User == null)
            {
                return NoContent();
            }

            return Ok(response);
        }
        catch(Exception ex)
        {
            _logger.LogError(ex.Message);
            return Problem();
        }
    }
}

