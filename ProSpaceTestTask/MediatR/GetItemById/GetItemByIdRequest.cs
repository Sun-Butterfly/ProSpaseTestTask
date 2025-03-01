using FluentResults;
using MediatR;

namespace ProSpaceTestTask.MediatR.GetItemById;

public record GetItemByIdRequest(string Id) : IRequest<Result<GetItemByIdResponse>>; 