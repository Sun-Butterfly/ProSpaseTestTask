using FluentResults;
using MediatR;
using ProSpaceTestTask.Models;
using ProSpaceTestTask.Repositories;
using ProSpaceTestTask.Services;

namespace ProSpaceTestTask.MediatR.CreateItem;

public class CreateItemHandler : IRequestHandler<CreateItemRequest, Result>
{
    private readonly IItemRepository _itemRepository;
    private readonly IService _service;

    public CreateItemHandler(IItemRepository itemRepository, IService service)
    {
        _itemRepository = itemRepository;
        _service = service;
    }

    public async Task<Result> Handle(CreateItemRequest request, CancellationToken cancellationToken)
    {
        var item = new Item()
        {
            Code = _service.GenerateItemCode(),
            Name = request.Name,
            Price = request.Price,
            Category = request.Category
        };
        
        _itemRepository.Add(item);
        await _itemRepository.SaveChanges(cancellationToken);
        
        return Result.Ok();
    }
}