using CLINICAL.UseCase.UseCases.User.Commands.CreateCommand;
using CLINICAL.UseCase.UseCases.User.Queries.LoginQuery;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CLINICAL.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    public IMediator _mediator;
    public UserController( IMediator mediator )
    {
        _mediator = mediator;
    }

    [AllowAnonymous]
    [HttpPost("Login")]
    public async Task<IActionResult> Login([FromBody] LoginQuery query)
    {
        var response = await _mediator.Send(query);
        return Ok(response);
    }
    

    [HttpPost("Register")]
    public async Task<IActionResult> RegisterUser([FromBody] CreateUserCommand command )
    {
        var response = await _mediator.Send(command);
        return Ok(response);
    }
}