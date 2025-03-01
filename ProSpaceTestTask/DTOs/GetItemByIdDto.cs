namespace ProSpaceTestTask.DTOs;

public record GetItemByIdDto(
    string Name,
    decimal Price,
    string Category
);