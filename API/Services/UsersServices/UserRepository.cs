using API.Data;
using API.dto.ProductsDto;
using API.dto.UsersDto;
using API.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

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

            var user = await getUser(Email);

            if (user!.Equals(null))
                return null!;



            var CountChecker = user.Cart!.FirstOrDefault(c => c.Description == newCart.Description && c.ProductName == newCart.ProductName);

            if (CountChecker != null)
            {
                user.Cart!.FirstOrDefault(CountChecker).Count++;
                await _userDb.SaveChangesAsync();

                return _mapper.Map<ProductAddDto>(CountChecker);
            }

            var cart = _mapper.Map<Cart>(newCart);
            cart.Userid = user.Id;
            cart.Id = 0;
            await _userDb.Carts.AddAsync(cart);
            await _userDb.SaveChangesAsync();


            return newCart;
        }

        public async Task<ProductAddDto> BuyProduct(string email, ProductAddDto product)
        {

            var user = await getUser(email);

            if (user == null)
                return null!;



            var CountChecker = user.PurchaseProduct!.FirstOrDefault(c => c.Description == product.Description && c.ProductName == product.ProductName);

            if (CountChecker != null)
            {
                user.PurchaseProduct!.FirstOrDefault(CountChecker).Count++;
                await _userDb.SaveChangesAsync();

                return _mapper.Map<ProductAddDto>(CountChecker);
            }


            var buyProduct = _mapper.Map<PurchaseProduct>(product);

            buyProduct.UserId = user.Id;
            buyProduct.Id = 0;

            await _userDb.purchaseProducts.AddAsync(buyProduct);

            await _userDb.SaveChangesAsync();

            return product;

        }

        public async Task<ProductGetDto> DeleteCart(string Email, int cartId)
        {

            var user = await getUser(Email);

            var cart = await _userDb.Carts.FirstOrDefaultAsync(c => c.Id == cartId);

            if (cart == null)
                return null!;


            if(cart.Count > 1)
            {
                cart.Count--;
                await _userDb.SaveChangesAsync();

                return _mapper.Map<ProductGetDto>(cart);
            }

            _userDb.Carts.Remove(cart);
            await _userDb.SaveChangesAsync();

            return _mapper.Map<ProductGetDto>(cart);


        }

        public async Task<ProductGetDto> DeletePurchaseProduct(string email, int productId)
        {

            var user = await getUser(email);

            if (user == null)
                return null!;

            var purchaseProduct = await _userDb.purchaseProducts.Where(p => p.UserId == user.Id).FirstOrDefaultAsync(p => p.Id == productId);

            if (purchaseProduct == null)
                return null!;

            if (purchaseProduct.Count > 1)
            {
                purchaseProduct.Count--;
                await _userDb.SaveChangesAsync();

                return _mapper.Map<ProductGetDto>(purchaseProduct);
            }

            _userDb.purchaseProducts.Remove(purchaseProduct);
            await _userDb.SaveChangesAsync();

            return _mapper.Map<ProductGetDto>(purchaseProduct);

        }

        public async Task<IEnumerable<ProductGetDto>> GetBuyProduct(string email)
        {

            var user = await getUser(email);

            if (user == null)
                return null!;

            var purchaseProduct = _mapper.Map<List<ProductGetDto>>(await _userDb.purchaseProducts.Where(p => p.UserId == user!.Id).ToListAsync());

            return purchaseProduct;

        }

        public async Task<UserDto> GetMe(string email)
        {
            return _mapper.Map<UserDto>(await _userDb.Users.Where(u => u.Email == email).Include(u => u.PurchaseProduct).FirstOrDefaultAsync());
        }



        public async Task<IEnumerable<ProductGetDto>> GetMyCart(string Email)
        {

            var user = await getUser(Email);

            if (user!.Equals(null))
                return null!;

            return _mapper.Map<List<ProductGetDto>>(await _userDb.Carts.Where(c => c.Userid == user.Id).ToListAsync());

        }

        public async Task<UserDto> UpdateProfileImage(string email, string profileImage)
        {

            var user = await getUser(email);

            if(user == null) 
                return null!;

            user.ProfileImg = profileImage;
            await _userDb.SaveChangesAsync();

            return _mapper.Map<UserDto>(user);


        }


        private async Task<User> getUser(string Email) => await _userDb.Users.FirstOrDefaultAsync(u => u.Email == Email);

    }
}
