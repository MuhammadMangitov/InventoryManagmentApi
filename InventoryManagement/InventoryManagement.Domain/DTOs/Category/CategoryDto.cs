﻿namespace InventoryManagement.Domain.DTOs.Category
{
    public class CategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? ParentName { get; set; }
        public int? ParentId { get; set; }

    }
}
