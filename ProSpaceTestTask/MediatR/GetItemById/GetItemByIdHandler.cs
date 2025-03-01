using FluentResults;
using MediatR;
using ProSpaceTestTask.Repositories;

namespace ProSpaceTestTask.MediatR.GetItemById;

public class GetItemByIdHandler : IRequestHandler<GetItemByIdRequest, Result<GetItemByIdResponse>>
{
    private readonly IItemRepository _itemRepository;

    public GetItemByIdHandler(IItemRepository itemRepository)
    {
        _itemRepository = itemRepository;
    }

    public async Task<Result<GetItemByIdResponse>> Handle(GetItemByIdRequest request, CancellationToken cancellationToken)
    {
        var idGuid = Guid.Parse(request.Id);
        var item = await _itemRepository.GetByIdDto(idGuid, cancellationToken);

        return Result.Ok(new GetItemByIdResponse(item));
    }
}