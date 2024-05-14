﻿namespace InventoryManagement.Domain.DTOs.Category;

public record CategoryForUpdateDto(
    int Id,
    string Name,
    string? Description,
    int ParentId);
