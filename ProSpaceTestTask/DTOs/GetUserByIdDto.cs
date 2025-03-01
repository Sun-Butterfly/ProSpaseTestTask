namespace ProSpaceTestTask.DTOs;

public record GetUserByIdDto(
    string Login,
    string Password,
    string RoleName,
    string? Name,
    string? Code,
    string? Address,
    int? Discount
);