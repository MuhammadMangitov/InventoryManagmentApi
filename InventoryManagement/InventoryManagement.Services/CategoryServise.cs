using AutoMapper;
using InventoryManagement.Domain.DTOs.Category;
using InventoryManagement.Domain.Entities;
using InventoryManagement.Domain.Interfaces.Services;
using InventoryManagement.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagement.Services;

public class CategoryServise : ICategoryService
{
    private readonly InventoryContext _context;
    private readonly IMapper _mapper;

    public CategoryServise(InventoryContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public CategoryDto Create(CategoryForCreateDto category)
    {
        var entity = _mapper.Map<Category>(category);
        
        _context.Categories.Add(entity);
        _context.SaveChanges();

        var dto = _mapper.Map<CategoryDto>(entity);

        return dto;
    }
    public void Update(CategoryForUpdateDto category)
    {
        var entity = _mapper.Map<Category>(category);

        _context.Categories.Update(entity);
        _context.SaveChanges();

    }
    public void Delete(int id)
    {
        var category = _context.Categories.FirstOrDefault(c => c.Id == id);
        if(category is not null)
        {
            _context.Categories.Remove(category);
        }
        _context.SaveChanges();
    }

    public IEnumerable<CategoryDto> GetCategories()
    {
        var category = _context.Categories.AsNoTracking().ToList();

        var categoryDto = _mapper.Map<IEnumerable<CategoryDto>>(category);

        return categoryDto;

    }

    public CategoryDto? GetCategoryById(int id)
    {
        var category = _context.Categories.Include(x => x.Parent).FirstOrDefault(c => c.Id == id);
        var dto = _mapper.Map<CategoryDto>(category);

        return dto;
    }

    
}
