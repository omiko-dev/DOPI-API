﻿using API.Data;
using API.dto.ProductsDto;
using API.Models.Enums;
using Microsoft.EntityFrameworkCore;

namespace API.Services.ProductsService
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductDbContext _context;

        public ProductRepository(ProductDbContext context)
        {
            _context = context;
        }
        async public Task<Product?> GetProductById(int id)
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

        async public Task<Product?> AddProduct(ProductAddDto product)
        {

            if (product == null)
                return null;

            var newProduct = new Product
            {
                Id = product.Id,
                ProductName = product.ProductName,
                Description = product.Description,
                Brand = product.Brand,
                Price = product.Price,
                Ingredients = product.Ingredients,
                CocoaPercentage = product.CocoaPercentage,
                Flavor = product.Flavor,
                Allergens = product.Allergens,
                ImageURL = product.ImageURL,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            await _context.products.AddAsync(newProduct);
            await _context.SaveChangesAsync();

            return newProduct;

        }

        async public Task<Product?> DeleteProduct(int id)
        {

            var _product = await _context.products.FindAsync(id);

            if (_product == null)
                return null;

            _context.products.Remove(_product);
            await _context.SaveChangesAsync();

            return _product;
        }


        async public Task<Product?> UpdateProduct(int id, Product product)
        {

            var _product = await _context.products.FindAsync(id);
            Console.WriteLine(product);

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
                _product.Ingredients = product.Ingredients;

            if (product.Allergens != null)
                _product.Allergens = product.Allergens;

            if (product.ImageURL != null)
                _product.ImageURL = product.ImageURL;

            _product.UpdatedAt = DateTime.Now;

            await _context.SaveChangesAsync();

            return _product;


        }
    }
}
