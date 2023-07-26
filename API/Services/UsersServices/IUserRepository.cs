using API.Models.dto.UsersDto;
using Microsoft.AspNetCore.Mvc;

namespace API.Services.UsersServices
{
    public interface IUserRepository
    {

        public Task<UserProduct> GetMyCart(string Email);

        public Task<IEnumerable<UserProduct>> AddCart(string Email, UserProduct product);

        //public Task<IEnumerable<Product>> GetMyPurchaseProduct(string Email);

        //public Task<IEnumerable<Product>> AddCart(List<int> product, string Email);

    }
}
