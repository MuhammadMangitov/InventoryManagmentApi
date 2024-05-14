using InventoryManagement.Domain.DTOs.Category;
namespace InventoryManagement.Domain.Interfaces.Services;

public interface ICategoryService
{
    IEnumerable<CategoryDto> GetCategories();
    CategoryDto? GetCategoryById(int id);
    CategoryDto Create(CategoryForCreateDto category);
    void Delete(int id);
    void Update(CategoryForUpdateDto category);

}
