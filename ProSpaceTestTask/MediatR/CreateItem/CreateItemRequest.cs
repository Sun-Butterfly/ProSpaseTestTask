using FluentResults;
using MediatR;

namespace ProSpaceTestTask.MediatR.CreateItem;

public record CreateItemRequest(
    string Name,
    decimal Price,
    string Category
) : IRequest<Result>;