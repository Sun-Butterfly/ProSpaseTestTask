using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProSpaceTestTask.DTOs;
using ProSpaceTestTask.MediatR.AcceptOrderById;
using ProSpaceTestTask.MediatR.CreateOrder;
using ProSpaceTestTask.MediatR.DeleteOrderById;

namespace ProSpaceTestTask.Controllers;

[Produces("application/json")]
[Route("[controller]/[action]")]
public class OrderController : Controller
{
    private readonly IMediator _mediator;

    public OrderController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    [Authorize(Roles = "customer")]
    public async Task<IActionResult> CreateOrder([FromBody] CreateOrderRequest request)
    {
        var result = await _mediator.Send(request);
        if (result.IsFailed)
        {
            return BadRequest(new ErrorModel(result.StringifyErrors()));
        }

        return Ok();
    }

    [HttpPut]
    [Authorize(Roles = "administrator")]
    public async Task<IActionResult> AcceptOrderById([FromBody] AcceptOrderByIdRequest byIdRequest)
    {
        var result = await _mediator.Send(byIdRequest);
        if (result.IsFailed)
        {
            return BadRequest(new ErrorModel(result.StringifyErrors()));
        }

        return Ok();
    }

    [HttpDelete]
    [Authorize(Roles = "customer")]
    public async Task<IActionResult> DeleteOrderById([FromBody] DeleteOrderByIdRequest request)
    {
        var result = await _mediator.Send(request);
        
        if (result.IsFailed)
        {
            return BadRequest(new ErrorModel(result.StringifyErrors()));
        }

        return Ok();
    }
}