using AProduct.Web.Dtos;
using AProduct.Web.Entities;
using AutoMapper;

namespace AProduct.Web.Profiles;

public class ProductProfile : Profile
{
    public ProductProfile()
    {
        CreateMap<Product, ProductReadDto>();
        CreateMap<ProductCreateDto, Product>();
    }
}