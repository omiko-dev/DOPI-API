using API.dto.ProductsDto;
using API.dto.UsersDto;
using API.Dto.UsersDto;
using AutoMapper;

namespace API.Helper
{
    public class MappingProfile : Profile
    {

        public MappingProfile()
        {

            CreateMap<ProductAddDto, Cart>();

            CreateMap<Cart, ProductAddDto>();

            CreateMap<UserDto, User>();

            CreateMap<RegisterDto, User>();

            CreateMap<User, UserDto>();

            CreateMap<CartDto, Cart>();

            CreateMap<Cart, CartDto>();

            CreateMap<Cart, ProductGetDto>();

            CreateMap<Product, Cart>();

            CreateMap<Product, ProductGetDto>();

            CreateMap<ProductAddDto, Product>();

            CreateMap<ProductAddDto, PurchaseProduct>();

            CreateMap<PurchaseProduct, ProductGetDto>();


        }

    }
}
