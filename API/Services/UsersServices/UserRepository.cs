using API.Data;
using API.Models.dto.UsersDto;
using API.Models.Enums;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using System.Text.Json;

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

        public async Task<Cart> AddCart(string Email, Cart newCart)
        {
            //var user = await _userDb.Users.FirstOrDefaultAsync(x => x.Email == Email);

            //if (user != null)
            //{
            //    newCart.User = user;
            //    newCart.User.Id = user.Id;

            //    await _userDb.Carts.AddAsync(newCart);
            //    await _userDb.SaveChangesAsync();

            //    newCart.User = null;
            //    return newCart;

            //}
            return null;
        }


        public async Task<IEnumerable<Cart>> GetMyCart(string Email)
        {

            //var user = _userDb.Users.FirstOrDefault(x => x.Email == Email);


            //if (user != null)
            //{

            //    var cart = await _userDb.Carts.Where(x => x.UserId == user.Id).ToListAsync();

            //    var userCart = new List<Cart>();

            //    if(cart != null)
            //    {
            //        foreach (var item in cart)
            //        {
            //            item.User = null;
            //            userCart.Add(item);
            //        }

            //        return userCart.ToList();

            //    }
            //}

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
