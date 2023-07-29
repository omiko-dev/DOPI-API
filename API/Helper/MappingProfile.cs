using API.dto.ProductsDto;
using API.dto.UsersDto;
using AutoMapper;

namespace API.Helper
{
    public class MappingProfile : Profile
    {

        public MappingProfile()
        {

            CreateMap<ProductAddDto, Cart>();

            CreateMap<UserDto, User>();

            CreateMap<User, UserDto>();

            CreateMap<CartDto, Cart>();

            CreateMap<Cart, CartDto>();

            CreateMap<Cart, ProductGetDto>();

            CreateMap<Product, Cart>();

            CreateMap<Product, ProductGetDto>();

            CreateMap<ProductAddDto, Product>();


        }

    }
}
