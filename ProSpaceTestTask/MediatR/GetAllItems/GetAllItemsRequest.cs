using FluentResults;
using MediatR;

namespace ProSpaceTestTask.MediatR.GetAllItems;

public record GetAllItemsRequest() : IRequest<Result<GetAllItemsResponse>>;