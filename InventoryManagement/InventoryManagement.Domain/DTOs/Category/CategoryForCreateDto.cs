namespace InventoryManagement.Domain.DTOs.Category;

public record CategoryForCreateDto(
    string Name,
    string? Description,
    int? ParentId);
