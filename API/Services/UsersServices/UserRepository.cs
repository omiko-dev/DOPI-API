using API.Data;
using API.Models.dto.UsersDto;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace API.Services.UsersServices
{
    public class UserRepository : IUserRepository
    {
        private readonly UserDbContext _userDb;
        private readonly IHttpContextAccessor _http;

        public UserRepository(UserDbContext userDb, IHttpContextAccessor http)
        {

            _userDb = userDb;
            _http = http;
        }

        public async Task<IEnumerable<UserProduct>> AddCart(string Email, UserProduct product)
        {
            var user = await _userDb.Users.FirstOrDefaultAsync(x => x.Email == Email);

            if(user != null)
            {
                //user.Cart = product;
                await _userDb.UserProduct.AddAsync(product);

                return _userDb.UserProduct.ToList();
            }
            return null;

        }

        public async Task<UserProduct> GetMyCart(string Email)
        {

            var user = await _userDb.Users.FirstOrDefaultAsync(x => x.Email == Email);

            if (user != null)
            {
                await Console.Out.WriteLineAsync(user.Name + "<----------------------");
                return user.Cart;
            }

            return null;

        }


        //public async Task<IEnumerable<Product>> GetMyPurchaseProduct(string Email)
        //{

        //    var user = await _userDb.Users.FirstOrDefaultAsync(u => u.Email == Email);

        //    if (user is not null)
        //    {
        //        return user.PurchaseProduct.ToList();
        //    }

        //    return null;

        //}

        //public async Task<IEnumerable<Product>> AddCart(List<UserProductDto> product, string Email)
        //{

        //    var user = await _userDb.Users.FirstOrDefaultAsync(u => u.Email == Email);

        //    if(user is not null)
        //    {
        //        user.Cart = product;
        //        _userDb.SaveChanges();
        //        return product;
        //    }

        //    return null;

        //}


    }
}
