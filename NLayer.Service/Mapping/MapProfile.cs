using AutoMapper;
using NLayer.Core;
using NLayer.Core.DTOs;
using NLayer.Core.Entities;

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


            CreateMap<Banka, BankaDto>()
               .ForMember(dto => dto.Subeler, ent => ent.MapFrom(p => p.Subeler.OrderBy(g => g.Adi)));

            CreateMap<Sube, SubeDto>()
                .ForMember(dto => dto.Hesaplar, ent => ent.MapFrom(p => p.Hesaplar.OrderBy(g => g.Kodu)));

            CreateMap<Hesap, HesapDto>()
                .ForMember(dto => dto.Hareketler, ent => ent.MapFrom(p => p.Hareketler.OrderBy(g => g.Id)));

            CreateMap<Hareket, HareketDto>()
                .ForMember(dto => dto.HareketTipi, ent => ent.MapFrom(p => p.HareketTipi));

            CreateMap<HareketTipi, HareketTipiDto>();
        }
    }
}