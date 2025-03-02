using FluentResults;
using MediatR;
using ProSpaceTestTask.Repositories;

namespace ProSpaceTestTask.MediatR.GetCartItemsByCartId;

public class GetCartItemsByCartIdHandler : IRequestHandler<GetCartItemsByCartIdRequest, Result<GetCartItemsByCartIdResponse>>
{
    private readonly ICartRepository _cartRepository;

    public GetCartItemsByCartIdHandler(ICartRepository cartRepository)
    {
        _cartRepository = cartRepository;
    }

    public async Task<Result<GetCartItemsByCartIdResponse>> Handle(GetCartItemsByCartIdRequest request, CancellationToken cancellationToken)
    {
        var cartIdGuid = Guid.Parse(request.CartId);
        var cartItems = await _cartRepository.GetCartItemsByCartId(cartIdGuid, cancellationToken);

        return Result.Ok(new GetCartItemsByCartIdResponse(cartItems));
    }
}