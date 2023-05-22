using AutoMapper;
using Domain.Entities.DTOs;
using Domain.Entities.Models;

namespace Application.Mapping
{
    public sealed class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductDTO>().ReverseMap();
        }
    }
}
