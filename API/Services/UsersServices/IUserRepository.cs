using API.Models.dto.UsersDto;
using Microsoft.AspNetCore.Mvc;

namespace API.Services.UsersServices
{
    public interface IUserRepository
    {

        public Task<IEnumerable<Cart>> GetMyCart(string Email);

        public Task<Cart> AddCart(string Email,Cart newCart);

        //public Task<IEnumerable<Product>> GetMyPurchaseProduct(string Email);

        //public Task<IEnumerable<Product>> AddCart(List<int> product, string Email);

    }
}
