namespace InventoryManagement.Domain.DTOs.Product;

public record ProductForUpdateDto(
    int Id,
    string Name,
    string? Description,
    DateTime ExpireDate,
    decimal Price,
    int CategoryId);