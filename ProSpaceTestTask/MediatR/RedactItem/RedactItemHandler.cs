using FluentResults;
using MediatR;
using ProSpaceTestTask.Repositories;

namespace ProSpaceTestTask.MediatR.RedactItem;

public class RedactItemHandler : IRequestHandler<RedactItemRequest, Result>
{
    private readonly IItemRepository _itemRepository;

    public RedactItemHandler(IItemRepository itemRepository)
    {
        _itemRepository = itemRepository;
    }

    public async Task<Result> Handle(RedactItemRequest request, CancellationToken cancellationToken)
    {
        var item = await _itemRepository.GetById(request.Id, cancellationToken);
        if (item == null)
        {
            return Result.Fail("Товар не найден!");
        }

        item.Name = request.Name;
        item.Price = request.Price;
        item.Category = request.Category;
        
        _itemRepository.Update(item);
        await _itemRepository.SaveChanges(cancellationToken);

        return Result.Ok();
    }
}