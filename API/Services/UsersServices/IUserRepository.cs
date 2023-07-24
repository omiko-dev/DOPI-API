using API.Models.dto.UsersDto;
using Microsoft.AspNetCore.Mvc;

namespace API.Services.UsersServices
{
    public interface IUserRepository
    {

        public Task<IEnumerable<Product>> GetMyCart(string Email);

        public Task<IEnumerable<Product>> GetMyPurchaseProduct(string Email);

        public Task<IEnumerable<Product>> AddCart(List<UserProductDto> product, string Email);

    }
}
