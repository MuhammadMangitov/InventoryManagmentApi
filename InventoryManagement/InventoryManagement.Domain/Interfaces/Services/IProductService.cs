using InventoryManagement.Domain.DTOs.Product;
namespace InventoryManagement.Domain.Interfaces.Services;

public interface IProductService
{
    IEnumerable<ProductDto> GetProducts();
    ProductDto? GetById(int id);
    ProductDto Create(ProductForCreateDto product);
    void Update(ProductForUpdateDto product);
    void Delete(int id);
}
