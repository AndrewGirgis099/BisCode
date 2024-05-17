using AutoMapper;
using BisWork.Core.Entities;
using BisWork.Core.Entities.Basket;
using BisWork.DTOs;
using System.Runtime.CompilerServices;

namespace BisWork.Helper
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Template, TemplateToReturnDto>()
                .ForMember(d => d.Category, o => o.MapFrom(s => s.Category.Name))
                .ForMember(d => d.PictureUrl, o => o.MapFrom<TemplatePictureUrlResolver>());

            CreateMap<CustomerBasketDto, CustomerBasket>();
            CreateMap<BasketItemDto, BasketItem>();
            CreateMap<TemplateDto, Template>();

        }
    }
}
