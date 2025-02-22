namespace ProSpaceTestTask.DTOs;

public record GetAllItemsDto(
    Guid Id,
    string Code,
    string Name,
    decimal Price,
    string Category
);