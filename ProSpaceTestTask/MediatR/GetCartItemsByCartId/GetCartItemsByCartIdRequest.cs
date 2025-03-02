using FluentResults;
using MediatR;

namespace ProSpaceTestTask.MediatR.GetCartItemsByCartId;

public record GetCartItemsByCartIdRequest(
    string CartId
) : IRequest<Result<GetCartItemsByCartIdResponse>>;