using API.dto.ProductsDto;
using API.Dto.ProductsDto;

namespace API.Services.ProductsService
{
    public interface IProductRepository
    {


        public Task<IEnumerable<ProductGetDto>> GetProducts();

        public Task<ProductGetDto?> GetProductById(int id);

        public Task<Product?> AddProduct(ProductAddDto product);

        public Task<ProductUpdateDto?> UpdateProduct(int id, ProductUpdateDto product);

        public Task<Product?> DeleteProduct(int id);





    }
}
