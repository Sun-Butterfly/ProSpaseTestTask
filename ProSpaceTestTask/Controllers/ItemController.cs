using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProSpaceTestTask.DTOs;
using ProSpaceTestTask.MediatR.CreateItem;
using ProSpaceTestTask.MediatR.DeleteItem;
using ProSpaceTestTask.MediatR.GetAllItems;
using ProSpaceTestTask.MediatR.RedactItem;

namespace ProSpaceTestTask.Controllers;

[Produces("application/json")]
[Route("[controller]/[action]")]
public class ItemController : Controller
{
    private readonly IMediator _mediator;

    public ItemController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Authorize(Roles = "administrator, customer")]
    public async Task<IActionResult> GetAll()
    {
        var request = new GetAllItemsRequest();
        var result = await _mediator.Send(request);
        
        if (result.IsFailed)
        {
            return BadRequest(new ErrorModel(result.StringifyErrors()));
        }

        return Ok(result.Value.ItemsDto);
    }

    [HttpPost]
    [Authorize(Roles = "administrator")]
    public async Task<IActionResult> CreateItem([FromBody]CreateItemRequest request)
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
    public async Task<IActionResult> RedactItem([FromBody]RedactItemRequest request)
    {
        var result = await _mediator.Send(request);
        if (result.IsFailed)
        {
            return BadRequest(new ErrorModel(result.StringifyErrors()));
        }
        return Ok();
    }

    [HttpDelete]
    [Authorize(Roles = "administrator")]
    public async Task<IActionResult> DeleteItem(Guid id)
    {
        var request = new DeleteItemRequest(id);
        var result = await _mediator.Send(request);
        
        if (result.IsFailed)
        {
            return BadRequest(new ErrorModel(result.StringifyErrors()));
        }
        return Ok();
    }
}