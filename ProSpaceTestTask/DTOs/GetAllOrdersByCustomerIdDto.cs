using ProSpaceTestTask.Models;

namespace ProSpaceTestTask.DTOs;

public record GetAllOrdersByCustomerIdDto(
    Guid Id,
    DateTime OrderDate,
    DateTime? ShipmentDate,
    long OrderNumber,
    string Status,
    List<OrderElementDto> OrderElements
);