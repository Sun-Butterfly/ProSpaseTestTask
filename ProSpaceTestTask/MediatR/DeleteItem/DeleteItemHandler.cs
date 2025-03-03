using FluentResults;
using MediatR;
using ProSpaceTestTask.Repositories;

namespace ProSpaceTestTask.MediatR.DeleteItem;

public class DeleteItemHandler : IRequestHandler<DeleteItemRequest, Result>
{
    private readonly IItemRepository _itemRepository;

    public DeleteItemHandler(IItemRepository itemRepository)
    {
        _itemRepository = itemRepository;
    }

    public async Task<Result> Handle(DeleteItemRequest request, CancellationToken cancellationToken)
    {
        var idGuid = Guid.Parse(request.Id);
        var item = await _itemRepository.GetById(idGuid, cancellationToken);
        if (item == null)
        {
            return Result.Fail("Товар не найден!");
        }

        await _itemRepository.Delete(item, cancellationToken);
        return Result.Ok();
    }
}