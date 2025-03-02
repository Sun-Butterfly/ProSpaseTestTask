using ProSpaceTestTask.DTOs;

namespace ProSpaceTestTask.MediatR.GetAllOrders;

public record GetAllOrdersResponse(List<GetAllOrdersDto> Orders);