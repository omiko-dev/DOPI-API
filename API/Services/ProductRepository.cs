using API.Data;
using API.Models.dto;
using API.Models.Enums;
using Microsoft.EntityFrameworkCore;

namespace API.Services
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductDbContext _context;

        public ProductRepository(ProductDbContext context)
        {
            _context = context;
        }
        async public Task<Product> GetProductById(int id)
        {
            var _product = await _context.products.FindAsync(id);

            if (_product == null)
                return null;

            return _product;
        }

        async public Task<IEnumerable<Product>> GetProducts()
        {

            return await _context.products.ToListAsync();

        }

        async public Task<Product> AddProduct(Product product)
        {

            if (product == null) 
                return null;

            product.CreatedAt = DateTime.Now;
            product.UpdatedAt = DateTime.Now; 

            await _context.products.AddAsync(product);
            await _context.SaveChangesAsync();

            return product;

        }

        async public Task<Product> DeleteProduct(int id)
        {
            
            var _product =  await _context.products.FindAsync(id);

            if (_product == null)
                return null;

            _context.products.Remove(_product);
            await _context.SaveChangesAsync();

            return _product;
        }


        async public Task<Product> UpdateProduct(int id, UpdateProduct product)
        {

            var _product = await _context.products.FindAsync(id);

            if (_product == null)
                return null;

            if (product.ProductName != null)
                _product.ProductName = product.ProductName;

            if (product.Description != null)
                _product.Description = product.Description;

            if (product.Brand != null)
                _product.Brand = product.Brand;

            if (product.Price != 0)
                _product.Price = product.Price;

            if (product.CocoaPercentage != 0)
                _product.CocoaPercentage = product.CocoaPercentage;

            if (Enum.IsDefined(typeof(Flavor), product.Flavor))
                _product.Flavor = product.Flavor;

            if (product.Ingredients != null)
                _product.Ingredients.Add(product.Ingredients);

            if (product.Allergens != null)
                _product.Allergens.Add(product.Allergens);

            if (product.ImageURL != null)
                _product.ImageURL.Add(product.ImageURL);

            _product.UpdatedAt = DateTime.Now;

            await _context.SaveChangesAsync();

            return _product;


        }
    }
}
