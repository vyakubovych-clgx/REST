using AutoMapper;
using REST.DataAccess.Entities;
using REST.Services.DTOs;

namespace REST.Services;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<Category, CategoryDto>()
            .ForMember(dest => dest.ItemIds, opt => opt.MapFrom(src => src.Items.Select(i => i.Id)))
            .ReverseMap();

        CreateMap<Item, ItemDto>()
            .ReverseMap();

        CreateMap<AddUpdateCategoryDto, Category>();
        CreateMap<AddUpdateItemDto, Item>();
    }
}