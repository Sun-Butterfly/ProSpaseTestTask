namespace ProSpaceTestTask.DTOs;

public record GetCartItemByCartIdDto(
    long Id,
    Guid ItemId,
    string ItemName,
    string ItemCode,
    decimal ItemPrice,
    string ItemCategory,
    int ItemsCount
    );