using API.dto.ProductsDto;
using API.dto.UsersDto;
using Microsoft.AspNetCore.Mvc;

namespace API.Services.UsersServices
{
    public interface IUserRepository
    {

        public Task<IEnumerable<ProductGetDto>> GetMyCart(string Email);

        public Task<ProductAddDto> AddCart(string Email, ProductAddDto newCart);

        public Task<ProductGetDto> DeleteCart(string Email, int cartId);

        public Task<UserDto> GetMe(string email);

        //public Task<IEnumerable<Product>> GetMyPurchaseProduct(string Email);

    }
}
