using FluentResults;
using MediatR;

namespace ProSpaceTestTask.MediatR.GetAllOrdersByCustomerId;

public record GetAllOrdersByCustomerIdRequest(string CustomerId) : IRequest<Result<GetAllOrdersByCustomerIdResponse>>;