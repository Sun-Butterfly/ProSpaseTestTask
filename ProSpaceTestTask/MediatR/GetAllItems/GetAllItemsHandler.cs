using FluentResults;
using MediatR;
using ProSpaceTestTask.Repositories;

namespace ProSpaceTestTask.MediatR.GetAllItems;

public class GetAllItemsHandler : IRequestHandler<GetAllItemsRequest, Result<GetAllItemsResponse>>
{
    private readonly IItemRepository _itemRepository;

    public GetAllItemsHandler(IItemRepository itemRepository)
    {
        _itemRepository = itemRepository;
    }

    public async Task<Result<GetAllItemsResponse>> Handle(GetAllItemsRequest request, CancellationToken cancellationToken)
    {
        var items = await _itemRepository.GetAll(cancellationToken);
        return Result.Ok(new GetAllItemsResponse(items));
    }
}