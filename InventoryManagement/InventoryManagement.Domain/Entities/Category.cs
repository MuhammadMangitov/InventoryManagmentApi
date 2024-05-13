using System.ComponentModel.DataAnnotations;

namespace InventoryManagement.Domain.Entities;

public class Category
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }

    public Category? Parent { get; set; }
    public int? ParentId { get; set; }

    public virtual ICollection<Product> Products { get; set; }
    public virtual ICollection<Category> Children { get; set; }

    public Category()
    {
        Products = new List<Product>();
        Children = new List<Category>();
    }
}