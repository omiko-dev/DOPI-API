﻿using API.dto.ProductsDto;
using API.dto.UsersDto;

namespace API.Services.UsersServices
{
    public interface IUserRepository
    {

        public Task<IEnumerable<ProductGetDto>> GetMyCart(string Email);

        public Task<ProductAddDto> AddCart(string Email, ProductAddDto newCart);

        public Task<ProductGetDto> DeleteCart(string Email, int cartId);

        public Task<UserDto> GetMe(string email);

        public Task<bool> BuyProduct(string email, List<ProductAddDto> product);

        public Task<IEnumerable<ProductGetDto>> GetBuyProduct(string email);

        public abstract Task<ProductGetDto> DeletePurchaseProduct(string email, int productId);

        public Task<UserDto> UpdateProfileImage(string email, string profileImage);
    }
}