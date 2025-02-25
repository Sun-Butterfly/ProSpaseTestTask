using FluentResults;
using MediatR;

namespace ProSpaceTestTask.MediatR.DeleteOrderById;

public record DeleteOrderByIdRequest(Guid OrderId) : IRequest<Result>;