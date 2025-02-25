using FluentResults;
using MediatR;

namespace ProSpaceTestTask.MediatR.AcceptOrderById;

public record AcceptOrderByIdRequest(Guid OrderId, DateTime ShipmentDate) : IRequest<Result>;