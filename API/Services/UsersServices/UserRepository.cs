using API.Data;
using API.dto.ProductsDto;
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

        public UserRepository(UserDbContext userDb, IMapper mapper)
        {

            _userDb = userDb;
            _mapper = mapper;
        }

        public async Task<ProductAddDto> AddCart(string Email, ProductAddDto newCart)
        {
            
            var user = _userDb.Users.Where(u => u.Email == Email).FirstOrDefault();

            if (user!.Equals(null))
                return null!;

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

        public async Task<ProductAddDto> BuyProduct(string email, ProductAddDto product)
        {

            var user = await _userDb.Users.FirstOrDefaultAsync(u => u.Email == email);

            if(user == null) 
                return null!;

            var buyProduct = _mapper.Map<PurchaseProduct>(product);

            buyProduct.UserId = user.Id;

            await _userDb.purchaseProducts.AddAsync(buyProduct);

            await _userDb.SaveChangesAsync();

            return product;

        }

        public async Task<ProductGetDto> DeleteCart(string Email, int cartId)
        {
            
            var user = _userDb.Users.FirstOrDefault(u => u.Email == Email);

            var carts = _userDb.userCarts.Where(u => u.UserId == user!.Id).Select(u => u.Cart).ToList();

            var cart = carts.FirstOrDefault(c => c.Id == cartId);

            if (cart == null)
                return null!;

            _userDb.Carts.Remove(cart);
            await _userDb.SaveChangesAsync();

            return _mapper.Map<ProductGetDto>(cart);
            

        }

        public async Task<ProductGetDto> DeletePurchaseProduct(string email, int productId)
        {
            
            var user = await _userDb.Users.FirstOrDefaultAsync(u => u.Email == email);

            if(user == null) 
                return null!;

            var purchaseProduct = await _userDb.purchaseProducts.Where(p => p.UserId == user.Id).FirstOrDefaultAsync(p => p.Id == productId);

            if (purchaseProduct == null) 
                return null!;

            _userDb.purchaseProducts.Remove(purchaseProduct);
            await _userDb.SaveChangesAsync();

            return _mapper.Map<ProductGetDto>(purchaseProduct);

        }

        public async Task<IEnumerable<ProductGetDto>> GetBuyProduct(string email)
        {
            
            var user = await _userDb.Users.FirstOrDefaultAsync(u => u.Email == email);

            if(user == null) 
                return null!;

            var purchaseProduct = _mapper.Map<List<ProductGetDto>>(await _userDb.purchaseProducts.Where(p => p.UserId == user!.Id).ToListAsync());

            return purchaseProduct;

        }

        public async Task<UserDto> GetMe(string email)
        {
            return _mapper.Map<UserDto>(await _userDb.Users.Where(u => u.Email == email).FirstOrDefaultAsync());
        }



        public async Task<IEnumerable<ProductGetDto>> GetMyCart(string Email)
        {

            var user = _userDb.Users.FirstOrDefault(u => u.Email == Email);

            if (user!.Equals(null))
                return null!;

            return _mapper.Map<List<ProductGetDto>>(await _userDb.userCarts.Where(u => u.UserId == user.Id).Select(u => u.Cart).ToListAsync());

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
