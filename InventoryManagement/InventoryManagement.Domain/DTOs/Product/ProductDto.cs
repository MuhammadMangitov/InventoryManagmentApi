namespace InventoryManagement.Domain.DTOs.Product;

public class ProductDto
{
    public string Category { get; init; }
    public int CategoryId { get; init; }
    public string? Description { get; init; }
    public string Expire { get; init; }
    public int Id { get; init; }
    public string Name { get; init; }
    public decimal Price { get; init; }
}
