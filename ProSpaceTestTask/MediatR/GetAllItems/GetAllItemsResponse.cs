using ProSpaceTestTask.Models;

namespace ProSpaceTestTask.MediatR.GetAllItems;

public record GetAllItemsResponse(List<Item> Items);