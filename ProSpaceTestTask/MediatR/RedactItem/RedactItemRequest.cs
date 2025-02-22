using FluentResults;
using MediatR;

namespace ProSpaceTestTask.MediatR.RedactItem;

public record RedactItemRequest(
    Guid Id,
    string Name,
    decimal Price,
    string Category
) : IRequest<Result>;