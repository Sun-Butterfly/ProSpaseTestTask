using ProSpaceTestTask.DTOs;
using ProSpaceTestTask.Models;

namespace ProSpaceTestTask.MediatR.GetAllItems;

public record GetAllItemsResponse(List<GetAllItemsDto> ItemsDto);