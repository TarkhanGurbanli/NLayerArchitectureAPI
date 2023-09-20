using AutoMapper;
using NLayer.Core.DTOs;
using NLayer.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Repository.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Product, ProductDTO>().ReverseMap();
            CreateMap<CategoryDTO, Category>().ReverseMap();
            CreateMap<ProductFeature, ProductFeatureDTO>().ReverseMap();
            CreateMap<ProductUpdateDTO, Product>();
            CreateMap<Product, ProductWithCategoryDTO>();
            CreateMap<Category, CategoryWithProductsDTO>();
        }
    }
}
