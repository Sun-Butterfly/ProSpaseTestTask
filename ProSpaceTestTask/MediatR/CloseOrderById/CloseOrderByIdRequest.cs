using FluentResults;
using MediatR;

namespace ProSpaceTestTask.MediatR.CloseOrderById;

public record CloseOrderByIdRequest(Guid OrderId) : IRequest<Result>;