using AutoMapper;
using ExampleApplication.DTO;
using ExampleDomen.Models;

namespace ExampleMinimalApi.AutoMappers;

public class AutoMappingProfile : Profile
{
    public AutoMappingProfile()
    {
        CreateMap<Product, ProductDto>()
            .ForMember(p => p.Category, y => y.MapFrom(src => src.Category.Name));
    }
}