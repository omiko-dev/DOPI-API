using API.dto.UsersDto;
using AutoMapper;

namespace API.Helper
{
    public class MappingProfile : Profile
    {

        public MappingProfile()
        {

            CreateMap<UserDto, User>();
            CreateMap<User, UserDto>();
            CreateMap<CartDto, Cart>();
            CreateMap<Cart, CartDto>();
        }

    }
}
