using ProSpaceTestTask.DTOs;

namespace ProSpaceTestTask.MediatR.GetCartItemsByCartId;

public record GetCartItemsByCartIdResponse(List<GetCartItemByCartIdDto> CartItems);