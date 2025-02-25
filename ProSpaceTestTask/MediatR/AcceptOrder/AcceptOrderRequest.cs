using FluentResults;
using MediatR;

namespace ProSpaceTestTask.MediatR.AcceptOrder;

public record AcceptOrderRequest(Guid OrderId, DateTime ShipmentDate) : IRequest<Result>;