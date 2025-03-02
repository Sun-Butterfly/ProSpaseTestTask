using ProSpaceTestTask.DTOs;

namespace ProSpaceTestTask.MediatR.GetAllOrdersByCustomerId;

public record GetAllOrdersByCustomerIdResponse(List<GetAllOrdersByCustomerIdDto> Orders);