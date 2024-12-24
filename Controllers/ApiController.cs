using System;
using System.Threading.Tasks;
using ApiGateway.Features.ApiQuery;
using ApiGateway.Features.ApiRegistration;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ApiGetway.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ApiController : ControllerBase
{
    private readonly IMediator _mediator;

    public ApiController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("register")]
    public async Task<IActionResult> RegisterApi([FromBody] CreateApiCommand command)
    {
        var apiId = await _mediator.Send(command);
        return Ok(new { ApiId = apiId });
    }

    [HttpGet("{apiId}")]
    public async Task<IActionResult> GetApiById(Guid apiId)
    {
        var api = await _mediator.Send(new GetApiByIdQuery { ApiId = apiId });
        return api == null ? NotFound() : Ok(api);
    }
}
