using AutoMapper;
using InventoryManagement.Domain.DTOs.Product;
using InventoryManagement.Domain.Entities;
using InventoryManagement.Domain.Interfaces.Services;
using InventoryManagement.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagement.Services;

public class ProductService : IProductService
{
    private readonly InventoryContext _context;
    private readonly IMapper _mapper;

    public ProductService(InventoryContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public IEnumerable<ProductDto> GetProducts()
    {
        var products = _context.Products
            .Include(x => x.Category)
            .AsNoTracking()
            .ToList();

        var productDtos = _mapper.Map<IEnumerable<ProductDto>>(products);

        return productDtos;
    }

    public ProductDto? GetById(int id)
    {
        var product = _context.Products.Include(x => x.Category).FirstOrDefault(product => product.Id == id);
        var dto = _mapper.Map<ProductDto>(product);

        return dto;
    }

    public ProductDto Create(ProductForCreateDto product)
    {
        var entity = _mapper.Map<Product>(product);
        
        _context.Products.Add(entity);
        _context.SaveChanges();

        var dto = _mapper.Map<ProductDto>(entity);

        return dto;
    }
    
    public void Update(ProductForUpdateDto product)
    {
        var entity = _mapper.Map<Product>(product);

        _context.Products.Update(entity);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var product = _context.Products.FirstOrDefault(x => x.Id == id);

        if (product is not null)
        {
            _context.Products.Remove(product);
        }

        _context.SaveChanges();
    }
}
