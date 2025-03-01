using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProSpaceTestTask.DTOs;
using ProSpaceTestTask.MediatR.CreateUser;
using ProSpaceTestTask.MediatR.DeleteUser;
using ProSpaceTestTask.MediatR.GetAllUsers;
using ProSpaceTestTask.MediatR.GetUserById;
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
    public async Task<IActionResult> DeleteUserById(Guid id)
    {
        var request = new DeleteUserRequest(id);
        var result = await _mediator.Send(request);
        if (result.IsFailed)
        {
            return BadRequest(new ErrorModel(result.StringifyErrors()));
        }
        return Ok();
    }

    [HttpGet]
    [Authorize(Roles = "administrator")]
    public async Task<IActionResult> GetAllUsers()
    {
        var request = new GetAllUsersRequest();
        var result = await _mediator.Send(request);
        
        if (result.IsFailed)
        {
            return BadRequest(new ErrorModel(result.StringifyErrors()));
        }
        return Ok(result.Value.Users);
    }

    [HttpGet]
    [Authorize(Roles = "administrator")]
    public async Task<IActionResult> GetUserById(Guid id)
    {
        var request = new GetUserByIdRequest(id);
        var result = await _mediator.Send(request);
        if (result.IsFailed)
        {
            return BadRequest(new ErrorModel(result.StringifyErrors()));
        }
        return Ok(result.Value.User);
    }
}