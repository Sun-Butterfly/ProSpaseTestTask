using FluentResults;
using MediatR;

namespace ProSpaceTestTask.MediatR.DeleteItem;

public record DeleteItemRequest(Guid Id) : IRequest<Result>;