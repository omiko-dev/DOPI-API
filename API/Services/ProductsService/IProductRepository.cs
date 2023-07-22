using API.Models.dto.ProductsDto;

namespace API.Services.ProductsService
{
    public interface IProductRepository
    {


        public Task<IEnumerable<Product>> GetProducts();

        public Task<Product?> GetProductById(int id);

        public Task<Product?> AddProduct(ProductAddDto product);

        public Task<Product?> UpdateProduct(int id, Product product);

        public Task<Product?> DeleteProduct(int id);





    }
}
