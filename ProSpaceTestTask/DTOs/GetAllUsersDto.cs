namespace ProSpaceTestTask.DTOs;

public record GetAllUsersDto(
    Guid Id,
    string RoleName,
    string? Name,
    string? Code,
    string? Address,
    int? Discount
);