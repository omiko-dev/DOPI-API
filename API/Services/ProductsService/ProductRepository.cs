using API.Data;
using API.dto.ProductsDto;
using API.Dto.ProductsDto;
using API.Models.Enums;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace API.Services.ProductsService
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductDbContext _context;
        private readonly IMapper _mapper;

        public ProductRepository(ProductDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        async public Task<ProductGetDto?> GetProductById(int id)
        {
            var _product = await _context.products.FindAsync(id);

            if (_product == null)
                return null;

            return _mapper.Map<ProductGetDto>(_product);
        }

        async public Task<IEnumerable<ProductGetDto>> GetProducts()
        {

            return _mapper.Map<List<ProductGetDto>>(await _context.products.ToListAsync());

        }

        async public Task<Product?> AddProduct(ProductAddDto product)
        {

            if (product == null)
                return null;

            var newProduct = _mapper.Map<Product>(product);

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


        async public Task<ProductUpdateDto?> UpdateProduct(int id, ProductUpdateDto product)
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

            return product;


        }
    }
}
