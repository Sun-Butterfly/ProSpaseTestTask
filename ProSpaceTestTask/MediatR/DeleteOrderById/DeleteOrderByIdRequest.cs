using FluentResults;
using MediatR;

namespace ProSpaceTestTask.MediatR.DeleteOrderById;

public record DeleteOrderByIdRequest(string OrderId) : IRequest<Result>;