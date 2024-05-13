using AutoMapper;
using InventoryManagement.Domain.DTOs.Product;
using InventoryManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Domain.Mappings
{
    public class ProductMappings : Profile
    {
        public ProductMappings() 
        {
            CreateMap<Product, ProductDto>()
                .ForMember(x => x.Category, m => m.MapFrom(e => e.Category.Name))
                .ForMember(x => x.Expire, m => m.MapFrom(e => CalcualteExpireDate(e.ExpireDate)));
            CreateMap<ProductForCreateDto, Product>();
            CreateMap<ProductForUpdateDto, Product>();
        }

        private static string CalcualteExpireDate(DateTime dateTime)
        {
            if (dateTime > DateTime.Now)
            {
                var difference = dateTime - DateTime.Now;
                return $"Expires in: {difference.Days}";
            }

            var expiredDate = DateTime.Now - dateTime;

            return $"Expired in: {expiredDate.Days}";
        }
    }
}
