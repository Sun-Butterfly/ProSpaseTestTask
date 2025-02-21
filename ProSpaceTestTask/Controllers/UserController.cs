using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProSpaceTestTask.DTOs;
using ProSpaceTestTask.MediatR.CreateUser;
using ProSpaceTestTask.MediatR.RedactUser;

namespace ProSpaceTestTask.Controllers;

[Produces("application/json")]
[Route("[controller]/[action]")]
public class UserController : Controller
{
    private readonly IMediator _mediator;

    public UserController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    [Authorize(Roles = "administrator")]
    public async Task<IActionResult> CreateUser([FromBody]CreateUserRequest createUserRequest)
    {
        var result = await _mediator.Send(createUserRequest);
        if (result.IsFailed)
        {
            return BadRequest(new ErrorModel(result.StringifyErrors()));
        }

        return Ok();
    }
    
    [HttpPut]
    [Authorize(Roles = "administrator")]
    public async Task<IActionResult> RedactUser([FromBody]RedactUserRequest redactUserRequest)
    {
        var result = await _mediator.Send(redactUserRequest);
        if (result.IsFailed)
        {
            return BadRequest(new ErrorModel(result.StringifyErrors()));
        }
        return Ok();
    }
    
    [HttpDelete]
    [Authorize(Roles = "administrator")]
    public async Task<IActionResult> DeleteUser()
    {
        return Ok();
    }
}