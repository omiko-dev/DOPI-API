using API.dto.UsersDto;
using Microsoft.AspNetCore.Mvc;

namespace API.Services.UsersServices
{
    public interface IUserRepository
    {

        public Task<IEnumerable<CartDto>> GetMyCart(string Email);

        public Task<CartDto> AddCart(string Email,CartDto newCart);

        public Task<CartDto> DeleteCart(string Email, int cartId);

        public Task<UserDto> GetMe(string email);

        //public Task<IEnumerable<Product>> GetMyPurchaseProduct(string Email);

        //public Task<IEnumerable<Product>> AddCart(List<int> product, string Email);

    }
}
