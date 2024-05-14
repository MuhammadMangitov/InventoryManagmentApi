using AutoMapper;
using InventoryManagement.Domain.DTOs.Category;
using InventoryManagement.Domain.Entities;

namespace InventoryManagement.Domain.Mappings
{
    public class CategoryMappings : Profile
    {
        public CategoryMappings()
        {
            CreateMap<Category, CategoryDto>()
                .ForMember(x => x.ParentName, m => m.MapFrom(e => e.Parent.Name));
            CreateMap<CategoryForCreateDto, Category>();
            CreateMap<CategoryForUpdateDto, Category>();
        }
    }
}
