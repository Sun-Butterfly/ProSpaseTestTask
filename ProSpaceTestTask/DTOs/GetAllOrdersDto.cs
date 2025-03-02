namespace ProSpaceTestTask.DTOs;

public record GetAllOrdersDto(
    Guid Id,
    Guid CustomerId,
    DateTime OrderDate,
    DateTime? ShipmentDate,
    long OrderNumber,
    string Status,
    List<OrderElementDto> OrderElements
);