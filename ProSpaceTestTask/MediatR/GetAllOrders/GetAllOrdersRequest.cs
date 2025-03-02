using FluentResults;
using MediatR;

namespace ProSpaceTestTask.MediatR.GetAllOrders;

public record GetAllOrdersRequest() : IRequest<Result<GetAllOrdersResponse>>;