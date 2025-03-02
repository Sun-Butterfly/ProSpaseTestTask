namespace ProSpaceTestTask.DTOs;

public record OrderElementDto(
    Guid Id,
    string ItemName,
    string Category,
    int ItemsCount,
    decimal ItemPrice
);