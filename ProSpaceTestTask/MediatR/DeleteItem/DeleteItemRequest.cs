using FluentResults;
using MediatR;

namespace ProSpaceTestTask.MediatR.DeleteItem;

public record DeleteItemRequest(string Id) : IRequest<Result>;