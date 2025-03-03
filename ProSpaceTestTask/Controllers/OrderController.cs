using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProSpaceTestTask.DTOs;
using ProSpaceTestTask.MediatR.AcceptOrderById;
using ProSpaceTestTask.MediatR.CloseOrderById;
using ProSpaceTestTask.MediatR.CreateOrder;
using ProSpaceTestTask.MediatR.DeleteOrderById;
using ProSpaceTestTask.MediatR.GetAllOrders;
using ProSpaceTestTask.MediatR.GetAllOrdersByCustomerId;

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
    public async Task<IActionResult> AcceptOrderById([FromBody] AcceptOrderByIdRequest request)
    {
        var result = await _mediator.Send(request);
        if (result.IsFailed)
        {
            return BadRequest(new ErrorModel(result.StringifyErrors()));
        }

        return Ok();
    }

    [HttpDelete]
    [Authorize(Roles = "customer")]
    public async Task<IActionResult> DeleteOrderById([FromQuery] string orderId)
    {
        var request = new DeleteOrderByIdRequest(orderId);
        var result = await _mediator.Send(request);
        
        if (result.IsFailed)
        {
            return BadRequest(new ErrorModel(result.StringifyErrors()));
        }

        return Ok();
    }

    [HttpGet]
    [Authorize(Roles = "customer")]
    public async Task<IActionResult> GetAllOrdersByCustomerId([FromQuery] string customerId)
    {
        var request = new GetAllOrdersByCustomerIdRequest(customerId);
        var result = await _mediator.Send(request);
        
        if (result.IsFailed)
        {
            return BadRequest(new ErrorModel(result.StringifyErrors()));
        }

        return Ok(result.Value.Orders);
    }

    [HttpGet]
    [Authorize(Roles = "administrator")]
    public async Task<IActionResult> GetAllOrders()
    {
        var request = new GetAllOrdersRequest();
        var result = await _mediator.Send(request);
        
        if (result.IsFailed)
        {
            return BadRequest(new ErrorModel(result.StringifyErrors()));
        }

        return Ok(result.Value.Orders);
    }
    
    [HttpPut]
    [Authorize(Roles = "administrator")]
    public async Task<IActionResult> CloseOrderById([FromBody] CloseOrderByIdRequest request)
    {
        var result = await _mediator.Send(request);
        if (result.IsFailed)
        {
            return BadRequest(new ErrorModel(result.StringifyErrors()));
        }

        return Ok();
    }
    
}