using AutoMapper;
using NLayer.Core;
using NLayer.Core.DTOs;

namespace NLayer.Service.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<ProductFeature, ProductFeatureDto>().ReverseMap();
            CreateMap<ProductUpdateDto, Product>();
            CreateMap<Product, ProductWithCategoryDto>();
            CreateMap<Category, CategoryWithProductsDto>();

            CreateMap<Ogrenci, OgrenciDto>().ReverseMap();
            CreateMap<Ogrenci, OgrenciUpdateWithDersDto>().ReverseMap();
            CreateMap<Ogrenci, OgrenciWithDersDto>();
            CreateMap<Ders, DersDto>().ReverseMap();
            CreateMap<DersDto, DersCheckedDto>().ReverseMap();
            CreateMap<Ders, DersWithOgrenciDto>();
            CreateMap<OgrenciDers, OgrenciDersDto>().ReverseMap();
            CreateMap<OgrenciDers, DersOgrenciDto>();
            CreateMap<OgrenciDers, OgrenciDersSaveDto>().ReverseMap();
        }
    }
}