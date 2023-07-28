using API.Data;
using API.dto.UsersDto;
using API.Models.Enums;
using AutoMapper;
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
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _http;

        public UserRepository(UserDbContext userDb, IMapper mapper)
        {

            _userDb = userDb;
            _mapper = mapper;
        }

        public async Task<CartDto> AddCart(string Email, CartDto newCart)
        {
            
            var user = _userDb.Users.Where(u => u.Email == Email).FirstOrDefault();

            if (user.Equals(null))
                return null;

            var cart = _mapper.Map<Cart>(newCart);

            var userCart = new UserCart
            {
                 Cart = cart,
                 User = user,
            };

            await _userDb.AddAsync(cart);
            
            await _userDb.AddAsync(userCart);

            await _userDb.SaveChangesAsync();


            return newCart;
        }

        public async Task<CartDto> DeleteCart(string Email, int cartId)
        {
            
            var user = _userDb.Users.FirstOrDefault(u => u.Email == Email);

            var carts = _userDb.userCarts.Where(u => u.UserId == user.Id).Select(u => u.Cart).ToList();

            var cart = carts.FirstOrDefault(c => c.Id == cartId);

            if (cart == null)
                return null;

            _userDb.Carts.Remove(cart);
            await _userDb.SaveChangesAsync();

            return _mapper.Map<CartDto>(cart);
            

        }

        public async Task<UserDto> GetMe(string email)
        {
            return _mapper.Map<UserDto>(await _userDb.Users.Where(u => u.Email == email).FirstOrDefaultAsync());
        }



        public async Task<IEnumerable<CartDto>> GetMyCart(string Email)
        {

            var user = _userDb.Users.FirstOrDefault(u => u.Email == Email);

            if (user.Equals(null))
                return null;

            return _mapper.Map<List<CartDto>>(_userDb.userCarts.Where(u => u.UserId == user.Id).Select(u => u.Cart).ToList());

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
