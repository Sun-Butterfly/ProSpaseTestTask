using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProSpaceTestTask.DTOs;
using ProSpaceTestTask.MediatR.CreateUser;

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
    public async Task<IActionResult> RedactUser()
    {
        return Ok();
    }
    
    [HttpDelete]
    [Authorize(Roles = "administrator")]
    public async Task<IActionResult> DeleteUser()
    {
        return Ok();
    }
}